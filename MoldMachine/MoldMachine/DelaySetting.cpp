#include "DelaySetting.h"

DelaySetting::DelaySetting(QWidget *parent)
	: QWidget(parent)
{
	this->setWindowFlags(Qt::Window | Qt::WindowTitleHint);
	this->setFixedSize(361, 350);
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);

	DelayInitParam();

	connect(ui.buttonSure, SIGNAL(clicked()), this, SLOT(buttonSureClicked()));

	connect(ui.buttonSwitch, SIGNAL(clicked()), this, SLOT(buttonSwitchClicked()));
	connect(ui.buttonClear, SIGNAL(clicked()), this, SLOT(buttonClearClicked()));

	// 0~9
	connect(ui.buttonZero, SIGNAL(clicked()), this, SLOT(buttonZeroClicked()));
	connect(ui.buttonOne, SIGNAL(clicked()), this, SLOT(buttonOneClicked()));
	connect(ui.buttonTwo, SIGNAL(clicked()), this, SLOT(buttonTwoClicked()));
	connect(ui.buttonThree, SIGNAL(clicked()), this, SLOT(buttonThreeClicked()));
	connect(ui.buttonFour, SIGNAL(clicked()), this, SLOT(buttonFourClicked()));
	connect(ui.buttonFive, SIGNAL(clicked()), this, SLOT(buttonFiveClicked()));
	connect(ui.buttonSix, SIGNAL(clicked()), this, SLOT(buttonSixClicked()));
	connect(ui.buttonSeven, SIGNAL(clicked()), this, SLOT(buttonSevenClicked()));
	connect(ui.buttonEight, SIGNAL(clicked()), this, SLOT(buttonEightClicked()));
	connect(ui.buttonNine, SIGNAL(clicked()), this, SLOT(buttonNineClicked()));

	ui.labelDisNumOne->setFrameStyle(3);
}

void DelaySetting::buttonSureClicked() {
	// save delay_1, delay_2 to mysql
	delayParam.DelayParamSaving(QString::number(delay_1).toStdString().c_str(),
		QString::number(delay_2).toStdString().c_str());
	// save delay_1, delay_2 to xml
	delayParam.xml_DelayParamSaving(QString::number(delay_1).toStdString().c_str(),
		QString::number(delay_2).toStdString().c_str());
	this->close();
}

void DelaySetting::buttonSwitchClicked() {
	target = !target;
	if (target) {
		ui.labelDisNumOne->setFrameStyle(2);
		ui.labelDisNumTwo->setFrameStyle(3);
	}
	else
	{
		ui.labelDisNumOne->setFrameStyle(3);
		ui.labelDisNumTwo->setFrameStyle(2);
	}
}


void DelaySetting::buttonClearClicked() {
	if (target) {
		delay_2 = 0;
		ui.labelDisNumTwo->setText(QString::number(delay_2));
	}
	else
	{
		delay_1 = 0;
		ui.labelDisNumOne->setText(QString::number(delay_1));
	}
}

void DelaySetting::buttonZeroClicked() {
	if (target) {
		dely_2.push(0);
		updateRes_2();
	}
	else
	{
		dely_1.push(0);
		updateRes_1();
	}
}

void DelaySetting::buttonOneClicked() {
	if (target) {
		dely_2.push(1);
		updateRes_2();
	}
	else
	{
		dely_1.push(1);
		updateRes_1();
	}
}

void DelaySetting::buttonTwoClicked() {
	if (target) {
		dely_2.push(2);
		updateRes_2();
	}
	else
	{
		dely_1.push(2);
		updateRes_1();
	}
}

void DelaySetting::buttonThreeClicked() {
	if (target) {
		dely_2.push(3);
		updateRes_2();
	}
	else
	{
		dely_1.push(3);
		updateRes_1();
	}
}

void DelaySetting::buttonFourClicked() {
	if (target) {
		dely_2.push(4);
		updateRes_2();
	}
	else
	{
		dely_1.push(4);
		updateRes_1();
	}
}

void DelaySetting::buttonFiveClicked() {
	if (target) {
		dely_2.push(5);
		updateRes_2();
	}
	else
	{
		dely_1.push(5);
		updateRes_1();
	}
}

void DelaySetting::buttonSixClicked() {
	if (target) {
		dely_2.push(6);
		updateRes_2();
	}
	else
	{
		dely_1.push(6);
		updateRes_1();
	}
}

void DelaySetting::buttonSevenClicked() {
	if (target) {
		dely_2.push(7);
		updateRes_2();
	}
	else
	{
		dely_1.push(7);
		updateRes_1();
	}
}

void DelaySetting::buttonEightClicked() {
	if (target) {
		dely_2.push(8);
		updateRes_2();
	}
	else
	{
		dely_1.push(8);
		updateRes_1();
	}
}

void DelaySetting::buttonNineClicked() {
	if (target) {
		dely_2.push(9);
		updateRes_2();
	}
	else
	{
		dely_1.push(9);
		updateRes_1();
	}
}

void DelaySetting::updateRes_1() {
	delay_1 = delay_1 * 10 + dely_1.front();
	dely_1.pop();
	ui.labelDisNumOne->setText(QString::number(delay_1));
}

void DelaySetting::updateRes_2() {
	delay_2 = delay_2 * 10 + dely_2.front();
	dely_2.pop();
	ui.labelDisNumTwo->setText(QString::number(delay_2));
}

void DelaySetting::DelayInitParam() {
	std::string delay1_val;
	std::string delay2_val;

	delayParam.DelayParamInit(delay1_val, delay2_val);

	ui.labelDisNumOne->setText(QString::fromStdString(delay1_val));
	ui.labelDisNumTwo->setText(QString::fromStdString(delay2_val));

	delay_1 = atoi(delay1_val.c_str());
	delay_2 = atoi(delay2_val.c_str());
}

DelaySetting::~DelaySetting() {

}