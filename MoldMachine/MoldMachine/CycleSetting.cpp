#include "CycleSetting.h"
#include <QDebug>

CycleSetting::CycleSetting(QWidget *parent)
	: QWidget(parent)
{
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);

	CycleTimesInitParam();

	connect(ui.buttonSure, SIGNAL(clicked()), this, SLOT(buttonSureClicked()));
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
}

void CycleSetting::buttonSureClicked() {
	// save cycle times to mysql
	cycleTimesParam.CycleTimesParamSaving(QString::number(res).toStdString().c_str());
	//cycleTimesParam.xml_CycleTimesParamSaving(QString::number(res).toStdString().c_str());
	this->close();
}

void CycleSetting::buttonClearClicked() {
	res = 0;
	ui.labelDisNum->setText(QString::number(res));
}

void CycleSetting::buttonZeroClicked() {
	numSaving.push(0);
	updateRes();
}

void CycleSetting::buttonOneClicked() {
	numSaving.push(1);
	updateRes();
}

void CycleSetting::buttonTwoClicked() {
	numSaving.push(2);
	updateRes();
}

void CycleSetting::buttonThreeClicked() {
	numSaving.push(3);
	updateRes();
}

void CycleSetting::buttonFourClicked() {
	numSaving.push(4);
	updateRes();
}

void CycleSetting::buttonFiveClicked() {
	numSaving.push(5);
	updateRes();
}

void CycleSetting::buttonSixClicked() {
	numSaving.push(6);
	updateRes();
}

void CycleSetting::buttonSevenClicked() {
	numSaving.push(7);
	updateRes();
}

void CycleSetting::buttonEightClicked() {
	numSaving.push(8);
	updateRes();
}

void CycleSetting::buttonNineClicked() {
	numSaving.push(9);
	updateRes();
}

void CycleSetting::updateRes() {
	res = res * 10 + numSaving.front();
	numSaving.pop();
	ui.labelDisNum->setText(QString::number(res));
}

void CycleSetting::CycleTimesInitParam() {
	std::string times_value;
	cycleTimesParam.CycleTimesParamInit(times_value);
	//cycleTimesParam.xml_CycleTimesParamInit(times_value);
	ui.labelDisNum->setText(QString::fromStdString(times_value));
	
	res = atoi(times_value.c_str());	// 将结果赋值给res
}

CycleSetting::~CycleSetting() {

}