#include <iostream>

#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include <opencv2/core/core.hpp>

#include <stack>

#include <ctime>

void cvThin(cv::Mat& src, cv::Mat& dst, int intera)
{
	if (src.type() != CV_8UC1)
	{
		printf("只能处理二值或灰度图像\n");
		return;
	}
	//非原地操作时候，copy src到dst
	if (dst.data != src.data)
	{
		src.copyTo(dst);
	}

	int i, j, n;
	int width, height;
	width = src.cols - 1;
	//之所以减1，是方便处理8邻域，防止越界
	height = src.rows - 1;
	int step = src.step;
	int  p2, p3, p4, p5, p6, p7, p8, p9;
	uchar* img;
	bool ifEnd;
	int A1;
	cv::Mat tmpimg;
	//n表示迭代次数
	for (n = 0; n<intera; n++)
	{
		dst.copyTo(tmpimg);
		ifEnd = false;
		img = tmpimg.data;
		for (i = 1; i < height; i++)
		{
			img += step;
			for (j = 1; j<width; j++)
			{
				uchar* p = img + j;
				A1 = 0;
				if (p[0] > 0)
				{
					if (p[-step] == 0 && p[-step + 1]>0) //p2,p3 01模式
					{
						A1++;
					}
					if (p[-step + 1] == 0 && p[1]>0) //p3,p4 01模式
					{
						A1++;
					}
					if (p[1] == 0 && p[step + 1]>0) //p4,p5 01模式
					{
						A1++;
					}
					if (p[step + 1] == 0 && p[step]>0) //p5,p6 01模式
					{
						A1++;
					}
					if (p[step] == 0 && p[step - 1]>0) //p6,p7 01模式
					{
						A1++;
					}
					if (p[step - 1] == 0 && p[-1]>0) //p7,p8 01模式
					{
						A1++;
					}
					if (p[-1] == 0 && p[-step - 1]>0) //p8,p9 01模式
					{
						A1++;
					}
					if (p[-step - 1] == 0 && p[-step]>0) //p9,p2 01模式
					{
						A1++;
					}
					p2 = p[-step]>0 ? 1 : 0;
					p3 = p[-step + 1]>0 ? 1 : 0;
					p4 = p[1]>0 ? 1 : 0;
					p5 = p[step + 1]>0 ? 1 : 0;
					p6 = p[step]>0 ? 1 : 0;
					p7 = p[step - 1]>0 ? 1 : 0;
					p8 = p[-1]>0 ? 1 : 0;
					p9 = p[-step - 1]>0 ? 1 : 0;
					if ((p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9)>1 && (p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9)<7 && A1 == 1)
					{
						if ((p2 == 0 || p4 == 0 || p6 == 0) && (p4 == 0 || p6 == 0 || p8 == 0)) //p2*p4*p6=0 && p4*p6*p8==0
						{
							dst.at<uchar>(i, j) = 0; //满足删除条件，设置当前像素为0
							ifEnd = true;
						}
					}
				}
			}
		}

		dst.copyTo(tmpimg);
		img = tmpimg.data;
		for (i = 1; i < height; i++)
		{
			img += step;
			for (j = 1; j<width; j++)
			{
				A1 = 0;
				uchar* p = img + j;
				if (p[0] > 0)
				{
					if (p[-step] == 0 && p[-step + 1]>0) //p2,p3 01模式
					{
						A1++;
					}
					if (p[-step + 1] == 0 && p[1]>0) //p3,p4 01模式
					{
						A1++;
					}
					if (p[1] == 0 && p[step + 1]>0) //p4,p5 01模式
					{
						A1++;
					}
					if (p[step + 1] == 0 && p[step]>0) //p5,p6 01模式
					{
						A1++;
					}
					if (p[step] == 0 && p[step - 1]>0) //p6,p7 01模式
					{
						A1++;
					}
					if (p[step - 1] == 0 && p[-1]>0) //p7,p8 01模式
					{
						A1++;
					}
					if (p[-1] == 0 && p[-step - 1]>0) //p8,p9 01模式
					{
						A1++;
					}
					if (p[-step - 1] == 0 && p[-step]>0) //p9,p2 01模式
					{
						A1++;
					}
					p2 = p[-step]>0 ? 1 : 0;
					p3 = p[-step + 1]>0 ? 1 : 0;
					p4 = p[1]>0 ? 1 : 0;
					p5 = p[step + 1]>0 ? 1 : 0;
					p6 = p[step]>0 ? 1 : 0;
					p7 = p[step - 1]>0 ? 1 : 0;
					p8 = p[-1]>0 ? 1 : 0;
					p9 = p[-step - 1]>0 ? 1 : 0;
					if ((p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9)>1 && (p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9)<7 && A1 == 1)
					{
						if ((p2 == 0 || p4 == 0 || p8 == 0) && (p2 == 0 || p6 == 0 || p8 == 0)) //p2*p4*p8=0 && p2*p6*p8==0
						{
							dst.at<uchar>(i, j) = 0; //满足删除条件，设置当前像素为0
							ifEnd = true;
						}
					}
				}
			}
		}

		//如果两个子迭代已经没有可以细化的像素了，则退出迭代
		if (!ifEnd) break;
	}

}

