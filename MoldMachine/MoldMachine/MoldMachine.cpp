#include "MoldMachine.h"

MoldMachine::MoldMachine(QWidget *parent)
	: QMainWindow(parent)
{
	ui.setupUi(this);
	this->setFixedSize(1300, 850);
	
	// status bar
	sBar = statusBar();
	dataSrc = new QLabel(this);
	sBar->addWidget(dataSrc);
	//dealDataSrcChosen(1);	// 默认XML File
	dataSrc->setText("当前模具Id : 1");
	//dataSrc->setText(QStringLiteral("当前模具ID : 1"));

	// read io name
	readInitParam();

	// Save Cfg As Xml
	connect(ui.actionSaveCfgAsXML, SIGNAL(triggered()), this, SLOT(saveConfig2XML()));

	// Read XML As SQL Data
	connect(ui.actionReadXMLAsSqlData, SIGNAL(triggered()), this, SLOT(readXML2SqlData()));

	// I/O Service
	connect(ui.actionENetIOSetting, SIGNAL(triggered()), this, SLOT(ENetIOSetting()));

	// Image Setting
	connect(ui.actionImageSetting, SIGNAL(triggered()), this, SLOT(imageSetting()));

	// CycleTimesSetting
	connect(ui.actionCycleTimesSetting, SIGNAL(triggered()), this, SLOT(cycleTimesSetting()));

	// CycleStepSetting
	connect(ui.actionCycleStepSetting, SIGNAL(triggered()), this, SLOT(cycleStepSetting()));

	// CounterSetting
	connect(ui.actionCounterSetting, SIGNAL(triggered()), this, SLOT(counterSetting()));

	// DelaySetting
	connect(ui.actionDelaySetting, SIGNAL(triggered()), this, SLOT(delaySetting()));

	//// Camera Config
	//connect(ui.actionCameraConfig, SIGNAL(triggered()), this, SLOT(cameraConfig()));

	//// data source
	//connect(ui.actionDataSrc, SIGNAL(triggered()), this, SLOT(dataSource()));

	// Mold Object
	connect(ui.actionMoldObjects, SIGNAL(triggered()), this, SLOT(moldObject()));

	// Help-About
	connect(ui.actionAbout, SIGNAL(triggered()), this, SLOT(aboutHelp()));

	// run and stop action init
	ui.actionRun->setDisabled(false);
	ui.actionStop->setDisabled(true);
	
	// Run
	connect(ui.actionRun, SIGNAL(triggered()), this, SLOT(runAll()));

	// Stop
	connect(ui.actionStop, SIGNAL(triggered()), this, SLOT(stopAll()));

	lightRed.load("./Resources/ico/light_red_20x20.jpg");
	lightGreen.load("./Resources/ico/light_green_20x20.jpg");


}

void MoldMachine::readXML2SqlData() {
	ParamInit param;

	param.readXML2SqlData();

	QMessageBox::about(this, "Tips", "Have Read XML From Current Folder to SQL DataBase. Press OK To Continue.");
}

void MoldMachine::saveConfig2XML() {
	// 从数据库中读出数据保存为XML文件
	std::cout << "is saving mold_id = " << curMoldId << " config to xml..." << std::endl;
	ParamInit param;
	// cycle_times/cnt/delay
	param.cycleTimesCountersDelaysCrt();
	// step
	param.cycleStepCrt(curMoldId);

	// addr
	param.imageAddrCrt();

	// ioservice
	param.ioServiceCrt();

	// block
	param.imageBlockCrt(curMoldId);

	QMessageBox::about(this, "Tips", "Have Saved Configuration to XML Files In Current Folder. Press OK To Continue.");
}

void MoldMachine::moldObject() {
	MoldObject *moldObj = new MoldObject();
	// 设置子窗口属性，在子窗口关闭之后，释放子窗口的资源(释放指针)
	moldObj->setAttribute(Qt::WA_DeleteOnClose);
	moldObj->show();
	connect(moldObj, SIGNAL(sendMoldId(int)), this, SLOT(dealMoldId(int)));
}

void MoldMachine::dealMoldId(int id) {
	curMoldId = id;		// 得到用户选取的mold id，default 1
	char txt[30];
	strcpy(txt, "当前模具Id : ");
	strcat(txt, std::to_string(id).c_str());
	dataSrc->setText(txt);

	// 修改ID后重新读取参数
	readInitParam();
}

