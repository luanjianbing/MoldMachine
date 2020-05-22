#pragma once

#include <QWidget>
#include <queue>
#include "ui_Counters.h"
#include "ParameterInit.h"

class CounterSetting : public QWidget
{
	Q_OBJECT

	public:
		CounterSetting(QWidget *parent = Q_NULLPTR);
		~CounterSetting();

	private:
		Ui::CounterClass ui;

		ParamInit counterParam;
		void CounterInitParam();

		bool target = 0;

		std::queue<int> cnt_1;
		std::queue<int> cnt_2;
		int counter_1 = 0;
		int counter_2 = 0;

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
