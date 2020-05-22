#include "MysqlSetting.h"

MysqlSetting::MysqlSetting(){
	info.host = HOST_;
	info.user = USER_;
	info.password = PASSWORD_;
	info.database = DATABASE_;	
	mysql_conn = mysqlConnect(info);
}

/***************************连接数据库***************************/
MYSQL *MysqlSetting::mysqlConnect(conn_info con) {
	MYSQL *mysql = mysql_init(NULL);	//mysql初始化函数，实例化一个新的对象（NULL为新的对象，否则为初始化以创建的对象)
	if (!mysql_real_connect(mysql, con.host, con.user, con.password, con.database, 3306, NULL, 0)) {	//mysql_real_connect(MYSQL *mysql,const char *host, const char *user, const char *passwd, const char *db, unsigned int port, const char *unix_socket, unsigned long client_flag)
		std::cout << "Connection MySQL Error" << std::endl;
		exit(1);
	}
	std::cout << "Connection MySQL Success" << std::endl;
	mysql_query(mysql, "set names utf8");		// 需要设置一下
	return mysql;	//返回实例化的对象
}

/**************************数据库操作函数**************************/
void MysqlSetting::mysqlOperation(char *sql_op) {
	if (mysql_query(mysql_conn, sql_op)) {		//mysql_query()函数为对mysql进行操作，第一个参数为刚才实例化的对象，第二个位需要进行的操作
		printf("MySQL query error : %s", mysql_error(mysql_conn));
		getchar();
		exit(1);
	}
}

/***************************断开数据库******************************/
void MysqlSetting::mysqlDisconnect() {
	mysql_close(mysql_conn);//断开连接
	std::cout << "Disconnect from MySQL" << std::endl;
}

/****************************显示所有数据***************************/
void MysqlSetting::mysqlShow(MYSQL_RES *res, std::vector<std::string> &colName) {
	MYSQL_ROW col;
	while ((col = mysql_fetch_row(res)) != NULL)	//	row = mysql_fetch_row(res);进行数据的转换,需要循环转换
	{
		for (int i = 0; i < colName.size(); i++)
			std::cout << col[i] << "  ";	//显示的行数,注意此处表格中只有两列，故row也只有2列，若写多列会出错
		std::cout << std::endl;
	}
}

/*****************************查询函数****************************/
MYSQL_RES *MysqlSetting::mysqlSelect(const char *table, MYSQL_RES *res) {
	char cmd[100];

	strcpy(cmd, "select * from ");
	strcat(cmd, table);		//拼接指令

	mysql_free_result(res);
	mysqlOperation(cmd);
	return mysql_store_result(mysql_conn);//查询的结果,用mysql_store_result函数后接mysql_affected_rows()可以返回查询次数，而用mysql_use_result()则不行
}

/****************************显示所有数据***************************/
void MysqlSetting::showAllData(const char *tableName, std::vector<std::string> &colName) {
	MYSQL_RES *res;
	res = NULL;//要先初始化，否则会报错
	for (std::vector<std::string>::const_iterator iter = colName.begin(); iter != colName.end(); ++iter)
		std::cout << *iter << " ";
	std::cout << std::endl;
	res = mysqlSelect(tableName, res);
	mysqlShow(res, colName);
}

/****************************更新修改某个数据***********************/
void MysqlSetting::updateData(const char *table, const char *val, const char *dstColName, const char *queryColName, const char *queryName, bool numOrStr) {
	char cmd[100];

	// bool numOrStr = 0  修改的为数字型
	// bool numOrStr = 1  修改的为字符型

	strcpy(cmd, "update ");
	strcat(cmd, table);
	strcat(cmd, " set ");
	strcat(cmd, dstColName);
	strcat(cmd, " = ");
	if (numOrStr)	strcat(cmd, "'");
	strcat(cmd, val);
	if (numOrStr)	strcat(cmd, "'");
	strcat(cmd, " where ");
	strcat(cmd, queryColName);
	strcat(cmd, " = '");
	strcat(cmd, queryName);
	strcat(cmd, "'");

	mysqlOperation(cmd);
}