void MoldMachine::dealStepRunFrom(int runMod) {
	curRunMode = runMod;
	// 设置progressBar
	if (!curRunMode) {
		ui.progressBarStep->setMaximum(cycleStep.size());
		ui.progressBarStep->setValue(0);
		ui.progressBarStep->setFormat(QString::fromLocal8Bit("%1 / %2").arg(0).arg(cycleStep.size()));
	}
	else {
		//int stepSize = cycleStepManualNorm.size();
		ui.progressBarStep->setMaximum(subRelationIdx[1]);
		ui.progressBarStep->setValue(0);
		ui.progressBarStep->setFormat(QString::fromLocal8Bit("%1 / %2").arg(0).arg(subRelationIdx[1]));
	}
	//std::cout << curRunMode << std::endl;
}

void MoldMachine::ENetIOSetting() {
	IOService *ioservice = new IOService();
	// 设置子窗口属性，在子窗口关闭之后，释放子窗口的资源(释放指针)
	ioservice->setAttribute(Qt::WA_DeleteOnClose);
	ioservice->show();
}

void MoldMachine::imageSetting() {
	ImageSetting *imageSetting = new ImageSetting(curMoldId);
	// 设置子窗口属性，在子窗口关闭之后，释放子窗口的资源(释放指针)
	imageSetting->setAttribute(Qt::WA_DeleteOnClose);
	imageSetting->show();
	
}

void MoldMachine::cycleTimesSetting() {
	CycleSetting *cycleSetting = new CycleSetting();
	// 设置子窗口属性，在子窗口关闭之后，释放子窗口的资源(释放指针)
	cycleSetting->setAttribute(Qt::WA_DeleteOnClose);
	cycleSetting->show();
}

void MoldMachine::cycleStepSetting() {
	CycleStepSetting *stepSetting = new CycleStepSetting(curMoldId);
	// 设置子窗口属性，在子窗口关闭之后，释放子窗口的资源(释放指针)
	stepSetting->setAttribute(Qt::WA_DeleteOnClose);
	stepSetting->show();
	connect(stepSetting, SIGNAL(sendRunFromTableOrManual(int)), this, SLOT(dealStepRunFrom(int)));
}

void MoldMachine::counterSetting() {
	CounterSetting *cnterSetting = new CounterSetting();
	// 设置子窗口属性，在子窗口关闭之后，释放子窗口的资源(释放指针)
	cnterSetting->setAttribute(Qt::WA_DeleteOnClose);
	cnterSetting->show();
}

void MoldMachine::delaySetting() {
	DelaySetting *delay = new DelaySetting();
	// 设置子窗口属性，在子窗口关闭之后，释放子窗口的资源(释放指针)
	delay->setAttribute(Qt::WA_DeleteOnClose);
	delay->show();
}

void MoldMachine::runAll() {
	// check for all setting is ok ?
	checkSetting();

	// run all
	std::cout << "threadStep new one" << std::endl;
	threadStepRun = new RunningThread(this, curMoldId, cycleParam, imgAddr, cycleStep, blockInt, ioEnet,
		cycleStepManualNorm, cycleStepManualSubCmd, subRelationIdx, mContinuousInput, curRunMode);
	threadStepRun->setRunFlag(1);
	//std::cout << "fromXmlOrSql: " << fromXmlOrSql << std::endl;
	threadStepRun->start();

	connect(threadStepRun, SIGNAL(grabImgQuest(int)), this, SLOT(dealGrabImg(int)));
	connect(threadStepRun, SIGNAL(excuteImageQuest(int, QString, QString)), this, SLOT(dealExcuteImg(int, QString, QString)));
	connect(threadStepRun, &RunningThread::stepRunIsDone, this, &MoldMachine::dealThreadDone);
	connect(threadStepRun, SIGNAL(statusInput(int, int)), this, SLOT(dealInputStatus(int, int)));
	connect(threadStepRun, SIGNAL(statusOutput(int, int)), this, SLOT(dealOutputStatus(int, int)));
	connect(threadStepRun, SIGNAL(emitResMsg(QString, QString, QString, QString)), this, SLOT(Log(QString, QString, QString, QString)));
	connect(threadStepRun, SIGNAL(emitCurMsg(QString)), this, SLOT(ShowCurProcess(QString)));
	connect(this, SIGNAL(emitInputStatusChg(int, int)), threadStepRun, SLOT(dealInputStatus(int, int)));
	connect(threadStepRun, SIGNAL(progressCur(int)), this, SLOT(updateProgressBar(int)));
	connect(threadStepRun, SIGNAL(autoShowRoi(int, int)), this, SLOT(dealAutoShowResRoi(int, int)));

	connect(this, &MoldMachine::destroyed, this, &MoldMachine::stopAll);

	ui.actionRun->setDisabled(true);
	ui.menuBar->setDisabled(true);
	ui.actionStop->setDisabled(false);
}

