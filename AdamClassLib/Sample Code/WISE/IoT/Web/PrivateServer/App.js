/**************************************************************************
    Change log:	Version 1.00 <2015/8/21>
                - Initial version 
                Version 1.01 <2016/01/05>
                - Auto rename file name to prevent upload file(ex: csv) over-write
                Version 1.02 <2016/05/09>
                - Change response.write to response.end in sendResponse() function
                
**************************************************************************/
var http = require("http");
var https = require('https');
var fs = require("fs");
var path = require("path");
var url = require('url');

/**************************************************************************
* Start of User Configuration Area
**************************************************************************/

// Log file directory path: current directory
var PUSH_LOG_FILE_PATH = path.join(process.cwd(), '/wise.log');

//Web Server Basic Authentication
var USER_ACCOUNT = 'root'; //user account name
var USER_PASSWORD = '00000000'; //user password

//WISE Push: IO channel Log receive URI
var WISE_PUSH_IO_LOG_RECEIVE_URI = '/io_log';
//WISE Push: System Log receive URI
var WISE_PUSH_SYSTEM_LOG_RECEIVE_URI = '/sys_log';

//WISE Upload: IO channel and system Log receive URI
var WISE_UPLOAD_LOG_RECEIVE_URI = '/upload_log';

//Web Server Listen port: default 8000
var SERVER_PORT = 8000;
/**************************************************************************
* End of User Configuration Area
**************************************************************************/

var WISE_UPLOAD_LOG_URI_AMOUNT = 6;

//use http or https flag
var startHttps = false;

//command line arguments
var argument = process.argv[2];

if(argument){
	if(isNaN(argument) && argument == 'https'){
		startHttps = true;
		SERVER_PORT = 443;
	}
	if(!isNaN(argument))
		SERVER_PORT = argument;
}

//web server startup options
var options;

if(startHttps){
    options = {
        key: fs.readFileSync('./key.pem'),
        cert: fs.readFileSync('./server.crt')
    };
} 

// List file name extensions and MIME type mapping
var mimeNames = {
    '.css': 'text/css',
    '.html': 'text/html',
    '.js': 'application/javascript',
};

//start web server
if(startHttps){
	https.createServer(options, function (req, res) { //https
		httpListener(req, res);
		}).listen(SERVER_PORT, '0.0.0.0'); 
}else{
	http.createServer(httpListener).listen(SERVER_PORT, '0.0.0.0'); //http
}

