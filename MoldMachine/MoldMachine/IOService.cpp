#include "IOService.h"
#include <QDebug>

IOService::IOService(QWidget *parent)
	: QWidget(parent)
{
	this->setFixedSize(750, 550);
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);

	IoServiceInitParam();

	// buttonApply->clicked
	connect(ui.buttonApply, SIGNAL(clicked()), this, SLOT(buttonApplyClicked()));

	// TabWidget
	// name modify
	connect(ui.lineEditInputOne, SIGNAL(editingFinished()), this, SLOT(nameInputOneModify()));
	connect(ui.lineEditInputTwo, SIGNAL(editingFinished()), this, SLOT(nameInputTwoModify()));
	connect(ui.lineEditInputThree, SIGNAL(editingFinished()), this, SLOT(nameInputThreeModify()));
	connect(ui.lineEditInputFour, SIGNAL(editingFinished()), this, SLOT(nameInputFourModify()));
	connect(ui.lineEditInputFive, SIGNAL(editingFinished()), this, SLOT(nameInputFiveModify()));
	connect(ui.lineEditInputSix, SIGNAL(editingFinished()), this, SLOT(nameInputSixModify()));

	connect(ui.lineEditOutputOne, SIGNAL(editingFinished()), this, SLOT(nameOutputOneModify()));
	connect(ui.lineEditOutputTwo, SIGNAL(editingFinished()), this, SLOT(nameOutputTwoModify()));
	connect(ui.lineEditOutputThree, SIGNAL(editingFinished()), this, SLOT(nameOutputThreeModify()));
	connect(ui.lineEditOutputFour, SIGNAL(editingFinished()), this, SLOT(nameOutputFourModify()));
	connect(ui.lineEditOutputFive, SIGNAL(editingFinished()), this, SLOT(nameOutputFiveModify()));
	connect(ui.lineEditOutputSix, SIGNAL(editingFinished()), this, SLOT(nameOutputSixModify()));

	// enet modify
	connect(ui.lineEditLocalIP, SIGNAL(editingFinished()), this, SLOT(localIPModify()));
	connect(ui.lineEditServerIP, SIGNAL(editingFinished()), this, SLOT(serverIPModify()));
	connect(ui.lineEditPort, SIGNAL(editingFinished()), this, SLOT(portModify()));

	// status modify
	// 双态勾选的state=2，未勾选state=0

	connect(ui.checkBoxInitialInputOne, SIGNAL(stateChanged(int)), this, SLOT(statusInitialInputOneModify(int)));
	connect(ui.checkBoxInitialInputTwo, SIGNAL(stateChanged(int)), this, SLOT(statusInitialInputTwoModify(int)));
	connect(ui.checkBoxInitialInputThree, SIGNAL(stateChanged(int)), this, SLOT(statusInitialInputThreeModify(int)));
	connect(ui.checkBoxInitialInputFour, SIGNAL(stateChanged(int)), this, SLOT(statusInitialInputFourModify(int)));
	connect(ui.checkBoxInitialInputFive, SIGNAL(stateChanged(int)), this, SLOT(statusInitialInputFiveModify(int)));
	connect(ui.checkBoxInitialInputSix, SIGNAL(stateChanged(int)), this, SLOT(statusInitialInputSixModify(int)));

	connect(ui.tabWidget, SIGNAL(currentChanged(int)), this, SLOT(onTabIndexChanged(int)));

	adamInitRes = adam.Adam6060Init(ui.lineEditLocalIP->text().toStdString(), ui.lineEditPort->text().toInt());
}

void IOService::onTabIndexChanged(int idx) {
	switch (idx)
	{
		case 1:
		{
			std::cout << "chg to ioTesting" << std::endl;
			if (adamInitRes) {
				if (timerForReadIn.isActive() == false) {
					// in
					timerForReadIn.start(200);
					connect(&timerForReadIn, SIGNAL(timeout()), this, SLOT(onReadInStatus()));

					// out
					connect(ui.checkBoxOutputOne, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputOneChanged(int)));
					connect(ui.checkBoxOutputTwo, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputTwoChanged(int)));
					connect(ui.checkBoxOutputThree, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputThreeChanged(int)));
					connect(ui.checkBoxOutputFour, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputFourChanged(int)));
					connect(ui.checkBoxOutputFive, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputFiveChanged(int)));
					connect(ui.checkBoxOutputSix, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputSixChanged(int)));
				}
			}
			else {
				std::cout << "error for init" << std::endl;
			}
			break;
		}
		default:
		{
			if (timerForReadIn.isActive() == true) {
				timerForReadIn.stop();
				disconnect(&timerForReadIn, SIGNAL(timeout()), this, SLOT(onReadInStatus()));

				disconnect(ui.checkBoxOutputOne, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputOneChanged(int)));
				disconnect(ui.checkBoxOutputTwo, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputTwoChanged(int)));
				disconnect(ui.checkBoxOutputThree, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputThreeChanged(int)));
				disconnect(ui.checkBoxOutputFour, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputFourChanged(int)));
				disconnect(ui.checkBoxOutputFive, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputFiveChanged(int)));
				disconnect(ui.checkBoxOutputSix, SIGNAL(stateChanged(int)), this, SLOT(oncheckBoxOutputSixChanged(int)));
			}
			break;
		}
	}
}