void MoldMachine::dealAutoShowResRoi(int flagBOrA, int flagNum) {
	std::cout << "auto show res last roi" << std::endl;
	if (flagBOrA == 0) {	// 顶出前
		CurRoiDisplay *curRoi = new CurRoiDisplay(imgBlock);
		curRoi->setAttribute(Qt::WA_DeleteOnClose);
		float ratioBX = 0;
		float ratioBY = 0;
		curRoi->displayRoi(grabImgAddrBefore, ratioBX, ratioBY, flagNum);
	}
	else if (flagBOrA == 1) {	// 顶出后
		CurRoiDisplay *curRoi = new CurRoiDisplay(imgBlock);
		curRoi->setAttribute(Qt::WA_DeleteOnClose);
		float ratioAX = 0;
		float ratioAY = 0;
		curRoi->displayRoi(grabImgAddrAfter, ratioAX, ratioAY, flagNum);
	}
}

void MoldMachine::stopAll() {
	// stop
	std::cout << std::endl;
	std::cout << "threadStep is stopped" << std::endl;

	threadStepRun->setRunFlag(0);
	threadStepRun->quit();
	
	// 等待线程停止存在问题（TODO）
	std::cout << "wait thread over" << std::endl;
	threadStepRun->wait();
	std::cout << "thread has over" << std::endl;

	delete threadStepRun;

	ui.actionRun->setDisabled(false);
	ui.menuBar->setDisabled(false);
	ui.actionStop->setDisabled(true);

	//disconnect(this, &MoldMachine::destroyed, this, &MoldMachine::stopAll);
}

void MoldMachine::dealThreadDone() {
	ui.labelDisCurProcess->setText("循环次数已归零");
	std::cout << "*************** cycle  over **************" << std::endl;
	stopAll();
}

void MoldMachine::checkSetting() {
	
}

void MoldMachine::dealGrabImg(int dstIO) {
	//QPixmap img;
	//img.load(addr);
	if (dstIO && !clearSelect) {
		ui.labelBeforeOne->setStyleSheet("border-width: 1px;border-style: solid;border-color: rgb(0, 0, 0);");
		ui.labelAfterOne->setStyleSheet("border-width: 1px;border-style: solid;border-color: rgb(0, 0, 0);");
	}

	switch (dstIO)
	{
		case 1:		// before ejection
		{
			//ui.labelBeforeOne->clear();
			//ui.labelBeforeOne->setPixmap(img.scaled(ui.labelBeforeOne->size(), Qt::IgnoreAspectRatio));
			ui.labelBeforeOne->setFrameStyle(QFrame::Box);
			ui.labelBeforeOne->setFrameShadow(QFrame::Sunken);
			ui.labelBeforeOne->setStyleSheet("border-width: 5px;border-style: solid;border-color: rgb(0, 0, 255);");
			clearSelect = 1;
			break;
		}
		case 2:		// after ejection
		{
			//ui.labelAfterOne->setStyleSheet("border-width: 1px;border-style: solid;border-color: rgb(0, 0, 0);");
			//ui.labelBeforeOne->setStyleSheet("border-width: 1px;border-style: solid;border-color: rgb(0, 0, 0);");
			//ui.labelAfterOne->clear();
			//ui.labelAfterOne->setPixmap(img.scaled(ui.labelBeforeOne->size(), Qt::IgnoreAspectRatio));
			ui.labelAfterOne->setFrameStyle(QFrame::Box);
			ui.labelAfterOne->setFrameShadow(QFrame::Sunken);
			ui.labelAfterOne->setStyleSheet("border-width: 5px;border-style: solid;border-color: rgb(0, 0, 255);");
			clearSelect = 1;
			break;
		}
		default:
		{
			clearSelect = 0;
			break;
		}
	}
}

