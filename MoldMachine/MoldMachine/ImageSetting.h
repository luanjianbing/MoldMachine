#pragma once

#include <QtWidgets/QMainWindow>
#include <QComboBox>
#include <QPixMap>
#include <QMouseEvent>
#include <QPen>
#include <QPainter>
#include <QEvent>
#include <QPoint>
#include <QTimer>
#include <QFileDialog>
#include <QTableWidget>
#include <QHeaderView>
#include <QRadioButton>

#include "ui_ImageSetting.h"
#include "CameraDrive.h"
#include "ImageProcessing.h"
#include "ParameterInit.h"

//struct info_ImageSetting
//{
//	QString contrast;
//	QString brightness;
//	QString band;
//	QString discriminateThreshold;
//};

class ImageSetting : public QMainWindow
{
	Q_OBJECT

	public:
		ImageSetting(int curMoldId, QWidget *parent = Q_NULLPTR);
		~ImageSetting();

	private:
		int curMoldObjId = 0;

		int curBlockId = 0;		// 表示每个框内使用的处理工具
		int curShapeId = 0;		// 0：矩形	1：圆形  2：三角形  3：菱形

		Ui::ImageSettingClass ui;
		int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
		bool buttonStatus = false;	// 触发pressevent事件时，才让paintevent中画landmark，避免删除时遗留

		//Camera *mycam;
		cv::Mat clonePic();
		QTimer timerForCamLive;

		cv::Mat imgForDraw_mat;
		QImage imgForDraw_qimg;

		std::vector<std::vector<int>> landMark;
		//int	landMarkNum = 0;
		void landMarkSave();
		cv::Mat landMarkRun(cv::Mat);

		ParamInit imageParam;
		void imageInitParam();

		float ratio_x = 0.5;	// 显示区域的大小labeldisplay(矩形框长跟宽设置)
		float ratio_y = 0.5;
		int x1_p = 0, y1_p = 0, x1_cur = 0, y1_cur = 0;
		int picSize_x = 0, picSize_y = 0, curSize_x = 0, curSize_y = 0, curSize_w = 0, curSize_h = 0, last_x = 0, last_y = 0;;

		//int curCamId = 1;
		int labelPartFixWidth = 772;
		int labelPartFixHeight = 751;
		int labelAllFixWidth = 333;
		int labelAllFixHeight = 287;

		// 切换不同框时的tabwidget界面设置
		void InterfaceComparaCaliper();	// 比较卡尺工具
		void InterfaceCaliper();		// 卡尺工具
		void InterfaceEdgeMarker();		// 边缘标记工具
		void InterfaceCounter();		//计数器工具
		void InterfaceFeatureAnalysis();	// 特征分析工具
		void InterfacePatternSearch();		// 图像搜索工具
		void InterfaceOnOrOff();			// 在/不在
		void InterfaceCorrect();			// 校正
		void Interface1SidelineSearch();	// 边线查找
		void InterfaceBrightness();			// 亮度检测
		void Interface1Uniformity();		// 一致性
		void InterfaceResidueDetection();	//残留物检测

	private slots:
		void buttonSureClicked();
		void comboxChanged(int);
		void imageShot();
		void imageLive();
		void deleteLandMark();
		void imageSave();

		void onShapeChosenRect();
		void onShapeChosenCircle();
		void onShapeChosenTriang();
		void onShapeChosenDiamond();

	protected:
		void mousePressEvent(QMouseEvent* ev);
		void mouseReleaseEvent(QMouseEvent* ev);
		void mouseMoveEvent(QMouseEvent *ev);
		//void paintEvent(QPaintEvent *);
		bool eventFilter(QObject *, QEvent *);

	signals:
};
