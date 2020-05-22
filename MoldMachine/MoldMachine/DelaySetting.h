#pragma once

#include <QWidget>
#include <queue>
#include "ui_DelaySetting.h"
#include "ParameterInit.h"

class DelaySetting : public QWidget
{
	Q_OBJECT

	public:
		DelaySetting(QWidget *parent = Q_NULLPTR);
		~DelaySetting();

	private:
		Ui::DelaySettingClass ui;

		ParamInit delayParam;
		void DelayInitParam();

		bool target = 0;

		std::queue<int> dely_1;
		std::queue<int> dely_2;
		int delay_1 = 0;
		int delay_2 = 0;

		void updateRes_1();
		void updateRes_2();

	private slots:
		void buttonSureClicked();
		void buttonSwitchClicked();
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

	signals:

};