void MoldMachine::dealExcuteImg(int mode, QString addr1, QString addr2) {
	

	switch (mode)
	{
		case 1:	// show all
		{
			QPixmap img_grab_before;
			QPixmap img_grab_after;
			img_grab_before.load(addr1);
			img_grab_after.load(addr2);

			ui.labelBeforeOne->clear();
			ui.labelAfterOne->clear();
			//ui.labelBeforeOne->setStyleSheet("background-color:black;");
			//ui.labelAfterOne->setStyleSheet("background-color:black;");

			ui.labelBeforeOne->setPixmap(img_grab_before.scaled(ui.labelBeforeOne->size(), Qt::IgnoreAspectRatio));
			ui.labelAfterOne->setPixmap(img_grab_after.scaled(ui.labelBeforeOne->size(), Qt::IgnoreAspectRatio));

			// 显示图片之后响应鼠标点击事件
			ui.labelBeforeOne->installEventFilter(this);
			ui.labelAfterOne->installEventFilter(this);
			grabImgAddrBefore = addr1;
			grabImgAddrAfter = addr2;

			break;
		}
		case 2:	// pause
		{
			break;
		}
		case 3:	// clear 
		{
			ui.labelBeforeOne->clear();
			ui.labelAfterOne->clear();
			//ui.labelBeforeOne->setStyleSheet("background-color:black;");
			//ui.labelAfterOne->setStyleSheet("background-color:black;");
			break;
		}
		case 4:	// show before only
		{
			QPixmap img_grab_before;
			img_grab_before.load(addr1);
			ui.labelBeforeOne->clear();
			//ui.labelBeforeOne->setStyleSheet("background-color:black;");
			ui.labelBeforeOne->setPixmap(img_grab_before.scaled(ui.labelBeforeOne->size(), Qt::IgnoreAspectRatio));

			// 显示图片之后响应鼠标点击事件
			ui.labelBeforeOne->installEventFilter(this);
			grabImgAddrBefore = addr1;
			break;
		}
		case 5:	// show after only
		{
			QPixmap img_grab_after;
			img_grab_after.load(addr2);
			ui.labelAfterOne->clear();
			//ui.labelAfterOne->setStyleSheet("background-color:black;");
			ui.labelAfterOne->setPixmap(img_grab_after.scaled(ui.labelBeforeOne->size(), Qt::IgnoreAspectRatio));

			// 显示图片之后响应鼠标点击事件
			ui.labelAfterOne->installEventFilter(this);
			grabImgAddrAfter = addr2;
			break;
		}
		default:
			break;
	}
}

