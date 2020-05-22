#include "CurRoiDisplay.h"


CurRoiDisplay::CurRoiDisplay(std::vector<std::vector<std::string>> blockstr, QWidget *parent)
	: QWidget(parent)
{
	block.resize(blockstr.size());
	for (int i = 0; i < blockstr.size(); i++) {
		for (int j = 1; j < blockstr[i].size(); j++) {
			block[i].push_back(atoi(blockstr[i][j].c_str()));
		}
	}

	this->setFixedSize(600, 500);
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);

	// buttonApply->clicked
	connect(ui.buttonSure, SIGNAL(clicked()), this, SLOT(buttonSureClicked()));
}

void CurRoiDisplay::buttonSureClicked() {
	this->close();
}

void CurRoiDisplay::displayRoi(QString addr, float ratio_x, float ratio_y, int flagAuto) {
	cv::Mat toShowImg = cv::imread(addr.toStdString());
	int trueX = 0, trueY = 0;
	if (flagAuto == -1) {
		trueX = (int)(ratio_x * toShowImg.cols);
		trueY = (int)(ratio_y * toShowImg.rows);
	}
	else {
		trueX = (int)(block[flagAuto][0] + block[flagAuto][2] / 2);
		trueY = (int)(block[flagAuto][1] + block[flagAuto][3] / 2);
	}

	int minDist = INT_MAX;
	int minDistIdx = INT_MAX;

	for (int i = 0; i < block.size(); i++) {
		int dist = sqrt(pow((block[i][0] - trueX), 2) + pow((block[i][1] - trueY), 2));
		if (dist < minDist && (trueX >= block[i][0]) && (trueY >= block[i][1])
			&&((block[i][2] + block[i][0]) >= trueX) && ((block[i][3] + block[i][1]) >= trueY)) {
			minDistIdx = i; 
			minDist = dist;
		}
	}

	if (minDistIdx != INT_MAX) {
		cv::Mat resImg;
		cv::cvtColor(toShowImg.clone(), resImg, cv::COLOR_BGR2RGB);
		cv::Mat cut = resImg(cv::Rect(block[minDistIdx][0], block[minDistIdx][1], block[minDistIdx][2], block[minDistIdx][3]));
		QImage cut_img = QImage(cut.data, cut.cols, cut.rows, cut.step, QImage::Format_RGB888);
		ui.labelDis->setPixmap(QPixmap::fromImage(cut_img).scaled(562, 421, Qt::KeepAspectRatio));
		this->show();
	}
	else {
		QMessageBox::about(this, "Tips", "Clicked Out Of Range, Retry...");
	}

	if (timerForRoiShow.isActive() == false) {
		timerForRoiShow.start(20);
		connect(&timerForRoiShow, SIGNAL(timeout()), this, SLOT(handleTimeOut()));
	}
}

void CurRoiDisplay::handleTimeOut() {
	timerCnt--;
	if (timerCnt == 0) {
		timerForRoiShow.stop();
		this->close();
	}
}

CurRoiDisplay::~CurRoiDisplay() {
	if (timerForRoiShow.isActive() == true) {
		timerForRoiShow.stop();
	}
}