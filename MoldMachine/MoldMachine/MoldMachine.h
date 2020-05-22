#pragma once

#include <QtWidgets/QMainWindow>
#include <QMessageBox>
#include <QHeaderView>
#include <QImage>
#include <QPixmap>

#include "ui_MoldMachine.h"

#include "IOService.h"
#include "ImageSetting.h"
#include "CycleSetting.h"
#include "CycleStepSetting.h"
#include "CounterSetting.h"
#include "DelaySetting.h"
#include "MoldObject.h"
//#include "CameraConfig.h"
//#include "dataSource.h"
#include "CurRoiDisplay.h"

#include "RunningStepThread.h"

//#include "MysqlSetting.h"
#include "ParameterInit.h"
//#include "xmlFileSetting.h"

class MoldMachine : public QMainWindow
{
	Q_OBJECT

	public:
		MoldMachine(QWidget *parent = Q_NULLPTR);
		~MoldMachine();

		Ui::MoldMachineClass ui;
	private:
		std::map<std::string, std::string> ioName;
		std::map<std::string, std::string> ioStatus;
		std::map<std::string, std::string> ioEnet;

		std::map<std::string, std::string> cycleParam;
		std::map<std::string, std::string> imgAddr;
		std::vector<std::vector<std::string>> cycleStep;
		std::vector<std::vector<std::string>> cycleStepManualNorm;
		std::vector<std::vector<std::string>> cycleStepManualSubCmd;
		std::map<int, int> subRelationIdx;
		int subAllNum = 3;		// 定义几个子程序
		std::vector<std::vector<std::string>> imgBlock;
		std::vector<std::vector<int>> blockInt;

		// read io name
		void readInitParam();
		
		// check all seting
		void checkSetting();

		RunningThread *threadStepRun;

		bool clearSelect = 0;	// 清除方框选择

		QStatusBar *sBar;
		QLabel *dataSrc;

		//int fromXmlOrSql = 0;
		int curMoldId = 1;
		// 运行步骤读取
		int curRunMode = 0;

		int stus1, stus2, stus3, stus4, stus5, stus6;
		QPixmap lightRed;
		QPixmap lightGreen;

		bool eventFilter(QObject *obj, QEvent *ev);

		QString grabImgAddrBefore, grabImgAddrAfter;
		bool imgBefIsOnShow = 0, imgAftIsOneshow = 0;

		std::vector<std::string> split(std::string s, char delim);
		std::map<int, int> mContinuousInput;
		void findMultiInput();

	private slots:
		void saveConfig2XML();
		void readXML2SqlData();
		void ENetIOSetting();
		void imageSetting();
		void cycleTimesSetting();
		void cycleStepSetting();
		void counterSetting();
		void delaySetting();
		void moldObject();
		//void dataSource();
		void aboutHelp();
		//void cameraConfig();

		//void dealDataSrcChosen(int);

		void runAll();
		void stopAll();

		void dealThreadDone();
		
		void dealGrabImg(int dstIO);
		void dealExcuteImg(int mode, QString addr1, QString addr2);

		void dealMoldId(int moldId);
		void dealStepRunFrom(int runMod);

		void Log(QString num, QString tim, QString result, QString msg);
		void ShowCurProcess(QString msg);

		void dealInputStatus(int, int);
		void dealOutputStatus(int, int);

		void updateProgressBar(int curProgress);

		//void dealCurCycleDone();
		void dealAutoShowResRoi(int, int);

	signals:
		void emitInputStatusChg(int dstIn, int stus);
};