//http request listener
function httpListener(request, response) {
	var uri = url.parse(request.url).pathname;
	var query = url.parse(request.url).query;
	var uriArray = uri.split("/");
	var targetUri = '/' + uriArray[1];
	//console.log("targetUri: " + targetUri);

	var filename = path.join(process.cwd(), targetUri);
	//console.log("filename: " + filename);

	var header = request.headers['authorization'] || '',    // get the header
		  token = header.split(/\s+/).pop() || '',          // and the encoded auth token
		  auth = new Buffer(token, 'base64').toString(),    // convert from base64
		  parts = auth.split(/:/),                          // split on colon
		  username = parts[0],
		  password = parts[1];
	
	
	//Perform Basic Authenticate check
	if(typeof(username) =='undefined' || typeof(password) =='undefined' ||
			username != USER_ACCOUNT || password != USER_PASSWORD ){
		//Tell client: Basic Authentication required
		sendResponse(response, 401, { 'WWW-Authenticate': 'Basic realm="WISE Log Server"' }, null, null); 
        return null;
	}

	//check valid url
	if(uri.indexOf("..") !=-1  || uri.indexOf("<") !=-1 || uri.indexOf(">") !=-1){
		sendResponse(response, 400, {"Content-Type": "text/plain"}, null, "Bad Request");
		return;
	}

	//POST method: For receive WISE Log
	if(request.method == 'POST'){
		if(targetUri == WISE_UPLOAD_LOG_RECEIVE_URI && uriArray.length == WISE_UPLOAD_LOG_URI_AMOUNT){
			//Get log path name
			var systemLogPath = path.join(process.cwd(), uriArray.slice(2, uriArray.length-1).join('/'));
			var systemLogFullPath = path.join(systemLogPath, uriArray[uriArray.length-1]);
			//console.log("systemLogFullPath: " + systemLogFullPath);
			//if log path not exists, create it
			if(!isFileOrPathExists(systemLogPath)){
				//create system log file directory
				console.log("Log path not exist, create it");
				try{
					//create diretory recursively
					mkdirSync(systemLogPath);
				}catch(err){
					console.log("Error: " + err)
					sendResponse(response, 500, {"Content-Type": "text/plain"}, null, "Internal Server Error");
					return;
				}
			}
			receivePost(request, response, systemLogFullPath, false);			
			return;
	 	}else if(targetUri == WISE_PUSH_IO_LOG_RECEIVE_URI || targetUri == WISE_PUSH_SYSTEM_LOG_RECEIVE_URI){
	 		receivePost(request, response, PUSH_LOG_FILE_PATH, true);
			return;
		}else{
			sendResponse(response, 404, {"Content-Type": "text/plain"}, null, "404 Not Found.");
			return;
		}
	}

	//Following codes are for general GET method.

	//If file not exist, return 404: File Not Found 
	if(!isFileOrPathExists(filename)){
		console.log("File Not Found: " + filename);
		sendResponse(response, 404, {"Content-Type": "text/plain"}, null, "404 Not Found.");
		return;
	}
	if(fs.statSync(filename).isDirectory()){
		filename += 'index.html';
	}
	
	//console.log("Request filename: " + filename);
	
	//Return known MIME type file
	if(mimeNames[path.extname(filename).toLowerCase()] != null){
		fs.readFile(filename, "binary", function(err, file) {
			if(err){
				sendResponse(response, 500,  {"Content-Type": "text/plain"}, err, null);
				return;
			}

			var headers = {};
			headers["Content-Type"] = getMimeType(path.extname(filename));
			headers['Accept-Ranges'] = 'bytes';
			response.writeHead(200, headers);
			response.write(file, "binary");
			response.end();
			return;
		})		
	}else{
		//Return file content by using HTTP Range
		var responseHeaders = {};
		var stat = fs.statSync(filename);
		var rangeRequest = readRangeHeader(request.headers['range'], stat.size);

		//If Range header not exists, return file directly
		if(rangeRequest == null) {
			responseHeaders['Content-Type'] = getMimeType(path.extname(filename));
			responseHeaders['Content-Length'] = stat.size;  // File size
			responseHeaders['Accept-Ranges'] = 'bytes';
			sendResponse(response, 200, responseHeaders, fs.createReadStream(filename), null);
			return null;
		}

		var start = rangeRequest.Start;
		var end = rangeRequest.End;

		// If range error, return 416: Requested Range Not Satisfiable
		if(start >= stat.size || end >= stat.size) {
			responseHeaders['Content-Range'] = 'bytes */' + stat.size;
			sendResponse(response, 416, responseHeaders, null, null);
			return;
		}
		
		if(start < 0 ) start =0;

		// Set response header
		responseHeaders['Content-Range'] = 'bytes ' + start + '-' + end + '/' + stat.size;
		responseHeaders['Content-Length'] = start == end ? 0 : (end - start + 1);
		responseHeaders['Content-Type'] = getMimeType(path.extname(filename));
		responseHeaders['Accept-Ranges'] = 'bytes';
		responseHeaders['Cache-Control'] = 'no-cache';
		// Return 206: Partial Content
		sendResponse(response, 206, responseHeaders, fs.createReadStream(filename, { start: start, end: end }), null);
	}
}

function receivePost(request, response, logFilePath, enableFileOverwrite){
    //receive log data
	var jsonData = '';
    request.on('data', function (data) {
        jsonData += data;
    });
	request.on('end', function () {
        //console.log("jsonData: " + jsonData);
		writeDataInfoFile(logFilePath, jsonData, false, enableFileOverwrite); //write log to file
        sendResponse(response, 200, {"Content-Type": "text/plain"}, null, "Log received");
    });
}

