#include "ImageSetting.h"
#include <QDebug>

bool drawRect = false;

ImageSetting::ImageSetting(int curMoldId, QWidget *parent)
	: curMoldObjId(curMoldId),  QMainWindow(parent)
{
	this->setFixedSize(1300, 860);
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);
	ui.labelPart->setFixedSize(labelPartFixWidth, labelPartFixHeight);
	ui.labelAll->setFixedSize(labelAllFixWidth, labelAllFixHeight);
	//ui.labelPart->setFixedWidth(labelPartFixWidth);
	//ui.labelAll->setFixedWidth(labelAllFixHeight);

	imageInitParam();

	// 为了解决画landmark时界面比例问题，强行规定大致比例
	//ui.splitter->setStretchFactor(0, 6.25);
	//ui.splitter->setStretchFactor(1, 3.75);

	// 创建mycam，此时已经在获取数据
	//mycam = new Camera();

	// buttonSure->clicked
	connect(ui.buttonSure, SIGNAL(clicked()), this, SLOT(buttonSureClicked()));

	// combo box
	ui.comboBox->setCurrentIndex(0);	// 预先设置一个在范围之外的index，默认default
	connect(ui.comboBox, SIGNAL(currentIndexChanged(int)), this, SLOT(comboxChanged(int)));

	// image shot
	connect(ui.actionImage, SIGNAL(triggered()), this, SLOT(imageShot()));

	// image live
	connect(ui.actionLive, SIGNAL(triggered()), this, SLOT(imageLive()));

	// buttonsave
	connect(ui.actionSave, SIGNAL(triggered()), this, SLOT(imageSave()));

	// landmark delete
	connect(ui.actionDelete, SIGNAL(triggered()), this, SLOT(deleteLandMark()));

	// draw rect
	ui.labelPart->installEventFilter(this);
}

/**********************************************************************************************
***	函数名称：void imageLive()																***
***	功能描述：实时图像采集，包括打开一个20ms间隔的定时器，通过调用imageShot()函数			***
***			  不断获取图像，达到实时显示													***
***																							***
***********************************************************************************************/
void ImageSetting::imageLive() {
	if (timerForCamLive.isActive() == false) {
		timerForCamLive.start(20);
		connect(&timerForCamLive, SIGNAL(timeout()), this, SLOT(imageShot()));
		
		// live情况下失能控件
		ui.comboBox->setDisabled(true);			// combobox disabled
		ui.actionImage->setDisabled(true);		// actionimage disabled
		ui.actionDelete->setDisabled(true);		// actiondelete disabled

		// 标记好landmark后，live情况下需要将combobox设置为default
		ui.comboBox->setCurrentIndex(0);
	}
	else
	{
		timerForCamLive.stop();
		disconnect(&timerForCamLive, SIGNAL(timeout()), this, SLOT(imageShot()));

		// live情况下使能控件
		ui.comboBox->setDisabled(false);		// combobox enabled
		ui.actionImage->setDisabled(false);		// actionimage enabled
		ui.actionDelete->setDisabled(false);	// actiondelete enabled
	}
}

/**********************************************************************************************
***	函数名称：void imageShot()																***
***	功能描述：获取一张图像，将得到的图像mat送到landMarkRun()函数中进行坐标转换及处理，		***
***			  得到处理后的结果res，进行显示													***
***																							***
***********************************************************************************************/
void ImageSetting::imageShot() {
	cv::Mat mat = clonePic();
	cv::Mat res = landMarkRun(mat);

	QImage img_part(res.data, res.cols, res.rows, res.step, QImage::Format_RGB888);
	QImage img_all(res.data, res.cols, res.rows, res.step, QImage::Format_RGB888);

	// 部分图
	ui.labelPart->setPixmap(QPixmap::fromImage(img_part).scaled(ui.labelPart->width(), ui.labelPart->height(), Qt::IgnoreAspectRatio));
	// 全部图
	ui.labelAll->setPixmap(QPixmap::fromImage(img_all).scaled(labelAllFixWidth, labelAllFixHeight, Qt::IgnoreAspectRatio));
}

/**********************************************************************************************
***	函数名称：cv::Mat landMarkRun(cv::Mat mat)												***
***	功能描述：将手动在label上画方框得到的坐标转换成实际获取到的图像上的坐标，				***
***			  在原图mat上通过矩形画出对应区域并返回											***
***	(TODO)	  将图像mat和转换后的坐标border传送给ImageProcessing进行相关处理				***
***********************************************************************************************/
cv::Mat ImageSetting::landMarkRun(cv::Mat mat) {

	for (int i = 0; i < landMark.size(); i++) {
		switch (landMark[i][5])		//	shapeid
		{
			case 0:		// 矩形
			{
				cv::rectangle(mat, cv::Rect(landMark[i][0], landMark[i][1],
					landMark[i][2], landMark[i][3]), CvScalar(0, 0, 255), 8, cv::LINE_8, 0);
				break;
			}
			case 1:		// 圆形
			{
				int lAxis = landMark[i][2] / 2;
				int sAxis = landMark[i][3] / 2;
				int cX = landMark[i][0] + lAxis;
				int cY = landMark[i][1] + sAxis;

				cv::ellipse(mat, cv::Point(cX, cY), cv::Size(lAxis, sAxis), 0, 0, 360, CvScalar(0, 0, 255), 8, cv::LINE_8);
				break;
			}
			case 2:		// 三角形
			{
				cv::Point points[1][3];
				points[0][0] = cv::Point(landMark[i][0], landMark[i][1] + landMark[i][3]);
				points[0][1] = cv::Point(landMark[i][0] + landMark[i][2] / 2, landMark[i][1]);
				points[0][2] = cv::Point(landMark[i][0] + landMark[i][2], landMark[i][1] + landMark[i][3]);
				const cv::Point *pts[1] = { points[0] };
				int npt[] = { 3 };
				cv::polylines(mat, pts, npt, 1, true, cv::Scalar(0, 0, 255), 8);
				break;
			}
			case 3:		// 菱形
			{
				cv::Point points[1][4];
				points[0][0] = cv::Point(landMark[i][0], landMark[i][1] + landMark[i][3] / 2);
				points[0][1] = cv::Point(landMark[i][0] + landMark[i][2] / 2, landMark[i][1]);
				points[0][2] = cv::Point(landMark[i][0] + landMark[i][2], landMark[i][1] + landMark[i][3] / 2);
				points[0][3] = cv::Point(landMark[i][0] + landMark[i][2] / 2, landMark[i][1] + landMark[i][3]);
				const cv::Point *pts[1] = { points[0] };
				int npt[] = { 4 };
				cv::polylines(mat, pts, npt, 1, true, cv::Scalar(0, 0, 255), 8);
				break;
			}
			default:
				break;
			}
	}
	return mat;
}