void IOService::onReadInStatus() {
	bool st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0;

	st1 = adam.Adam6060ReadStatus(0);
	st2 = adam.Adam6060ReadStatus(1);
	st3 = adam.Adam6060ReadStatus(2);
	st4 = adam.Adam6060ReadStatus(3);
	st5 = adam.Adam6060ReadStatus(4);
	st6 = adam.Adam6060ReadStatus(5);

	if (st1) ui.checkBoxInputOne->setCheckState(Qt::CheckState(1));
	else ui.checkBoxInputOne->setCheckState(Qt::CheckState(0));

	if (st2) ui.checkBoxInputTwo->setCheckState(Qt::CheckState(1));
	else ui.checkBoxInputTwo->setCheckState(Qt::CheckState(0));

	if (st3) ui.checkBoxInputThree->setCheckState(Qt::CheckState(1));
	else ui.checkBoxInputThree->setCheckState(Qt::CheckState(0));

	if (st4) ui.checkBoxInputFour->setCheckState(Qt::CheckState(1));
	else ui.checkBoxInputFour->setCheckState(Qt::CheckState(0));

	if (st5) ui.checkBoxInputFive->setCheckState(Qt::CheckState(1));
	else ui.checkBoxInputFive->setCheckState(Qt::CheckState(0));

	if (st6) ui.checkBoxInputSix->setCheckState(Qt::CheckState(1));
	else ui.checkBoxInputSix->setCheckState(Qt::CheckState(0));
}

void IOService::oncheckBoxOutputOneChanged(int status) {
	if (status) {	// status=2
		adam.Adam6060SingleSetOut(0, 1);
	}
	else {
		adam.Adam6060SingleSetOut(0, 0);
	}
}

void IOService::oncheckBoxOutputTwoChanged(int status) {
	if (status) {	// status=2
		adam.Adam6060SingleSetOut(1, 1);
	}
	else {
		adam.Adam6060SingleSetOut(1, 0);
	}
}

void IOService::oncheckBoxOutputThreeChanged(int status) {
	if (status) {	// status=2
		adam.Adam6060SingleSetOut(2, 1);
	}
	else {
		adam.Adam6060SingleSetOut(2, 0);
	}
}

void IOService::oncheckBoxOutputFourChanged(int status) {
	if (status) {	// status=2
		adam.Adam6060SingleSetOut(3, 1);
	}
	else {
		adam.Adam6060SingleSetOut(3, 0);
	}
}

void IOService::oncheckBoxOutputFiveChanged(int status) {
	if (status) {	// status=2
		adam.Adam6060SingleSetOut(4, 1);
	}
	else {
		adam.Adam6060SingleSetOut(4, 0);
	}
}

void IOService::oncheckBoxOutputSixChanged(int status) {
	if (status) {	// status=2
		adam.Adam6060SingleSetOut(5, 1);
	}
	else {
		adam.Adam6060SingleSetOut(5, 0);
	}
}

// buttonApply保存所有配置
void IOService::buttonApplyClicked() {
	// save param to mysql
	// 修改之后的map1,map2,map3
	// map_modify中存放的是修改过的key和value值
	// 1.找到修改的是哪些

	// 2.保存配置
	ioServiceParam.IOServiceParamSaving(map_modify_1, map_modify_2, map_modify_3);
	//ioServiceParam.xml_IOServiceParamSaving(map_modify_1, map_modify_2, map_modify_3);
	this->close();
}

void IOService::statusInitialInputOneModify(int state) {
	m2_init["input_status_1"] = std::to_string(state);
	map_modify_2["input_status_1"] = std::to_string(state);
}

void IOService::statusInitialInputTwoModify(int state) {
	m2_init["input_status_2"] = std::to_string(state);
	map_modify_2["input_status_2"] = std::to_string(state);
}

void IOService::statusInitialInputThreeModify(int state) {
	m2_init["input_status_3"] = std::to_string(state);
	map_modify_2["input_status_3"] = std::to_string(state);
}

void IOService::statusInitialInputFourModify(int state) {
	m2_init["input_status_4"] = std::to_string(state);
	map_modify_2["input_status_4"] = std::to_string(state);
}