void MysqlSetting::updateIdData(const char *table, const char *val, const char *dstColName, const char *queryColName, const char *queryName, bool numOrStr, int moldId) {
	char cmd[100];

	// bool numOrStr = 0  修改的为数字型
	// bool numOrStr = 1  修改的为字符型

	strcpy(cmd, "update ");
	strcat(cmd, table);
	strcat(cmd, " set ");
	strcat(cmd, dstColName);
	strcat(cmd, " = ");
	if (numOrStr)	strcat(cmd, "'");
	strcat(cmd, val);
	if (numOrStr)	strcat(cmd, "'");
	strcat(cmd, " where ");
	strcat(cmd, queryColName);
	strcat(cmd, " = '");
	strcat(cmd, queryName);
	strcat(cmd, "'");
	strcat(cmd, " and mold_id = ");
	strcat(cmd, std::to_string(moldId).c_str());

	mysqlOperation(cmd);
}

/****************************某张表末尾插入一个数据***********************/
void MysqlSetting::insertData(const char *table, const char *val) {
	char cmd[100];

	strcpy(cmd, "insert into ");
	strcat(cmd, table);
	strcat(cmd, " values ");
	strcat(cmd, val);

	mysqlOperation(cmd);
}

/****************************查询某个数据***************************/
char *MysqlSetting::queryData(const char *table, const char *dstColName, const char *queryColName, const char *queryName) {
	char cmd[100];
	MYSQL_RES *res;
	MYSQL_ROW col;
	res = NULL;//要先初始化，否则会报错

	strcpy(cmd, "select ");
	strcat(cmd, dstColName);
	strcat(cmd, " from ");
	strcat(cmd, table);		
	strcat(cmd, " where ");
	strcat(cmd, queryColName);
	strcat(cmd, " = ");
	strcat(cmd, "\"");
	strcat(cmd, queryName);
	strcat(cmd, "\"");
	
	mysql_free_result(res);
	mysqlOperation(cmd);
	res = mysql_store_result(mysql_conn);
	col = mysql_fetch_row(res);

	return col[0];
}
/****************************查询所有表格数据返回二维vector***************************/
std::vector<std::vector<std::string>> MysqlSetting::tab2Vector(const char * table, const int colNum) {
	char cmd[100];

	MYSQL_RES *res;
	MYSQL_ROW col;

	std::vector<std::vector<std::string>> vect;
	std::vector<std::string> _vect;

	res = NULL;//要先初始化，否则会报错

	strcpy(cmd, "select * from ");
	strcat(cmd, table);		//拼接指令

	mysql_free_result(res);
	mysqlOperation(cmd);
	res = mysql_store_result(mysql_conn);

	while ((col = mysql_fetch_row(res)) != NULL)		// 每一行访问
	{
		for (int i = 0; i < colNum; i++) {
			_vect.push_back(col[i]);
		}
		vect.push_back(_vect);
		for (int i = 0; i < colNum; i++) {
			_vect.pop_back();
		}
	}

	return vect;
}

/****************************查询所有表格数据返回二维vector排序ID***************************/
std::vector<std::vector<std::string>> MysqlSetting::tab2VectorOrderById(const char * table, const int colNum) {
	char cmd[100];

	MYSQL_RES *res;
	MYSQL_ROW col;

	std::vector<std::vector<std::string>> vect;
	std::vector<std::string> _vect;

	res = NULL;//要先初始化，否则会报错

	strcpy(cmd, "select * from ");
	strcat(cmd, table);		//拼接指令
	strcat(cmd, " order by id asc");		//拼接指令

	mysql_free_result(res);
	mysqlOperation(cmd);
	res = mysql_store_result(mysql_conn);

	while ((col = mysql_fetch_row(res)) != NULL)		// 每一行访问
	{
		for (int i = 0; i < colNum; i++) {
			_vect.push_back(col[i]);
		}
		vect.push_back(_vect);
		for (int i = 0; i < colNum; i++) {
			_vect.pop_back();
		}
	}

	return vect;
}