void logEnhance(cv::Mat & src) {
	cv::Mat imageLog(src.size(), src.type());
	for (int i = 0; i < src.rows; i++)
	{
		for (int j = 0; j < src.cols; j++)
		{
			imageLog.at<uchar>(i, j) = log(1 + src.at<uchar>(i, j));
		}
	}

	//归一化到0~255    
	normalize(imageLog, imageLog, 0, 255, CV_MINMAX);
	//转换成8bit图像显示    
	convertScaleAbs(imageLog, src);
}

void binaryzation(cv::Mat & srcImg) {
	cv::Mat lookUpTable(1, 256, CV_8U, cv::Scalar(255));
	lookUpTable.data[0] = 0;
	LUT(srcImg, lookUpTable, srcImg);
}

void findConnectedDomain(cv::Mat & srcImg, std::vector<std::vector<cv::Point>>& connectedDomains, int area, int WHRatio) {
	cv::Mat_<uchar> tempImg = (cv::Mat_<uchar> &)srcImg;

	for (int i = 0; i < tempImg.rows; ++i) {
		uchar* row = tempImg.ptr(i);
		for (int j = 0; j < tempImg.cols; ++j) {
			if (row[j] == 255) {
				std::stack<cv::Point> connectedPoints;
				std::vector<cv::Point> domain;
				connectedPoints.push(cv::Point(j, i));
				while (!connectedPoints.empty()) {
					cv::Point currentPoint = connectedPoints.top();
					domain.push_back(currentPoint);

					int colNum = currentPoint.x;
					int rowNum = currentPoint.y;

					tempImg.ptr(rowNum)[colNum] = 0;
					connectedPoints.pop();

					if (rowNum - 1 >= 0 && colNum - 1 >= 0 && tempImg.ptr(rowNum - 1)[colNum - 1] == 255) {
						tempImg.ptr(rowNum - 1)[colNum - 1] = 0;
						connectedPoints.push(cv::Point(colNum - 1, rowNum - 1));
					}
					if (rowNum - 1 >= 0 && tempImg.ptr(rowNum - 1)[colNum] == 255) {
						tempImg.ptr(rowNum - 1)[colNum] = 0;
						connectedPoints.push(cv::Point(colNum, rowNum - 1));
					}
					if (rowNum - 1 >= 0 && colNum + 1 < tempImg.cols && tempImg.ptr(rowNum - 1)[colNum + 1] == 255) {
						tempImg.ptr(rowNum - 1)[colNum + 1] = 0;
						connectedPoints.push(cv::Point(colNum + 1, rowNum - 1));
					}
					if (colNum - 1 >= 0 && tempImg.ptr(rowNum)[colNum - 1] == 255) {
						tempImg.ptr(rowNum)[colNum - 1] = 0;
						connectedPoints.push(cv::Point(colNum - 1, rowNum));
					}
					if (colNum + 1 < tempImg.cols && tempImg.ptr(rowNum)[colNum + 1] == 255) {
						tempImg.ptr(rowNum)[colNum + 1] = 0;
						connectedPoints.push(cv::Point(colNum + 1, rowNum));
					}
					if (rowNum + 1 < tempImg.rows && colNum - 1 > 0 && tempImg.ptr(rowNum + 1)[colNum - 1] == 255) {
						tempImg.ptr(rowNum + 1)[colNum - 1] = 0;
						connectedPoints.push(cv::Point(colNum - 1, rowNum + 1));
					}
					if (rowNum + 1 < tempImg.rows && tempImg.ptr(rowNum + 1)[colNum] == 255) {
						tempImg.ptr(rowNum + 1)[colNum] = 0;
						connectedPoints.push(cv::Point(colNum, rowNum + 1));
					}
					if (rowNum + 1 < tempImg.rows && colNum + 1 < tempImg.cols && tempImg.ptr(rowNum + 1)[colNum + 1] == 255) {
						tempImg.ptr(rowNum + 1)[colNum + 1] = 0;
						connectedPoints.push(cv::Point(colNum + 1, rowNum + 1));
					}
				}
				if (domain.size() > area) {
					cv::RotatedRect rect = cv::minAreaRect(domain);
					float width = rect.size.width;
					float height = rect.size.height;
					if (width < height) {
						float temp = width;
						width = height;
						height = temp;
					}
					if (width > height * WHRatio && width > 50) {
						for (auto cit = domain.begin(); cit != domain.end(); ++cit) {
							tempImg.ptr(cit->y)[cit->x] = 250;
						}
						connectedDomains.push_back(domain);
					}
				}
			}
		}
	}

	binaryzation(srcImg);
}

