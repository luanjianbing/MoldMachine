#include "CounterSetting.h"

CounterSetting::CounterSetting(QWidget *parent)
	: QWidget(parent) 
{
	this->setWindowFlags(Qt::Window | Qt::WindowTitleHint);
	this->setFixedSize(361, 350);
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);

	CounterInitParam();

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

void CounterSetting::buttonSureClicked() {
	// save counter_1, counter_2 to mysql
	counterParam.CounterParamSaving(QString::number(counter_1).toStdString().c_str(), 
		QString::number(counter_2).toStdString().c_str());
	// save counter_1, counter_2 to xml
	counterParam.xml_CounterParamSaving(QString::number(counter_1).toStdString().c_str(),
		QString::number(counter_2).toStdString().c_str());
	this->close();
}

void CounterSetting::buttonSwitchClicked() {
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

void CounterSetting::buttonClearClicked() {
	if (target) {
		counter_2 = 0;
		ui.labelDisNumTwo->setText(QString::number(counter_2));
	}
	else
	{
		counter_1 = 0;
		ui.labelDisNumOne->setText(QString::number(counter_1));
	}
}

void CounterSetting::buttonZeroClicked() {
	if (target) {
		cnt_2.push(0);
		updateRes_2();
	}
	else
	{
		cnt_1.push(0);
		updateRes_1();
	}
}

void CounterSetting::buttonOneClicked() {
	if (target) {
		cnt_2.push(1);
		updateRes_2();
	}
	else
	{
		cnt_1.push(1);
		updateRes_1();
	}
}

void CounterSetting::buttonTwoClicked() {
	if (target) {
		cnt_2.push(2);
		updateRes_2();
	}
	else
	{
		cnt_1.push(2);
		updateRes_1();
	}
}

void CounterSetting::buttonThreeClicked() {
	if (target) {
		cnt_2.push(3);
		updateRes_2();
	}
	else
	{
		cnt_1.push(3);
		updateRes_1();
	}
}

void CounterSetting::buttonFourClicked() {
	if (target) {
		cnt_2.push(4);
		updateRes_2();
	}
	else
	{
		cnt_1.push(4);
		updateRes_1();
	}
}

void CounterSetting::buttonFiveClicked() {
	if (target) {
		cnt_2.push(5);
		updateRes_2();
	}
	else
	{
		cnt_1.push(5);
		updateRes_1();
	}
}

void CounterSetting::buttonSixClicked() {
	if (target) {
		cnt_2.push(6);
		updateRes_2();
	}
	else
	{
		cnt_1.push(6);
		updateRes_1();
	}
}

void CounterSetting::buttonSevenClicked() {
	if (target) {
		cnt_2.push(7);
		updateRes_2();
	}
	else
	{
		cnt_1.push(7);
		updateRes_1();
	}
}

void CounterSetting::buttonEightClicked() {
	if (target) {
		cnt_2.push(8);
		updateRes_2();
	}
	else
	{
		cnt_1.push(8);
		updateRes_1();
	}
}

void CounterSetting::buttonNineClicked() {
	if (target) {
		cnt_2.push(9);
		updateRes_2();
	}
	else
	{
		cnt_1.push(9);
		updateRes_1();
	}
}

void CounterSetting::updateRes_1() {
	counter_1 = counter_1 * 10 + cnt_1.front();
	cnt_1.pop();
	ui.labelDisNumOne->setText(QString::number(counter_1));
}

void CounterSetting::updateRes_2() {
	counter_2 = counter_2 * 10 + cnt_2.front();
	cnt_2.pop();
	ui.labelDisNumTwo->setText(QString::number(counter_2));
}

void CounterSetting::CounterInitParam() {
	std::string counter1_val;
	std::string counter2_val;

	counterParam.CounterParamInit(counter1_val, counter2_val);

	ui.labelDisNumOne->setText(QString::fromStdString(counter1_val));
	ui.labelDisNumTwo->setText(QString::fromStdString(counter2_val));

	counter_1 = atoi(counter1_val.c_str());
	counter_2 = atoi(counter2_val.c_str());
}

CounterSetting::~CounterSetting() {

}