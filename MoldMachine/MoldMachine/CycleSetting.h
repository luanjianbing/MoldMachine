#pragma once

#include <QWidget>
#include "ui_CycleSetting.h"
#include "ParameterInit.h"

#include <queue>

class CycleSetting : public QWidget
{
	Q_OBJECT

public:
	CycleSetting(QWidget *parent = Q_NULLPTR);
	~CycleSetting();

	int cycleTimes;		// times for cycle

private:
	Ui::CycleClass ui;

	ParamInit cycleTimesParam;
	void CycleTimesInitParam();

	std::queue<int> numSaving;
	int res = 0;
	void updateRes();

private slots:
	void buttonSureClicked();
	void buttonClearClicked();

	// 0~9
	void buttonZeroClicked();
	void buttonOneClicked();
	void buttonTwoClicked();
	void buttonThreeClicked();
	void buttonFourClicked();
	void buttonFiveClicked();
	void buttonSixClicked();
	void buttonSevenClicked();
	void buttonEightClicked();
	void buttonNineClicked();
};
