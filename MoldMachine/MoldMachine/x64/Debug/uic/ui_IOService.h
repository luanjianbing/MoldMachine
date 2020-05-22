/********************************************************************************
** Form generated from reading UI file 'IOService.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_IOSERVICE_H
#define UI_IOSERVICE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QCheckBox>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QTabWidget>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_IOServiceClass
{
public:
    QGridLayout *gridLayout_2;
    QWidget *widget;
    QGridLayout *gridLayout;
    QSpacerItem *horizontalSpacer;
    QPushButton *buttonApply;
    QTabWidget *tabWidget;
    QWidget *tabNameSet;
    QGroupBox *nameSetGroupBoxInput;
    QGridLayout *gridLayout_3;
    QLineEdit *lineEditInputTwo;
    QLabel *labelInputOne;
    QLineEdit *lineEditInputFour;
    QLineEdit *lineEditInputThree;
    QLineEdit *lineEditInputSix;
    QLabel *labelInputSix;
    QLineEdit *lineEditInputFive;
    QLabel *labelInputFive;
    QLabel *labelInputTwo;
    QLabel *labelInputFour;
    QLabel *labelInputThree;
    QLineEdit *lineEditInputOne;
    QGroupBox *nameSetGroupBoxOutput;
    QGridLayout *gridLayout_19;
    QLabel *labelOutputOne;
    QLineEdit *lineEditOutputOne;
    QLineEdit *lineEditOutputSix;
    QLabel *labelOutputSix;
    QLineEdit *lineEditOutputFour;
    QLabel *labelOutputFour;
    QLabel *labelOutputFive;
    QLineEdit *lineEditOutputFive;
    QLabel *labelOutputThree;
    QLineEdit *lineEditOutputTwo;
    QLabel *labelOutputTwo;
    QLineEdit *lineEditOutputThree;
    QWidget *tabIOTest;
    QGroupBox *IOTestGroupBoxInput;
    QGridLayout *gridLayout_4;
    QCheckBox *checkBoxInputThree;
    QCheckBox *checkBoxInputFive;
    QCheckBox *checkBoxInputSix;
    QCheckBox *checkBoxInputFour;
    QCheckBox *checkBoxInputOne;
    QCheckBox *checkBoxInputTwo;
    QGroupBox *IOTestGroupBoxOutput;
    QGridLayout *gridLayout_21;
    QCheckBox *checkBoxOutputSix;
    QCheckBox *checkBoxOutputThree;
    QCheckBox *checkBoxOutputOne;
    QCheckBox *checkBoxOutputFour;
    QCheckBox *checkBoxOutputTwo;
    QCheckBox *checkBoxOutputFive;
    QWidget *tabInputSet;
    QGroupBox *initialInputConditionGroupBox;
    QGridLayout *gridLayout_22;
    QCheckBox *checkBoxInitialInputFive;
    QCheckBox *checkBoxInitialInputOne;
    QCheckBox *checkBoxInitialInputTwo;
    QCheckBox *checkBoxInitialInputFour;
    QCheckBox *checkBoxInitialInputThree;
    QCheckBox *checkBoxInitialInputSix;
    QWidget *tabENetIOSet;
    QGroupBox *localSetingGroupBox;
    QGridLayout *gridLayout_6;
    QLineEdit *lineEditLocalIP;
    QGroupBox *serverIPAndPortSettingGroupBox;
    QGridLayout *gridLayout_5;
    QLineEdit *lineEditServerIP;
    QLineEdit *lineEditPort;

    void setupUi(QWidget *IOServiceClass)
    {
        if (IOServiceClass->objectName().isEmpty())
            IOServiceClass->setObjectName(QString::fromUtf8("IOServiceClass"));
        IOServiceClass->resize(750, 550);
        gridLayout_2 = new QGridLayout(IOServiceClass);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        widget = new QWidget(IOServiceClass);
        widget->setObjectName(QString::fromUtf8("widget"));
        widget->setAutoFillBackground(false);
        gridLayout = new QGridLayout(widget);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        horizontalSpacer = new QSpacerItem(40, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout->addItem(horizontalSpacer, 1, 0, 1, 1);

        buttonApply = new QPushButton(widget);
        buttonApply->setObjectName(QString::fromUtf8("buttonApply"));

        gridLayout->addWidget(buttonApply, 1, 1, 1, 1);

        tabWidget = new QTabWidget(widget);
        tabWidget->setObjectName(QString::fromUtf8("tabWidget"));
        tabWidget->setAutoFillBackground(false);
        tabNameSet = new QWidget();
        tabNameSet->setObjectName(QString::fromUtf8("tabNameSet"));
        nameSetGroupBoxInput = new QGroupBox(tabNameSet);
        nameSetGroupBoxInput->setObjectName(QString::fromUtf8("nameSetGroupBoxInput"));
        nameSetGroupBoxInput->setGeometry(QRect(20, 10, 221, 431));
        nameSetGroupBoxInput->setAutoFillBackground(false);
        gridLayout_3 = new QGridLayout(nameSetGroupBoxInput);
        gridLayout_3->setObjectName(QString::fromUtf8("gridLayout_3"));
        lineEditInputTwo = new QLineEdit(nameSetGroupBoxInput);
        lineEditInputTwo->setObjectName(QString::fromUtf8("lineEditInputTwo"));
        lineEditInputTwo->setEnabled(true);

        gridLayout_3->addWidget(lineEditInputTwo, 1, 2, 1, 1);

        labelInputOne = new QLabel(nameSetGroupBoxInput);
        labelInputOne->setObjectName(QString::fromUtf8("labelInputOne"));

        gridLayout_3->addWidget(labelInputOne, 0, 0, 1, 2);

        lineEditInputFour = new QLineEdit(nameSetGroupBoxInput);
        lineEditInputFour->setObjectName(QString::fromUtf8("lineEditInputFour"));
        lineEditInputFour->setEnabled(true);

        gridLayout_3->addWidget(lineEditInputFour, 3, 2, 1, 1);

        lineEditInputThree = new QLineEdit(nameSetGroupBoxInput);
        lineEditInputThree->setObjectName(QString::fromUtf8("lineEditInputThree"));
        lineEditInputThree->setEnabled(true);

        gridLayout_3->addWidget(lineEditInputThree, 2, 2, 1, 1);

        lineEditInputSix = new QLineEdit(nameSetGroupBoxInput);
        lineEditInputSix->setObjectName(QString::fromUtf8("lineEditInputSix"));
        lineEditInputSix->setEnabled(true);

        gridLayout_3->addWidget(lineEditInputSix, 5, 2, 1, 1);

        labelInputSix = new QLabel(nameSetGroupBoxInput);
        labelInputSix->setObjectName(QString::fromUtf8("labelInputSix"));

        gridLayout_3->addWidget(labelInputSix, 5, 0, 1, 2);

        lineEditInputFive = new QLineEdit(nameSetGroupBoxInput);
        lineEditInputFive->setObjectName(QString::fromUtf8("lineEditInputFive"));
        lineEditInputFive->setEnabled(true);

        gridLayout_3->addWidget(lineEditInputFive, 4, 2, 1, 1);

        labelInputFive = new QLabel(nameSetGroupBoxInput);
        labelInputFive->setObjectName(QString::fromUtf8("labelInputFive"));

        gridLayout_3->addWidget(labelInputFive, 4, 0, 1, 2);

        labelInputTwo = new QLabel(nameSetGroupBoxInput);
        labelInputTwo->setObjectName(QString::fromUtf8("labelInputTwo"));

        gridLayout_3->addWidget(labelInputTwo, 1, 0, 1, 2);

        labelInputFour = new QLabel(nameSetGroupBoxInput);
        labelInputFour->setObjectName(QString::fromUtf8("labelInputFour"));

        gridLayout_3->addWidget(labelInputFour, 3, 0, 1, 2);

        labelInputThree = new QLabel(nameSetGroupBoxInput);
        labelInputThree->setObjectName(QString::fromUtf8("labelInputThree"));

        gridLayout_3->addWidget(labelInputThree, 2, 0, 1, 2);

        lineEditInputOne = new QLineEdit(nameSetGroupBoxInput);
        lineEditInputOne->setObjectName(QString::fromUtf8("lineEditInputOne"));
        lineEditInputOne->setEnabled(true);

        gridLayout_3->addWidget(lineEditInputOne, 0, 2, 1, 1);

        nameSetGroupBoxOutput = new QGroupBox(tabNameSet);
        nameSetGroupBoxOutput->setObjectName(QString::fromUtf8("nameSetGroupBoxOutput"));
        nameSetGroupBoxOutput->setGeometry(QRect(260, 10, 221, 431));
        nameSetGroupBoxOutput->setAutoFillBackground(false);
        gridLayout_19 = new QGridLayout(nameSetGroupBoxOutput);
        gridLayout_19->setObjectName(QString::fromUtf8("gridLayout_19"));
        labelOutputOne = new QLabel(nameSetGroupBoxOutput);
        labelOutputOne->setObjectName(QString::fromUtf8("labelOutputOne"));

        gridLayout_19->addWidget(labelOutputOne, 0, 0, 1, 2);

        lineEditOutputOne = new QLineEdit(nameSetGroupBoxOutput);
        lineEditOutputOne->setObjectName(QString::fromUtf8("lineEditOutputOne"));
        lineEditOutputOne->setEnabled(true);

        gridLayout_19->addWidget(lineEditOutputOne, 0, 2, 1, 1);

        lineEditOutputSix = new QLineEdit(nameSetGroupBoxOutput);
        lineEditOutputSix->setObjectName(QString::fromUtf8("lineEditOutputSix"));
        lineEditOutputSix->setEnabled(true);

        gridLayout_19->addWidget(lineEditOutputSix, 5, 2, 1, 1);

        labelOutputSix = new QLabel(nameSetGroupBoxOutput);
        labelOutputSix->setObjectName(QString::fromUtf8("labelOutputSix"));

        gridLayout_19->addWidget(labelOutputSix, 5, 0, 1, 2);

        lineEditOutputFour = new QLineEdit(nameSetGroupBoxOutput);
        lineEditOutputFour->setObjectName(QString::fromUtf8("lineEditOutputFour"));
        lineEditOutputFour->setEnabled(true);

        gridLayout_19->addWidget(lineEditOutputFour, 3, 2, 1, 1);

        labelOutputFour = new QLabel(nameSetGroupBoxOutput);
        labelOutputFour->setObjectName(QString::fromUtf8("labelOutputFour"));

        gridLayout_19->addWidget(labelOutputFour, 3, 0, 1, 2);

        labelOutputFive = new QLabel(nameSetGroupBoxOutput);
        labelOutputFive->setObjectName(QString::fromUtf8("labelOutputFive"));

        gridLayout_19->addWidget(labelOutputFive, 4, 0, 1, 2);

        lineEditOutputFive = new QLineEdit(nameSetGroupBoxOutput);
        lineEditOutputFive->setObjectName(QString::fromUtf8("lineEditOutputFive"));
        lineEditOutputFive->setEnabled(true);

        gridLayout_19->addWidget(lineEditOutputFive, 4, 2, 1, 1);

        labelOutputThree = new QLabel(nameSetGroupBoxOutput);
        labelOutputThree->setObjectName(QString::fromUtf8("labelOutputThree"));

        gridLayout_19->addWidget(labelOutputThree, 2, 0, 1, 2);

        lineEditOutputTwo = new QLineEdit(nameSetGroupBoxOutput);
        lineEditOutputTwo->setObjectName(QString::fromUtf8("lineEditOutputTwo"));
        lineEditOutputTwo->setEnabled(true);

        gridLayout_19->addWidget(lineEditOutputTwo, 1, 2, 1, 1);

        labelOutputTwo = new QLabel(nameSetGroupBoxOutput);
        labelOutputTwo->setObjectName(QString::fromUtf8("labelOutputTwo"));

        gridLayout_19->addWidget(labelOutputTwo, 1, 0, 1, 2);

        lineEditOutputThree = new QLineEdit(nameSetGroupBoxOutput);
        lineEditOutputThree->setObjectName(QString::fromUtf8("lineEditOutputThree"));
        lineEditOutputThree->setEnabled(true);

        gridLayout_19->addWidget(lineEditOutputThree, 2, 2, 1, 1);

        tabWidget->addTab(tabNameSet, QString());
        tabIOTest = new QWidget();
        tabIOTest->setObjectName(QString::fromUtf8("tabIOTest"));
        IOTestGroupBoxInput = new QGroupBox(tabIOTest);
        IOTestGroupBoxInput->setObjectName(QString::fromUtf8("IOTestGroupBoxInput"));
        IOTestGroupBoxInput->setGeometry(QRect(20, 10, 221, 431));
        IOTestGroupBoxInput->setAutoFillBackground(false);
        gridLayout_4 = new QGridLayout(IOTestGroupBoxInput);
        gridLayout_4->setObjectName(QString::fromUtf8("gridLayout_4"));
        checkBoxInputThree = new QCheckBox(IOTestGroupBoxInput);
        checkBoxInputThree->setObjectName(QString::fromUtf8("checkBoxInputThree"));
        checkBoxInputThree->setEnabled(true);
        checkBoxInputThree->setCheckable(false);

        gridLayout_4->addWidget(checkBoxInputThree, 2, 0, 1, 1);

        checkBoxInputFive = new QCheckBox(IOTestGroupBoxInput);
        checkBoxInputFive->setObjectName(QString::fromUtf8("checkBoxInputFive"));
        checkBoxInputFive->setEnabled(true);
        checkBoxInputFive->setCheckable(false);

        gridLayout_4->addWidget(checkBoxInputFive, 4, 0, 1, 1);

        checkBoxInputSix = new QCheckBox(IOTestGroupBoxInput);
        checkBoxInputSix->setObjectName(QString::fromUtf8("checkBoxInputSix"));
        checkBoxInputSix->setEnabled(true);
        checkBoxInputSix->setCheckable(false);

        gridLayout_4->addWidget(checkBoxInputSix, 5, 0, 1, 1);

        checkBoxInputFour = new QCheckBox(IOTestGroupBoxInput);
        checkBoxInputFour->setObjectName(QString::fromUtf8("checkBoxInputFour"));
        checkBoxInputFour->setEnabled(true);
        checkBoxInputFour->setCheckable(false);

        gridLayout_4->addWidget(checkBoxInputFour, 3, 0, 1, 1);

        checkBoxInputOne = new QCheckBox(IOTestGroupBoxInput);
        checkBoxInputOne->setObjectName(QString::fromUtf8("checkBoxInputOne"));
        checkBoxInputOne->setEnabled(true);
        checkBoxInputOne->setCheckable(false);

        gridLayout_4->addWidget(checkBoxInputOne, 0, 0, 1, 1);

        checkBoxInputTwo = new QCheckBox(IOTestGroupBoxInput);
        checkBoxInputTwo->setObjectName(QString::fromUtf8("checkBoxInputTwo"));
        checkBoxInputTwo->setEnabled(true);
        checkBoxInputTwo->setCheckable(false);

        gridLayout_4->addWidget(checkBoxInputTwo, 1, 0, 1, 1);

        IOTestGroupBoxOutput = new QGroupBox(tabIOTest);
        IOTestGroupBoxOutput->setObjectName(QString::fromUtf8("IOTestGroupBoxOutput"));
        IOTestGroupBoxOutput->setGeometry(QRect(260, 10, 221, 431));
        IOTestGroupBoxOutput->setAutoFillBackground(false);
        gridLayout_21 = new QGridLayout(IOTestGroupBoxOutput);
        gridLayout_21->setObjectName(QString::fromUtf8("gridLayout_21"));
        checkBoxOutputSix = new QCheckBox(IOTestGroupBoxOutput);
        checkBoxOutputSix->setObjectName(QString::fromUtf8("checkBoxOutputSix"));
        checkBoxOutputSix->setEnabled(true);

        gridLayout_21->addWidget(checkBoxOutputSix, 5, 0, 1, 1);

        checkBoxOutputThree = new QCheckBox(IOTestGroupBoxOutput);
        checkBoxOutputThree->setObjectName(QString::fromUtf8("checkBoxOutputThree"));
        checkBoxOutputThree->setEnabled(true);

        gridLayout_21->addWidget(checkBoxOutputThree, 2, 0, 1, 1);

        checkBoxOutputOne = new QCheckBox(IOTestGroupBoxOutput);
        checkBoxOutputOne->setObjectName(QString::fromUtf8("checkBoxOutputOne"));
        checkBoxOutputOne->setEnabled(true);

        gridLayout_21->addWidget(checkBoxOutputOne, 0, 0, 1, 1);

        checkBoxOutputFour = new QCheckBox(IOTestGroupBoxOutput);
        checkBoxOutputFour->setObjectName(QString::fromUtf8("checkBoxOutputFour"));
        checkBoxOutputFour->setEnabled(true);

        gridLayout_21->addWidget(checkBoxOutputFour, 3, 0, 1, 1);

        checkBoxOutputTwo = new QCheckBox(IOTestGroupBoxOutput);
        checkBoxOutputTwo->setObjectName(QString::fromUtf8("checkBoxOutputTwo"));
        checkBoxOutputTwo->setEnabled(true);

        gridLayout_21->addWidget(checkBoxOutputTwo, 1, 0, 1, 1);

        checkBoxOutputFive = new QCheckBox(IOTestGroupBoxOutput);
        checkBoxOutputFive->setObjectName(QString::fromUtf8("checkBoxOutputFive"));
        checkBoxOutputFive->setEnabled(true);

        gridLayout_21->addWidget(checkBoxOutputFive, 4, 0, 1, 1);

        tabWidget->addTab(tabIOTest, QString());
        tabInputSet = new QWidget();
        tabInputSet->setObjectName(QString::fromUtf8("tabInputSet"));
        initialInputConditionGroupBox = new QGroupBox(tabInputSet);
        initialInputConditionGroupBox->setObjectName(QString::fromUtf8("initialInputConditionGroupBox"));
        initialInputConditionGroupBox->setGeometry(QRect(20, 10, 221, 431));
        initialInputConditionGroupBox->setAutoFillBackground(false);
        gridLayout_22 = new QGridLayout(initialInputConditionGroupBox);
        gridLayout_22->setObjectName(QString::fromUtf8("gridLayout_22"));
        checkBoxInitialInputFive = new QCheckBox(initialInputConditionGroupBox);
        checkBoxInitialInputFive->setObjectName(QString::fromUtf8("checkBoxInitialInputFive"));
        checkBoxInitialInputFive->setEnabled(true);
        checkBoxInitialInputFive->setTristate(false);

        gridLayout_22->addWidget(checkBoxInitialInputFive, 4, 0, 1, 1);

        checkBoxInitialInputOne = new QCheckBox(initialInputConditionGroupBox);
        checkBoxInitialInputOne->setObjectName(QString::fromUtf8("checkBoxInitialInputOne"));
        checkBoxInitialInputOne->setEnabled(true);
        checkBoxInitialInputOne->setChecked(false);
        checkBoxInitialInputOne->setTristate(false);

        gridLayout_22->addWidget(checkBoxInitialInputOne, 0, 0, 1, 1);

        checkBoxInitialInputTwo = new QCheckBox(initialInputConditionGroupBox);
        checkBoxInitialInputTwo->setObjectName(QString::fromUtf8("checkBoxInitialInputTwo"));
        checkBoxInitialInputTwo->setEnabled(true);
        checkBoxInitialInputTwo->setTristate(false);

        gridLayout_22->addWidget(checkBoxInitialInputTwo, 1, 0, 1, 1);

        checkBoxInitialInputFour = new QCheckBox(initialInputConditionGroupBox);
        checkBoxInitialInputFour->setObjectName(QString::fromUtf8("checkBoxInitialInputFour"));
        checkBoxInitialInputFour->setEnabled(true);
        checkBoxInitialInputFour->setTristate(false);

        gridLayout_22->addWidget(checkBoxInitialInputFour, 3, 0, 1, 1);

        checkBoxInitialInputThree = new QCheckBox(initialInputConditionGroupBox);
        checkBoxInitialInputThree->setObjectName(QString::fromUtf8("checkBoxInitialInputThree"));
        checkBoxInitialInputThree->setEnabled(true);
        checkBoxInitialInputThree->setTristate(false);

        gridLayout_22->addWidget(checkBoxInitialInputThree, 2, 0, 1, 1);

        checkBoxInitialInputSix = new QCheckBox(initialInputConditionGroupBox);
        checkBoxInitialInputSix->setObjectName(QString::fromUtf8("checkBoxInitialInputSix"));
        checkBoxInitialInputSix->setEnabled(true);
        checkBoxInitialInputSix->setTristate(false);

        gridLayout_22->addWidget(checkBoxInitialInputSix, 5, 0, 1, 1);

        tabWidget->addTab(tabInputSet, QString());
        tabENetIOSet = new QWidget();
        tabENetIOSet->setObjectName(QString::fromUtf8("tabENetIOSet"));
        tabENetIOSet->setAutoFillBackground(false);
        localSetingGroupBox = new QGroupBox(tabENetIOSet);
        localSetingGroupBox->setObjectName(QString::fromUtf8("localSetingGroupBox"));
        localSetingGroupBox->setGeometry(QRect(10, 20, 195, 63));
        gridLayout_6 = new QGridLayout(localSetingGroupBox);
        gridLayout_6->setObjectName(QString::fromUtf8("gridLayout_6"));
        lineEditLocalIP = new QLineEdit(localSetingGroupBox);
        lineEditLocalIP->setObjectName(QString::fromUtf8("lineEditLocalIP"));
        lineEditLocalIP->setEnabled(true);

        gridLayout_6->addWidget(lineEditLocalIP, 0, 0, 1, 1);

        serverIPAndPortSettingGroupBox = new QGroupBox(tabENetIOSet);
        serverIPAndPortSettingGroupBox->setObjectName(QString::fromUtf8("serverIPAndPortSettingGroupBox"));
        serverIPAndPortSettingGroupBox->setGeometry(QRect(10, 90, 281, 71));
        gridLayout_5 = new QGridLayout(serverIPAndPortSettingGroupBox);
        gridLayout_5->setObjectName(QString::fromUtf8("gridLayout_5"));
        lineEditServerIP = new QLineEdit(serverIPAndPortSettingGroupBox);
        lineEditServerIP->setObjectName(QString::fromUtf8("lineEditServerIP"));
        lineEditServerIP->setEnabled(true);
        lineEditServerIP->setLayoutDirection(Qt::LeftToRight);
        lineEditServerIP->setReadOnly(false);

        gridLayout_5->addWidget(lineEditServerIP, 0, 0, 1, 1);

        lineEditPort = new QLineEdit(serverIPAndPortSettingGroupBox);
        lineEditPort->setObjectName(QString::fromUtf8("lineEditPort"));
        lineEditPort->setEnabled(true);

        gridLayout_5->addWidget(lineEditPort, 0, 1, 1, 1);

        gridLayout_5->setColumnStretch(0, 7);
        gridLayout_5->setColumnStretch(1, 3);
        tabWidget->addTab(tabENetIOSet, QString());

        gridLayout->addWidget(tabWidget, 0, 0, 1, 2);


        gridLayout_2->addWidget(widget, 0, 0, 1, 1);


        retranslateUi(IOServiceClass);

        tabWidget->setCurrentIndex(0);


        QMetaObject::connectSlotsByName(IOServiceClass);
    } // setupUi

    void retranslateUi(QWidget *IOServiceClass)
    {
        IOServiceClass->setWindowTitle(QApplication::translate("IOServiceClass", "\350\276\223\345\205\245/\350\276\223\345\207\272\345\261\236\346\200\247", nullptr));
        buttonApply->setText(QApplication::translate("IOServiceClass", "\347\241\256\345\256\232", nullptr));
        nameSetGroupBoxInput->setTitle(QApplication::translate("IOServiceClass", "\350\276\223\345\205\245", nullptr));
        labelInputOne->setText(QApplication::translate("IOServiceClass", "1", nullptr));
        labelInputSix->setText(QApplication::translate("IOServiceClass", "6", nullptr));
        labelInputFive->setText(QApplication::translate("IOServiceClass", "5", nullptr));
        labelInputTwo->setText(QApplication::translate("IOServiceClass", "2", nullptr));
        labelInputFour->setText(QApplication::translate("IOServiceClass", "4", nullptr));
        labelInputThree->setText(QApplication::translate("IOServiceClass", "3", nullptr));
        lineEditInputOne->setText(QString());
        nameSetGroupBoxOutput->setTitle(QApplication::translate("IOServiceClass", "\350\276\223\345\207\272", nullptr));
        labelOutputOne->setText(QApplication::translate("IOServiceClass", "1", nullptr));
        lineEditOutputOne->setText(QString());
        lineEditOutputSix->setText(QString());
        labelOutputSix->setText(QApplication::translate("IOServiceClass", "6", nullptr));
        lineEditOutputFour->setText(QString());
        labelOutputFour->setText(QApplication::translate("IOServiceClass", "4", nullptr));
        labelOutputFive->setText(QApplication::translate("IOServiceClass", "5", nullptr));
        lineEditOutputFive->setText(QString());
        labelOutputThree->setText(QApplication::translate("IOServiceClass", "3", nullptr));
        lineEditOutputTwo->setText(QString());
        labelOutputTwo->setText(QApplication::translate("IOServiceClass", "2", nullptr));
        lineEditOutputThree->setText(QString());
        tabWidget->setTabText(tabWidget->indexOf(tabNameSet), QApplication::translate("IOServiceClass", "\350\276\223\345\205\245/\350\276\223\345\207\272\345\221\275\345\220\215", nullptr));
        IOTestGroupBoxInput->setTitle(QApplication::translate("IOServiceClass", "\350\276\223\345\205\245", nullptr));
        checkBoxInputThree->setText(QString());
        checkBoxInputFive->setText(QString());
        checkBoxInputSix->setText(QString());
        checkBoxInputFour->setText(QString());
        checkBoxInputOne->setText(QString());
        checkBoxInputTwo->setText(QString());
        IOTestGroupBoxOutput->setTitle(QApplication::translate("IOServiceClass", "\350\276\223\345\207\272", nullptr));
        checkBoxOutputSix->setText(QString());
        checkBoxOutputThree->setText(QString());
        checkBoxOutputOne->setText(QString());
        checkBoxOutputFour->setText(QString());
        checkBoxOutputTwo->setText(QString());
        checkBoxOutputFive->setText(QString());
        tabWidget->setTabText(tabWidget->indexOf(tabIOTest), QApplication::translate("IOServiceClass", "\350\276\223\345\205\245/\350\276\223\345\207\272\346\265\213\350\257\225", nullptr));
        initialInputConditionGroupBox->setTitle(QApplication::translate("IOServiceClass", "\350\276\223\345\205\245\345\210\235\345\247\213\345\200\274", nullptr));
        checkBoxInitialInputFive->setText(QString());
        checkBoxInitialInputOne->setText(QString());
        checkBoxInitialInputTwo->setText(QString());
        checkBoxInitialInputFour->setText(QString());
        checkBoxInitialInputThree->setText(QString());
        checkBoxInitialInputSix->setText(QString());
        tabWidget->setTabText(tabWidget->indexOf(tabInputSet), QApplication::translate("IOServiceClass", "\350\276\223\345\205\245\350\256\276\347\275\256", nullptr));
        localSetingGroupBox->setTitle(QApplication::translate("IOServiceClass", "\346\234\254\345\234\260I/O\346\250\241\345\235\227IP\345\234\260\345\235\200", nullptr));
        lineEditLocalIP->setText(QString());
        serverIPAndPortSettingGroupBox->setTitle(QApplication::translate("IOServiceClass", "\346\234\215\345\212\241\347\253\257IP\345\234\260\345\235\200\345\222\214\347\253\257\345\217\243Port", nullptr));
        lineEditServerIP->setText(QString());
        lineEditPort->setText(QString());
        tabWidget->setTabText(tabWidget->indexOf(tabENetIOSet), QApplication::translate("IOServiceClass", "\344\273\245\345\244\252\347\275\221\350\256\276\347\275\256", nullptr));
    } // retranslateUi

};

namespace Ui {
    class IOServiceClass: public Ui_IOServiceClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_IOSERVICE_H
