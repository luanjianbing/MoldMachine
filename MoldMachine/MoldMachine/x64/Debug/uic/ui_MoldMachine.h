/********************************************************************************
** Form generated from reading UI file 'MoldMachine.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MOLDMACHINE_H
#define UI_MOLDMACHINE_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenu>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QProgressBar>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTableWidget>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MoldMachineClass
{
public:
    QAction *actionENetIOSetting;
    QAction *actionImageSetting;
    QAction *actionRun;
    QAction *actionCycleTimesSetting;
    QAction *actionAbout;
    QAction *actionStop;
    QAction *actionCycleStepSetting;
    QAction *actionCounterSetting;
    QAction *actionDelaySetting;
    QAction *actionSaveCfgAsXML;
    QAction *actionReadXMLAsSqlData;
    QAction *actionMoldObjects;
    QWidget *centralWidget;
    QGridLayout *gridLayout;
    QWidget *widgetAll;
    QGridLayout *gridLayout_5;
    QWidget *widgetDisImg;
    QGridLayout *gridLayout_2;
    QLabel *labelBeforeOne;
    QLabel *labelAfterOne;
    QWidget *widget;
    QGridLayout *gridLayout_4;
    QLabel *labelDisCurProcess;
    QProgressBar *progressBarStep;
    QWidget *widgetDisIO;
    QGridLayout *gridLayout_3;
    QGroupBox *groupBoxIOState;
    QGridLayout *gridLayout_6;
    QLabel *labelInS1;
    QLabel *labelInS2;
    QLabel *labelInS3;
    QLabel *labelInS4;
    QLabel *labelInS5;
    QLabel *labelInS6;
    QGroupBox *groupBoxOutState;
    QGridLayout *gridLayout_7;
    QLabel *labelOutS1;
    QLabel *labelOutS2;
    QLabel *labelOutS3;
    QLabel *labelOutS4;
    QLabel *labelOutS5;
    QLabel *labelOutS6;
    QTableWidget *tableWidgetDisRes;
    QMenuBar *menuBar;
    QMenu *menuFile;
    QMenu *menuRobin;
    QMenu *menuImage;
    QMenu *menuIO;
    QMenu *menuRun;
    QMenu *menuHelp;
    QMenu *menuOption;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *MoldMachineClass)
    {
        if (MoldMachineClass->objectName().isEmpty())
            MoldMachineClass->setObjectName(QString::fromUtf8("MoldMachineClass"));
        MoldMachineClass->resize(1300, 850);
        actionENetIOSetting = new QAction(MoldMachineClass);
        actionENetIOSetting->setObjectName(QString::fromUtf8("actionENetIOSetting"));
        QIcon icon;
        icon.addFile(QString::fromUtf8("Resources/ico/IO.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionENetIOSetting->setIcon(icon);
        actionImageSetting = new QAction(MoldMachineClass);
        actionImageSetting->setObjectName(QString::fromUtf8("actionImageSetting"));
        QIcon icon1;
        icon1.addFile(QString::fromUtf8("Resources/ico/pic.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionImageSetting->setIcon(icon1);
        actionRun = new QAction(MoldMachineClass);
        actionRun->setObjectName(QString::fromUtf8("actionRun"));
        QIcon icon2;
        icon2.addFile(QString::fromUtf8("Resources/ico/run.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionRun->setIcon(icon2);
        actionCycleTimesSetting = new QAction(MoldMachineClass);
        actionCycleTimesSetting->setObjectName(QString::fromUtf8("actionCycleTimesSetting"));
        QIcon icon3;
        icon3.addFile(QString::fromUtf8("Resources/ico/times.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionCycleTimesSetting->setIcon(icon3);
        actionAbout = new QAction(MoldMachineClass);
        actionAbout->setObjectName(QString::fromUtf8("actionAbout"));
        QIcon icon4;
        icon4.addFile(QString::fromUtf8("Resources/ico/about.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionAbout->setIcon(icon4);
        actionStop = new QAction(MoldMachineClass);
        actionStop->setObjectName(QString::fromUtf8("actionStop"));
        QIcon icon5;
        icon5.addFile(QString::fromUtf8("Resources/ico/stop.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionStop->setIcon(icon5);
        actionCycleStepSetting = new QAction(MoldMachineClass);
        actionCycleStepSetting->setObjectName(QString::fromUtf8("actionCycleStepSetting"));
        QIcon icon6;
        icon6.addFile(QString::fromUtf8("Resources/ico/step.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionCycleStepSetting->setIcon(icon6);
        actionCounterSetting = new QAction(MoldMachineClass);
        actionCounterSetting->setObjectName(QString::fromUtf8("actionCounterSetting"));
        QIcon icon7;
        icon7.addFile(QString::fromUtf8("Resources/ico/count.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionCounterSetting->setIcon(icon7);
        actionDelaySetting = new QAction(MoldMachineClass);
        actionDelaySetting->setObjectName(QString::fromUtf8("actionDelaySetting"));
        QIcon icon8;
        icon8.addFile(QString::fromUtf8("Resources/ico/delay.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionDelaySetting->setIcon(icon8);
        actionSaveCfgAsXML = new QAction(MoldMachineClass);
        actionSaveCfgAsXML->setObjectName(QString::fromUtf8("actionSaveCfgAsXML"));
        QIcon icon9;
        icon9.addFile(QString::fromUtf8("Resources/ico/save.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionSaveCfgAsXML->setIcon(icon9);
        actionReadXMLAsSqlData = new QAction(MoldMachineClass);
        actionReadXMLAsSqlData->setObjectName(QString::fromUtf8("actionReadXMLAsSqlData"));
        QIcon icon10;
        icon10.addFile(QString::fromUtf8("Resources/ico/load.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionReadXMLAsSqlData->setIcon(icon10);
        actionMoldObjects = new QAction(MoldMachineClass);
        actionMoldObjects->setObjectName(QString::fromUtf8("actionMoldObjects"));
        QIcon icon11;
        icon11.addFile(QString::fromUtf8("Resources/ico/objects.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionMoldObjects->setIcon(icon11);
        centralWidget = new QWidget(MoldMachineClass);
        centralWidget->setObjectName(QString::fromUtf8("centralWidget"));
        gridLayout = new QGridLayout(centralWidget);
        gridLayout->setSpacing(6);
        gridLayout->setContentsMargins(11, 11, 11, 11);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        widgetAll = new QWidget(centralWidget);
        widgetAll->setObjectName(QString::fromUtf8("widgetAll"));
        gridLayout_5 = new QGridLayout(widgetAll);
        gridLayout_5->setSpacing(6);
        gridLayout_5->setContentsMargins(11, 11, 11, 11);
        gridLayout_5->setObjectName(QString::fromUtf8("gridLayout_5"));
        widgetDisImg = new QWidget(widgetAll);
        widgetDisImg->setObjectName(QString::fromUtf8("widgetDisImg"));
        gridLayout_2 = new QGridLayout(widgetDisImg);
        gridLayout_2->setSpacing(6);
        gridLayout_2->setContentsMargins(11, 11, 11, 11);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        gridLayout_2->setContentsMargins(-1, 9, -1, 9);
        labelBeforeOne = new QLabel(widgetDisImg);
        labelBeforeOne->setObjectName(QString::fromUtf8("labelBeforeOne"));
        labelBeforeOne->setStyleSheet(QString::fromUtf8("background-color:black"));
        labelBeforeOne->setFrameShape(QFrame::StyledPanel);
        labelBeforeOne->setFrameShadow(QFrame::Plain);
        labelBeforeOne->setLineWidth(1);
        labelBeforeOne->setScaledContents(false);
        labelBeforeOne->setAlignment(Qt::AlignCenter);

        gridLayout_2->addWidget(labelBeforeOne, 0, 0, 1, 1);

        labelAfterOne = new QLabel(widgetDisImg);
        labelAfterOne->setObjectName(QString::fromUtf8("labelAfterOne"));
        labelAfterOne->setStyleSheet(QString::fromUtf8("background-color:black"));
        labelAfterOne->setFrameShape(QFrame::StyledPanel);
        labelAfterOne->setScaledContents(false);
        labelAfterOne->setAlignment(Qt::AlignCenter);

        gridLayout_2->addWidget(labelAfterOne, 0, 1, 1, 1);


        gridLayout_5->addWidget(widgetDisImg, 0, 0, 1, 1);

        widget = new QWidget(widgetAll);
        widget->setObjectName(QString::fromUtf8("widget"));
        gridLayout_4 = new QGridLayout(widget);
        gridLayout_4->setSpacing(6);
        gridLayout_4->setContentsMargins(11, 11, 11, 11);
        gridLayout_4->setObjectName(QString::fromUtf8("gridLayout_4"));
        labelDisCurProcess = new QLabel(widget);
        labelDisCurProcess->setObjectName(QString::fromUtf8("labelDisCurProcess"));
        labelDisCurProcess->setFrameShape(QFrame::Panel);
        labelDisCurProcess->setAlignment(Qt::AlignCenter);

        gridLayout_4->addWidget(labelDisCurProcess, 0, 1, 1, 1);

        progressBarStep = new QProgressBar(widget);
        progressBarStep->setObjectName(QString::fromUtf8("progressBarStep"));
        progressBarStep->setValue(0);
        progressBarStep->setAlignment(Qt::AlignCenter);
        progressBarStep->setTextVisible(true);
        progressBarStep->setTextDirection(QProgressBar::TopToBottom);

        gridLayout_4->addWidget(progressBarStep, 1, 1, 1, 1);

        widgetDisIO = new QWidget(widget);
        widgetDisIO->setObjectName(QString::fromUtf8("widgetDisIO"));
        gridLayout_3 = new QGridLayout(widgetDisIO);
        gridLayout_3->setSpacing(6);
        gridLayout_3->setContentsMargins(11, 11, 11, 11);
        gridLayout_3->setObjectName(QString::fromUtf8("gridLayout_3"));
        groupBoxIOState = new QGroupBox(widgetDisIO);
        groupBoxIOState->setObjectName(QString::fromUtf8("groupBoxIOState"));
        gridLayout_6 = new QGridLayout(groupBoxIOState);
        gridLayout_6->setSpacing(6);
        gridLayout_6->setContentsMargins(11, 11, 11, 11);
        gridLayout_6->setObjectName(QString::fromUtf8("gridLayout_6"));
        labelInS1 = new QLabel(groupBoxIOState);
        labelInS1->setObjectName(QString::fromUtf8("labelInS1"));
        labelInS1->setEnabled(true);
        labelInS1->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_red_20x20.jpg")));
        labelInS1->setScaledContents(false);
        labelInS1->setAlignment(Qt::AlignCenter);

        gridLayout_6->addWidget(labelInS1, 0, 0, 1, 1);

        labelInS2 = new QLabel(groupBoxIOState);
        labelInS2->setObjectName(QString::fromUtf8("labelInS2"));
        labelInS2->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_red_20x20.jpg")));
        labelInS2->setAlignment(Qt::AlignCenter);

        gridLayout_6->addWidget(labelInS2, 0, 1, 1, 1);

        labelInS3 = new QLabel(groupBoxIOState);
        labelInS3->setObjectName(QString::fromUtf8("labelInS3"));
        labelInS3->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_red_20x20.jpg")));
        labelInS3->setAlignment(Qt::AlignCenter);

        gridLayout_6->addWidget(labelInS3, 0, 2, 1, 1);

        labelInS4 = new QLabel(groupBoxIOState);
        labelInS4->setObjectName(QString::fromUtf8("labelInS4"));
        labelInS4->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_red_20x20.jpg")));
        labelInS4->setAlignment(Qt::AlignCenter);

        gridLayout_6->addWidget(labelInS4, 0, 3, 1, 1);

        labelInS5 = new QLabel(groupBoxIOState);
        labelInS5->setObjectName(QString::fromUtf8("labelInS5"));
        labelInS5->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_red_20x20.jpg")));
        labelInS5->setAlignment(Qt::AlignCenter);

        gridLayout_6->addWidget(labelInS5, 0, 4, 1, 1);

        labelInS6 = new QLabel(groupBoxIOState);
        labelInS6->setObjectName(QString::fromUtf8("labelInS6"));
        labelInS6->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_red_20x20.jpg")));
        labelInS6->setAlignment(Qt::AlignCenter);

        gridLayout_6->addWidget(labelInS6, 0, 5, 1, 1);


        gridLayout_3->addWidget(groupBoxIOState, 0, 0, 1, 1);

        groupBoxOutState = new QGroupBox(widgetDisIO);
        groupBoxOutState->setObjectName(QString::fromUtf8("groupBoxOutState"));
        gridLayout_7 = new QGridLayout(groupBoxOutState);
        gridLayout_7->setSpacing(6);
        gridLayout_7->setContentsMargins(11, 11, 11, 11);
        gridLayout_7->setObjectName(QString::fromUtf8("gridLayout_7"));
        labelOutS1 = new QLabel(groupBoxOutState);
        labelOutS1->setObjectName(QString::fromUtf8("labelOutS1"));
        labelOutS1->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_green_20x20.jpg")));
        labelOutS1->setAlignment(Qt::AlignCenter);

        gridLayout_7->addWidget(labelOutS1, 0, 0, 1, 1);

        labelOutS2 = new QLabel(groupBoxOutState);
        labelOutS2->setObjectName(QString::fromUtf8("labelOutS2"));
        labelOutS2->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_green_20x20.jpg")));
        labelOutS2->setAlignment(Qt::AlignCenter);

        gridLayout_7->addWidget(labelOutS2, 0, 1, 1, 1);

        labelOutS3 = new QLabel(groupBoxOutState);
        labelOutS3->setObjectName(QString::fromUtf8("labelOutS3"));
        labelOutS3->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_green_20x20.jpg")));
        labelOutS3->setAlignment(Qt::AlignCenter);

        gridLayout_7->addWidget(labelOutS3, 0, 2, 1, 1);

        labelOutS4 = new QLabel(groupBoxOutState);
        labelOutS4->setObjectName(QString::fromUtf8("labelOutS4"));
        labelOutS4->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_green_20x20.jpg")));
        labelOutS4->setAlignment(Qt::AlignCenter);

        gridLayout_7->addWidget(labelOutS4, 0, 3, 1, 1);

        labelOutS5 = new QLabel(groupBoxOutState);
        labelOutS5->setObjectName(QString::fromUtf8("labelOutS5"));
        labelOutS5->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_green_20x20.jpg")));
        labelOutS5->setAlignment(Qt::AlignCenter);

        gridLayout_7->addWidget(labelOutS5, 0, 4, 1, 1);

        labelOutS6 = new QLabel(groupBoxOutState);
        labelOutS6->setObjectName(QString::fromUtf8("labelOutS6"));
        labelOutS6->setPixmap(QPixmap(QString::fromUtf8("Resources/ico/light_green_20x20.jpg")));
        labelOutS6->setAlignment(Qt::AlignCenter);

        gridLayout_7->addWidget(labelOutS6, 0, 5, 1, 1);


        gridLayout_3->addWidget(groupBoxOutState, 1, 0, 1, 1);


        gridLayout_4->addWidget(widgetDisIO, 0, 2, 2, 1);

        tableWidgetDisRes = new QTableWidget(widget);
        if (tableWidgetDisRes->columnCount() < 4)
            tableWidgetDisRes->setColumnCount(4);
        QTableWidgetItem *__qtablewidgetitem = new QTableWidgetItem();
        __qtablewidgetitem->setTextAlignment(Qt::AlignCenter);
        tableWidgetDisRes->setHorizontalHeaderItem(0, __qtablewidgetitem);
        QTableWidgetItem *__qtablewidgetitem1 = new QTableWidgetItem();
        __qtablewidgetitem1->setTextAlignment(Qt::AlignCenter);
        tableWidgetDisRes->setHorizontalHeaderItem(1, __qtablewidgetitem1);
        QTableWidgetItem *__qtablewidgetitem2 = new QTableWidgetItem();
        __qtablewidgetitem2->setTextAlignment(Qt::AlignCenter);
        tableWidgetDisRes->setHorizontalHeaderItem(2, __qtablewidgetitem2);
        QTableWidgetItem *__qtablewidgetitem3 = new QTableWidgetItem();
        __qtablewidgetitem3->setTextAlignment(Qt::AlignCenter);
        tableWidgetDisRes->setHorizontalHeaderItem(3, __qtablewidgetitem3);
        tableWidgetDisRes->setObjectName(QString::fromUtf8("tableWidgetDisRes"));
        tableWidgetDisRes->setEditTriggers(QAbstractItemView::NoEditTriggers);
        tableWidgetDisRes->setSortingEnabled(false);
        tableWidgetDisRes->setRowCount(0);
        tableWidgetDisRes->horizontalHeader()->setVisible(true);
        tableWidgetDisRes->horizontalHeader()->setCascadingSectionResizes(false);
        tableWidgetDisRes->horizontalHeader()->setMinimumSectionSize(25);
        tableWidgetDisRes->horizontalHeader()->setDefaultSectionSize(85);
        tableWidgetDisRes->horizontalHeader()->setHighlightSections(true);
        tableWidgetDisRes->horizontalHeader()->setStretchLastSection(true);
        tableWidgetDisRes->verticalHeader()->setVisible(false);
        tableWidgetDisRes->verticalHeader()->setMinimumSectionSize(25);
        tableWidgetDisRes->verticalHeader()->setDefaultSectionSize(30);
        tableWidgetDisRes->verticalHeader()->setProperty("showSortIndicator", QVariant(false));
        tableWidgetDisRes->verticalHeader()->setStretchLastSection(false);

        gridLayout_4->addWidget(tableWidgetDisRes, 0, 0, 2, 1);

        gridLayout_4->setColumnStretch(0, 1);
        gridLayout_4->setColumnStretch(1, 1);
        gridLayout_4->setColumnStretch(2, 1);

        gridLayout_5->addWidget(widget, 1, 0, 1, 1);

        gridLayout_5->setRowStretch(0, 8);
        gridLayout_5->setRowStretch(1, 2);

        gridLayout->addWidget(widgetAll, 0, 0, 1, 1);

        MoldMachineClass->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(MoldMachineClass);
        menuBar->setObjectName(QString::fromUtf8("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 1300, 26));
        menuFile = new QMenu(menuBar);
        menuFile->setObjectName(QString::fromUtf8("menuFile"));
        menuRobin = new QMenu(menuBar);
        menuRobin->setObjectName(QString::fromUtf8("menuRobin"));
        menuImage = new QMenu(menuBar);
        menuImage->setObjectName(QString::fromUtf8("menuImage"));
        menuIO = new QMenu(menuBar);
        menuIO->setObjectName(QString::fromUtf8("menuIO"));
        menuRun = new QMenu(menuBar);
        menuRun->setObjectName(QString::fromUtf8("menuRun"));
        menuHelp = new QMenu(menuBar);
        menuHelp->setObjectName(QString::fromUtf8("menuHelp"));
        menuOption = new QMenu(menuBar);
        menuOption->setObjectName(QString::fromUtf8("menuOption"));
        MoldMachineClass->setMenuBar(menuBar);
        mainToolBar = new QToolBar(MoldMachineClass);
        mainToolBar->setObjectName(QString::fromUtf8("mainToolBar"));
        MoldMachineClass->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(MoldMachineClass);
        statusBar->setObjectName(QString::fromUtf8("statusBar"));
        MoldMachineClass->setStatusBar(statusBar);

        menuBar->addAction(menuFile->menuAction());
        menuBar->addAction(menuRobin->menuAction());
        menuBar->addAction(menuImage->menuAction());
        menuBar->addAction(menuIO->menuAction());
        menuBar->addAction(menuRun->menuAction());
        menuBar->addAction(menuOption->menuAction());
        menuBar->addAction(menuHelp->menuAction());
        menuFile->addAction(actionSaveCfgAsXML);
        menuFile->addAction(actionReadXMLAsSqlData);
        menuRobin->addAction(actionCycleTimesSetting);
        menuRobin->addAction(actionCycleStepSetting);
        menuRobin->addAction(actionCounterSetting);
        menuRobin->addAction(actionDelaySetting);
        menuImage->addAction(actionImageSetting);
        menuIO->addAction(actionENetIOSetting);
        menuRun->addAction(actionRun);
        menuHelp->addAction(actionAbout);
        menuOption->addAction(actionMoldObjects);
        mainToolBar->addAction(actionRun);
        mainToolBar->addSeparator();
        mainToolBar->addAction(actionStop);
        mainToolBar->addSeparator();

        retranslateUi(MoldMachineClass);

        QMetaObject::connectSlotsByName(MoldMachineClass);
    } // setupUi

    void retranslateUi(QMainWindow *MoldMachineClass)
    {
        MoldMachineClass->setWindowTitle(QApplication::translate("MoldMachineClass", "\346\263\250\345\241\221\350\277\207\347\250\213\347\233\221\346\216\247\347\263\273\347\273\237", nullptr));
        actionENetIOSetting->setText(QApplication::translate("MoldMachineClass", "\350\276\223\345\205\245/\350\276\223\345\207\272\345\261\236\346\200\247", nullptr));
        actionImageSetting->setText(QApplication::translate("MoldMachineClass", "\345\233\276\345\203\217\350\256\276\347\275\256", nullptr));
        actionRun->setText(QApplication::translate("MoldMachineClass", "\350\277\220\350\241\214", nullptr));
        actionCycleTimesSetting->setText(QApplication::translate("MoldMachineClass", "\345\276\252\347\216\257\346\254\241\346\225\260", nullptr));
        actionAbout->setText(QApplication::translate("MoldMachineClass", "\345\205\263\344\272\216", nullptr));
        actionStop->setText(QApplication::translate("MoldMachineClass", "Stop", nullptr));
        actionCycleStepSetting->setText(QApplication::translate("MoldMachineClass", "\345\276\252\347\216\257\346\255\245\351\252\244", nullptr));
        actionCounterSetting->setText(QApplication::translate("MoldMachineClass", "\350\256\241\346\225\260\345\231\250", nullptr));
        actionDelaySetting->setText(QApplication::translate("MoldMachineClass", "\345\273\266\346\227\266\345\231\250", nullptr));
        actionSaveCfgAsXML->setText(QApplication::translate("MoldMachineClass", "\344\277\235\345\255\230", nullptr));
        actionReadXMLAsSqlData->setText(QApplication::translate("MoldMachineClass", "\350\257\273\345\217\226", nullptr));
        actionMoldObjects->setText(QApplication::translate("MoldMachineClass", "\346\250\241\345\205\267\345\257\271\350\261\241", nullptr));
        labelBeforeOne->setText(QString());
        labelAfterOne->setText(QString());
        labelDisCurProcess->setText(QApplication::translate("MoldMachineClass", "\347\263\273\347\273\237\346\234\252\345\220\257\345\212\250", nullptr));
        progressBarStep->setFormat(QApplication::translate("MoldMachineClass", "%p%", nullptr));
        groupBoxIOState->setTitle(QApplication::translate("MoldMachineClass", "\350\276\223\345\205\245\347\212\266\346\200\201", nullptr));
        labelInS1->setText(QString());
        labelInS2->setText(QString());
        labelInS3->setText(QString());
        labelInS4->setText(QString());
        labelInS5->setText(QString());
        labelInS6->setText(QString());
        groupBoxOutState->setTitle(QApplication::translate("MoldMachineClass", "\350\276\223\345\207\272\347\212\266\346\200\201", nullptr));
        labelOutS1->setText(QString());
        labelOutS2->setText(QString());
        labelOutS3->setText(QString());
        labelOutS4->setText(QString());
        labelOutS5->setText(QString());
        labelOutS6->setText(QString());
        QTableWidgetItem *___qtablewidgetitem = tableWidgetDisRes->horizontalHeaderItem(0);
        ___qtablewidgetitem->setText(QApplication::translate("MoldMachineClass", "\345\272\217\345\217\267", nullptr));
        QTableWidgetItem *___qtablewidgetitem1 = tableWidgetDisRes->horizontalHeaderItem(1);
        ___qtablewidgetitem1->setText(QApplication::translate("MoldMachineClass", "\346\227\266\351\227\264", nullptr));
        QTableWidgetItem *___qtablewidgetitem2 = tableWidgetDisRes->horizontalHeaderItem(2);
        ___qtablewidgetitem2->setText(QApplication::translate("MoldMachineClass", "\347\273\223\346\236\234", nullptr));
        QTableWidgetItem *___qtablewidgetitem3 = tableWidgetDisRes->horizontalHeaderItem(3);
        ___qtablewidgetitem3->setText(QApplication::translate("MoldMachineClass", "\344\277\241\346\201\257", nullptr));
        menuFile->setTitle(QApplication::translate("MoldMachineClass", "\346\226\207\344\273\266", nullptr));
        menuRobin->setTitle(QApplication::translate("MoldMachineClass", "\345\276\252\347\216\257", nullptr));
        menuImage->setTitle(QApplication::translate("MoldMachineClass", "\345\233\276\345\203\217", nullptr));
        menuIO->setTitle(QApplication::translate("MoldMachineClass", "\350\276\223\345\205\245/\350\276\223\345\207\272", nullptr));
        menuRun->setTitle(QApplication::translate("MoldMachineClass", "\350\277\220\350\241\214", nullptr));
        menuHelp->setTitle(QApplication::translate("MoldMachineClass", "\345\270\256\345\212\251", nullptr));
        menuOption->setTitle(QApplication::translate("MoldMachineClass", "\351\200\211\351\241\271", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MoldMachineClass: public Ui_MoldMachineClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MOLDMACHINE_H
