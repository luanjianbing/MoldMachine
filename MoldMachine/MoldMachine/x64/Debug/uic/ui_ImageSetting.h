/********************************************************************************
** Form generated from reading UI file 'ImageSetting.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_IMAGESETTING_H
#define UI_IMAGESETTING_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QCheckBox>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTabWidget>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_ImageSettingClass
{
public:
    QAction *actionSave;
    QAction *actionImage;
    QAction *actionLive;
    QAction *actionDelete;
    QWidget *centralwidget;
    QGridLayout *gridLayout_2;
    QWidget *widgetLeft;
    QGridLayout *gridLayout;
    QLabel *labelPart;
    QWidget *widgetRight;
    QGridLayout *gridLayout_10;
    QTabWidget *tabWidget;
    QWidget *tabImageParamSet;
    QGridLayout *gridLayout_4;
    QGroupBox *groupBox;
    QGridLayout *gridLayout_5;
    QLineEdit *lineEditContrast;
    QGroupBox *groupBox_2;
    QGridLayout *gridLayout_6;
    QLineEdit *lineEditLight;
    QGroupBox *groupBox_3;
    QGridLayout *gridLayout_7;
    QLineEdit *lineEditBaud;
    QWidget *tabAutoDiscriminate;
    QGridLayout *gridLayout_9;
    QCheckBox *checkBoxAutoDiscriminate;
    QGroupBox *groupBox_4;
    QGridLayout *gridLayout_8;
    QLineEdit *lineEditThreshold;
    QWidget *widget;
    QGridLayout *gridLayout_3;
    QComboBox *comboBox;
    QLabel *labelAll;
    QPushButton *buttonSure;
    QStatusBar *statusbar;
    QToolBar *toolBar;

    void setupUi(QMainWindow *ImageSettingClass)
    {
        if (ImageSettingClass->objectName().isEmpty())
            ImageSettingClass->setObjectName(QString::fromUtf8("ImageSettingClass"));
        ImageSettingClass->resize(1300, 860);
        ImageSettingClass->setTabShape(QTabWidget::Rounded);
        ImageSettingClass->setUnifiedTitleAndToolBarOnMac(false);
        actionSave = new QAction(ImageSettingClass);
        actionSave->setObjectName(QString::fromUtf8("actionSave"));
        QIcon icon;
        icon.addFile(QString::fromUtf8("Resources/ico/save.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionSave->setIcon(icon);
        actionImage = new QAction(ImageSettingClass);
        actionImage->setObjectName(QString::fromUtf8("actionImage"));
        QIcon icon1;
        icon1.addFile(QString::fromUtf8("Resources/ico/pic.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionImage->setIcon(icon1);
        actionLive = new QAction(ImageSettingClass);
        actionLive->setObjectName(QString::fromUtf8("actionLive"));
        QIcon icon2;
        icon2.addFile(QString::fromUtf8("Resources/ico/uE743-live.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionLive->setIcon(icon2);
        actionDelete = new QAction(ImageSettingClass);
        actionDelete->setObjectName(QString::fromUtf8("actionDelete"));
        QIcon icon3;
        icon3.addFile(QString::fromUtf8("Resources/ico/delete.png"), QSize(), QIcon::Normal, QIcon::Off);
        actionDelete->setIcon(icon3);
        centralwidget = new QWidget(ImageSettingClass);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        gridLayout_2 = new QGridLayout(centralwidget);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        widgetLeft = new QWidget(centralwidget);
        widgetLeft->setObjectName(QString::fromUtf8("widgetLeft"));
        gridLayout = new QGridLayout(widgetLeft);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        labelPart = new QLabel(widgetLeft);
        labelPart->setObjectName(QString::fromUtf8("labelPart"));
        labelPart->setStyleSheet(QString::fromUtf8("background-color:black"));
        labelPart->setFrameShape(QFrame::WinPanel);
        labelPart->setScaledContents(false);

        gridLayout->addWidget(labelPart, 0, 0, 1, 1);


        gridLayout_2->addWidget(widgetLeft, 0, 0, 1, 1);

        widgetRight = new QWidget(centralwidget);
        widgetRight->setObjectName(QString::fromUtf8("widgetRight"));
        gridLayout_10 = new QGridLayout(widgetRight);
        gridLayout_10->setObjectName(QString::fromUtf8("gridLayout_10"));
        tabWidget = new QTabWidget(widgetRight);
        tabWidget->setObjectName(QString::fromUtf8("tabWidget"));
        tabImageParamSet = new QWidget();
        tabImageParamSet->setObjectName(QString::fromUtf8("tabImageParamSet"));
        gridLayout_4 = new QGridLayout(tabImageParamSet);
        gridLayout_4->setObjectName(QString::fromUtf8("gridLayout_4"));
        groupBox = new QGroupBox(tabImageParamSet);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        gridLayout_5 = new QGridLayout(groupBox);
        gridLayout_5->setObjectName(QString::fromUtf8("gridLayout_5"));
        lineEditContrast = new QLineEdit(groupBox);
        lineEditContrast->setObjectName(QString::fromUtf8("lineEditContrast"));

        gridLayout_5->addWidget(lineEditContrast, 0, 0, 1, 1);


        gridLayout_4->addWidget(groupBox, 0, 0, 1, 1);

        groupBox_2 = new QGroupBox(tabImageParamSet);
        groupBox_2->setObjectName(QString::fromUtf8("groupBox_2"));
        gridLayout_6 = new QGridLayout(groupBox_2);
        gridLayout_6->setObjectName(QString::fromUtf8("gridLayout_6"));
        lineEditLight = new QLineEdit(groupBox_2);
        lineEditLight->setObjectName(QString::fromUtf8("lineEditLight"));

        gridLayout_6->addWidget(lineEditLight, 0, 0, 1, 1);


        gridLayout_4->addWidget(groupBox_2, 0, 1, 1, 1);

        groupBox_3 = new QGroupBox(tabImageParamSet);
        groupBox_3->setObjectName(QString::fromUtf8("groupBox_3"));
        gridLayout_7 = new QGridLayout(groupBox_3);
        gridLayout_7->setObjectName(QString::fromUtf8("gridLayout_7"));
        lineEditBaud = new QLineEdit(groupBox_3);
        lineEditBaud->setObjectName(QString::fromUtf8("lineEditBaud"));

        gridLayout_7->addWidget(lineEditBaud, 0, 0, 1, 1);


        gridLayout_4->addWidget(groupBox_3, 0, 2, 1, 1);

        tabWidget->addTab(tabImageParamSet, QString());
        tabAutoDiscriminate = new QWidget();
        tabAutoDiscriminate->setObjectName(QString::fromUtf8("tabAutoDiscriminate"));
        gridLayout_9 = new QGridLayout(tabAutoDiscriminate);
        gridLayout_9->setObjectName(QString::fromUtf8("gridLayout_9"));
        checkBoxAutoDiscriminate = new QCheckBox(tabAutoDiscriminate);
        checkBoxAutoDiscriminate->setObjectName(QString::fromUtf8("checkBoxAutoDiscriminate"));

        gridLayout_9->addWidget(checkBoxAutoDiscriminate, 0, 0, 1, 1);

        groupBox_4 = new QGroupBox(tabAutoDiscriminate);
        groupBox_4->setObjectName(QString::fromUtf8("groupBox_4"));
        gridLayout_8 = new QGridLayout(groupBox_4);
        gridLayout_8->setObjectName(QString::fromUtf8("gridLayout_8"));
        lineEditThreshold = new QLineEdit(groupBox_4);
        lineEditThreshold->setObjectName(QString::fromUtf8("lineEditThreshold"));

        gridLayout_8->addWidget(lineEditThreshold, 0, 0, 1, 1);


        gridLayout_9->addWidget(groupBox_4, 0, 1, 1, 1);

        gridLayout_9->setColumnStretch(0, 1);
        gridLayout_9->setColumnStretch(1, 1);
        tabWidget->addTab(tabAutoDiscriminate, QString());

        gridLayout_10->addWidget(tabWidget, 0, 0, 1, 1);

        widget = new QWidget(widgetRight);
        widget->setObjectName(QString::fromUtf8("widget"));
        gridLayout_3 = new QGridLayout(widget);
        gridLayout_3->setObjectName(QString::fromUtf8("gridLayout_3"));
        comboBox = new QComboBox(widget);
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->addItem(QString());
        comboBox->setObjectName(QString::fromUtf8("comboBox"));

        gridLayout_3->addWidget(comboBox, 0, 0, 1, 1);

        labelAll = new QLabel(widget);
        labelAll->setObjectName(QString::fromUtf8("labelAll"));
        labelAll->setStyleSheet(QString::fromUtf8("background-color:black"));
        labelAll->setFrameShape(QFrame::WinPanel);
        labelAll->setScaledContents(true);

        gridLayout_3->addWidget(labelAll, 1, 0, 1, 1);

        buttonSure = new QPushButton(widget);
        buttonSure->setObjectName(QString::fromUtf8("buttonSure"));

        gridLayout_3->addWidget(buttonSure, 2, 1, 1, 1);

        gridLayout_3->setColumnStretch(0, 9);
        gridLayout_3->setColumnStretch(1, 1);

        gridLayout_10->addWidget(widget, 1, 0, 1, 1);

        gridLayout_10->setRowStretch(0, 1);
        gridLayout_10->setRowStretch(1, 1);

        gridLayout_2->addWidget(widgetRight, 0, 1, 1, 1);

        gridLayout_2->setColumnStretch(0, 5);
        gridLayout_2->setColumnStretch(1, 3);
        ImageSettingClass->setCentralWidget(centralwidget);
        statusbar = new QStatusBar(ImageSettingClass);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        ImageSettingClass->setStatusBar(statusbar);
        toolBar = new QToolBar(ImageSettingClass);
        toolBar->setObjectName(QString::fromUtf8("toolBar"));
        ImageSettingClass->addToolBar(Qt::TopToolBarArea, toolBar);

        toolBar->addAction(actionSave);
        toolBar->addSeparator();
        toolBar->addAction(actionImage);
        toolBar->addSeparator();
        toolBar->addAction(actionLive);
        toolBar->addSeparator();
        toolBar->addAction(actionDelete);
        toolBar->addSeparator();

        retranslateUi(ImageSettingClass);

        tabWidget->setCurrentIndex(0);


        QMetaObject::connectSlotsByName(ImageSettingClass);
    } // setupUi

    void retranslateUi(QMainWindow *ImageSettingClass)
    {
        ImageSettingClass->setWindowTitle(QApplication::translate("ImageSettingClass", "\345\233\276\345\203\217\350\256\276\347\275\256", nullptr));
        actionSave->setText(QApplication::translate("ImageSettingClass", "Save...", nullptr));
        actionImage->setText(QApplication::translate("ImageSettingClass", "Image", nullptr));
        actionLive->setText(QApplication::translate("ImageSettingClass", "Live", nullptr));
        actionDelete->setText(QApplication::translate("ImageSettingClass", "Delete", nullptr));
        labelPart->setText(QApplication::translate("ImageSettingClass", "Part                                                                          ", nullptr));
        groupBox->setTitle(QApplication::translate("ImageSettingClass", "\345\257\271\346\257\224\345\272\246", nullptr));
        lineEditContrast->setText(QApplication::translate("ImageSettingClass", "63", nullptr));
        groupBox_2->setTitle(QApplication::translate("ImageSettingClass", "\344\272\256\345\272\246", nullptr));
        lineEditLight->setText(QApplication::translate("ImageSettingClass", "47", nullptr));
        groupBox_3->setTitle(QApplication::translate("ImageSettingClass", "\346\263\242\346\256\265", nullptr));
        lineEditBaud->setText(QApplication::translate("ImageSettingClass", "128", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(tabImageParamSet), QApplication::translate("ImageSettingClass", "\345\233\276\345\203\217\345\217\202\346\225\260\350\256\276\347\275\256", nullptr));
        checkBoxAutoDiscriminate->setText(QApplication::translate("ImageSettingClass", "\350\207\252\345\212\250\350\276\250\345\210\253", nullptr));
        groupBox_4->setTitle(QApplication::translate("ImageSettingClass", "\345\267\256\345\210\206\351\230\210\345\200\274", nullptr));
        lineEditThreshold->setText(QApplication::translate("ImageSettingClass", "10", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(tabAutoDiscriminate), QApplication::translate("ImageSettingClass", "\350\207\252\345\212\250\350\276\250\345\210\253", nullptr));
        comboBox->setItemText(0, QApplication::translate("ImageSettingClass", "\351\273\230\350\256\244", nullptr));
        comboBox->setItemText(1, QApplication::translate("ImageSettingClass", "\346\257\224\350\276\203\345\215\241\345\260\272\345\267\245\345\205\267", nullptr));
        comboBox->setItemText(2, QApplication::translate("ImageSettingClass", "\345\215\241\345\260\272\345\267\245\345\205\267", nullptr));
        comboBox->setItemText(3, QApplication::translate("ImageSettingClass", "\350\276\271\347\274\230\346\240\207\350\256\260\345\267\245\345\205\267", nullptr));
        comboBox->setItemText(4, QApplication::translate("ImageSettingClass", "\350\256\241\346\225\260\345\231\250\345\267\245\345\205\267", nullptr));
        comboBox->setItemText(5, QApplication::translate("ImageSettingClass", "\347\211\271\345\276\201\345\210\206\346\236\220\345\267\245\345\205\267", nullptr));
        comboBox->setItemText(6, QApplication::translate("ImageSettingClass", "\345\233\276\345\203\217\346\220\234\347\264\242\345\267\245\345\205\267", nullptr));
        comboBox->setItemText(7, QApplication::translate("ImageSettingClass", "\345\234\250/\344\270\215\345\234\250\347\252\227\345\217\243", nullptr));
        comboBox->setItemText(8, QApplication::translate("ImageSettingClass", "\346\240\241\346\255\243\347\252\227\345\217\243", nullptr));
        comboBox->setItemText(9, QApplication::translate("ImageSettingClass", "\350\276\271\347\272\277\346\237\245\346\211\276\347\252\227\345\217\243", nullptr));
        comboBox->setItemText(10, QApplication::translate("ImageSettingClass", "\344\272\256\345\272\246\346\243\200\346\265\213\347\252\227\345\217\243", nullptr));
        comboBox->setItemText(11, QApplication::translate("ImageSettingClass", "\344\270\200\350\207\264\346\200\247\347\252\227\345\217\243", nullptr));
        comboBox->setItemText(12, QApplication::translate("ImageSettingClass", "\346\250\241\350\205\224\346\256\213\347\225\231\347\211\251\346\243\200\346\265\213\345\267\245\345\205\267", nullptr));

        labelAll->setText(QApplication::translate("ImageSettingClass", "All", nullptr));
        buttonSure->setText(QApplication::translate("ImageSettingClass", "\347\241\256\345\256\232", nullptr));
        toolBar->setWindowTitle(QApplication::translate("ImageSettingClass", "toolBar", nullptr));
    } // retranslateUi

};

namespace Ui {
    class ImageSettingClass: public Ui_ImageSettingClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_IMAGESETTING_H
