/********************************************************************************
** Form generated from reading UI file 'CycleStepSetting.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CYCLESTEPSETTING_H
#define UI_CYCLESTEPSETTING_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QListWidget>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QRadioButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QTabWidget>
#include <QtWidgets/QTableWidget>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_CycleStepClass
{
public:
    QGridLayout *gridLayout;
    QWidget *widget;
    QGridLayout *gridLayout_6;
    QComboBox *comboBox;
    QSpacerItem *horizontalSpacer_2;
    QPushButton *buttonSure;
    QSpacerItem *horizontalSpacer_3;
    QTabWidget *tabWidget;
    QWidget *tab;
    QGridLayout *gridLayout_5;
    QTableWidget *tableWidget;
    QWidget *widget_2;
    QGridLayout *gridLayout_4;
    QSpacerItem *verticalSpacer_3;
    QGroupBox *groupBox_2;
    QGridLayout *gridLayout_3;
    QPushButton *buttonColAdd;
    QPushButton *buttonColDelete;
    QSpacerItem *verticalSpacer_2;
    QLabel *labelStepNum;
    QGroupBox *groupBox;
    QGridLayout *gridLayout_2;
    QPushButton *buttonMinus;
    QPushButton *buttonUp;
    QPushButton *buttonAdd;
    QPushButton *buttonLeft;
    QPushButton *buttonDown;
    QPushButton *buttonRight;
    QSpacerItem *verticalSpacer;
    QLabel *labelStep;
    QWidget *tabInput;
    QGridLayout *gridLayout_10;
    QTabWidget *tabWidgetWord;
    QWidget *tabNormalStepDisplay;
    QGridLayout *gridLayout_7;
    QListWidget *listWidgetNormal;
    QLabel *labelTabNormalName;
    QWidget *tabAddCommand;
    QGridLayout *gridLayout_9;
    QTabWidget *tabWidgetCmd;
    QWidget *tabCmdStandard;
    QGridLayout *gridLayout_11;
    QListWidget *listWidgetIOStd;
    QSpacerItem *horizontalSpacer;
    QSpacerItem *verticalSpacer_5;
    QWidget *tabAuto;
    QGridLayout *gridLayout_18;
    QSpacerItem *horizontalSpacer_5;
    QListWidget *listWidgetAutoCmd;
    QSpacerItem *horizontalSpacer_7;
    QGroupBox *groupBoxAuto;
    QGridLayout *gridLayout_19;
    QLineEdit *lineEditAddName;
    QComboBox *comboBoxInOrOut;
    QPushButton *buttonSureAddAutoIO;
    QWidget *widgetOnOrOff;
    QGridLayout *gridLayout_12;
    QRadioButton *radioButtonOn;
    QRadioButton *radioButtonOff;
    QWidget *widgetAddAndDeleteCmd;
    QGridLayout *gridLayout_8;
    QPushButton *buttonDeleteCmd;
    QPushButton *buttonAddCmd;
    QTableWidget *tableWidgetManualIOName;
    QLabel *labelDisplayCmd;
    QLabel *labelTabCmdName;
    QWidget *tabSub;
    QGridLayout *gridLayout_13;
    QTabWidget *tabWidgetSub;
    QWidget *tabJump;
    QGridLayout *gridLayout_16;
    QLineEdit *lineEditInputLabelNum;
    QSpacerItem *verticalSpacer_4;
    QListWidget *listWidgetJump;
    QLabel *labelInputLabelNum;
    QSpacerItem *horizontalSpacer_4;
    QLabel *labelLabelMsgDisplay;
    QWidget *tabCustomize;
    QGridLayout *gridLayout_14;
    QListWidget *listWidgetSubLabel;
    QWidget *widget_5;
    QSpacerItem *horizontalSpacer_6;
    QSpacerItem *verticalSpacer_7;
    QWidget *widget_4;
    QGridLayout *gridLayout_20;
    QPushButton *buttonFactor;
    QSpacerItem *verticalSpacer_6;
    QLabel *labelTabSubName;
    QLabel *labelDisplayJumpDst;
    QWidget *widgetAddAndDeleteSub;
    QGridLayout *gridLayout_15;
    QLabel *labelExplanationSub;
    QPushButton *buttonAddSub;
    QPushButton *buttonDeleteSub;
    QWidget *tabMore;
    QGridLayout *gridLayout_17;
    QLabel *labelTabMoreName;
    QWidget *widget_3;
    QGridLayout *gridLayout_22;
    QGroupBox *groupBoxDelay;
    QGridLayout *gridLayout_23;
    QLineEdit *lineEditDelay;
    QLabel *labelDelay;
    QSpacerItem *horizontalSpacer_8;
    QWidget *widgetMore;
    QGridLayout *gridLayout_21;
    QLabel *labelExplanationMore;
    QPushButton *buttonAddMore;
    QPushButton *buttonDeleteMore;
    QGroupBox *groupBoxCnt;
    QGroupBox *groupBoxImg;
    QGridLayout *gridLayout_24;
    QWidget *widget_6;
    QGridLayout *gridLayout_25;
    QRadioButton *radioButtonBeforeEject;
    QRadioButton *radioButtonAfterEject;
    QComboBox *comboBoxImage;
    QSpacerItem *horizontalSpacer_9;

    void setupUi(QWidget *CycleStepClass)
    {
        if (CycleStepClass->objectName().isEmpty())
            CycleStepClass->setObjectName(QString::fromUtf8("CycleStepClass"));
        CycleStepClass->resize(1150, 950);
        QSizePolicy sizePolicy(QSizePolicy::Preferred, QSizePolicy::Preferred);
        sizePolicy.setHorizontalStretch(0);
        sizePolicy.setVerticalStretch(0);
        sizePolicy.setHeightForWidth(CycleStepClass->sizePolicy().hasHeightForWidth());
        CycleStepClass->setSizePolicy(sizePolicy);
        gridLayout = new QGridLayout(CycleStepClass);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        widget = new QWidget(CycleStepClass);
        widget->setObjectName(QString::fromUtf8("widget"));
        gridLayout_6 = new QGridLayout(widget);
        gridLayout_6->setObjectName(QString::fromUtf8("gridLayout_6"));
        comboBox = new QComboBox(widget);
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->setObjectName(QString::fromUtf8("comboBox"));

        gridLayout_6->addWidget(comboBox, 2, 1, 1, 1);

        horizontalSpacer_2 = new QSpacerItem(880, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_6->addItem(horizontalSpacer_2, 2, 0, 1, 1);

        buttonSure = new QPushButton(widget);
        buttonSure->setObjectName(QString::fromUtf8("buttonSure"));

        gridLayout_6->addWidget(buttonSure, 2, 3, 1, 1);

        horizontalSpacer_3 = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_6->addItem(horizontalSpacer_3, 2, 2, 1, 1);

        tabWidget = new QTabWidget(widget);
        tabWidget->setObjectName(QString::fromUtf8("tabWidget"));
        tab = new QWidget();
        tab->setObjectName(QString::fromUtf8("tab"));
        gridLayout_5 = new QGridLayout(tab);
        gridLayout_5->setObjectName(QString::fromUtf8("gridLayout_5"));
        tableWidget = new QTableWidget(tab);
        if (tableWidget->columnCount() < 1)
            tableWidget->setColumnCount(1);
        QTableWidgetItem *__qtablewidgetitem = new QTableWidgetItem();
        tableWidget->setHorizontalHeaderItem(0, __qtablewidgetitem);
        if (tableWidget->rowCount() < 30)
            tableWidget->setRowCount(30);
        QTableWidgetItem *__qtablewidgetitem1 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(0, __qtablewidgetitem1);
        QTableWidgetItem *__qtablewidgetitem2 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(1, __qtablewidgetitem2);
        QTableWidgetItem *__qtablewidgetitem3 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(2, __qtablewidgetitem3);
        QTableWidgetItem *__qtablewidgetitem4 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(3, __qtablewidgetitem4);
        QTableWidgetItem *__qtablewidgetitem5 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(4, __qtablewidgetitem5);
        QTableWidgetItem *__qtablewidgetitem6 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(5, __qtablewidgetitem6);
        QTableWidgetItem *__qtablewidgetitem7 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(6, __qtablewidgetitem7);
        QTableWidgetItem *__qtablewidgetitem8 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(7, __qtablewidgetitem8);
        QTableWidgetItem *__qtablewidgetitem9 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(8, __qtablewidgetitem9);
        QTableWidgetItem *__qtablewidgetitem10 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(9, __qtablewidgetitem10);
        QTableWidgetItem *__qtablewidgetitem11 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(10, __qtablewidgetitem11);
        QTableWidgetItem *__qtablewidgetitem12 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(11, __qtablewidgetitem12);
        QTableWidgetItem *__qtablewidgetitem13 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(12, __qtablewidgetitem13);
        QTableWidgetItem *__qtablewidgetitem14 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(13, __qtablewidgetitem14);
        QTableWidgetItem *__qtablewidgetitem15 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(14, __qtablewidgetitem15);
        QTableWidgetItem *__qtablewidgetitem16 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(15, __qtablewidgetitem16);
        QTableWidgetItem *__qtablewidgetitem17 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(16, __qtablewidgetitem17);
        QTableWidgetItem *__qtablewidgetitem18 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(17, __qtablewidgetitem18);
        QTableWidgetItem *__qtablewidgetitem19 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(18, __qtablewidgetitem19);
        QTableWidgetItem *__qtablewidgetitem20 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(19, __qtablewidgetitem20);
        QTableWidgetItem *__qtablewidgetitem21 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(20, __qtablewidgetitem21);
        QTableWidgetItem *__qtablewidgetitem22 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(21, __qtablewidgetitem22);
        QTableWidgetItem *__qtablewidgetitem23 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(22, __qtablewidgetitem23);
        QTableWidgetItem *__qtablewidgetitem24 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(23, __qtablewidgetitem24);
        QTableWidgetItem *__qtablewidgetitem25 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(24, __qtablewidgetitem25);
        QTableWidgetItem *__qtablewidgetitem26 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(25, __qtablewidgetitem26);
        QTableWidgetItem *__qtablewidgetitem27 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(26, __qtablewidgetitem27);
        QTableWidgetItem *__qtablewidgetitem28 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(27, __qtablewidgetitem28);
        QTableWidgetItem *__qtablewidgetitem29 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(28, __qtablewidgetitem29);
        QTableWidgetItem *__qtablewidgetitem30 = new QTableWidgetItem();
        tableWidget->setVerticalHeaderItem(29, __qtablewidgetitem30);
        QTableWidgetItem *__qtablewidgetitem31 = new QTableWidgetItem();
        __qtablewidgetitem31->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(0, 0, __qtablewidgetitem31);
        QTableWidgetItem *__qtablewidgetitem32 = new QTableWidgetItem();
        __qtablewidgetitem32->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(1, 0, __qtablewidgetitem32);
        QTableWidgetItem *__qtablewidgetitem33 = new QTableWidgetItem();
        __qtablewidgetitem33->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(2, 0, __qtablewidgetitem33);
        QTableWidgetItem *__qtablewidgetitem34 = new QTableWidgetItem();
        __qtablewidgetitem34->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(3, 0, __qtablewidgetitem34);
        QTableWidgetItem *__qtablewidgetitem35 = new QTableWidgetItem();
        __qtablewidgetitem35->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(4, 0, __qtablewidgetitem35);
        QTableWidgetItem *__qtablewidgetitem36 = new QTableWidgetItem();
        __qtablewidgetitem36->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(5, 0, __qtablewidgetitem36);
        QTableWidgetItem *__qtablewidgetitem37 = new QTableWidgetItem();
        __qtablewidgetitem37->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(6, 0, __qtablewidgetitem37);
        QTableWidgetItem *__qtablewidgetitem38 = new QTableWidgetItem();
        __qtablewidgetitem38->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(7, 0, __qtablewidgetitem38);
        QTableWidgetItem *__qtablewidgetitem39 = new QTableWidgetItem();
        __qtablewidgetitem39->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(8, 0, __qtablewidgetitem39);
        QTableWidgetItem *__qtablewidgetitem40 = new QTableWidgetItem();
        __qtablewidgetitem40->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(9, 0, __qtablewidgetitem40);
        QTableWidgetItem *__qtablewidgetitem41 = new QTableWidgetItem();
        __qtablewidgetitem41->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(10, 0, __qtablewidgetitem41);
        QTableWidgetItem *__qtablewidgetitem42 = new QTableWidgetItem();
        __qtablewidgetitem42->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(11, 0, __qtablewidgetitem42);
        QTableWidgetItem *__qtablewidgetitem43 = new QTableWidgetItem();
        __qtablewidgetitem43->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(12, 0, __qtablewidgetitem43);
        QTableWidgetItem *__qtablewidgetitem44 = new QTableWidgetItem();
        __qtablewidgetitem44->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(13, 0, __qtablewidgetitem44);
        QTableWidgetItem *__qtablewidgetitem45 = new QTableWidgetItem();
        __qtablewidgetitem45->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(14, 0, __qtablewidgetitem45);
        QTableWidgetItem *__qtablewidgetitem46 = new QTableWidgetItem();
        __qtablewidgetitem46->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(15, 0, __qtablewidgetitem46);
        QTableWidgetItem *__qtablewidgetitem47 = new QTableWidgetItem();
        __qtablewidgetitem47->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(16, 0, __qtablewidgetitem47);
        QTableWidgetItem *__qtablewidgetitem48 = new QTableWidgetItem();
        __qtablewidgetitem48->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(17, 0, __qtablewidgetitem48);
        QTableWidgetItem *__qtablewidgetitem49 = new QTableWidgetItem();
        __qtablewidgetitem49->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(18, 0, __qtablewidgetitem49);
        QTableWidgetItem *__qtablewidgetitem50 = new QTableWidgetItem();
        __qtablewidgetitem50->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(19, 0, __qtablewidgetitem50);
        QTableWidgetItem *__qtablewidgetitem51 = new QTableWidgetItem();
        __qtablewidgetitem51->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(20, 0, __qtablewidgetitem51);
        QTableWidgetItem *__qtablewidgetitem52 = new QTableWidgetItem();
        __qtablewidgetitem52->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(21, 0, __qtablewidgetitem52);
        QTableWidgetItem *__qtablewidgetitem53 = new QTableWidgetItem();
        __qtablewidgetitem53->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(22, 0, __qtablewidgetitem53);
        QTableWidgetItem *__qtablewidgetitem54 = new QTableWidgetItem();
        __qtablewidgetitem54->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(23, 0, __qtablewidgetitem54);
        QTableWidgetItem *__qtablewidgetitem55 = new QTableWidgetItem();
        __qtablewidgetitem55->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(24, 0, __qtablewidgetitem55);
        QTableWidgetItem *__qtablewidgetitem56 = new QTableWidgetItem();
        __qtablewidgetitem56->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(25, 0, __qtablewidgetitem56);
        QTableWidgetItem *__qtablewidgetitem57 = new QTableWidgetItem();
        __qtablewidgetitem57->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(26, 0, __qtablewidgetitem57);
        QTableWidgetItem *__qtablewidgetitem58 = new QTableWidgetItem();
        __qtablewidgetitem58->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(27, 0, __qtablewidgetitem58);
        QTableWidgetItem *__qtablewidgetitem59 = new QTableWidgetItem();
        __qtablewidgetitem59->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(28, 0, __qtablewidgetitem59);
        QTableWidgetItem *__qtablewidgetitem60 = new QTableWidgetItem();
        __qtablewidgetitem60->setTextAlignment(Qt::AlignCenter);
        tableWidget->setItem(29, 0, __qtablewidgetitem60);
        tableWidget->setObjectName(QString::fromUtf8("tableWidget"));
        tableWidget->setAutoFillBackground(false);
        tableWidget->setFrameShape(QFrame::WinPanel);
        tableWidget->setTextElideMode(Qt::ElideRight);
        tableWidget->setShowGrid(true);
        tableWidget->setGridStyle(Qt::SolidLine);
        tableWidget->horizontalHeader()->setVisible(false);
        tableWidget->horizontalHeader()->setCascadingSectionResizes(false);
        tableWidget->horizontalHeader()->setMinimumSectionSize(20);
        tableWidget->horizontalHeader()->setDefaultSectionSize(70);
        tableWidget->horizontalHeader()->setHighlightSections(true);
        tableWidget->horizontalHeader()->setProperty("showSortIndicator", QVariant(false));
        tableWidget->verticalHeader()->setVisible(false);
        tableWidget->verticalHeader()->setMinimumSectionSize(20);
        tableWidget->verticalHeader()->setDefaultSectionSize(25);

        gridLayout_5->addWidget(tableWidget, 0, 0, 1, 1);

        widget_2 = new QWidget(tab);
        widget_2->setObjectName(QString::fromUtf8("widget_2"));
        gridLayout_4 = new QGridLayout(widget_2);
        gridLayout_4->setObjectName(QString::fromUtf8("gridLayout_4"));
        verticalSpacer_3 = new QSpacerItem(20, 17, QSizePolicy::Minimum, QSizePolicy::Expanding);

        gridLayout_4->addItem(verticalSpacer_3, 3, 2, 1, 1);

        groupBox_2 = new QGroupBox(widget_2);
        groupBox_2->setObjectName(QString::fromUtf8("groupBox_2"));
        gridLayout_3 = new QGridLayout(groupBox_2);
        gridLayout_3->setObjectName(QString::fromUtf8("gridLayout_3"));
        buttonColAdd = new QPushButton(groupBox_2);
        buttonColAdd->setObjectName(QString::fromUtf8("buttonColAdd"));

        gridLayout_3->addWidget(buttonColAdd, 0, 0, 1, 1);

        buttonColDelete = new QPushButton(groupBox_2);
        buttonColDelete->setObjectName(QString::fromUtf8("buttonColDelete"));

        gridLayout_3->addWidget(buttonColDelete, 0, 1, 1, 1);


        gridLayout_4->addWidget(groupBox_2, 2, 0, 1, 5);

        verticalSpacer_2 = new QSpacerItem(20, 206, QSizePolicy::Minimum, QSizePolicy::Expanding);

        gridLayout_4->addItem(verticalSpacer_2, 1, 3, 1, 1);

        labelStepNum = new QLabel(widget_2);
        labelStepNum->setObjectName(QString::fromUtf8("labelStepNum"));

        gridLayout_4->addWidget(labelStepNum, 0, 1, 1, 1);

        groupBox = new QGroupBox(widget_2);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        gridLayout_2 = new QGridLayout(groupBox);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        buttonMinus = new QPushButton(groupBox);
        buttonMinus->setObjectName(QString::fromUtf8("buttonMinus"));

        gridLayout_2->addWidget(buttonMinus, 0, 0, 1, 1);

        buttonUp = new QPushButton(groupBox);
        buttonUp->setObjectName(QString::fromUtf8("buttonUp"));

        gridLayout_2->addWidget(buttonUp, 0, 1, 1, 1);

        buttonAdd = new QPushButton(groupBox);
        buttonAdd->setObjectName(QString::fromUtf8("buttonAdd"));

        gridLayout_2->addWidget(buttonAdd, 0, 2, 1, 1);

        buttonLeft = new QPushButton(groupBox);
        buttonLeft->setObjectName(QString::fromUtf8("buttonLeft"));

        gridLayout_2->addWidget(buttonLeft, 1, 0, 1, 1);

        buttonDown = new QPushButton(groupBox);
        buttonDown->setObjectName(QString::fromUtf8("buttonDown"));

        gridLayout_2->addWidget(buttonDown, 1, 1, 1, 1);

        buttonRight = new QPushButton(groupBox);
        buttonRight->setObjectName(QString::fromUtf8("buttonRight"));

        gridLayout_2->addWidget(buttonRight, 1, 2, 1, 1);


        gridLayout_4->addWidget(groupBox, 4, 0, 1, 5);

        verticalSpacer = new QSpacerItem(20, 205, QSizePolicy::Minimum, QSizePolicy::Expanding);

        gridLayout_4->addItem(verticalSpacer, 5, 3, 1, 1);

        labelStep = new QLabel(widget_2);
        labelStep->setObjectName(QString::fromUtf8("labelStep"));

        gridLayout_4->addWidget(labelStep, 0, 0, 1, 1);


        gridLayout_5->addWidget(widget_2, 0, 1, 1, 1);

        tabWidget->addTab(tab, QString());
        tabInput = new QWidget();
        tabInput->setObjectName(QString::fromUtf8("tabInput"));
        gridLayout_10 = new QGridLayout(tabInput);
        gridLayout_10->setObjectName(QString::fromUtf8("gridLayout_10"));
        tabWidgetWord = new QTabWidget(tabInput);
        tabWidgetWord->setObjectName(QString::fromUtf8("tabWidgetWord"));
        tabWidgetWord->setTabPosition(QTabWidget::East);
        tabWidgetWord->setIconSize(QSize(50, 100));
        tabNormalStepDisplay = new QWidget();
        tabNormalStepDisplay->setObjectName(QString::fromUtf8("tabNormalStepDisplay"));
        tabNormalStepDisplay->setEnabled(true);
        gridLayout_7 = new QGridLayout(tabNormalStepDisplay);
        gridLayout_7->setObjectName(QString::fromUtf8("gridLayout_7"));
        listWidgetNormal = new QListWidget(tabNormalStepDisplay);
        listWidgetNormal->setObjectName(QString::fromUtf8("listWidgetNormal"));
        QFont font;
        font.setPointSize(15);
        listWidgetNormal->setFont(font);
        listWidgetNormal->setMovement(QListView::Static);
        listWidgetNormal->setFlow(QListView::TopToBottom);
        listWidgetNormal->setResizeMode(QListView::Fixed);

        gridLayout_7->addWidget(listWidgetNormal, 1, 0, 1, 1);

        labelTabNormalName = new QLabel(tabNormalStepDisplay);
        labelTabNormalName->setObjectName(QString::fromUtf8("labelTabNormalName"));
        labelTabNormalName->setFont(font);
        labelTabNormalName->setFrameShape(QFrame::WinPanel);

        gridLayout_7->addWidget(labelTabNormalName, 0, 0, 1, 1);

        gridLayout_7->setRowStretch(0, 1);
        gridLayout_7->setRowStretch(1, 9);
        tabWidgetWord->addTab(tabNormalStepDisplay, QString());
        tabAddCommand = new QWidget();
        tabAddCommand->setObjectName(QString::fromUtf8("tabAddCommand"));
        gridLayout_9 = new QGridLayout(tabAddCommand);
        gridLayout_9->setObjectName(QString::fromUtf8("gridLayout_9"));
        tabWidgetCmd = new QTabWidget(tabAddCommand);
        tabWidgetCmd->setObjectName(QString::fromUtf8("tabWidgetCmd"));
        tabWidgetCmd->setFont(font);
        tabCmdStandard = new QWidget();
        tabCmdStandard->setObjectName(QString::fromUtf8("tabCmdStandard"));
        gridLayout_11 = new QGridLayout(tabCmdStandard);
        gridLayout_11->setObjectName(QString::fromUtf8("gridLayout_11"));
        gridLayout_11->setContentsMargins(-1, -1, 11, 11);
        listWidgetIOStd = new QListWidget(tabCmdStandard);
        listWidgetIOStd->setObjectName(QString::fromUtf8("listWidgetIOStd"));
        listWidgetIOStd->setFrameShape(QFrame::StyledPanel);

        gridLayout_11->addWidget(listWidgetIOStd, 0, 0, 1, 1);

        horizontalSpacer = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_11->addItem(horizontalSpacer, 0, 1, 1, 1);

        verticalSpacer_5 = new QSpacerItem(20, 40, QSizePolicy::Minimum, QSizePolicy::Expanding);

        gridLayout_11->addItem(verticalSpacer_5, 1, 0, 1, 1);

        gridLayout_11->setRowStretch(0, 1);
        gridLayout_11->setRowStretch(1, 1);
        gridLayout_11->setColumnStretch(0, 1);
        gridLayout_11->setColumnStretch(1, 1);
        tabWidgetCmd->addTab(tabCmdStandard, QString());
        tabAuto = new QWidget();
        tabAuto->setObjectName(QString::fromUtf8("tabAuto"));
        gridLayout_18 = new QGridLayout(tabAuto);
        gridLayout_18->setObjectName(QString::fromUtf8("gridLayout_18"));
        horizontalSpacer_5 = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_18->addItem(horizontalSpacer_5, 0, 1, 1, 1);

        listWidgetAutoCmd = new QListWidget(tabAuto);
        listWidgetAutoCmd->setObjectName(QString::fromUtf8("listWidgetAutoCmd"));

        gridLayout_18->addWidget(listWidgetAutoCmd, 0, 0, 1, 1);

        horizontalSpacer_7 = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_18->addItem(horizontalSpacer_7, 1, 2, 1, 1);

        groupBoxAuto = new QGroupBox(tabAuto);
        groupBoxAuto->setObjectName(QString::fromUtf8("groupBoxAuto"));
        gridLayout_19 = new QGridLayout(groupBoxAuto);
        gridLayout_19->setObjectName(QString::fromUtf8("gridLayout_19"));
        lineEditAddName = new QLineEdit(groupBoxAuto);
        lineEditAddName->setObjectName(QString::fromUtf8("lineEditAddName"));

        gridLayout_19->addWidget(lineEditAddName, 0, 1, 1, 1);

        comboBoxInOrOut = new QComboBox(groupBoxAuto);
        comboBoxInOrOut->addItem(QString());
        comboBoxInOrOut->addItem(QString());
        comboBoxInOrOut->setObjectName(QString::fromUtf8("comboBoxInOrOut"));

        gridLayout_19->addWidget(comboBoxInOrOut, 0, 0, 1, 1);

        buttonSureAddAutoIO = new QPushButton(groupBoxAuto);
        buttonSureAddAutoIO->setObjectName(QString::fromUtf8("buttonSureAddAutoIO"));
        QSizePolicy sizePolicy1(QSizePolicy::Preferred, QSizePolicy::Fixed);
        sizePolicy1.setHorizontalStretch(0);
        sizePolicy1.setVerticalStretch(0);
        sizePolicy1.setHeightForWidth(buttonSureAddAutoIO->sizePolicy().hasHeightForWidth());
        buttonSureAddAutoIO->setSizePolicy(sizePolicy1);

        gridLayout_19->addWidget(buttonSureAddAutoIO, 0, 2, 1, 1);

        gridLayout_19->setColumnStretch(0, 2);
        gridLayout_19->setColumnStretch(1, 6);
        gridLayout_19->setColumnStretch(2, 2);

        gridLayout_18->addWidget(groupBoxAuto, 1, 0, 1, 2);

        gridLayout_18->setRowStretch(0, 1);
        gridLayout_18->setRowStretch(1, 1);
        gridLayout_18->setColumnStretch(0, 5);
        gridLayout_18->setColumnStretch(1, 2);
        gridLayout_18->setColumnStretch(2, 3);
        tabWidgetCmd->addTab(tabAuto, QString());

        gridLayout_9->addWidget(tabWidgetCmd, 2, 0, 1, 1);

        widgetOnOrOff = new QWidget(tabAddCommand);
        widgetOnOrOff->setObjectName(QString::fromUtf8("widgetOnOrOff"));
        gridLayout_12 = new QGridLayout(widgetOnOrOff);
        gridLayout_12->setObjectName(QString::fromUtf8("gridLayout_12"));
        radioButtonOn = new QRadioButton(widgetOnOrOff);
        radioButtonOn->setObjectName(QString::fromUtf8("radioButtonOn"));
        QSizePolicy sizePolicy2(QSizePolicy::Minimum, QSizePolicy::Expanding);
        sizePolicy2.setHorizontalStretch(0);
        sizePolicy2.setVerticalStretch(0);
        sizePolicy2.setHeightForWidth(radioButtonOn->sizePolicy().hasHeightForWidth());
        radioButtonOn->setSizePolicy(sizePolicy2);
        radioButtonOn->setFont(font);
        radioButtonOn->setChecked(true);

        gridLayout_12->addWidget(radioButtonOn, 0, 0, 1, 1);

        radioButtonOff = new QRadioButton(widgetOnOrOff);
        radioButtonOff->setObjectName(QString::fromUtf8("radioButtonOff"));
        sizePolicy2.setHeightForWidth(radioButtonOff->sizePolicy().hasHeightForWidth());
        radioButtonOff->setSizePolicy(sizePolicy2);
        radioButtonOff->setFont(font);

        gridLayout_12->addWidget(radioButtonOff, 1, 0, 1, 1);


        gridLayout_9->addWidget(widgetOnOrOff, 2, 1, 1, 1);

        widgetAddAndDeleteCmd = new QWidget(tabAddCommand);
        widgetAddAndDeleteCmd->setObjectName(QString::fromUtf8("widgetAddAndDeleteCmd"));
        gridLayout_8 = new QGridLayout(widgetAddAndDeleteCmd);
        gridLayout_8->setObjectName(QString::fromUtf8("gridLayout_8"));
        buttonDeleteCmd = new QPushButton(widgetAddAndDeleteCmd);
        buttonDeleteCmd->setObjectName(QString::fromUtf8("buttonDeleteCmd"));
        sizePolicy2.setHeightForWidth(buttonDeleteCmd->sizePolicy().hasHeightForWidth());
        buttonDeleteCmd->setSizePolicy(sizePolicy2);
        buttonDeleteCmd->setFont(font);

        gridLayout_8->addWidget(buttonDeleteCmd, 0, 2, 1, 1);

        buttonAddCmd = new QPushButton(widgetAddAndDeleteCmd);
        buttonAddCmd->setObjectName(QString::fromUtf8("buttonAddCmd"));
        sizePolicy2.setHeightForWidth(buttonAddCmd->sizePolicy().hasHeightForWidth());
        buttonAddCmd->setSizePolicy(sizePolicy2);
        buttonAddCmd->setFont(font);

        gridLayout_8->addWidget(buttonAddCmd, 0, 1, 1, 1);

        tableWidgetManualIOName = new QTableWidget(widgetAddAndDeleteCmd);
        tableWidgetManualIOName->setObjectName(QString::fromUtf8("tableWidgetManualIOName"));
        tableWidgetManualIOName->horizontalHeader()->setVisible(false);
        tableWidgetManualIOName->horizontalHeader()->setStretchLastSection(false);
        tableWidgetManualIOName->verticalHeader()->setVisible(false);
        tableWidgetManualIOName->verticalHeader()->setStretchLastSection(false);

        gridLayout_8->addWidget(tableWidgetManualIOName, 0, 0, 1, 1);

        gridLayout_8->setColumnStretch(0, 6);
        gridLayout_8->setColumnStretch(1, 2);
        gridLayout_8->setColumnStretch(2, 2);

        gridLayout_9->addWidget(widgetAddAndDeleteCmd, 3, 0, 1, 2);

        labelDisplayCmd = new QLabel(tabAddCommand);
        labelDisplayCmd->setObjectName(QString::fromUtf8("labelDisplayCmd"));
        labelDisplayCmd->setFont(font);
        labelDisplayCmd->setFrameShape(QFrame::StyledPanel);

        gridLayout_9->addWidget(labelDisplayCmd, 1, 0, 1, 2);

        labelTabCmdName = new QLabel(tabAddCommand);
        labelTabCmdName->setObjectName(QString::fromUtf8("labelTabCmdName"));
        labelTabCmdName->setFont(font);
        labelTabCmdName->setFrameShape(QFrame::WinPanel);

        gridLayout_9->addWidget(labelTabCmdName, 0, 0, 1, 2);

        gridLayout_9->setRowStretch(0, 1);
        gridLayout_9->setRowStretch(1, 1);
        gridLayout_9->setRowStretch(2, 6);
        gridLayout_9->setRowStretch(3, 2);
        gridLayout_9->setColumnStretch(0, 9);
        gridLayout_9->setColumnStretch(1, 1);
        tabWidgetWord->addTab(tabAddCommand, QString());
        tabSub = new QWidget();
        tabSub->setObjectName(QString::fromUtf8("tabSub"));
        gridLayout_13 = new QGridLayout(tabSub);
        gridLayout_13->setObjectName(QString::fromUtf8("gridLayout_13"));
        tabWidgetSub = new QTabWidget(tabSub);
        tabWidgetSub->setObjectName(QString::fromUtf8("tabWidgetSub"));
        tabWidgetSub->setFont(font);
        tabJump = new QWidget();
        tabJump->setObjectName(QString::fromUtf8("tabJump"));
        gridLayout_16 = new QGridLayout(tabJump);
        gridLayout_16->setObjectName(QString::fromUtf8("gridLayout_16"));
        lineEditInputLabelNum = new QLineEdit(tabJump);
        lineEditInputLabelNum->setObjectName(QString::fromUtf8("lineEditInputLabelNum"));

        gridLayout_16->addWidget(lineEditInputLabelNum, 3, 0, 1, 1);

        verticalSpacer_4 = new QSpacerItem(20, 40, QSizePolicy::Minimum, QSizePolicy::Expanding);

        gridLayout_16->addItem(verticalSpacer_4, 1, 0, 1, 1);

        listWidgetJump = new QListWidget(tabJump);
        QFont font1;
        font1.setFamily(QString::fromUtf8("Arial"));
        font1.setPointSize(15);
        QListWidgetItem *__qlistwidgetitem = new QListWidgetItem(listWidgetJump);
        __qlistwidgetitem->setFont(font1);
        QListWidgetItem *__qlistwidgetitem1 = new QListWidgetItem(listWidgetJump);
        __qlistwidgetitem1->setFont(font1);
        listWidgetJump->setObjectName(QString::fromUtf8("listWidgetJump"));
        listWidgetJump->setFont(font);

        gridLayout_16->addWidget(listWidgetJump, 0, 0, 1, 1);

        labelInputLabelNum = new QLabel(tabJump);
        labelInputLabelNum->setObjectName(QString::fromUtf8("labelInputLabelNum"));

        gridLayout_16->addWidget(labelInputLabelNum, 2, 0, 1, 1);

        horizontalSpacer_4 = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_16->addItem(horizontalSpacer_4, 0, 1, 1, 1);

        labelLabelMsgDisplay = new QLabel(tabJump);
        labelLabelMsgDisplay->setObjectName(QString::fromUtf8("labelLabelMsgDisplay"));
        labelLabelMsgDisplay->setAlignment(Qt::AlignCenter);

        gridLayout_16->addWidget(labelLabelMsgDisplay, 0, 2, 1, 2);

        gridLayout_16->setRowStretch(0, 5);
        gridLayout_16->setRowStretch(1, 3);
        gridLayout_16->setRowStretch(2, 1);
        gridLayout_16->setRowStretch(3, 1);
        gridLayout_16->setColumnStretch(0, 2);
        gridLayout_16->setColumnStretch(1, 1);
        gridLayout_16->setColumnStretch(2, 2);
        tabWidgetSub->addTab(tabJump, QString());
        tabCustomize = new QWidget();
        tabCustomize->setObjectName(QString::fromUtf8("tabCustomize"));
        gridLayout_14 = new QGridLayout(tabCustomize);
        gridLayout_14->setObjectName(QString::fromUtf8("gridLayout_14"));
        listWidgetSubLabel = new QListWidget(tabCustomize);
        listWidgetSubLabel->setObjectName(QString::fromUtf8("listWidgetSubLabel"));

        gridLayout_14->addWidget(listWidgetSubLabel, 0, 0, 1, 1);

        widget_5 = new QWidget(tabCustomize);
        widget_5->setObjectName(QString::fromUtf8("widget_5"));

        gridLayout_14->addWidget(widget_5, 0, 2, 1, 1);

        horizontalSpacer_6 = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_14->addItem(horizontalSpacer_6, 0, 1, 1, 1);

        verticalSpacer_7 = new QSpacerItem(20, 40, QSizePolicy::Minimum, QSizePolicy::Expanding);

        gridLayout_14->addItem(verticalSpacer_7, 1, 0, 1, 1);

        gridLayout_14->setRowStretch(0, 1);
        gridLayout_14->setRowStretch(1, 1);
        gridLayout_14->setColumnStretch(0, 2);
        gridLayout_14->setColumnStretch(1, 1);
        gridLayout_14->setColumnStretch(2, 2);
        tabWidgetSub->addTab(tabCustomize, QString());

        gridLayout_13->addWidget(tabWidgetSub, 2, 0, 1, 1);

        widget_4 = new QWidget(tabSub);
        widget_4->setObjectName(QString::fromUtf8("widget_4"));
        gridLayout_20 = new QGridLayout(widget_4);
        gridLayout_20->setObjectName(QString::fromUtf8("gridLayout_20"));
        buttonFactor = new QPushButton(widget_4);
        buttonFactor->setObjectName(QString::fromUtf8("buttonFactor"));
        sizePolicy2.setHeightForWidth(buttonFactor->sizePolicy().hasHeightForWidth());
        buttonFactor->setSizePolicy(sizePolicy2);
        buttonFactor->setFont(font);

        gridLayout_20->addWidget(buttonFactor, 1, 0, 1, 1);

        verticalSpacer_6 = new QSpacerItem(20, 40, QSizePolicy::Minimum, QSizePolicy::Expanding);

        gridLayout_20->addItem(verticalSpacer_6, 0, 0, 1, 1);

        gridLayout_20->setRowStretch(0, 8);
        gridLayout_20->setRowStretch(1, 2);

        gridLayout_13->addWidget(widget_4, 2, 1, 1, 1);

        labelTabSubName = new QLabel(tabSub);
        labelTabSubName->setObjectName(QString::fromUtf8("labelTabSubName"));
        labelTabSubName->setFont(font);
        labelTabSubName->setFrameShape(QFrame::WinPanel);

        gridLayout_13->addWidget(labelTabSubName, 0, 0, 1, 2);

        labelDisplayJumpDst = new QLabel(tabSub);
        labelDisplayJumpDst->setObjectName(QString::fromUtf8("labelDisplayJumpDst"));
        labelDisplayJumpDst->setFont(font);
        labelDisplayJumpDst->setFrameShape(QFrame::StyledPanel);

        gridLayout_13->addWidget(labelDisplayJumpDst, 1, 0, 1, 2);

        widgetAddAndDeleteSub = new QWidget(tabSub);
        widgetAddAndDeleteSub->setObjectName(QString::fromUtf8("widgetAddAndDeleteSub"));
        gridLayout_15 = new QGridLayout(widgetAddAndDeleteSub);
        gridLayout_15->setObjectName(QString::fromUtf8("gridLayout_15"));
        labelExplanationSub = new QLabel(widgetAddAndDeleteSub);
        labelExplanationSub->setObjectName(QString::fromUtf8("labelExplanationSub"));
        labelExplanationSub->setFont(font);
        labelExplanationSub->setFrameShape(QFrame::StyledPanel);

        gridLayout_15->addWidget(labelExplanationSub, 0, 0, 1, 1);

        buttonAddSub = new QPushButton(widgetAddAndDeleteSub);
        buttonAddSub->setObjectName(QString::fromUtf8("buttonAddSub"));
        sizePolicy2.setHeightForWidth(buttonAddSub->sizePolicy().hasHeightForWidth());
        buttonAddSub->setSizePolicy(sizePolicy2);
        buttonAddSub->setFont(font);

        gridLayout_15->addWidget(buttonAddSub, 0, 1, 1, 1);

        buttonDeleteSub = new QPushButton(widgetAddAndDeleteSub);
        buttonDeleteSub->setObjectName(QString::fromUtf8("buttonDeleteSub"));
        sizePolicy2.setHeightForWidth(buttonDeleteSub->sizePolicy().hasHeightForWidth());
        buttonDeleteSub->setSizePolicy(sizePolicy2);
        buttonDeleteSub->setFont(font);

        gridLayout_15->addWidget(buttonDeleteSub, 0, 2, 1, 1);

        gridLayout_15->setColumnStretch(0, 6);
        gridLayout_15->setColumnStretch(1, 2);
        gridLayout_15->setColumnStretch(2, 2);

        gridLayout_13->addWidget(widgetAddAndDeleteSub, 3, 0, 1, 2);

        gridLayout_13->setRowStretch(0, 1);
        gridLayout_13->setRowStretch(1, 1);
        gridLayout_13->setRowStretch(2, 6);
        gridLayout_13->setRowStretch(3, 2);
        gridLayout_13->setColumnStretch(0, 9);
        gridLayout_13->setColumnStretch(1, 1);
        tabWidgetWord->addTab(tabSub, QString());
        tabMore = new QWidget();
        tabMore->setObjectName(QString::fromUtf8("tabMore"));
        gridLayout_17 = new QGridLayout(tabMore);
        gridLayout_17->setObjectName(QString::fromUtf8("gridLayout_17"));
        labelTabMoreName = new QLabel(tabMore);
        labelTabMoreName->setObjectName(QString::fromUtf8("labelTabMoreName"));
        labelTabMoreName->setFont(font);
        labelTabMoreName->setFrameShape(QFrame::WinPanel);

        gridLayout_17->addWidget(labelTabMoreName, 0, 0, 1, 1);

        widget_3 = new QWidget(tabMore);
        widget_3->setObjectName(QString::fromUtf8("widget_3"));
        gridLayout_22 = new QGridLayout(widget_3);
        gridLayout_22->setObjectName(QString::fromUtf8("gridLayout_22"));
        groupBoxDelay = new QGroupBox(widget_3);
        groupBoxDelay->setObjectName(QString::fromUtf8("groupBoxDelay"));
        groupBoxDelay->setFont(font);
        gridLayout_23 = new QGridLayout(groupBoxDelay);
        gridLayout_23->setObjectName(QString::fromUtf8("gridLayout_23"));
        lineEditDelay = new QLineEdit(groupBoxDelay);
        lineEditDelay->setObjectName(QString::fromUtf8("lineEditDelay"));

        gridLayout_23->addWidget(lineEditDelay, 0, 0, 1, 1);

        labelDelay = new QLabel(groupBoxDelay);
        labelDelay->setObjectName(QString::fromUtf8("labelDelay"));

        gridLayout_23->addWidget(labelDelay, 0, 1, 1, 1);


        gridLayout_22->addWidget(groupBoxDelay, 0, 0, 1, 1);

        horizontalSpacer_8 = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_22->addItem(horizontalSpacer_8, 0, 1, 1, 1);

        widgetMore = new QWidget(widget_3);
        widgetMore->setObjectName(QString::fromUtf8("widgetMore"));
        gridLayout_21 = new QGridLayout(widgetMore);
        gridLayout_21->setObjectName(QString::fromUtf8("gridLayout_21"));
        labelExplanationMore = new QLabel(widgetMore);
        labelExplanationMore->setObjectName(QString::fromUtf8("labelExplanationMore"));
        labelExplanationMore->setFont(font);
        labelExplanationMore->setFrameShape(QFrame::StyledPanel);

        gridLayout_21->addWidget(labelExplanationMore, 0, 0, 1, 1);

        buttonAddMore = new QPushButton(widgetMore);
        buttonAddMore->setObjectName(QString::fromUtf8("buttonAddMore"));
        sizePolicy2.setHeightForWidth(buttonAddMore->sizePolicy().hasHeightForWidth());
        buttonAddMore->setSizePolicy(sizePolicy2);
        buttonAddMore->setFont(font);

        gridLayout_21->addWidget(buttonAddMore, 0, 1, 1, 1);

        buttonDeleteMore = new QPushButton(widgetMore);
        buttonDeleteMore->setObjectName(QString::fromUtf8("buttonDeleteMore"));
        sizePolicy2.setHeightForWidth(buttonDeleteMore->sizePolicy().hasHeightForWidth());
        buttonDeleteMore->setSizePolicy(sizePolicy2);
        buttonDeleteMore->setFont(font);

        gridLayout_21->addWidget(buttonDeleteMore, 0, 2, 1, 1);

        gridLayout_21->setColumnStretch(0, 6);
        gridLayout_21->setColumnStretch(1, 2);
        gridLayout_21->setColumnStretch(2, 2);

        gridLayout_22->addWidget(widgetMore, 3, 0, 1, 2);

        groupBoxCnt = new QGroupBox(widget_3);
        groupBoxCnt->setObjectName(QString::fromUtf8("groupBoxCnt"));
        groupBoxCnt->setFont(font);

        gridLayout_22->addWidget(groupBoxCnt, 2, 0, 1, 2);

        groupBoxImg = new QGroupBox(widget_3);
        groupBoxImg->setObjectName(QString::fromUtf8("groupBoxImg"));
        groupBoxImg->setFont(font);
        gridLayout_24 = new QGridLayout(groupBoxImg);
        gridLayout_24->setObjectName(QString::fromUtf8("gridLayout_24"));
        widget_6 = new QWidget(groupBoxImg);
        widget_6->setObjectName(QString::fromUtf8("widget_6"));
        gridLayout_25 = new QGridLayout(widget_6);
        gridLayout_25->setObjectName(QString::fromUtf8("gridLayout_25"));
        radioButtonBeforeEject = new QRadioButton(widget_6);
        radioButtonBeforeEject->setObjectName(QString::fromUtf8("radioButtonBeforeEject"));
        radioButtonBeforeEject->setChecked(true);

        gridLayout_25->addWidget(radioButtonBeforeEject, 0, 0, 1, 1);

        radioButtonAfterEject = new QRadioButton(widget_6);
        radioButtonAfterEject->setObjectName(QString::fromUtf8("radioButtonAfterEject"));

        gridLayout_25->addWidget(radioButtonAfterEject, 0, 1, 1, 1);


        gridLayout_24->addWidget(widget_6, 0, 1, 1, 1);

        comboBoxImage = new QComboBox(groupBoxImg);
        comboBoxImage->addItem(QString());
        comboBoxImage->addItem(QString());
        comboBoxImage->addItem(QString());
        comboBoxImage->addItem(QString());
        comboBoxImage->setObjectName(QString::fromUtf8("comboBoxImage"));

        gridLayout_24->addWidget(comboBoxImage, 0, 2, 1, 1);


        gridLayout_22->addWidget(groupBoxImg, 1, 0, 1, 1);

        horizontalSpacer_9 = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout_22->addItem(horizontalSpacer_9, 1, 1, 1, 1);

        gridLayout_22->setRowStretch(0, 2);
        gridLayout_22->setRowStretch(1, 2);
        gridLayout_22->setRowStretch(2, 3);
        gridLayout_22->setRowStretch(3, 2);
        gridLayout_22->setColumnStretch(0, 1);
        gridLayout_22->setColumnStretch(1, 1);

        gridLayout_17->addWidget(widget_3, 1, 0, 1, 1);

        gridLayout_17->setRowStretch(0, 1);
        gridLayout_17->setRowStretch(1, 9);
        tabWidgetWord->addTab(tabMore, QString());

        gridLayout_10->addWidget(tabWidgetWord, 0, 0, 1, 1);

        tabWidget->addTab(tabInput, QString());

        gridLayout_6->addWidget(tabWidget, 1, 0, 1, 4);


        gridLayout->addWidget(widget, 0, 0, 1, 1);


        retranslateUi(CycleStepClass);

        tabWidget->setCurrentIndex(1);
        tabWidgetWord->setCurrentIndex(3);
        tabWidgetCmd->setCurrentIndex(0);
        tabWidgetSub->setCurrentIndex(0);


        QMetaObject::connectSlotsByName(CycleStepClass);
    } // setupUi

    void retranslateUi(QWidget *CycleStepClass)
    {
        CycleStepClass->setWindowTitle(QApplication::translate("CycleStepClass", "\345\276\252\347\216\257\346\255\245\351\252\244\350\256\276\347\275\256", nullptr));
        comboBox->setItemText(0, QApplication::translate("CycleStepClass", "\350\241\250\346\240\274\346\226\271\345\274\217", nullptr));
        comboBox->setItemText(1, QApplication::translate("CycleStepClass", "\346\226\207\345\255\227\347\274\226\350\276\221", nullptr));

        buttonSure->setText(QApplication::translate("CycleStepClass", "\347\241\256\345\256\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem = tableWidget->horizontalHeaderItem(0);
        ___qtablewidgetitem->setText(QApplication::translate("CycleStepClass", "1", nullptr));
        QTableWidgetItem *___qtablewidgetitem1 = tableWidget->verticalHeaderItem(0);
        ___qtablewidgetitem1->setText(QApplication::translate("CycleStepClass", "\346\270\205\351\231\244\350\276\223\345\205\245\347\274\223\345\206\262\345\231\250\357\274\237", nullptr));
        QTableWidgetItem *___qtablewidgetitem2 = tableWidget->verticalHeaderItem(1);
        ___qtablewidgetitem2->setText(QApplication::translate("CycleStepClass", "1\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem3 = tableWidget->verticalHeaderItem(2);
        ___qtablewidgetitem3->setText(QApplication::translate("CycleStepClass", "2\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem4 = tableWidget->verticalHeaderItem(3);
        ___qtablewidgetitem4->setText(QApplication::translate("CycleStepClass", "3\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem5 = tableWidget->verticalHeaderItem(4);
        ___qtablewidgetitem5->setText(QApplication::translate("CycleStepClass", "4\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem6 = tableWidget->verticalHeaderItem(5);
        ___qtablewidgetitem6->setText(QApplication::translate("CycleStepClass", "5\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem7 = tableWidget->verticalHeaderItem(6);
        ___qtablewidgetitem7->setText(QApplication::translate("CycleStepClass", "6\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem8 = tableWidget->verticalHeaderItem(7);
        ___qtablewidgetitem8->setText(QApplication::translate("CycleStepClass", "\346\227\240\350\276\223\345\205\245\346\227\266\350\267\263\350\277\207", nullptr));
        QTableWidgetItem *___qtablewidgetitem9 = tableWidget->verticalHeaderItem(8);
        ___qtablewidgetitem9->setText(QApplication::translate("CycleStepClass", "\346\214\211\351\222\256", nullptr));
        QTableWidgetItem *___qtablewidgetitem10 = tableWidget->verticalHeaderItem(9);
        ___qtablewidgetitem10->setText(QApplication::translate("CycleStepClass", "\345\244\232\344\270\252\350\256\241\346\225\260\345\231\250", nullptr));
        QTableWidgetItem *___qtablewidgetitem11 = tableWidget->verticalHeaderItem(10);
        ___qtablewidgetitem11->setText(QApplication::translate("CycleStepClass", "\345\275\223CNT=0\346\227\266\350\267\263\350\277\207", nullptr));
        QTableWidgetItem *___qtablewidgetitem12 = tableWidget->verticalHeaderItem(11);
        ___qtablewidgetitem12->setText(QApplication::translate("CycleStepClass", "1\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem13 = tableWidget->verticalHeaderItem(12);
        ___qtablewidgetitem13->setText(QApplication::translate("CycleStepClass", "2\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem14 = tableWidget->verticalHeaderItem(13);
        ___qtablewidgetitem14->setText(QApplication::translate("CycleStepClass", "3\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem15 = tableWidget->verticalHeaderItem(14);
        ___qtablewidgetitem15->setText(QApplication::translate("CycleStepClass", "4\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem16 = tableWidget->verticalHeaderItem(15);
        ___qtablewidgetitem16->setText(QApplication::translate("CycleStepClass", "5\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem17 = tableWidget->verticalHeaderItem(16);
        ___qtablewidgetitem17->setText(QApplication::translate("CycleStepClass", "6\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem18 = tableWidget->verticalHeaderItem(17);
        ___qtablewidgetitem18->setText(QApplication::translate("CycleStepClass", "\345\273\266\346\227\266", nullptr));
        QTableWidgetItem *___qtablewidgetitem19 = tableWidget->verticalHeaderItem(18);
        ___qtablewidgetitem19->setText(QApplication::translate("CycleStepClass", "1\357\274\232\351\241\266\345\207\272\345\211\215\345\233\276\345\203\217", nullptr));
        QTableWidgetItem *___qtablewidgetitem20 = tableWidget->verticalHeaderItem(19);
        ___qtablewidgetitem20->setText(QApplication::translate("CycleStepClass", "2\357\274\232\351\241\266\345\207\272\345\220\216\345\233\276\345\203\217", nullptr));
        QTableWidgetItem *___qtablewidgetitem21 = tableWidget->verticalHeaderItem(20);
        ___qtablewidgetitem21->setText(QApplication::translate("CycleStepClass", "3\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem22 = tableWidget->verticalHeaderItem(21);
        ___qtablewidgetitem22->setText(QApplication::translate("CycleStepClass", "4\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem23 = tableWidget->verticalHeaderItem(22);
        ___qtablewidgetitem23->setText(QApplication::translate("CycleStepClass", "5\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem24 = tableWidget->verticalHeaderItem(23);
        ___qtablewidgetitem24->setText(QApplication::translate("CycleStepClass", "6\357\274\232", nullptr));
        QTableWidgetItem *___qtablewidgetitem25 = tableWidget->verticalHeaderItem(24);
        ___qtablewidgetitem25->setText(QApplication::translate("CycleStepClass", "\346\243\200\346\237\245\345\233\276\345\203\217", nullptr));
        QTableWidgetItem *___qtablewidgetitem26 = tableWidget->verticalHeaderItem(25);
        ___qtablewidgetitem26->setText(QApplication::translate("CycleStepClass", "\345\233\276\345\203\217\345\201\234\346\255\242\346\227\266\350\267\263\350\277\207", nullptr));
        QTableWidgetItem *___qtablewidgetitem27 = tableWidget->verticalHeaderItem(26);
        ___qtablewidgetitem27->setText(QApplication::translate("CycleStepClass", "\345\233\276\345\203\217\346\211\247\350\241\214", nullptr));
        QTableWidgetItem *___qtablewidgetitem28 = tableWidget->verticalHeaderItem(27);
        ___qtablewidgetitem28->setText(QApplication::translate("CycleStepClass", "\345\276\252\347\216\257", nullptr));
        QTableWidgetItem *___qtablewidgetitem29 = tableWidget->verticalHeaderItem(28);
        ___qtablewidgetitem29->setText(QApplication::translate("CycleStepClass", "\346\211\247\350\241\214\346\227\245\345\277\227", nullptr));
        QTableWidgetItem *___qtablewidgetitem30 = tableWidget->verticalHeaderItem(29);
        ___qtablewidgetitem30->setText(QApplication::translate("CycleStepClass", "\344\270\213\344\270\200\346\255\245", nullptr));

        const bool __sortingEnabled = tableWidget->isSortingEnabled();
        tableWidget->setSortingEnabled(false);
        tableWidget->setSortingEnabled(__sortingEnabled);

        groupBox_2->setTitle(QApplication::translate("CycleStepClass", "\345\242\236\345\212\240/\345\210\240\351\231\244\345\210\227", nullptr));
        buttonColAdd->setText(QApplication::translate("CycleStepClass", "+", nullptr));
        buttonColDelete->setText(QApplication::translate("CycleStepClass", "-", nullptr));
        labelStepNum->setText(QApplication::translate("CycleStepClass", "0", nullptr));
        groupBox->setTitle(QApplication::translate("CycleStepClass", "\345\215\225\345\205\203\346\240\274\344\277\256\346\224\271", nullptr));
        buttonMinus->setText(QApplication::translate("CycleStepClass", "-", nullptr));
        buttonUp->setText(QApplication::translate("CycleStepClass", "\342\206\221", nullptr));
        buttonAdd->setText(QApplication::translate("CycleStepClass", "+", nullptr));
        buttonLeft->setText(QApplication::translate("CycleStepClass", "\342\206\220", nullptr));
        buttonDown->setText(QApplication::translate("CycleStepClass", "\342\206\223", nullptr));
        buttonRight->setText(QApplication::translate("CycleStepClass", "\342\206\222", nullptr));
        labelStep->setText(QApplication::translate("CycleStepClass", "\346\255\245\351\252\244\346\225\260\357\274\232", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(tab), QApplication::translate("CycleStepClass", "\350\241\250\346\240\274\346\226\271\345\274\217", nullptr));
        labelTabNormalName->setText(QApplication::translate("CycleStepClass", "Tab Name", nullptr));
        tabWidgetWord->setTabText(tabWidgetWord->indexOf(tabNormalStepDisplay), QString());
        tabWidgetCmd->setTabText(tabWidgetCmd->indexOf(tabCmdStandard), QApplication::translate("CycleStepClass", "\346\240\207\345\207\206", nullptr));
        groupBoxAuto->setTitle(QApplication::translate("CycleStepClass", "\350\207\252\345\256\232\344\271\211I/O", nullptr));
        comboBoxInOrOut->setItemText(0, QApplication::translate("CycleStepClass", "\345\205\201\350\256\270", nullptr));
        comboBoxInOrOut->setItemText(1, QApplication::translate("CycleStepClass", "\347\255\211\345\276\205", nullptr));

        buttonSureAddAutoIO->setText(QApplication::translate("CycleStepClass", "\347\241\256\350\256\244\346\267\273\345\212\240", nullptr));
        tabWidgetCmd->setTabText(tabWidgetCmd->indexOf(tabAuto), QApplication::translate("CycleStepClass", "\350\207\252\345\212\250", nullptr));
        radioButtonOn->setText(QApplication::translate("CycleStepClass", "ON", nullptr));
        radioButtonOff->setText(QApplication::translate("CycleStepClass", "OFF", nullptr));
        buttonDeleteCmd->setText(QApplication::translate("CycleStepClass", "\345\210\240\351\231\244", nullptr));
        buttonAddCmd->setText(QApplication::translate("CycleStepClass", "\346\267\273\345\212\240", nullptr));
        labelDisplayCmd->setText(QString());
        labelTabCmdName->setText(QApplication::translate("CycleStepClass", "Tab Name", nullptr));
        tabWidgetWord->setTabText(tabWidgetWord->indexOf(tabAddCommand), QString());
        lineEditInputLabelNum->setText(QApplication::translate("CycleStepClass", "Label - 001", nullptr));

        const bool __sortingEnabled1 = listWidgetJump->isSortingEnabled();
        listWidgetJump->setSortingEnabled(false);
        QListWidgetItem *___qlistwidgetitem = listWidgetJump->item(0);
        ___qlistwidgetitem->setText(QApplication::translate("CycleStepClass", "\350\267\263\350\267\203", nullptr));
        QListWidgetItem *___qlistwidgetitem1 = listWidgetJump->item(1);
        ___qlistwidgetitem1->setText(QApplication::translate("CycleStepClass", "\347\273\223\346\235\237", nullptr));
        listWidgetJump->setSortingEnabled(__sortingEnabled1);

        labelInputLabelNum->setText(QApplication::translate("CycleStepClass", "\350\276\223\345\205\245\346\240\207\347\255\276", nullptr));
        labelLabelMsgDisplay->setText(QString());
        tabWidgetSub->setTabText(tabWidgetSub->indexOf(tabJump), QApplication::translate("CycleStepClass", "\350\267\263\350\267\203", nullptr));
        tabWidgetSub->setTabText(tabWidgetSub->indexOf(tabCustomize), QApplication::translate("CycleStepClass", "\346\240\207\347\255\276/\345\255\220\347\250\213\345\272\217", nullptr));
        buttonFactor->setText(QApplication::translate("CycleStepClass", "\346\235\241\344\273\266", nullptr));
        labelTabSubName->setText(QApplication::translate("CycleStepClass", "Tab Name", nullptr));
        labelDisplayJumpDst->setText(QString());
        labelExplanationSub->setText(QApplication::translate("CycleStepClass", "\346\227\240\346\233\264\345\244\232\350\257\264\346\230\216", nullptr));
        buttonAddSub->setText(QApplication::translate("CycleStepClass", "\346\267\273\345\212\240", nullptr));
        buttonDeleteSub->setText(QApplication::translate("CycleStepClass", "\345\217\226\346\266\210", nullptr));
        tabWidgetWord->setTabText(tabWidgetWord->indexOf(tabSub), QString());
        labelTabMoreName->setText(QApplication::translate("CycleStepClass", "Tab Name", nullptr));
        groupBoxDelay->setTitle(QApplication::translate("CycleStepClass", "\345\273\266\346\227\266", nullptr));
        labelDelay->setText(QApplication::translate("CycleStepClass", "\357\274\210\345\215\225\344\275\215\357\274\232\346\257\253\347\247\222\357\274\211", nullptr));
        labelExplanationMore->setText(QApplication::translate("CycleStepClass", "\345\233\276\345\203\217  \351\241\266\345\207\272\345\211\215  :  \346\243\200\346\237\245", nullptr));
        buttonAddMore->setText(QApplication::translate("CycleStepClass", "\346\267\273\345\212\240", nullptr));
        buttonDeleteMore->setText(QApplication::translate("CycleStepClass", "\345\210\240\351\231\244", nullptr));
        groupBoxCnt->setTitle(QApplication::translate("CycleStepClass", "\350\256\241\346\254\241\345\231\250", nullptr));
        groupBoxImg->setTitle(QApplication::translate("CycleStepClass", "\345\233\276\345\203\217", nullptr));
        radioButtonBeforeEject->setText(QApplication::translate("CycleStepClass", "\351\241\266\345\207\272\345\211\215\345\233\276\345\203\217", nullptr));
        radioButtonAfterEject->setText(QApplication::translate("CycleStepClass", "\351\241\266\345\207\272\345\220\216\345\233\276\345\203\217", nullptr));
        comboBoxImage->setItemText(0, QApplication::translate("CycleStepClass", "\346\243\200\346\237\245", nullptr));
        comboBoxImage->setItemText(1, QApplication::translate("CycleStepClass", "\346\230\276\347\244\272", nullptr));
        comboBoxImage->setItemText(2, QApplication::translate("CycleStepClass", "\346\232\202\345\201\234", nullptr));
        comboBoxImage->setItemText(3, QApplication::translate("CycleStepClass", "\346\270\205\351\231\244", nullptr));

        tabWidgetWord->setTabText(tabWidgetWord->indexOf(tabMore), QString());
        tabWidget->setTabText(tabWidget->indexOf(tabInput), QApplication::translate("CycleStepClass", "\346\226\207\345\255\227\347\274\226\350\276\221", nullptr));
    } // retranslateUi

};

namespace Ui {
    class CycleStepClass: public Ui_CycleStepClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CYCLESTEPSETTING_H
