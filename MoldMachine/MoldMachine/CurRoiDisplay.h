#pragma once

#include <QWidget>
#include <QMessageBox>
#include <QTimer>

#include <vector>
#include <iostream>

#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>

#include "ui_CurRoiDisPlay.h"

class CurRoiDisplay : public QWidget
{
	Q_OBJECT

	public:
		CurRoiDisplay(std::vector<std::vector<std::string>> blockstr, QWidget *parent = Q_NULLPTR);
		~CurRoiDisplay();

		void displayRoi(QString addr, float ratio_x, float ratio_y, int flagAuto);

	private:
		Ui::DisplayBolckClass ui;

		std::vector<std::vector<int>> block;

		QTimer timerForRoiShow;
		int timerCnt = 1500 * 4;	// 30 * 4s

	private slots:
		void buttonSureClicked();

		void handleTimeOut();
signals:

};