std::vector<std::vector<std::string>> MysqlSetting::tabId2Vector(const char * table, int moldId, const int colNum) {
	char cmd[150];

	MYSQL_RES *res;
	MYSQL_ROW col;

	std::vector<std::vector<std::string>> vect;
	std::vector<std::string> _vect;

	res = NULL;//要先初始化，否则会报错

	strcpy(cmd, "select * from ");
	strcat(cmd, table);		//拼接指令
	strcat(cmd, " where mold_id = ");
	strcat(cmd, std::to_string(moldId).c_str());
	if (colNum == 31|| colNum == 2 || colNum == 3) {
		strcat(cmd, " order by id asc");
	}

	mysql_free_result(res);
	mysqlOperation(cmd);
	res = mysql_store_result(mysql_conn);

	while ((col = mysql_fetch_row(res)) != NULL)		// 每一行访问
	{
		for (int i = 0; i < colNum; i++) {
			_vect.push_back(col[i]);
		}
		vect.push_back(_vect);
		for (int i = 0; i < colNum; i++) {
			_vect.pop_back();
		}
	}

	return vect;
}

/****************************查询两列返回map***************************/
std::map<std::string, std::string> MysqlSetting::queryAllData(const char *table, const char *Colname1, const char *Colname2) {
	char cmd[100];

	MYSQL_RES *res;
	MYSQL_ROW col;

	std::map<std::string, std::string> m;
	std::queue<std::string> name;
	std::queue<std::string> val;

	res = NULL;//要先初始化，否则会报错

	strcpy(cmd, "select ");
	strcat(cmd, Colname1);
	strcat(cmd, ", ");
	strcat(cmd, Colname2);
	strcat(cmd, " from ");
	strcat(cmd, table);

	mysql_free_result(res);
	mysqlOperation(cmd);
	res = mysql_store_result(mysql_conn);

	while ((col = mysql_fetch_row(res)) != NULL)	
	{
		name.push(col[0]);
		val.push(col[1]);
	}

	while (!name.empty()) {
		m[name.front()] = val.front();
		name.pop();
		val.pop();
	}

	return m;
}
/****************************查询表格的所有列名***************************/
void MysqlSetting::queryAllColName(std::vector<std::string> &vec_colName, const char *table) {
	char cmd[150];

	MYSQL_RES *res;
	MYSQL_ROW col;

	res = NULL;//要先初始化，否则会报错

	strcpy(cmd, "select column_name from information_schema.columns where table_name = ");
	strcat(cmd, table);

	mysql_free_result(res);
	mysqlOperation(cmd);
	res = mysql_store_result(mysql_conn);

	while ((col = mysql_fetch_row(res)) != NULL)
	{
		vec_colName.push_back(col[0]);
	}
}

void MysqlSetting::detManualNameAndNewData(const char *table, std::vector<std::vector<std::string>> vect_chg) {
	char cmd[2000];

	strcpy(cmd, "delete from ");
	strcat(cmd, table);

	mysqlOperation(cmd);

	if (!vect_chg.empty()) {
		strcpy(cmd, "insert into ");
		strcat(cmd, table);
		strcat(cmd, " values ");
		for (int i = 0; i < vect_chg.size(); i++) {
			strcat(cmd, "(");
			strcat(cmd, vect_chg[i][0].c_str());
			strcat(cmd, ",");
			strcat(cmd, "\"");
			strcat(cmd, vect_chg[i][1].c_str());
			strcat(cmd, "\",");
			strcat(cmd, vect_chg[i][2].c_str());
			if (i != (vect_chg.size() - 1))	strcat(cmd, "),");
			else strcat(cmd, ")");
		}
		mysqlOperation(cmd);
	}
}
/****************************删除表格的所有数据并赋值***************************/
void MysqlSetting::detAndNewData(const char *table, std::vector<std::vector<std::string>> vect_chg) {
	char cmd[2000];

	strcpy(cmd, "delete from ");
	strcat(cmd, table);

	mysqlOperation(cmd);

	if (!vect_chg.empty()) {
		strcpy(cmd, "insert into ");
		strcat(cmd, table);
		strcat(cmd, " values ");
		for (int i = 0; i < vect_chg.size(); i++) {
			strcat(cmd, "(");
			strcat(cmd, std::to_string(i + 1).c_str());
			for (int j = 0; j < vect_chg[i].size(); j++) {
				strcat(cmd, ",");
				strcat(cmd, "\"");
				strcat(cmd, vect_chg[i][j].c_str());
				strcat(cmd, "\"");
			}
			if (i != (vect_chg.size() - 1))	strcat(cmd, "),");
			else strcat(cmd, ")");
		}
		mysqlOperation(cmd);
	}
}