void MoldMachine::readInitParam() {
	MysqlSetting mysql_con;

	ioName = mysql_con.queryAllData("ioservice_name", "name", "value");
	ioStatus = mysql_con.queryAllData("ioservice_status", "name", "status");
	ioEnet = mysql_con.queryAllData("ioservice_enet", "name", "addr");

	cycleParam = mysql_con.queryAllData("cycle_cnt_delay_val", "name", "value");
	curRunMode = atoi(cycleParam["run_mode"].c_str());

	imgAddr = mysql_con.queryAllData("image_addr", "name", "value");
	cycleStep = mysql_con.tabId2Vector("cycle_step", curMoldId, 31);
	imgBlock = mysql_con.tabId2Vector("image_block", curMoldId, 7);

	// cycle step manual
	cycleStepManualNorm = mysql_con.tabId2Vector("cycle_step_manual", 0, 3);	// 0为正常处理步骤
	subRelationIdx[0] = 0;	// 用来记录每一段从哪里开始
	for (int i = 1; i < subAllNum; ++i) {
		subRelationIdx[i] = cycleStepManualNorm.size();
		std::vector<std::vector<std::string>> tmp;
		tmp = mysql_con.tabId2Vector("cycle_step_manual", i, 3);
		cycleStepManualNorm.insert(cycleStepManualNorm.end(), tmp.begin(), tmp.end());
	}
	subRelationIdx[subAllNum] = cycleStepManualNorm.size();	// 用于最后的截至位置判断

	findMultiInput(); // 找连续的input，用于后面的判断同时获取输入
	//for (std::map<int, int>::iterator iter = mContinuousInput.begin(); iter != mContinuousInput.end(); iter++)
	//	std::cout << iter->first << "  " << iter->second << std::endl;

	cycleStepManualSubCmd = mysql_con.tab2VectorOrderById("manual_sub_cmd", 4);

	blockInt.resize(imgBlock.size());
	for (int i = 0; i < imgBlock.size(); i++) {
		for (int j = 1; j < imgBlock[i].size(); j++) {
			blockInt[i].push_back(atoi(imgBlock[i][j].c_str()));
		}
	}
	
	if (ioName["input_name_1"] == "/") ui.labelInS1->setEnabled(false);
	else ui.labelInS1->installEventFilter(this);
	if (ioName["input_name_2"] == "/") ui.labelInS2->setEnabled(false);
	else ui.labelInS2->installEventFilter(this);
	if (ioName["input_name_3"] == "/") ui.labelInS3->setEnabled(false);
	else ui.labelInS3->installEventFilter(this);
	if (ioName["input_name_4"] == "/") ui.labelInS4->setEnabled(false);
	else ui.labelInS4->installEventFilter(this);
	if (ioName["input_name_5"] == "/") ui.labelInS5->setEnabled(false);
	else ui.labelInS5->installEventFilter(this);
	if (ioName["input_name_6"] == "/") ui.labelInS6->setEnabled(false);
	else ui.labelInS6->installEventFilter(this);

	if (ioName["output_name_1"] == "/") ui.labelOutS1->setEnabled(false);
	if (ioName["output_name_2"] == "/") ui.labelOutS2->setEnabled(false);
	if (ioName["output_name_3"] == "/") ui.labelOutS3->setEnabled(false);
	if (ioName["output_name_4"] == "/") ui.labelOutS4->setEnabled(false);
	if (ioName["output_name_5"] == "/") ui.labelOutS5->setEnabled(false);
	if (ioName["output_name_6"] == "/") ui.labelOutS6->setEnabled(false);

	// 初始化progress bar
	if (cycleParam["run_mode"] == "1")
	{
		ui.progressBarStep->setMaximum(subRelationIdx[1]);
		ui.progressBarStep->setValue(0);
		ui.progressBarStep->setFormat(QString::fromLocal8Bit("%1 / %2").arg(0).arg(subRelationIdx[1]));
	}
	else
	{
		ui.progressBarStep->setMaximum(cycleStep.size());
		ui.progressBarStep->setValue(0);
		ui.progressBarStep->setFormat(QString::fromLocal8Bit("%1 / %2").arg(0).arg(cycleStep.size()));
	}
	ui.tableWidgetDisRes->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	ui.tableWidgetDisRes->horizontalHeader()->setSectionResizeMode(0, QHeaderView::ResizeToContents);
	ui.tableWidgetDisRes->horizontalHeader()->setSectionResizeMode(1, QHeaderView::ResizeToContents);

	//ui.labelBeforeOne->installEventFilter(this);
	//ui.labelAfterOne->installEventFilter(this);
}

void MoldMachine::dealInputStatus(int dstIO, int status) {
	switch (dstIO)
	{
		case 1:
		{
			stus1 = status;
			if (status)
				ui.labelInS1->setPixmap(lightRed);
			else 
				ui.labelInS1->setPixmap(lightGreen);
			break;
		}
		case 2:
		{
			stus2 = status;
			if (status)
				ui.labelInS2->setPixmap(lightRed);
			else
				ui.labelInS2->setPixmap(lightGreen);
			break;
		}
		case 3:
		{
			stus3 = status;
			if (status)
				ui.labelInS3->setPixmap(lightRed);
			else
				ui.labelInS3->setPixmap(lightGreen);
			break;
		}
		case 4:
		{
			stus4 = status;
			if (status)
				ui.labelInS4->setPixmap(lightRed);
			else
				ui.labelInS4->setPixmap(lightGreen);
			break;
		}
		case 5:
		{
			stus5 = status;
			if (status)
				ui.labelInS5->setPixmap(lightRed);
			else
				ui.labelInS5->setPixmap(lightGreen);
			break;
		}
		case 6:
		{
			stus6 = status;
			if (status)
				ui.labelInS6->setPixmap(lightRed);
			else
				ui.labelInS6->setPixmap(lightGreen);
			break;
		}
		default:
			break;
	}
}

