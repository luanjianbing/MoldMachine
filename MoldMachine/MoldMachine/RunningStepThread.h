#pragma once
#include <iostream>
#include <ctime>
#include <atltime.h>
//#include <thread>	// 用于处理并发接受IO数据和并发输出IO数据
//#include <Windows.h>

#include "MysqlSetting.h"
#include "xmlFileSetting.h"

#include "CameraDrive.h"
#include "ImageProcessing.h"
#include "Adam6060.h"

#include <time.h>

#include <QThread>
#include <QString>

class RunningThread : public QThread {
	Q_OBJECT
public:
	explicit RunningThread(QObject *parent, int moldId,
		std::map<std::string, std::string> cycleParam,
		std::map<std::string, std::string> imgAddr,
		std::vector<std::vector<std::string>> cycleStep,
		std::vector<std::vector<int>> blockInt,
		std::map<std::string, std::string> ioEnet,
		std::vector<std::vector<std::string>> cycleStepManualNorm,
		std::vector<std::vector<std::string>> cycleStepManualSubCmd,
		std::map<int, int> subRelationIndex,
		std::map<int, int> stepMContinuousInputIdx,
		int runMode);

	~RunningThread();
	
	// 获取输入状态
	std::string getStatus(int dstIO);

	// 控制输出
	void setStatus(int dstIO, bool status);

	//// 从sql中读取参数，当前读出一张map跟一个vector
	//void readParam(std::map<std::string, std::string> &param, std::map<std::string, std::string> &addr, 
	//	std::vector<std::vector<std::string>> &step, std::vector<std::vector<std::string>> &block);

	bool threadRunFlag = 0;
	//int threadMode = 0;		// 1 is from xml, 2 is from sql
	void setRunFlag(bool run_flag);

	void stopThread();

protected:
	void run();

signals:
	void stepRunIsDone();

	void grabImgQuest(int);

	void excuteImageQuest(int, QString, QString);

	void emitResMsg(QString num, QString tim, QString result, QString msg);
	void emitCurMsg(QString msg);

	void statusInput(int, int);
	void statusOutput(int, int);

	void progressCur(int);

	void autoShowRoi(int, int);

	//void curCycleIsDone();
private:
	bool isNeedManual = 0;	// 默认不需要人工干预
	bool isSuccess = 0;
	std::vector<int> noNeedManualAreaB;
	std::vector<int> noNeedManualAreaA;
	bool isNeedManualForDetail(std::vector<int> errorNumB, std::vector<int> errorNumA);
	double SimilarityMin = 0.9;

	int curMoldObjId = 0;
	int curRunMold = 0;

	bool adamInitRes = 0;
	std::string ioIPAddr;
	int ioPort;

	std::map<std::string, std::string> enet;
	std::map<std::string, std::string> param;
	std::map<std::string, std::string> addr;
	std::vector<std::vector<std::string>> step;
	std::vector<std::vector<std::string>> stepMNorm;
	std::vector<std::vector<std::string>> stepMSubCmd;
	std::map<int, int> stepMSubIdx;
	std::map<int, int> stepMCtsInputIdx;
	std::vector<std::vector<int>> block;
	
	//MysqlSetting mysql_con;

	//Camera *mycam;
	Adam6060 adam;
	
	cv::Mat picBeforeEjection;	// 已有图像
	cv::Mat picAfterEjection;
	std::string addr_before;
	std::string addr_after;

	cv::Mat grabImageBefore;	// 抓取图像
	cv::Mat grabImageAfter;
	std::string grab_addr_before;
	std::string grab_addr_after;

	std::string before_with_block;
	std::string after_with_block;

	void shotPicture(cv::Mat &picture);


	int cycle_times = 0;	// 总循环次数
	int counter_1 = 0;		// 计数器1
	int counter_2 = 0;		// 计数器2
	int delay_1 = 0;		// 延迟器1
	int delay_2 = 0;		// 延迟器2

	void bufferInputClear();
	void delayTime(int time);

	bool beforeSelected = 0;
	bool afterSelected = 0;
	void grabImage(int dstIO);

	bool checkRes = 0;	// bool型检查结果
	std::string detailCheckRes = "正常";	// 字符型检查结果
	//ImageProcessing imgProcess;
	bool checkImage();

	void excuteImage(std::string cur);
	void dealExcuteImagePause(cv::Mat &pic1, cv::Mat &pic2);

	//int logErrorImageNum = 0;
	//int logErrorImageTotal = 2000;	// 限定保存2000张错误图片
	int check_img_forword = 2;
	void logSaving(std::string log_message, int for_step);
	
	void printResMsg(std::string num, std::string tim, std::string result, std::string msg);
	void printCurMsg(std::string msg);

	int getInIO, getInStus;
	bool hasGetIn = 0;

	std::vector<std::string> split(std::string s, char delim);

	// 用于存储相似度
	std::vector<double> SimilarityBefore;
	std::vector<double> SimilarityAfter;

	//void getMultiInputStatus(int idxVect[], std::string statusVect[], int &length);
	//void setMultiOutputStatus(int idxVect[], bool statusVect[], int &length);
	//void dealGetInputStatusSingle(int dstIO, std::string status);

	void getPossibleMultiInput(std::string inputMsg, std::string inputStatus);

private slots:
	void dealInputStatus(int dstIn, int stus);
};