/**********************************************************************************************
***	函数名称：IplImage *clonePic()															***
***	功能描述：从CameraDriver中的Camera类创建的对象mycam得到的图像clone过来，				***
***			  并按scale缩放后返回该图像														***
***	(TODO)	  在创建mycam对象时，获取图像的子线程在mycam->stop中并没有停止					***
***********************************************************************************************/
cv::Mat ImageSetting::clonePic() {
	cv::Mat dst;

	//mycam->matImg_1.copyTo(dst);
	//cv::cvtColor(dst, dst, cv::COLOR_BGR2RGB);
	dst = cv::imread("./Resources/image/before_ejection.png");
	cv::cvtColor(dst, dst, cv::COLOR_BGR2RGB);

	picSize_x = dst.cols;		// 获得图片的大小
	picSize_y = dst.rows;
	curSize_w = ratio_x * picSize_x;	// 获得图片中part框的大小
	curSize_h = ratio_y * picSize_y;

	return dst;
}

/**********************************************************************************************
***	函数名称：void comboxChanged(int index)													***
***	功能描述：进入绘框index时，clone one pic给imgForDraw供在画图事件中画图					***
***																							***
***																							***
***********************************************************************************************/
void ImageSetting::comboxChanged(int index) {
	qDebug() << "combox index has changed";
	switch (index)
	{
		case 0:		// 默认
		{
			curBlockId = 0;
			drawRect = false;		// false表明处在鼠标控制图片移动状态
			break;
		}
		case 1:		// 比较卡尺工具
		{
			curBlockId = 1;
			InterfaceComparaCaliper();
			drawRect = true;		// ture表明处在画框状态
			ui.labelPart->clear();		// 进入绘框时可以显示框
			imgForDraw_mat = clonePic();
			break;
		}
		case 2:		// 卡尺工具
		{
			curBlockId = 2;
			InterfaceCaliper();
			break;
		}
		case 3:		// 边缘标记工具
		{
			curBlockId = 3;
			InterfaceEdgeMarker();
			break;
		}
		case 4:		// 计数器工具
		{
			curBlockId = 4;
			InterfaceCounter();
			break;
		}
		case 5:		// 特征分析工具
		{
			curBlockId = 5;
			break;
		}
		case 6:		// 图像搜索工具
		{
			curBlockId = 6;
			break;
		}
		case 7:		// 在/不在窗口
		{
			curBlockId = 7;
			InterfaceOnOrOff();
			drawRect = true;		// ture表明处在画框状态
			ui.labelPart->clear();		// 进入绘框时可以显示框
			imgForDraw_mat = clonePic();
			break;	
		}
		case 8:		// 校正窗口
		{
			curBlockId = 8;
			break;
		}
		case 9:		// 边线查找窗口
		{
			curBlockId = 9;
			break;
		}
		case 10:		// 亮度检测窗口
		{
			curBlockId = 10;
			break;
		}
		case 11:		// 一致性窗口
		{
			curBlockId = 11;
			break;
		}
		case 12: {		// 残留物检测
			curBlockId = 12;
			InterfaceResidueDetection();
			drawRect = true;		// ture表明处在画框状态
			ui.labelPart->clear();		// 进入绘框时可以显示框
			imgForDraw_mat = clonePic();
			break;
		}
		default:
		{
			break;
		}
	}
}

void ImageSetting::InterfaceResidueDetection() {
	// 残留物检测界面参数设定
	// (TODO)
}