void MysqlSetting::detStepIdAndNewData(const char *table, std::vector<std::vector<std::string>> vect_chg, int moldId) {
	char cmd[2500];

	strcpy(cmd, "delete from ");
	strcat(cmd, table);
	strcat(cmd, " where mold_id = ");
	strcat(cmd, std::to_string(moldId).c_str());

	mysqlOperation(cmd);

	if (!vect_chg.empty()) {
		strcpy(cmd, "insert into ");
		strcat(cmd, table);
		strcat(cmd, " values ");
		for (int i = 0; i < vect_chg.size(); i++) {
			strcat(cmd, "(");
			strcat(cmd, std::to_string(i + 1).c_str());
			for (int j = 0; j < vect_chg[i].size(); j++) {
				strcat(cmd, ",");
				strcat(cmd, "\"");
				strcat(cmd, vect_chg[i][j].c_str());
				strcat(cmd, "\"");
			}
			if (i != (vect_chg.size() - 1))	strcat(cmd, "),");
			else strcat(cmd, ")");
		}
		mysqlOperation(cmd);
	}
}

void MysqlSetting::detMoldIdAndNewData(const char *table, std::vector<std::vector<std::string>> vect_chg, int moldId) {
	char cmd[2000];

	strcpy(cmd, "delete from ");
	strcat(cmd, table);
	strcat(cmd, " where mold_id = ");
	strcat(cmd, std::to_string(moldId).c_str());

	mysqlOperation(cmd);

	if (!vect_chg.empty()) {
		strcpy(cmd, "insert into ");
		strcat(cmd, table);
		strcat(cmd, " values ");
		for (int i = 0; i < vect_chg.size(); i++) {
			strcat(cmd, "(");
			strcat(cmd, std::to_string(moldId).c_str());
			for (int j = 0; j < vect_chg[i].size(); j++) {
				strcat(cmd, ",");
				strcat(cmd, "\"");
				strcat(cmd, vect_chg[i][j].c_str());
				strcat(cmd, "\"");
			}
			if (i != (vect_chg.size() - 1))	strcat(cmd, "),");
			else strcat(cmd, ")");
		}
		mysqlOperation(cmd);
	}
}

/****************************查询表格的行数***************************/
int MysqlSetting::queryRowCnt(const char *table) {
	char cmd[100];

	MYSQL_RES *res;
	MYSQL_ROW col;

	res = NULL;//要先初始化，否则会报错

	strcpy(cmd, "select count(*) from ");
	strcat(cmd, table);

	mysql_free_result(res);
	mysqlOperation(cmd);
	res = mysql_store_result(mysql_conn);

	col = mysql_fetch_row(res);

	return atoi(col[0]);
}

int MysqlSetting::queryIdRowCnt(const char *table, int moldId) {
	char cmd[100];

	MYSQL_RES *res;
	MYSQL_ROW col;

	res = NULL;//要先初始化，否则会报错

	strcpy(cmd, "select count(*) from ");
	strcat(cmd, table);
	strcat(cmd, " where mold_id = ");
	strcat(cmd, std::to_string(moldId).c_str());

	mysql_free_result(res);
	mysqlOperation(cmd);
	res = mysql_store_result(mysql_conn);

	col = mysql_fetch_row(res);

	return atoi(col[0]);
}

/****************************插入日志信息***************************/
void MysqlSetting::insertLogData(const char *table, std::string time, std::string res, std::string mesg) {
	char cmd[200];

	strcpy(cmd, "insert into ");
	strcat(cmd, table);
	strcat(cmd, "(time_occur, result, error_image_message)");
	strcat(cmd, " values ");
	strcat(cmd, "(");
	strcat(cmd, "\"");
	strcat(cmd, time.c_str());
	strcat(cmd, "\"");
	strcat(cmd, ",");
	strcat(cmd, "\"");
	strcat(cmd, res.c_str());
	strcat(cmd, "\"");
	strcat(cmd, ",");
	strcat(cmd, "\"");
	strcat(cmd, mesg.c_str());
	strcat(cmd, "\"");
	strcat(cmd, ")");

	mysqlOperation(cmd);
}

MysqlSetting::~MysqlSetting() {
	mysqlDisconnect();
}
