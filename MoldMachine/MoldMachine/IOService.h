#pragma once

#include <QTimer>
#include <QCheckBox>

#include "ui_IOService.h"
#include "ParameterInit.h"
#include "Adam6060.h"

class IOService : public QWidget
{
	Q_OBJECT

	public:
		IOService(QWidget *parent = Q_NULLPTR);
		~IOService();

	private:
		Ui::IOServiceClass ui;

		// 初始化信息参数
		ParamInit ioServiceParam;
		std::map<std::string, std::string> m1_init;		// name
		std::map<std::string, std::string> m2_init;		// status
		std::map<std::string, std::string> m3_init;		// addr
		void IoServiceInitParam();

		bool stringToBool(std::string s);

		// 用来保存哪些被修改了
		std::map<std::string, std::string> map_modify_1;
		std::map<std::string, std::string> map_modify_2;
		std::map<std::string, std::string> map_modify_3;

		Adam6060 adam;
		bool adamInitRes = 0;

		bool onIoTest = 0;

		QTimer timerForReadIn;

	private slots:
		void buttonApplyClicked();

		// name modify
		void nameInputOneModify();
		void nameInputTwoModify();
		void nameInputThreeModify();
		void nameInputFourModify();
		void nameInputFiveModify();
		void nameInputSixModify();

		void nameOutputOneModify();
		void nameOutputTwoModify();
		void nameOutputThreeModify();
		void nameOutputFourModify();
		void nameOutputFiveModify();
		void nameOutputSixModify();

		// enet modify
		void localIPModify();
		void serverIPModify();
		void portModify();

		// status modify

		void statusInitialInputOneModify(int state);
		void statusInitialInputTwoModify(int state);
		void statusInitialInputThreeModify(int state);
		void statusInitialInputFourModify(int state);
		void statusInitialInputFiveModify(int state);
		void statusInitialInputSixModify(int state);

		// tab widget
		void onTabIndexChanged(int);

		//// io test in
		void onReadInStatus();
		//void oncheckBoxOutputOneChanged(int status);
		//void oncheckBoxOutputTwoChanged(int status);
		//void oncheckBoxOutputThreeChanged(int status);
		//void oncheckBoxOutputFourChanged(int status);
		//void oncheckBoxOutputFiveChanged(int status);
		//void oncheckBoxOutputSixChanged(int status);
		// io test out
		void oncheckBoxOutputOneChanged(int status);
		void oncheckBoxOutputTwoChanged(int status);
		void oncheckBoxOutputThreeChanged(int status);
		void oncheckBoxOutputFourChanged(int status);
		void oncheckBoxOutputFiveChanged(int status);
		void oncheckBoxOutputSixChanged(int status);
};
