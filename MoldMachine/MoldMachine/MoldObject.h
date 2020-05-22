#pragma once

#include <QWidget>
#include <iostream>
#include <map>
#include "ui_MoldObjects.h"
#include "ParameterInit.h"

class MoldObject : public QWidget
{
	Q_OBJECT

	public:
		MoldObject(QWidget *parent = Q_NULLPTR);
		~MoldObject();

	private:
		Ui::MoldObjectClass ui;	

		void moldObjParamInit();
		int curMoldId = 1;

	private slots:
		void buttonApplyClicked();
		void onComboxChanged(int);

	signals:
		void sendMoldId(int);
};