void ImageSetting::InterfaceOnOrOff() {
	ui.tabWidget->clear();
	QWidget *tabOnOrOff = new QWidget();
	tabOnOrOff->setObjectName(QString::fromUtf8("tabOnOrOff"));

	QGridLayout *gridLayoutOnOrOff = new QGridLayout(tabOnOrOff);
	gridLayoutOnOrOff->setObjectName(QString::fromUtf8("gridLayoutOnOrOff"));

	QLabel *labelName = new QLabel(tabOnOrOff);
	labelName->setObjectName(QString::fromUtf8("labelName"));
	labelName->setText("名称");
	QLineEdit *lineEditName = new QLineEdit(tabOnOrOff);
	lineEditName->setObjectName(QString::fromUtf8("lineEditName"));
	lineEditName->setText("7-在/不在窗口");
	lineEditName->setEnabled(false);

	QLabel *labelStopVol = new QLabel(tabOnOrOff);
	labelStopVol->setObjectName(QString::fromUtf8("labelStopVol"));
	labelStopVol->setText("停止量");
	QLineEdit *lineEditStopVol = new QLineEdit(tabOnOrOff);
	lineEditStopVol->setObjectName(QString::fromUtf8("lineEditStopVol"));
	lineEditStopVol->setText("2812");

	QLabel *labelLastStopVol = new QLabel(tabOnOrOff);
	labelLastStopVol->setObjectName(QString::fromUtf8("labelLastStopVol"));
	labelLastStopVol->setText("上一次停止量记录");
	QLineEdit *lineEditLastStopVol = new QLineEdit(tabOnOrOff);
	lineEditLastStopVol->setObjectName(QString::fromUtf8("lineEditLastStopVol"));
	lineEditLastStopVol->setText("0");

	QLabel *labelThresHold = new QLabel(tabOnOrOff);
	labelThresHold->setObjectName(QString::fromUtf8("labelThresHold"));
	labelThresHold->setText("差分阈值");
	QLineEdit *lineEditThresHold = new QLineEdit(tabOnOrOff);
	lineEditThresHold->setObjectName(QString::fromUtf8("lineEditThresHold"));
	lineEditThresHold->setText("20");

	gridLayoutOnOrOff->addWidget(labelStopVol, 0, 0, 1, 1);
	gridLayoutOnOrOff->addWidget(lineEditStopVol, 0, 1, 1, 1);

	gridLayoutOnOrOff->addWidget(labelLastStopVol, 1, 0, 1, 1);
	gridLayoutOnOrOff->addWidget(lineEditLastStopVol, 2, 0, 1, 1);

	gridLayoutOnOrOff->addWidget(labelThresHold, 1, 1, 1, 1);
	gridLayoutOnOrOff->addWidget(lineEditThresHold, 2, 1, 1, 1);

	gridLayoutOnOrOff->addWidget(labelName, 3, 0, 1, 1);
	gridLayoutOnOrOff->addWidget(lineEditName, 4, 0, 1, 1);

	ui.tabWidget->addTab(tabOnOrOff, "在/缺 设置");

	// (TODO)
	QWidget *tabShape = new QWidget();
	tabShape->setObjectName(QString::fromUtf8("tabShape"));

	QGridLayout *gridLayoutShape = new QGridLayout(tabShape);
	gridLayoutShape->setObjectName(QString::fromUtf8("gridLayoutShape"));

	QGroupBox *groupBoxShape = new QGroupBox(tabShape);
	groupBoxShape->setObjectName(QString::fromUtf8("groupBoxShape"));
	groupBoxShape->setTitle("请选择形状");

	QGridLayout *gridLayoutBoxShape = new QGridLayout(groupBoxShape);
	gridLayoutBoxShape->setObjectName(QString::fromUtf8("gridLayoutBoxShape"));

	QRadioButton *radioButtonRect = new QRadioButton();		// 矩形
	radioButtonRect->setLayoutDirection(Qt::RightToLeft);
	radioButtonRect->setObjectName(QString::fromUtf8("radioButtonRect"));
	radioButtonRect->setChecked(1);
	QLabel *labelRect = new QLabel(tabShape);
	labelRect->setObjectName(QString::fromUtf8("labelRect"));
	QPixmap pixRect;
	pixRect.load("./Resources/ico/rectangle.png");
	labelRect->setPixmap(pixRect);
	
	QRadioButton *radioButtonCircle = new QRadioButton();	// 圆形
	radioButtonCircle->setLayoutDirection(Qt::RightToLeft);
	radioButtonCircle->setObjectName(QString::fromUtf8("radioButtonCircle"));
	QLabel *labelCircle = new QLabel(tabShape);
	labelCircle->setObjectName(QString::fromUtf8("labelCircle"));
	QPixmap pixCircle;
	pixCircle.load("./Resources/ico/circle.png");
	labelCircle->setPixmap(pixCircle);

	QRadioButton *radioButtonTriang = new QRadioButton();	// 三角
	radioButtonTriang->setLayoutDirection(Qt::RightToLeft);
	radioButtonTriang->setObjectName(QString::fromUtf8("radioButtonTriang"));
	QLabel *labelTriang = new QLabel(tabShape);
	labelTriang->setObjectName(QString::fromUtf8("labelTriang"));
	QPixmap pixTriang;
	pixTriang.load("./Resources/ico/triangle.png");
	labelTriang->setPixmap(pixTriang);

	QRadioButton *radioButtonDiamond = new QRadioButton();	// 菱形
	radioButtonDiamond->setLayoutDirection(Qt::RightToLeft);
	radioButtonDiamond->setObjectName(QString::fromUtf8("radioButtonDiamond"));
	QLabel *labelDiamond = new QLabel(tabShape);
	labelDiamond->setObjectName(QString::fromUtf8("labelDiamond"));
	QPixmap pixDiamond;
	pixDiamond.load("./Resources/ico/diamond.png");
	labelDiamond->setPixmap(pixDiamond);


	gridLayoutShape->addWidget(groupBoxShape, 0, 0, 1, 1);

	gridLayoutBoxShape->addWidget(radioButtonRect, 0, 0, 1, 1);
	gridLayoutBoxShape->addWidget(labelRect, 0, 1, 1, 1);

	gridLayoutBoxShape->addWidget(radioButtonCircle, 0, 2, 1, 1);
	gridLayoutBoxShape->addWidget(labelCircle, 0, 3, 1, 1);

	gridLayoutBoxShape->addWidget(radioButtonTriang, 1, 0, 1, 1);
	gridLayoutBoxShape->addWidget(labelTriang, 1, 1, 1, 1);

	gridLayoutBoxShape->addWidget(radioButtonDiamond, 1, 2, 1, 1);
	gridLayoutBoxShape->addWidget(labelDiamond, 1, 3, 1, 1);

	ui.tabWidget->addTab(tabShape, "形状");

	connect(radioButtonRect, SIGNAL(clicked()), this, SLOT(onShapeChosenRect()));
	connect(radioButtonCircle, SIGNAL(clicked()), this, SLOT(onShapeChosenCircle()));
	connect(radioButtonTriang, SIGNAL(clicked()), this, SLOT(onShapeChosenTriang()));
	connect(radioButtonDiamond, SIGNAL(clicked()), this, SLOT(onShapeChosenDiamond()));
}