void pixelAndOperation(cv::Mat & inputImg) {
	for (int i = 0; i < inputImg.cols; i++) {
		for (int j = 0; j < inputImg.rows; j++) {
			inputImg.at<int>(i, j) = inputImg.at<int>(i, j) & 1;
		}
	}
}

void addContrast(cv::Mat & srcImg) {
	cv::Mat lookUpTable(1, 256, CV_8U);
	double temp = pow(1.1, 5);
	uchar* p = lookUpTable.data;
	for (int i = 0; i < 256; ++i)
		p[i] = cv::saturate_cast<uchar>(i * temp);
	LUT(srcImg, lookUpTable, srcImg);
}

void DoGWithCannyDetect(cv::Mat & inputImg) {
	cv::Mat gray;
	if (inputImg.channels() != 1)
		cv::cvtColor(inputImg, gray, CV_RGB2GRAY);
	else 
		gray = inputImg.clone();

	//cv::GaussianBlur(gray, gray, cv::Size(5, 5), 0);

	cv::Size wsize = cv::Size(3, 3);
	double sigma = 0.3, k = 0.2;
	cv::Mat DoGRes1, DoGRes2, DoGRes3, gaussian_dst1, gaussian_dst2, gaussian_dst3;

	// 高斯滤波
	cv::GaussianBlur(gray, gaussian_dst1, wsize, sigma, 0.4);
	cv::GaussianBlur(gray, gaussian_dst2, wsize, sigma + 0.3, 0.7);
	cv::GaussianBlur(gray, gaussian_dst3, wsize, sigma + 0.4, 0.8);

	//cv::GaussianBlur(gray, gaussian_dst1, wsize, sigma, 0.4);
	//cv::GaussianBlur(gray, gaussian_dst2, wsize, 2 * sigma, 0.7);

	//cv::imshow("gaussian_dst1", gaussian_dst1);
	//cv::imshow("gaussian_dst2", gaussian_dst2);
	//cv::imshow("gaussian_dst3", gaussian_dst3);

	DoGRes1 = gaussian_dst1 - gaussian_dst2;
	DoGRes2 = gaussian_dst2 - gaussian_dst3;
	DoGRes3 = (DoGRes1 - DoGRes2);
	//DoGRes1 = gaussian_dst1 - gaussian_dst2;
	//DoGRes2 = gaussian_dst2 - gaussian_dst1;
	//DoGRes3 = DoGRes1 + DoGRes2;

	cv::Mat DoGRes;
	DoGRes = DoGRes3;
	normalize(DoGRes, DoGRes, 0, 255, CV_MINMAX);//增加对比对
	cv::imshow("DoGRes", DoGRes);

	//// 直方图均衡
	//cv::Mat equalHistRes;
	//cv::equalizeHist(DoGRes, equalHistRes);
	//cv::imshow("equalHistRes", equalHistRes);

	//// 双边滤波
	//cv::Mat bilateralRes;
	//cv::bilateralFilter(DoGRes, bilateralRes, 35, 15, 10);
	//cv::imshow("bilateralRes", bilateralRes);

	//// log
	//logEnhance(DoGRes);
	//cv::imshow("logEnhance", DoGRes);


	// 增加对比度
	addContrast(DoGRes);
	cv::imshow("addContrast", DoGRes);

	//// 图像像素点与运算
	//cv::Mat andOperationRes;
	//cv::Mat maskOne = cv::Mat::ones(bilateralRes.size(), bilateralRes.type());
	//cv::imshow("maskOne", maskOne);
	//cv::bitwise_and(bilateralRes, maskOne, andOperationRes);
	//cv::imshow("andOperationRes", andOperationRes);
	//pixelAndOperation(bilateralRes);
	//cv::imshow("pixelAndOperation", bilateralRes);

	cv::Mat binary;
	cv::threshold(DoGRes, binary, 64, 255, cv::THRESH_BINARY_INV);
	cv::imshow("binary", binary);
	//cv::adaptiveThreshold(DoGRes, binary, 255, CV_ADAPTIVE_THRESH_GAUSSIAN_C, CV_THRESH_BINARY, 31, 10);
	//cv::imshow("binary", binary);

	//cv::Mat MedemBlur;
	//cv::medianBlur(DoGRes, MedemBlur, 3);
	//cv::imshow("MedemBlur", MedemBlur);

	//// 增加对比度
	//addContrast(MedemBlur);
	//cv::imshow("addContrast", MedemBlur);

	//cv::Mat dstImg;
	//cv::Canny(gray, dstImg, 50, 150);
	//cv::imshow("Canny", dstImg);

	//cv::Mat kernel = cv::getStructuringElement(cv::MorphShapes::MORPH_ELLIPSE, cv::Size(3, 3));
	////cv::dilate(dstImg, dstImg, kernel);
	////cv::imshow("erode", dstImg);
	//morphologyEx(DoGRes, dstImg, cv::MORPH_CLOSE, kernel, cv::Point(-1, -1), 3);
	////morphologyEx(gray, gray, cv::MORPH_OPEN, kernel);

	//cv::imshow("morphologyEx", dstImg);

	cv::Mat dstImg;
	addContrast(gray);
	cv::Canny(DoGRes, dstImg, 50, 150);
	cv::imshow("Canny", dstImg);

	cv::Mat kernel = cv::getStructuringElement(cv::MORPH_ELLIPSE, cv::Size(3, 3));
	dilate(dstImg, dstImg, kernel);
	morphologyEx(dstImg, dstImg, CV_MOP_CLOSE, kernel, cv::Point(-1, -1), 3);
	morphologyEx(dstImg, dstImg, CV_MOP_CLOSE, kernel);
	cv::imshow("mp1", dstImg);
	
	//kernel = cv::getStructuringElement(cv::MORPH_ELLIPSE, cv::Size(7, 7));
	//morphologyEx(dstImg, dstImg, CV_MOP_CLOSE, kernel, cv::Point(-1, -1), 5);
	//cv::imshow("mp2", dstImg);

	kernel = cv::getStructuringElement(cv::MORPH_CROSS, cv::Size(3, 3));
	morphologyEx(dstImg, dstImg, CV_MOP_OPEN, kernel);
	cv::imshow("mp3", dstImg);

	//kernel = cv::getStructuringElement(cv::MORPH_ELLIPSE, cv::Size(3, 3));
	//erode(dstImg, dstImg, kernel);
	//cv::imshow("mp4", dstImg);

	cvThin(dstImg, dstImg, 3);
	cv::imshow("cvThin", dstImg);
}

int main() {
	clock_t startTime, endTime;

	cv::Mat src = cv::imread("./liewen.jpg");
	//cv::Mat src = cv::imread("./liewen2.jpeg");
	//cv::Mat src = cv::imread("./liewen3.jpg");
	//cv::Mat src = cv::imread("./liewen4.jpg");
	//cv::Mat src = cv::imread("./diandu.png");
	//cv::Mat src = cv::imread("./huahen.jpg");
	//cv::Mat src = cv::imread("./lena.jpg");
	//cv::Mat src = cv::imread("./test2.png");

	cv::imshow("src", src);
	startTime = clock();	// 计时开始

	DoGWithCannyDetect(src);

	endTime = clock();	// 计时结束
	std::cout << "The run time is : "
		<< (double)(endTime - startTime) / CLOCKS_PER_SEC << "s" << std::endl;
	cv::waitKey(0);

	system("pause");
	return 0;
}