void IOService::statusInitialInputFiveModify(int state) {
	m2_init["input_status_5"] = std::to_string(state);
	map_modify_2["input_status_5"] = std::to_string(state);
}

void IOService::statusInitialInputSixModify(int state) {
	m2_init["input_status_6"] = std::to_string(state);
	map_modify_2["input_status_6"] = std::to_string(state);
}

void IOService::localIPModify() {
	m3_init["localIP"] = ui.lineEditLocalIP->text().toStdString();
	map_modify_3["localIP"] = m3_init["localIP"];
}

void IOService::serverIPModify() {
	m3_init["serverIP"] = ui.lineEditServerIP->text().toStdString();
	map_modify_3["serverIP"] = m3_init["serverIP"];
}

void IOService::portModify() {
	m3_init["port"] = ui.lineEditPort->text().toStdString();
	map_modify_3["port"] = m3_init["port"];
}

void IOService::nameInputOneModify() {
	m1_init["input_name_1"] = ui.lineEditInputOne->text().toStdString();
	map_modify_1["input_name_1"] = m1_init["input_name_1"];
}

void IOService::nameInputTwoModify() {
	m1_init["input_name_2"] = ui.lineEditInputTwo->text().toStdString();
	map_modify_1["input_name_2"] = m1_init["input_name_2"];
}

void IOService::nameInputThreeModify() {
	m1_init["input_name_3"] = ui.lineEditInputThree->text().toStdString();
	map_modify_1["input_name_3"] = m1_init["input_name_3"];
}

void IOService::nameInputFourModify() {
	m1_init["input_name_4"] = ui.lineEditInputFour->text().toStdString();
	map_modify_1["input_name_4"] = m1_init["input_name_4"];
}

void IOService::nameInputFiveModify() {
	m1_init["input_name_5"] = ui.lineEditInputFive->text().toStdString();
	map_modify_1["input_name_5"] = m1_init["input_name_5"];
}

void IOService::nameInputSixModify() {
	m1_init["input_name_6"] = ui.lineEditInputSix->text().toStdString();
	map_modify_1["input_name_6"] = m1_init["input_name_6"];
}

void IOService::nameOutputOneModify() {
	m1_init["output_name_1"] = ui.lineEditOutputOne->text().toStdString();
	map_modify_1["output_name_1"] = m1_init["output_name_1"];
}

void IOService::nameOutputTwoModify() {
	m1_init["output_name_2"] = ui.lineEditOutputTwo->text().toStdString();
	map_modify_1["output_name_2"] = m1_init["output_name_2"];
}

void IOService::nameOutputThreeModify() {
	m1_init["output_name_3"] = ui.lineEditOutputThree->text().toStdString();
	map_modify_1["output_name_3"] = m1_init["output_name_3"];
}

void IOService::nameOutputFourModify() {
	m1_init["output_name_4"] = ui.lineEditOutputFour->text().toStdString();
	map_modify_1["output_name_4"] = m1_init["output_name_4"];
}

void IOService::nameOutputFiveModify() {
	m1_init["output_name_5"] = ui.lineEditOutputFive->text().toStdString();
	map_modify_1["output_name_5"] = m1_init["output_name_5"];
}

void IOService::nameOutputSixModify() {
	m1_init["output_name_6"] = ui.lineEditOutputSix->text().toStdString();
	map_modify_1["output_name_6"] = m1_init["output_name_6"];
}