void MoldMachine::dealOutputStatus(int dstIO, int status) {
	switch (dstIO)
	{
		case 1:
		{
			if (status)
				ui.labelOutS1->setPixmap(lightRed);
			else
				ui.labelOutS1->setPixmap(lightGreen);
			break;
		}
		case 2:
		{
			if (status)
				ui.labelOutS2->setPixmap(lightRed);
			else
				ui.labelOutS2->setPixmap(lightGreen);
			break;
		}
		case 3:
		{
			if (status)
				ui.labelOutS3->setPixmap(lightRed);
			else
				ui.labelOutS3->setPixmap(lightGreen);
			break;
		}
		case 4:
		{
			if (status)
				ui.labelOutS4->setPixmap(lightRed);
			else
				ui.labelOutS4->setPixmap(lightGreen);
			break;
		}
		case 5:
		{
			if (status)
				ui.labelOutS5->setPixmap(lightRed);
			else
				ui.labelOutS5->setPixmap(lightGreen);
			break;
		}
		case 6:
		{
			if (status)
				ui.labelOutS6->setPixmap(lightRed);
			else
				ui.labelOutS6->setPixmap(lightGreen);
			break;
		}
		default:
			break;
	}
}

bool MoldMachine::eventFilter(QObject *obj, QEvent *ev) {
	if (obj == ui.labelInS1) {
		if (ev->type() == QEvent::MouseButtonPress) {
			QMouseEvent *mouseevent = static_cast<QMouseEvent *>(ev);
			if (mouseevent->buttons() == Qt::LeftButton) {
				if (stus1)
					emit emitInputStatusChg(1, 0);	// 反
				else 
					emit emitInputStatusChg(1, 1);
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else if (obj == ui.labelInS2) {
		if (ev->type() == QEvent::MouseButtonPress) {
			QMouseEvent *mouseevent = static_cast<QMouseEvent *>(ev);
			if (mouseevent->buttons() == Qt::LeftButton) {
				if (stus2)
					emit emitInputStatusChg(2, 0);	// 反
				else
					emit emitInputStatusChg(2, 1);
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else if (obj == ui.labelInS3) {
		if (ev->type() == QEvent::MouseButtonPress) {
			QMouseEvent *mouseevent = static_cast<QMouseEvent *>(ev);
			if (mouseevent->buttons() == Qt::LeftButton) {
				if (stus3)
					emit emitInputStatusChg(3, 0);	// 反
				else
					emit emitInputStatusChg(3, 1);
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else if (obj == ui.labelInS4) {
		if (ev->type() == QEvent::MouseButtonPress) {
			QMouseEvent *mouseevent = static_cast<QMouseEvent *>(ev);
			if (mouseevent->buttons() == Qt::LeftButton) {
				if (stus4)
					emit emitInputStatusChg(4, 0);	// 反
				else
					emit emitInputStatusChg(4, 1);
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else if (obj == ui.labelInS5) {
		if (ev->type() == QEvent::MouseButtonPress) {
			QMouseEvent *mouseevent = static_cast<QMouseEvent *>(ev);
			if (mouseevent->buttons() == Qt::LeftButton) {
				if (stus5)
					emit emitInputStatusChg(5, 0);	// 反
				else
					emit emitInputStatusChg(5, 1);
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else if (obj == ui.labelInS6) {
		if (ev->type() == QEvent::MouseButtonPress) {
			QMouseEvent *mouseevent = static_cast<QMouseEvent *>(ev);
			if (mouseevent->buttons() == Qt::LeftButton) {
				if (stus6)
					emit emitInputStatusChg(6, 0);	// 反
				else
					emit emitInputStatusChg(6, 1);
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else if (obj == ui.labelBeforeOne && !imgBefIsOnShow) {
		if (ev->type() == QEvent::MouseButtonPress) {
			QMouseEvent *mouseevent = static_cast<QMouseEvent *>(ev);
			if (mouseevent->buttons() == Qt::LeftButton) {
				//imgBefIsOnShow = 1;
				CurRoiDisplay *curRoi = new CurRoiDisplay(imgBlock);
				curRoi->setAttribute(Qt::WA_DeleteOnClose);
				float ratioBX = (float)mouseevent->pos().x() / ui.labelBeforeOne->width();
				float ratioBY = (float)mouseevent->pos().y() / ui.labelBeforeOne->height();
				curRoi->displayRoi(grabImgAddrBefore, ratioBX, ratioBY, -1);
				//curRoi->show();
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else if (obj == ui.labelAfterOne && !imgAftIsOneshow) {
		if (ev->type() == QEvent::MouseButtonPress) {
			QMouseEvent *mouseevent = static_cast<QMouseEvent *>(ev);
			if (mouseevent->buttons() == Qt::LeftButton) {
				//imgAftIsOneshow = 1;
				CurRoiDisplay *curRoi = new CurRoiDisplay(imgBlock);
				curRoi->setAttribute(Qt::WA_DeleteOnClose);
				float ratioAX = (float)mouseevent->pos().x() / ui.labelAfterOne->width();
				float ratioAY = (float)mouseevent->pos().y() / ui.labelAfterOne->height();
				curRoi->displayRoi(grabImgAddrAfter, ratioAX, ratioAY, -1);
				//curRoi->show();
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else {
		return QMainWindow::eventFilter(obj, ev);
	}
}

void MoldMachine::updateProgressBar(int curProgress) {
	if (!curRunMode) {
		ui.progressBarStep->setValue(curProgress);
		ui.progressBarStep->setFormat(QString::fromLocal8Bit("%1 / %2").arg(curProgress).arg(cycleStep.size()));
	}
	else {
		//int stepSize = cycleStepManualNorm.size();
		ui.progressBarStep->setValue(curProgress);
		ui.progressBarStep->setFormat(QString::fromLocal8Bit("%1 / %2").arg(curProgress).arg(subRelationIdx[1]));
	}
}

void MoldMachine::Log(QString num, QString tim, QString result, QString msg) {
	int curRowCnt = ui.tableWidgetDisRes->rowCount();
	ui.tableWidgetDisRes->insertRow(curRowCnt);
	
	ui.tableWidgetDisRes->setItem(curRowCnt, 0, new QTableWidgetItem(num));
	ui.tableWidgetDisRes->setItem(curRowCnt, 1, new QTableWidgetItem(tim));
	ui.tableWidgetDisRes->setItem(curRowCnt, 2, new QTableWidgetItem(result));
	ui.tableWidgetDisRes->setItem(curRowCnt, 3, new QTableWidgetItem(msg));

	ui.tableWidgetDisRes->item(curRowCnt, 0)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
	//ui.tableWidgetDisRes->item(curRowCnt, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
	ui.tableWidgetDisRes->item(curRowCnt, 2)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
	ui.tableWidgetDisRes->item(curRowCnt, 3)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);

	
}

void MoldMachine::ShowCurProcess(QString msg) {
	//ui.labelDisCurProcess->clear();
	ui.labelDisCurProcess->setText(msg);
	//Sleep(100);
}

void MoldMachine::aboutHelp() {
	QMessageBox::about(this, "about", "Process monitoring system for injection molding machine.");
}

// 用于预先判断连续输入区域
void MoldMachine::findMultiInput() {
	std::string curOpt;
	std::vector<std::string> splitWithSharp;
	int n = 0, cnt = 0;
	bool isContinuous = false;
	for (int i = 0; i < cycleStepManualNorm.size(); i++) {
		curOpt = cycleStepManualNorm[i][1];
		splitWithSharp = split(curOpt, '#');
		if (splitWithSharp.size() == 4 + 1 && splitWithSharp[1] == "1") {	// 对I进行判断
			n = i + 1;
			cnt = 0;	
			std::string curInput = splitWithSharp[2];	// 连续判断的话不可能出现同样的input口
			isContinuous = true;
			if (n != cycleStepManualNorm.size()) {
				while (isContinuous) {
					isContinuous = false;
					// 清空向量
					while (!splitWithSharp.empty()) {
						splitWithSharp.pop_back();
					}
					curOpt = cycleStepManualNorm[n][1];
					splitWithSharp = split(curOpt, '#');
					if (splitWithSharp.size() == 4 + 1 && splitWithSharp[1] == "1" && splitWithSharp[2] != curInput) {
						n++;
						cnt++;
						isContinuous = true;
						//std::cout << n << std::endl;
					}
				}
				if (cnt >= 1) {
					mContinuousInput[i] = (cnt + 1);	// 连本身
					i += cnt;
				}
			}
		}
		while (!splitWithSharp.empty()) {
			splitWithSharp.pop_back();
		}
	}
}

std::vector<std::string> MoldMachine::split(std::string s, char delim) {
	std::vector<std::string> v;
	std::stringstream stringstream1(s);
	std::string tmp;
	while (getline(stringstream1, tmp, delim)) {
		v.push_back(tmp);
	}
	return v;
}

MoldMachine::~MoldMachine()
{
	delete threadStepRun;
	delete sBar;
	delete dataSrc;

}