function sendResponse(response, responseStatus, responseHeaders, readable, responseMessage) {
    response.writeHead(responseStatus, responseHeaders);
    if(responseMessage != null && readable == null)
        response.end(responseMessage);
    	//response.write(responseMessage + "\n");
    else if(readable == null)
        response.end();
    else
        readable.on('open', function () {
            readable.pipe(response);
        });

    return null;
}

function isFileOrPathExists(name){
	var fileExist = false;
	try{
		stats = fs.statSync(name);
		fileExist = true;
	}catch(e){
		//console.log("Error: " + e);
	}
	return fileExist;
}

function mkdirSync(dirPath, mode, callBackFun){
	var relativePath = path.relative(process.cwd(), dirPath);
    var arr = relativePath.split(path.sep);

    mode = mode || 0755;
    callBackFun = callBackFun || function(){};
    //console.log("arr:" + arr);
    function inner(cur){
    	//console.log("cur===>"+cur);
    	//create directory if not exists
        if(!fs.existsSync(cur)){
            fs.mkdirSync(cur, mode)
        }
        if(arr.length){
            inner(cur + "/" + arr.shift());
        }else{
            callBackFun();
        }
    }
    arr.length && inner(arr.shift());
}

function getMimeType(ext) {
    var result = mimeNames[ext.toLowerCase()];
    if(result == null)
        result = 'application/octet-stream';
    
    return result;
}

function readRangeHeader(range, totalLength) {
    if(range == null || range.length == 0)
        return null;

    var array = range.split(/bytes=([0-9]*)-([0-9]*)/);
    var start = parseInt(array[1]);
    var end = parseInt(array[2]);
    var result = {
        Start: isNaN(start) ? 0 : start,
        End: isNaN(end) ? (totalLength - 1) : end
    };
    
    if(!isNaN(start) && isNaN(end)) {
        result.Start = start;
        result.End = totalLength - 1;
    }

    if(isNaN(start) && !isNaN(end)) {
        result.Start = totalLength - end;
        result.End = totalLength - 1;
    }

    return result;
}

function getUniqueFileName(logFilePath){
    while(true){
        var fileExist = false;
        try{
            fs.statSync(logFilePath);
            fileExist = true;
        }catch(e){}
                    
        if(fileExist) {
            //file exists, create new file name
            var extensionName = path.extname(logFilePath);
            var fileName = path.basename(logFilePath, extensionName);
            var dirName = path.dirname(logFilePath);
            
            if(fileName.indexOf(' ') == -1){ //ex: 20151125111821
                fileName = fileName + " (1)" + extensionName;
            }else{ //ex: 20151125111821 (1)
                var ret = fileName.match(/(\S+)\ \((\d+)\)/);
                if(ret == null){ //no match
                    //match failed, append a random number to file name
                    fileName = fileName + "_" + Math.floor((Math.random() * 1000) + 1) +extensionName;
                }else{
                    //append a new number to file name
                    var tmp = parseInt(ret[2]) + 1;
                    fileName = ret[1] + " (" + tmp + ")" + extensionName;
                }
            }
            logFilePath = path.join(dirName, fileName);
        }else{
            //file not exists
            console.log('Get new File name: ' +  logFilePath);
            return logFilePath;
        }
    }
}

function writeDataInfoFile(logFilePath, jsonData, removeNewLine, enableFileOverwrite){
	var jsonTxt = '';
	if(removeNewLine)
		jsonTxt = jsonData.replace(/\n/g, '');
	else
		jsonTxt = jsonData;
    
    if(!enableFileOverwrite){
        //get unique file name(not over-write or append file)
        logFilePath = getUniqueFileName(logFilePath);
    }

	fs.appendFile(logFilePath, jsonTxt + "\n", function(err){
		if (err){
			console.log("Log File Write Failed."+ err);
        }
	});
}

process.on('uncaughtException', function (err) {
  //Print Error Message
  console.log("Error: " + err.message);
  //Print Error Stack
  console.log(err.stack);
});

if(startHttps)
	console.log("Log server running at https://localhost:" + SERVER_PORT + "/\nCTRL + C to shutdown");
else
	console.log("Log server running at http://localhost:" + SERVER_PORT + "/\nCTRL + C to shutdown");