void ImageSetting::InterfaceCounter() {
	ui.tabWidget->clear();
	QWidget *tabCounter = new QWidget();
	tabCounter->setObjectName(QString::fromUtf8("tabCounter"));

	QGridLayout *gridLayoutCounter = new QGridLayout(tabCounter);
	gridLayoutCounter->setObjectName(QString::fromUtf8("gridLayoutCounter"));

	QLabel *labelRecv = new QLabel(tabCounter);
	labelRecv->setObjectName(QString::fromUtf8("labelRecv"));
	labelRecv->setText("接受");
	QLineEdit *lineEditRecv = new QLineEdit(tabCounter);
	lineEditRecv->setObjectName(QString::fromUtf8("lineEditRecv"));
	lineEditRecv->setText("1");

	QLabel *labelMin = new QLabel(tabCounter);
	labelMin->setObjectName(QString::fromUtf8("labelMin"));
	labelMin->setText("最小值");
	QLineEdit *lineEditMin = new QLineEdit(tabCounter);
	lineEditMin->setObjectName(QString::fromUtf8("lineEditMin"));
	lineEditMin->setText("1");

	QLabel *labelMax = new QLabel(tabCounter);
	labelMax->setObjectName(QString::fromUtf8("labelMax"));
	labelMax->setText("最小值");
	QLineEdit *lineEditMax = new QLineEdit(tabCounter);
	lineEditMax->setObjectName(QString::fromUtf8("lineEditMax"));
	lineEditMax->setText("50000");

	QLabel *labelName = new QLabel(tabCounter);
	labelName->setObjectName(QString::fromUtf8("labelName"));
	labelName->setText("名称");
	QLineEdit *lineEditName = new QLineEdit(tabCounter);
	lineEditName->setObjectName(QString::fromUtf8("lineEditName"));
	lineEditName->setText("4-计数器");
	lineEditName->setEnabled(false);

	QTableWidget *tabDisRes = new QTableWidget(tabCounter);
	tabDisRes->verticalHeader()->setVisible(false);
	tabDisRes->horizontalHeader()->setVisible(false);
	tabDisRes->setColumnCount(2);
	tabDisRes->setRowCount(4);
	tabDisRes->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	tabDisRes->verticalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	tabDisRes->setEditTriggers(QAbstractItemView::NoEditTriggers);
	tabDisRes->setItem(0, 0, new QTableWidgetItem("计数"));
	tabDisRes->setItem(1, 0, new QTableWidgetItem("平均尺寸"));
	tabDisRes->setItem(2, 0, new QTableWidgetItem("最小值"));
	tabDisRes->setItem(3, 0, new QTableWidgetItem("最大值"));
	tabDisRes->setItem(0, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(1, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(2, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(3, 1, new QTableWidgetItem("0"));

	gridLayoutCounter->addWidget(tabDisRes, 0, 0, 1, 2);

	gridLayoutCounter->addWidget(labelRecv, 1, 0, 1, 1);
	gridLayoutCounter->addWidget(lineEditRecv, 2, 0, 1, 1);

	gridLayoutCounter->addWidget(labelMin, 3, 0, 1, 1);
	gridLayoutCounter->addWidget(lineEditMin, 4, 0, 1, 1);
	gridLayoutCounter->addWidget(labelMax, 3, 1, 1, 1);
	gridLayoutCounter->addWidget(lineEditMax, 4, 1, 1, 1);

	gridLayoutCounter->addWidget(labelName, 5, 0, 1, 1);
	gridLayoutCounter->addWidget(lineEditName, 6, 0, 1, 1);

	ui.tabWidget->addTab(tabCounter, "计数器设置");

	// (TODO)
	QWidget *tabSegment = new QWidget();
	tabSegment->setObjectName(QString::fromUtf8("tabSegment"));

	QGridLayout *gridLayoutSegment = new QGridLayout(tabSegment);
	gridLayoutSegment->setObjectName(QString::fromUtf8("gridLayoutSegment"));

	QLabel *labelThresholdRed = new QLabel(tabSegment);
	labelThresholdRed->setObjectName(QString::fromUtf8("labelThresholdRed"));
	labelThresholdRed->setText("阈值（红）");
	QLineEdit *lineEditThresholdRed = new QLineEdit(tabSegment);
	lineEditThresholdRed->setObjectName(QString::fromUtf8("lineEditThresholdRed"));
	lineEditThresholdRed->setText("64");

	QLabel *labelThresholdBlue = new QLabel(tabSegment);
	labelThresholdBlue->setObjectName(QString::fromUtf8("labelThresholdBlue"));
	labelThresholdBlue->setText("阈值（蓝）");
	QLineEdit *lineEditThresholdBlue = new QLineEdit(tabSegment);
	lineEditThresholdBlue->setObjectName(QString::fromUtf8("lineEditThresholdBlue"));
	lineEditThresholdBlue->setText("127");

	gridLayoutSegment->addWidget(labelThresholdRed, 0, 0, 1, 1);
	gridLayoutSegment->addWidget(lineEditThresholdRed, 0, 1, 1, 1);
	gridLayoutSegment->addWidget(labelThresholdBlue, 0, 2, 1, 1);
	gridLayoutSegment->addWidget(lineEditThresholdBlue, 0, 3, 1, 1);

	ui.tabWidget->addTab(tabSegment, "分割");

	// (TODO)
	QWidget *tabNoise = new QWidget();
	tabNoise->setObjectName(QString::fromUtf8("tabNoise"));

	QGridLayout *gridLayoutNoise = new QGridLayout(tabNoise);
	gridLayoutNoise->setObjectName(QString::fromUtf8("gridLayoutNoise"));

	QGroupBox *groupBoxNoise = new QGroupBox(tabNoise);
	groupBoxNoise->setObjectName(QString::fromUtf8("groupBoxNoise"));
	groupBoxNoise->setTitle("使用以下步骤减少噪声");

	QGridLayout *gridLayoutGroupNoise = new QGridLayout(groupBoxNoise);
	gridLayoutGroupNoise->setObjectName(QString::fromUtf8("gridLayoutGroupNoise"));

	QLabel *label1 = new QLabel(groupBoxNoise);
	label1->setObjectName(QString::fromUtf8("label1"));
	label1->setText("1.");

	gridLayoutNoise->addWidget(groupBoxNoise, 0, 0, 1, 1);

	gridLayoutGroupNoise->addWidget(label1, 0, 0, 1, 1);

	ui.tabWidget->addTab(tabNoise, "噪声");

	// (TODO)
	QWidget *tabShape = new QWidget();
	tabShape->setObjectName(QString::fromUtf8("tabShape"));

	QGridLayout *gridLayoutShape = new QGridLayout(tabShape);
	gridLayoutShape->setObjectName(QString::fromUtf8("gridLayoutShape"));

	QGroupBox *groupBoxShape = new QGroupBox(tabShape);
	groupBoxShape->setObjectName(QString::fromUtf8("groupBoxShape"));
	groupBoxShape->setTitle("请选择形状");

	QGridLayout *gridLayoutBoxShape = new QGridLayout(groupBoxShape);
	gridLayoutBoxShape->setObjectName(QString::fromUtf8("gridLayoutBoxShape"));

	QRadioButton *radioButtonRect = new QRadioButton();		// 矩形
	radioButtonRect->setLayoutDirection(Qt::RightToLeft);
	radioButtonRect->setObjectName(QString::fromUtf8("radioButtonRect"));
	radioButtonRect->setChecked(1);
	QLabel *labelRect = new QLabel(tabShape);
	labelRect->setObjectName(QString::fromUtf8("labelRect"));
	QPixmap pixRect;
	pixRect.load("./Resources/ico/rectangle.png");
	labelRect->setPixmap(pixRect);

	QRadioButton *radioButtonCircle = new QRadioButton();	// 圆形
	radioButtonCircle->setLayoutDirection(Qt::RightToLeft);
	radioButtonCircle->setObjectName(QString::fromUtf8("radioButtonCircle"));
	QLabel *labelCircle = new QLabel(tabShape);
	labelCircle->setObjectName(QString::fromUtf8("labelCircle"));
	QPixmap pixCircle;
	pixCircle.load("./Resources/ico/circle.png");
	labelCircle->setPixmap(pixCircle);

	QRadioButton *radioButtonTriang = new QRadioButton();	// 三角
	radioButtonTriang->setLayoutDirection(Qt::RightToLeft);
	radioButtonTriang->setObjectName(QString::fromUtf8("radioButtonTriang"));
	QLabel *labelTriang = new QLabel(tabShape);
	labelTriang->setObjectName(QString::fromUtf8("labelTriang"));
	QPixmap pixTriang;
	pixTriang.load("./Resources/ico/triangle.png");
	labelTriang->setPixmap(pixTriang);

	QRadioButton *radioButtonDiamond = new QRadioButton();	// 菱形
	radioButtonDiamond->setLayoutDirection(Qt::RightToLeft);
	radioButtonDiamond->setObjectName(QString::fromUtf8("radioButtonDiamond"));
	QLabel *labelDiamond = new QLabel(tabShape);
	labelDiamond->setObjectName(QString::fromUtf8("labelDiamond"));
	QPixmap pixDiamond;
	pixDiamond.load("./Resources/ico/diamond.png");
	labelDiamond->setPixmap(pixDiamond);


	gridLayoutShape->addWidget(groupBoxShape, 0, 0, 1, 1);

	gridLayoutBoxShape->addWidget(radioButtonRect, 0, 0, 1, 1);
	gridLayoutBoxShape->addWidget(labelRect, 0, 1, 1, 1);

	gridLayoutBoxShape->addWidget(radioButtonCircle, 0, 2, 1, 1);
	gridLayoutBoxShape->addWidget(labelCircle, 0, 3, 1, 1);

	gridLayoutBoxShape->addWidget(radioButtonTriang, 1, 0, 1, 1);
	gridLayoutBoxShape->addWidget(labelTriang, 1, 1, 1, 1);

	gridLayoutBoxShape->addWidget(radioButtonDiamond, 1, 2, 1, 1);
	gridLayoutBoxShape->addWidget(labelDiamond, 1, 3, 1, 1);

	ui.tabWidget->addTab(tabShape, "形状");

	connect(radioButtonRect, SIGNAL(clicked()), this, SLOT(onShapeChosenRect()));
	connect(radioButtonCircle, SIGNAL(clicked()), this, SLOT(onShapeChosenCircle()));
	connect(radioButtonTriang, SIGNAL(clicked()), this, SLOT(onShapeChosenTriang()));
	connect(radioButtonDiamond, SIGNAL(clicked()), this, SLOT(onShapeChosenDiamond()));
}

void ImageSetting::onShapeChosenRect() {
	std::cout << "rect" << std::endl;
	curShapeId = 0;
	landMark.pop_back();
	landMarkSave();
}

void ImageSetting::onShapeChosenCircle() {
	std::cout << "circle" << std::endl;
	curShapeId = 1;
	landMark.pop_back();
	landMarkSave();
}

void ImageSetting::onShapeChosenTriang() {
	std::cout << "triangle" << std::endl;
	curShapeId = 2;
	landMark.pop_back();
	landMarkSave();
}

void ImageSetting::onShapeChosenDiamond() {
	std::cout << "diamond" << std::endl;
	curShapeId = 3;
	landMark.pop_back();
	landMarkSave();
}

void ImageSetting::InterfaceEdgeMarker() {
	ui.tabWidget->clear();
	QWidget *tabEdgeMarker = new QWidget();
	tabEdgeMarker->setObjectName(QString::fromUtf8("tabEdgeMarker"));

	QGridLayout *gridLayoutEdgeMarker = new QGridLayout(tabEdgeMarker);
	gridLayoutEdgeMarker->setObjectName(QString::fromUtf8("gridLayoutEdgeMarker"));

	QLabel *labelName = new QLabel(tabEdgeMarker);
	labelName->setObjectName(QString::fromUtf8("labelName"));
	labelName->setText("名称");
	QLineEdit *lineEditName = new QLineEdit(tabEdgeMarker);
	lineEditName->setObjectName(QString::fromUtf8("lineEditName"));
	lineEditName->setText("3-边缘标记");
	lineEditName->setEnabled(false);

	QLabel *labelRecv = new QLabel(tabEdgeMarker);
	labelRecv->setObjectName(QString::fromUtf8("labelRecv"));
	labelRecv->setText("接受");
	QLineEdit *lineEditRecv = new QLineEdit(tabEdgeMarker);
	lineEditRecv->setObjectName(QString::fromUtf8("lineEditRecv"));
	lineEditRecv->setText("70");

	QTableWidget *tabDisRes = new QTableWidget(tabEdgeMarker);
	tabDisRes->verticalHeader()->setVisible(false);
	tabDisRes->horizontalHeader()->setVisible(false);
	tabDisRes->setColumnCount(2);
	tabDisRes->setRowCount(3);
	tabDisRes->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	tabDisRes->verticalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	tabDisRes->setEditTriggers(QAbstractItemView::NoEditTriggers);
	tabDisRes->setItem(0, 0, new QTableWidgetItem("记分"));
	tabDisRes->setItem(1, 0, new QTableWidgetItem("尺度"));
	tabDisRes->setItem(2, 0, new QTableWidgetItem("距离"));
	tabDisRes->setItem(0, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(1, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(2, 1, new QTableWidgetItem("0"));

	gridLayoutEdgeMarker->addWidget(tabDisRes, 0, 0, 1, 1);

	gridLayoutEdgeMarker->addWidget(labelRecv, 1, 0, 1, 1);
	gridLayoutEdgeMarker->addWidget(lineEditRecv, 2, 0, 1, 1);

	gridLayoutEdgeMarker->addWidget(labelName, 3, 0, 1, 1);
	gridLayoutEdgeMarker->addWidget(lineEditName, 4, 0, 1, 1);

	ui.tabWidget->addTab(tabEdgeMarker, "边缘标记");
}

void ImageSetting::InterfaceCaliper() {
	ui.tabWidget->clear();
	QWidget *tabCaliperSet = new QWidget();
	tabCaliperSet->setObjectName(QString::fromUtf8("tabCaliperSet"));

	QGridLayout *gridLayoutCaliperSet = new QGridLayout(tabCaliperSet);
	gridLayoutCaliperSet->setObjectName(QString::fromUtf8("gridLayoutCaliperSet"));

	QLabel *labelName = new QLabel(tabCaliperSet);
	labelName->setObjectName(QString::fromUtf8("labelName"));
	labelName->setText("名称");
	QLineEdit *lineEditName = new QLineEdit(tabCaliperSet);
	lineEditName->setObjectName(QString::fromUtf8("lineEditName"));
	lineEditName->setText("2-卡尺");
	lineEditName->setEnabled(false);

	QLabel *labelRecv = new QLabel(tabCaliperSet);
	labelRecv->setObjectName(QString::fromUtf8("labelRecv"));
	labelRecv->setText("接受");
	QLineEdit *lineEditRecv = new QLineEdit(tabCaliperSet);
	lineEditRecv->setObjectName(QString::fromUtf8("lineEditRecv"));
	lineEditRecv->setText("70");

	QLabel *labelSize = new QLabel(tabCaliperSet);
	labelSize->setObjectName(QString::fromUtf8("labelSize"));
	labelSize->setText("尺度");
	QLineEdit *lineEditSize = new QLineEdit(tabCaliperSet);
	lineEditSize->setObjectName(QString::fromUtf8("lineEditSize"));
	lineEditSize->setText("1.0000");

	QLabel *labelTol = new QLabel(tabCaliperSet);
	labelTol->setObjectName(QString::fromUtf8("labelTol"));
	labelTol->setText("公差");
	QLabel *labelTolPlus = new QLabel(tabCaliperSet);
	labelTolPlus->setObjectName(QString::fromUtf8("labelTolPlus"));
	labelTolPlus->setText("+");
	QLineEdit *lineEditTolPlus = new QLineEdit(tabCaliperSet);
	lineEditTolPlus->setObjectName(QString::fromUtf8("lineEditTolPlus"));
	lineEditTolPlus->setText("1.0000");
	QLabel *labelTolMinus = new QLabel(tabCaliperSet);
	labelTolMinus->setObjectName(QString::fromUtf8("labelTolMinus"));
	labelTolMinus->setText("-");
	QLineEdit *lineEditTolMinus = new QLineEdit(tabCaliperSet);
	lineEditTolMinus->setObjectName(QString::fromUtf8("lineEditTolMinus"));
	lineEditTolMinus->setText("1.0000");

	QTableWidget *tabDisRes = new QTableWidget(tabCaliperSet);
	tabDisRes->verticalHeader()->setVisible(false);
	tabDisRes->horizontalHeader()->setVisible(false);
	tabDisRes->setColumnCount(2);
	tabDisRes->setRowCount(6);
	tabDisRes->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	tabDisRes->verticalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	tabDisRes->setEditTriggers(QAbstractItemView::NoEditTriggers);
	tabDisRes->setItem(0, 0, new QTableWidgetItem("记分"));
	tabDisRes->setItem(1, 0, new QTableWidgetItem("尺度"));
	tabDisRes->setItem(2, 0, new QTableWidgetItem("夹角"));
	tabDisRes->setItem(3, 0, new QTableWidgetItem("First"));
	tabDisRes->setItem(4, 0, new QTableWidgetItem("Position"));
	tabDisRes->setItem(5, 0, new QTableWidgetItem("Second"));
	tabDisRes->setItem(0, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(1, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(2, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(3, 1, new QTableWidgetItem("-10"));
	tabDisRes->setItem(4, 1, new QTableWidgetItem("-10"));
	tabDisRes->setItem(5, 1, new QTableWidgetItem("-10"));

	gridLayoutCaliperSet->addWidget(tabDisRes, 0, 0, 1, 4);

	gridLayoutCaliperSet->addWidget(labelRecv, 1, 0, 1, 2);
	gridLayoutCaliperSet->addWidget(lineEditRecv, 2, 0, 1, 2);

	gridLayoutCaliperSet->addWidget(labelSize, 3, 0, 1, 2);
	gridLayoutCaliperSet->addWidget(lineEditSize, 4, 0, 1, 2);

	gridLayoutCaliperSet->addWidget(labelTol, 5, 0, 1, 1);
	gridLayoutCaliperSet->addWidget(labelTolPlus, 6, 0, 1, 1);
	gridLayoutCaliperSet->addWidget(lineEditTolPlus, 6, 1, 1, 1);
	gridLayoutCaliperSet->addWidget(labelTolMinus, 6, 2, 1, 1);
	gridLayoutCaliperSet->addWidget(lineEditTolMinus, 6, 3, 1, 1);

	gridLayoutCaliperSet->addWidget(labelName, 7, 0, 1, 2);
	gridLayoutCaliperSet->addWidget(lineEditName, 8, 0, 1, 2);

	gridLayoutCaliperSet->setColumnStretch(0, 1);
	gridLayoutCaliperSet->setColumnStretch(1, 2);
	gridLayoutCaliperSet->setColumnStretch(2, 1);
	gridLayoutCaliperSet->setColumnStretch(3, 2);
	ui.tabWidget->addTab(tabCaliperSet, "卡尺设置");

	// (TODO)
	ui.tabWidget->addTab(new QWidget(), "边缘描述");

	QWidget *tabLimit = new QWidget();
	tabLimit->setObjectName(QString::fromUtf8("tabLimit"));

	QGridLayout *gridLayoutLimit = new QGridLayout(tabLimit);
	gridLayoutLimit->setObjectName(QString::fromUtf8("gridLayoutLimit"));

	QLabel *labelFirst = new QLabel(tabLimit);
	labelFirst->setObjectName(QString::fromUtf8("labelFirst"));
	labelFirst->setText("First:");
	QLabel *labelLimit1 = new QLabel(tabLimit);
	labelLimit1->setObjectName(QString::fromUtf8("labelLimit1"));
	labelLimit1->setText("Limit");
	QLabel *labelMinus1 = new QLabel(tabLimit);
	labelMinus1->setObjectName(QString::fromUtf8("labelMinus1"));
	labelMinus1->setText("-");
	QLineEdit *lineEditFirstMinus = new QLineEdit(tabLimit);
	lineEditFirstMinus->setObjectName(QString::fromUtf8("lineEditFirstMinus"));
	lineEditFirstMinus->setText("0.0000");

	QLabel *labelPosition = new QLabel(tabLimit);
	labelPosition->setObjectName(QString::fromUtf8("labelPosition"));
	labelPosition->setText("Position:");
	QLabel *labelLimit2 = new QLabel(tabLimit);
	labelLimit2->setObjectName(QString::fromUtf8("labelLimit2"));
	labelLimit2->setText("Limit");
	QLabel *labelPlus2 = new QLabel(tabLimit);
	labelPlus2->setObjectName(QString::fromUtf8("labelPlus2"));
	labelPlus2->setText("+");
	QLineEdit *lineEditPositionPlus = new QLineEdit(tabLimit);
	lineEditPositionPlus->setObjectName(QString::fromUtf8("lineEditPositionPlus"));
	lineEditPositionPlus->setText("0.0000");
	QLabel *labelMinus2 = new QLabel(tabLimit);
	labelMinus2->setObjectName(QString::fromUtf8("labelMinus2"));
	labelMinus2->setText("-");
	QLineEdit *lineEditPositionMinus = new QLineEdit(tabLimit);
	lineEditPositionMinus->setObjectName(QString::fromUtf8("lineEditPositionMinus"));
	lineEditPositionMinus->setText("0.0000");

	QLabel *labelSecond = new QLabel(tabLimit);
	labelSecond->setObjectName(QString::fromUtf8("labelSecond"));
	labelSecond->setText("Second:");
	QLabel *labelLimit3 = new QLabel(tabLimit);
	labelLimit3->setObjectName(QString::fromUtf8("labelLimit3"));
	labelLimit3->setText("Limit");
	QLabel *labelPlus3 = new QLabel(tabLimit);
	labelPlus3->setObjectName(QString::fromUtf8("labelPlus3"));
	labelPlus3->setText("+");
	QLineEdit *lineEdiSecondPlus = new QLineEdit(tabLimit);
	lineEdiSecondPlus->setObjectName(QString::fromUtf8("lineEdiSecondPlus"));
	lineEdiSecondPlus->setText("0.0000");

	gridLayoutLimit->addWidget(labelFirst, 0, 0, 1, 1);
	gridLayoutLimit->addWidget(labelLimit1, 0, 1, 1, 1);
	gridLayoutLimit->addWidget(labelMinus1, 0, 4, 1, 1);
	gridLayoutLimit->addWidget(lineEditFirstMinus, 0, 5, 1, 1);

	gridLayoutLimit->addWidget(labelPosition, 1, 0, 1, 1);
	gridLayoutLimit->addWidget(labelLimit2, 1, 1, 1, 1);
	gridLayoutLimit->addWidget(labelPlus2, 1, 2, 1, 1);
	gridLayoutLimit->addWidget(lineEditPositionPlus, 1, 3, 1, 1);
	gridLayoutLimit->addWidget(labelMinus2, 1, 4, 1, 1);
	gridLayoutLimit->addWidget(lineEditPositionMinus, 1, 5, 1, 1);

	gridLayoutLimit->addWidget(labelSecond, 2, 0, 1, 1);
	gridLayoutLimit->addWidget(labelLimit3, 2, 1, 1, 1);
	gridLayoutLimit->addWidget(labelPlus3, 2, 2, 1, 1);
	gridLayoutLimit->addWidget(lineEdiSecondPlus, 2, 3, 1, 1);

	ui.tabWidget->addTab(tabLimit, "限度");
}

void ImageSetting::InterfaceComparaCaliper() {
	ui.tabWidget->clear();
	QWidget *tabCaliperSet = new QWidget();
	tabCaliperSet->setObjectName(QString::fromUtf8("tabCaliperSet"));

	QGridLayout *gridLayoutCaliperSet = new QGridLayout(tabCaliperSet);
	gridLayoutCaliperSet->setObjectName(QString::fromUtf8("gridLayoutCaliperSet"));

	QLabel *labelName = new QLabel(tabCaliperSet);
	labelName->setObjectName(QString::fromUtf8("labelName"));
	labelName->setText("名称");
	QLineEdit *lineEditName = new QLineEdit(tabCaliperSet);
	lineEditName->setObjectName(QString::fromUtf8("lineEditName"));
	lineEditName->setText("2-卡尺");
	lineEditName->setEnabled(false);

	QLabel *labelRecv = new QLabel(tabCaliperSet);
	labelRecv->setObjectName(QString::fromUtf8("labelRecv"));
	labelRecv->setText("接受");
	QLineEdit *lineEditRecv = new QLineEdit(tabCaliperSet);
	lineEditRecv->setObjectName(QString::fromUtf8("lineEditRecv"));
	lineEditRecv->setText("70");

	QLabel *labelSize = new QLabel(tabCaliperSet);
	labelSize->setObjectName(QString::fromUtf8("labelSize"));
	labelSize->setText("尺度");
	QLineEdit *lineEditSize = new QLineEdit(tabCaliperSet);
	lineEditSize->setObjectName(QString::fromUtf8("lineEditSize"));
	lineEditSize->setText("1.0000");

	QLabel *labelTol = new QLabel(tabCaliperSet);
	labelTol->setObjectName(QString::fromUtf8("labelTol"));
	labelTol->setText("公差");
	QLabel *labelTolPlus = new QLabel(tabCaliperSet);
	labelTolPlus->setObjectName(QString::fromUtf8("labelTolPlus"));
	labelTolPlus->setText("+");
	QLineEdit *lineEditTolPlus = new QLineEdit(tabCaliperSet);
	lineEditTolPlus->setObjectName(QString::fromUtf8("lineEditTolPlus"));
	lineEditTolPlus->setText("1.0000");
	QLabel *labelTolMinus = new QLabel(tabCaliperSet);
	labelTolMinus->setObjectName(QString::fromUtf8("labelTolMinus"));
	labelTolMinus->setText("-");
	QLineEdit *lineEditTolMinus = new QLineEdit(tabCaliperSet);
	lineEditTolMinus->setObjectName(QString::fromUtf8("lineEditTolMinus"));
	lineEditTolMinus->setText("1.0000");

	QTableWidget *tabDisRes = new QTableWidget(tabCaliperSet);
	tabDisRes->verticalHeader()->setVisible(false);
	tabDisRes->horizontalHeader()->setVisible(false);
	tabDisRes->setColumnCount(2);
	tabDisRes->setRowCount(3);
	tabDisRes->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	tabDisRes->verticalHeader()->setSectionResizeMode(QHeaderView::Stretch);
	tabDisRes->setEditTriggers(QAbstractItemView::NoEditTriggers);
	tabDisRes->setItem(0, 0, new QTableWidgetItem("记分"));
	tabDisRes->setItem(1, 0, new QTableWidgetItem("尺度"));
	tabDisRes->setItem(2, 0, new QTableWidgetItem("夹角"));
	tabDisRes->setItem(0, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(1, 1, new QTableWidgetItem("0"));
	tabDisRes->setItem(2, 1, new QTableWidgetItem("0"));

	gridLayoutCaliperSet->addWidget(tabDisRes, 0, 0, 1, 4);

	gridLayoutCaliperSet->addWidget(labelRecv, 1, 0, 1, 2);
	gridLayoutCaliperSet->addWidget(lineEditRecv, 2, 0, 1, 2);

	gridLayoutCaliperSet->addWidget(labelSize, 3, 0, 1, 2);
	gridLayoutCaliperSet->addWidget(lineEditSize, 4, 0, 1, 2);

	gridLayoutCaliperSet->addWidget(labelTol, 5, 0, 1, 1);
	gridLayoutCaliperSet->addWidget(labelTolPlus, 6, 0, 1, 1);
	gridLayoutCaliperSet->addWidget(lineEditTolPlus, 6, 1, 1, 1);
	gridLayoutCaliperSet->addWidget(labelTolMinus, 6, 2, 1, 1);
	gridLayoutCaliperSet->addWidget(lineEditTolMinus, 6, 3, 1, 1);

	gridLayoutCaliperSet->addWidget(labelName, 7, 0, 1, 2);
	gridLayoutCaliperSet->addWidget(lineEditName, 8, 0, 1, 2);

	gridLayoutCaliperSet->setColumnStretch(0, 1);
	gridLayoutCaliperSet->setColumnStretch(1, 2);
	gridLayoutCaliperSet->setColumnStretch(2, 1);
	gridLayoutCaliperSet->setColumnStretch(3, 2);
	ui.tabWidget->addTab(tabCaliperSet, "卡尺设置");

	
	// (TODO)
	ui.tabWidget->addTab(new QWidget(), "边缘描述");
}


// buttonSure保存所有配置
void ImageSetting::buttonSureClicked() {
	// Image Parameter Setting

	// 这里应该将landmark的坐标保存到数据库
	//if (!landMark.empty())
	imageParam.blockSaving(landMark, curMoldObjId);
	//imageParam.xml_blockSaving(landMark);

	this->close();
}

/**********************************************************************************************
***	函数名称：void mousePressEvent(QMouseEvent *ev)											***
***	功能描述：记录鼠标点击时的坐标															***
***																							***
***																							***
***********************************************************************************************/
void ImageSetting::mousePressEvent(QMouseEvent *ev) {
	if (drawRect) {
		if (ev->buttons() & Qt::LeftButton) {
			std::cout << "button left clicked" << std::endl;
			x1 = ev->pos().x();
			y1 = ev->pos().y();
			x2 = x1;
			y2 = y1;
			QCursor cursor;
			cursor.setShape(Qt::ClosedHandCursor);
			QApplication::setOverrideCursor(cursor);

			buttonStatus = true;		// 用来解决鼠标画图时的最后一个方框去不掉的问题
		}
		else if (ev->buttons() & Qt::RightButton) {
			std::cout << "button right clicked" << std::endl;
			x1_p = ev->pos().x();		// 获取点击时的坐标
			y1_p = ev->pos().y();
			x1_cur = x1_p;
			y1_cur = y1_p;
			
			// 记住上一次的起点坐标
			last_x = curSize_x;
			last_y = curSize_y;
		}
	}
}

/**********************************************************************************************
***	函数名称：void mousePressEvent(QMouseEvent *ev)											***
***	功能描述：记录鼠标松开时的坐标，并保存坐标到一个vector中								***
***																							***
***																							***
***********************************************************************************************/
void ImageSetting::mouseReleaseEvent(QMouseEvent* ev) {
	if (drawRect) {
		if (ev->button() == Qt::LeftButton) {
			x2 = ev->pos().x(); //鼠标相对于所在控件的位置
			y2 = ev->pos().y();
			update();
			QApplication::restoreOverrideCursor();

			// for save cordination
			if (x1 != x2)
			{
				landMarkSave();
				//landMarkNum++;
			}

			buttonStatus = false;		// 用来解决鼠标画图时的最后一个方框去不掉的问题
		}
	}
}

/**********************************************************************************************
***	函数名称：void mouseMoveEvent(QMouseEvent *ev)											***
***	功能描述：更新坐标，实现实时绘图														***
***																							***
***																							***
***********************************************************************************************/
void ImageSetting::mouseMoveEvent(QMouseEvent *ev) {
	if (drawRect) {
		if (ev->buttons() & Qt::LeftButton) {
			x2 = ev->pos().x(); //鼠标相对于所在控件的位置
			y2 = ev->pos().y();
			update();
		}
		else if (ev->buttons() & Qt::RightButton) {
			x1_cur = ev->pos().x(); //鼠标相对于所在控件的位置
			y1_cur = ev->pos().y();
			update();
		}
	}
}

/**********************************************************************************************
***	函数名称：bool eventFilter(QObject *obj, QEvent *event)									***
***	功能描述：在label中绘图																	***
***																							***
***																							***
***********************************************************************************************/
bool ImageSetting::eventFilter(QObject *obj, QEvent *event)
{
	if (drawRect) {
		if (obj == ui.labelPart && event->type() == QEvent::Paint) {
			QPainter painter(ui.labelPart);
			painter.setPen(QPen(Qt::red, 1));

			ui.labelPart->clear();	// 清除标签
			ui.labelAll->clear();
			
			cv::Mat mat_cp;	
			imgForDraw_mat.copyTo(mat_cp);	// 拷贝图片

			mat_cp = landMarkRun(mat_cp);	// 将图片送进去画完框出来

			int x_max = (picSize_x - curSize_w) - 1;	// 起点坐标最大值
			int y_max = (picSize_y - curSize_h) - 1;

			curSize_x =(x1_cur - x1_p) + last_x;	// 起点坐标
			curSize_y =(y1_cur - y1_p) + last_y;

			if (curSize_x <= 0) curSize_x = 0;		// 限定起点坐标范围
			else if (curSize_x >= x_max) curSize_x = x_max;
			if (curSize_y <= 0) curSize_y = 0;
			else if (curSize_y >= y_max) curSize_y = y_max;
			
			// 画部分图
			cv::Mat cut = mat_cp(cv::Rect(curSize_x, curSize_y, curSize_w, curSize_h));
			
			QImage cut_img = QImage(cut.data, cut.cols, cut.rows, cut.step, QImage::Format_RGB888);
			painter.drawImage(QPoint(0, 0), cut_img.scaled(QSize(labelPartFixWidth, labelPartFixHeight), Qt::IgnoreAspectRatio));

			// 画全部图
			cv::rectangle(mat_cp, cv::Rect(curSize_x, curSize_y, curSize_w, curSize_h), CvScalar(0, 0, 255), 8, cv::LINE_8, 0);
			imgForDraw_qimg = QImage(mat_cp.data, mat_cp.cols, mat_cp.rows, mat_cp.step, QImage::Format_RGB888);
			ui.labelAll->setPixmap(QPixmap::fromImage(imgForDraw_qimg).scaled(labelAllFixWidth, labelAllFixHeight, Qt::IgnoreAspectRatio));

			if (buttonStatus) {
				painter.drawRect(QRect(x1 - 25, y1 - 52, x2 - x1, y2 - y1));
			}
			painter.end();
		}
	}
	return QWidget::eventFilter(obj, event);
}

/**********************************************************************************************
***	函数名称：void landMarkSave(int num)													***
***	功能描述：n*4，每行为每个框的四个数据													***
***																							***
***																							***
***********************************************************************************************/
void ImageSetting::landMarkSave() {
	std::vector<int> _landmark = { x1 - 25, y1 - 52, abs(x2 - x1), abs(y2 - y1) };
	std::vector<std::vector<int>> convertToTrueSize;
	std::vector<int> _oneRow;

	float ratio_row = (float)picSize_x / ui.labelPart->width() * ratio_x;
	float ratio_col = (float)picSize_y / ui.labelPart->height() * ratio_y;

	_landmark[0] = int(_landmark[0] * ratio_row + curSize_x);
	_landmark[1] = int(_landmark[1] * ratio_col+ curSize_y);
	_landmark[2] = int(_landmark[2] * ratio_row);
	_landmark[3] = int(_landmark[3] * ratio_col);

	// 记录此次操作的blockid与shapeid
	_landmark.push_back(curBlockId);
	_landmark.push_back(curShapeId);

	landMark.push_back(_landmark);
}

/**********************************************************************************************
***	函数名称：void deleteLandMark()															***
***	功能描述：删除框																		***
***																							***
***																							***
***********************************************************************************************/
void ImageSetting::deleteLandMark() {
	if (landMark.size()) {
		landMark.pop_back();
		imageShot();
	}
}

void ImageSetting::imageInitParam() {
	imageParam.blockInit(landMark, curMoldObjId);	// 包含moldId(个数1 + 4)
}

void ImageSetting::imageSave() {
	cv::Mat mat = clonePic();
	cv::cvtColor(mat, mat, cv::COLOR_RGB2BGR);

	QFileDialog *saveImageDialog = new QFileDialog();
	QString setFilter = "Images (*.png)";
	QString selectFilter, dirString;
	QString saveFileName = saveImageDialog->getSaveFileName(this, "Image Save As", dirString, setFilter, &selectFilter, QFileDialog::ShowDirsOnly | QFileDialog::DontResolveSymlinks);

	if (saveFileName.size() > 0) {
		cv::imwrite(saveFileName.toStdString(), mat);
		std::cout << "Image has saved" << std::endl;
	}

	delete saveImageDialog;
}

ImageSetting::~ImageSetting()
{
	qDebug() << "close";

	// delete mycam
	//mycam->cam_stop();

	// close timer 防止在只点击一次Live的情况下关闭
	if (timerForCamLive.isActive() == true)
	{
		qDebug() << "close timer";
		timerForCamLive.stop();
		//disconnect(&timerForCamLive, SIGNAL(timeout()), this, SLOT(imageShot()));
	}

	// reset paramrter
	drawRect = false;
}