void IOService::IoServiceInitParam() {
	ioServiceParam.IOServiceParamInit(m1_init, m2_init, m3_init);
	//ioServiceParam.xml_IOServiceParamInit(m1_init, m2_init, m3_init);
	// index 0 name setting
	ui.lineEditInputOne->setText(QString::fromStdString(m1_init["input_name_1"]));
	ui.lineEditInputTwo->setText(QString::fromStdString(m1_init["input_name_2"]));
	ui.lineEditInputThree->setText(QString::fromStdString(m1_init["input_name_3"]));
	ui.lineEditInputFour->setText(QString::fromStdString(m1_init["input_name_4"]));
	ui.lineEditInputFive->setText(QString::fromStdString(m1_init["input_name_5"]));
	ui.lineEditInputSix->setText(QString::fromStdString(m1_init["input_name_6"]));

	ui.lineEditOutputOne->setText(QString::fromStdString(m1_init["output_name_1"]));
	ui.lineEditOutputTwo->setText(QString::fromStdString(m1_init["output_name_2"]));
	ui.lineEditOutputThree->setText(QString::fromStdString(m1_init["output_name_3"]));
	ui.lineEditOutputFour->setText(QString::fromStdString(m1_init["output_name_4"]));
	ui.lineEditOutputFive->setText(QString::fromStdString(m1_init["output_name_5"]));
	ui.lineEditOutputSix->setText(QString::fromStdString(m1_init["output_name_6"]));

	// index 1 io testing
	// name input read
	ui.checkBoxInputOne->setText(QString::fromStdString(m1_init["input_name_1"]));
	ui.checkBoxInputTwo->setText(QString::fromStdString(m1_init["input_name_2"]));
	ui.checkBoxInputThree->setText(QString::fromStdString(m1_init["input_name_3"]));
	ui.checkBoxInputFour->setText(QString::fromStdString(m1_init["input_name_4"]));
	ui.checkBoxInputFive->setText(QString::fromStdString(m1_init["input_name_5"]));
	ui.checkBoxInputSix->setText(QString::fromStdString(m1_init["input_name_6"]));

	// name output read
	ui.checkBoxOutputOne->setText(QString::fromStdString(m1_init["output_name_1"]));
	ui.checkBoxOutputTwo->setText(QString::fromStdString(m1_init["output_name_2"]));
	ui.checkBoxOutputThree->setText(QString::fromStdString(m1_init["output_name_3"]));
	ui.checkBoxOutputFour->setText(QString::fromStdString(m1_init["output_name_4"]));
	ui.checkBoxOutputFive->setText(QString::fromStdString(m1_init["output_name_5"]));
	ui.checkBoxOutputSix->setText(QString::fromStdString(m1_init["output_name_6"]));
	
	// status input read
	ui.checkBoxInputOne->setChecked(stringToBool(m2_init["input_status_1"]));
	ui.checkBoxInputTwo->setChecked(stringToBool(m2_init["input_status_2"]));
	ui.checkBoxInputThree->setChecked(stringToBool(m2_init["input_status_3"]));
	ui.checkBoxInputFour->setChecked(stringToBool(m2_init["input_status_4"]));
	ui.checkBoxInputFive->setChecked(stringToBool(m2_init["input_status_5"]));
	ui.checkBoxInputSix->setChecked(stringToBool(m2_init["input_status_6"]));

	// status output read
	ui.checkBoxOutputOne->setChecked(stringToBool(m2_init["output_status_1"]));
	ui.checkBoxOutputTwo->setChecked(stringToBool(m2_init["output_status_2"]));
	ui.checkBoxOutputThree->setChecked(stringToBool(m2_init["output_status_3"]));
	ui.checkBoxOutputFour->setChecked(stringToBool(m2_init["output_status_4"]));
	ui.checkBoxOutputFive->setChecked(stringToBool(m2_init["output_status_5"]));
	ui.checkBoxOutputSix->setChecked(stringToBool(m2_init["output_status_6"]));

	// index 2 input setting
	// name input read
	ui.checkBoxInitialInputOne->setText(QString::fromStdString(m1_init["input_name_1"]));
	ui.checkBoxInitialInputTwo->setText(QString::fromStdString(m1_init["input_name_2"]));
	ui.checkBoxInitialInputThree->setText(QString::fromStdString(m1_init["input_name_3"]));
	ui.checkBoxInitialInputFour->setText(QString::fromStdString(m1_init["input_name_4"]));
	ui.checkBoxInitialInputFive->setText(QString::fromStdString(m1_init["input_name_5"]));
	ui.checkBoxInitialInputSix->setText(QString::fromStdString(m1_init["input_name_6"]));

	// status input read
	ui.checkBoxInitialInputOne->setChecked(stringToBool(m2_init["input_status_1"]));
	ui.checkBoxInitialInputTwo->setChecked(stringToBool(m2_init["input_status_2"]));
	ui.checkBoxInitialInputThree->setChecked(stringToBool(m2_init["input_status_3"]));
	ui.checkBoxInitialInputFour->setChecked(stringToBool(m2_init["input_status_4"]));
	ui.checkBoxInitialInputFive->setChecked(stringToBool(m2_init["input_status_5"]));
	ui.checkBoxInitialInputSix->setChecked(stringToBool(m2_init["input_status_6"]));

	// index 3 enet setting
	ui.lineEditLocalIP->setText(QString::fromStdString(m3_init["localIP"]));
	ui.lineEditServerIP->setText(QString::fromStdString(m3_init["serverIP"]));
	ui.lineEditPort->setText(QString::fromStdString(m3_init["port"]));
}

bool IOService::stringToBool(std::string s) {
	// setchecked()只有勾选和非勾选两种状态
	// setcheckstate() 三态 Qt::Checked Qt::PartiallyChecked  Qt::Unchecked
	return (s == "2" ? 1 : 0);
}

IOService::~IOService() {
	if (timerForReadIn.isActive() == true)
		timerForReadIn.stop();
}
