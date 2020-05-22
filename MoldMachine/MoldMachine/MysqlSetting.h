#pragma once
#include <winsock.h>
#include <mysql.h>
#include <iostream>
#include <string>
#include <vector>
#include <queue>
#include <map>

#define HOST_ "localhost"
#define USER_ "root"
#define PASSWORD_ "111111"
#define DATABASE_ "moldmachinedatabase"

struct conn_info {
	char *host;
	char *user;
	char *password;
	char *database;
};

class MysqlSetting {
public:
	MysqlSetting();
	~MysqlSetting();

	// 查询表的行数
	int queryRowCnt(const char *table);

	// 查询符合moldId的个数
	int queryIdRowCnt(const char *table, int moldId);

	// table all data
	void showAllData(const char *tableName, std::vector<std::string> &colName);

	// 查询某个数据 select (dstColName) from (table) where (queryColName) = (queryName);
	char *queryData(const char *table, const char *dstColName, const char *queryColName, const char *queryName);

	// 查询两列数据，返回两列数据组成的map	select (Colname1), (Colname2) from table;
	std::map<std::string, std::string> queryAllData(const char *table, const char *Colname1, const char *Colname2);

	// 查询所有数据，返回所有数据组成的vector	select * from (table)
	std::vector<std::vector<std::string>> tab2Vector(const char * table, const int colNum);

	// 查询表格返回vector order by id
	std::vector<std::vector<std::string>> tab2VectorOrderById(const char * table, const int colNum);

	// 查询符合moldid的数据传入vector
	std::vector<std::vector<std::string>> tabId2Vector(const char * table, int moldId, const int colNum);

	// 表末尾插入数据 insert into (table) values (val);
	void insertData(const char *table, const char *val);

	// 更新表中的某个数据 update (table) set (dstColName) = (val) where (queryColName) = (queryName) 
	void updateData(const char *table, const char *val, const char *dstColName, const char *queryColName, const char *queryName, bool numOrStr);

	// 更改符合moldid的步骤
	void updateIdData(const char *table, const char *val, const char *dstColName, const char *queryColName, const char *queryName, bool numOrStr, int moldId);

	// 查询表的所有列名，返回放在一个vector里面
	void queryAllColName(std::vector<std::string> &vec_colName, const char *table);

	// 删除表格的所有数据并将传入的vector赋值
	void detAndNewData(const char *table, std::vector<std::vector<std::string>> vect_chg);

	// 删除符合moldid的数据传入vector
	void detMoldIdAndNewData(const char *table, std::vector<std::vector<std::string>> vect_chg, int moldId);

	void detStepIdAndNewData(const char *table, std::vector<std::vector<std::string>> vect_chg, int moldId);

	// 插入日志信息
	void insertLogData(const char *table, std::string time, std::string res, std::string mesg);

	// 保存manual name 信息
	void detManualNameAndNewData(const char *table, std::vector<std::vector<std::string>> vect_chg);

private:
	MYSQL *mysql_conn;
	conn_info info;
	
	// connect
	MYSQL *mysqlConnect(conn_info con);

	// operation cmd
	void mysqlOperation(char *sql_op);

	// for show
	void mysqlShow(MYSQL_RES *res, std::vector<std::string> &colName);
	MYSQL_RES *mysqlSelect(const char *table, MYSQL_RES *res);

	// disconnect from sql
	void mysqlDisconnect();
};
