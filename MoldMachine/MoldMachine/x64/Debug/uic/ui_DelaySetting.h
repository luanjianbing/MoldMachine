/********************************************************************************
** Form generated from reading UI file 'DelaySetting.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_DELAYSETTING_H
#define UI_DELAYSETTING_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_DelaySettingClass
{
public:
    QGridLayout *gridLayout;
    QGroupBox *groupBox;
    QGridLayout *gridLayout_3;
    QWidget *widget;
    QGroupBox *groupBox_2;
    QLabel *labelDisNumOne;
    QGroupBox *groupBox_3;
    QLabel *labelDisNumTwo;
    QPushButton *buttonSwitch;
    QPushButton *buttonClear;
    QWidget *widget_2;
    QGridLayout *gridLayout_2;
    QPushButton *buttonThree;
    QPushButton *buttonTwo;
    QPushButton *buttonOne;
    QPushButton *buttonSeven;
    QPushButton *buttonEight;
    QPushButton *buttonFour;
    QPushButton *buttonFive;
    QPushButton *buttonSix;
    QPushButton *buttonNine;
    QPushButton *buttonZero;
    QPushButton *buttonSure;

    void setupUi(QWidget *DelaySettingClass)
    {
        if (DelaySettingClass->objectName().isEmpty())
            DelaySettingClass->setObjectName(QString::fromUtf8("DelaySettingClass"));
        DelaySettingClass->resize(361, 350);
        gridLayout = new QGridLayout(DelaySettingClass);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        groupBox = new QGroupBox(DelaySettingClass);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        gridLayout_3 = new QGridLayout(groupBox);
        gridLayout_3->setObjectName(QString::fromUtf8("gridLayout_3"));
        widget = new QWidget(groupBox);
        widget->setObjectName(QString::fromUtf8("widget"));
        groupBox_2 = new QGroupBox(widget);
        groupBox_2->setObjectName(QString::fromUtf8("groupBox_2"));
        groupBox_2->setGeometry(QRect(9, 9, 161, 51));
        labelDisNumOne = new QLabel(groupBox_2);
        labelDisNumOne->setObjectName(QString::fromUtf8("labelDisNumOne"));
        labelDisNumOne->setEnabled(true);
        labelDisNumOne->setGeometry(QRect(10, 22, 141, 21));
        labelDisNumOne->setFrameShape(QFrame::Panel);
        groupBox_3 = new QGroupBox(widget);
        groupBox_3->setObjectName(QString::fromUtf8("groupBox_3"));
        groupBox_3->setGeometry(QRect(10, 60, 161, 51));
        labelDisNumTwo = new QLabel(groupBox_3);
        labelDisNumTwo->setObjectName(QString::fromUtf8("labelDisNumTwo"));
        labelDisNumTwo->setEnabled(true);
        labelDisNumTwo->setGeometry(QRect(10, 22, 141, 21));
        labelDisNumTwo->setFrameShape(QFrame::Panel);
        buttonSwitch = new QPushButton(widget);
        buttonSwitch->setObjectName(QString::fromUtf8("buttonSwitch"));
        buttonSwitch->setGeometry(QRect(210, 30, 91, 23));
        buttonClear = new QPushButton(widget);
        buttonClear->setObjectName(QString::fromUtf8("buttonClear"));
        buttonClear->setGeometry(QRect(210, 80, 91, 23));

        gridLayout_3->addWidget(widget, 0, 0, 1, 1);

        widget_2 = new QWidget(groupBox);
        widget_2->setObjectName(QString::fromUtf8("widget_2"));
        gridLayout_2 = new QGridLayout(widget_2);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        buttonThree = new QPushButton(widget_2);
        buttonThree->setObjectName(QString::fromUtf8("buttonThree"));

        gridLayout_2->addWidget(buttonThree, 0, 2, 1, 1);

        buttonTwo = new QPushButton(widget_2);
        buttonTwo->setObjectName(QString::fromUtf8("buttonTwo"));

        gridLayout_2->addWidget(buttonTwo, 0, 1, 1, 1);

        buttonOne = new QPushButton(widget_2);
        buttonOne->setObjectName(QString::fromUtf8("buttonOne"));

        gridLayout_2->addWidget(buttonOne, 0, 0, 1, 1);

        buttonSeven = new QPushButton(widget_2);
        buttonSeven->setObjectName(QString::fromUtf8("buttonSeven"));

        gridLayout_2->addWidget(buttonSeven, 2, 0, 1, 1);

        buttonEight = new QPushButton(widget_2);
        buttonEight->setObjectName(QString::fromUtf8("buttonEight"));

        gridLayout_2->addWidget(buttonEight, 2, 1, 1, 1);

        buttonFour = new QPushButton(widget_2);
        buttonFour->setObjectName(QString::fromUtf8("buttonFour"));

        gridLayout_2->addWidget(buttonFour, 1, 0, 1, 1);

        buttonFive = new QPushButton(widget_2);
        buttonFive->setObjectName(QString::fromUtf8("buttonFive"));

        gridLayout_2->addWidget(buttonFive, 1, 1, 1, 1);

        buttonSix = new QPushButton(widget_2);
        buttonSix->setObjectName(QString::fromUtf8("buttonSix"));

        gridLayout_2->addWidget(buttonSix, 1, 2, 1, 1);

        buttonNine = new QPushButton(widget_2);
        buttonNine->setObjectName(QString::fromUtf8("buttonNine"));

        gridLayout_2->addWidget(buttonNine, 2, 2, 1, 1);

        buttonZero = new QPushButton(widget_2);
        buttonZero->setObjectName(QString::fromUtf8("buttonZero"));

        gridLayout_2->addWidget(buttonZero, 3, 1, 1, 1);

        buttonSure = new QPushButton(widget_2);
        buttonSure->setObjectName(QString::fromUtf8("buttonSure"));

        gridLayout_2->addWidget(buttonSure, 3, 2, 1, 1);


        gridLayout_3->addWidget(widget_2, 1, 0, 1, 1);


        gridLayout->addWidget(groupBox, 0, 0, 1, 1);


        retranslateUi(DelaySettingClass);

        QMetaObject::connectSlotsByName(DelaySettingClass);
    } // setupUi

    void retranslateUi(QWidget *DelaySettingClass)
    {
        DelaySettingClass->setWindowTitle(QApplication::translate("DelaySettingClass", "\345\273\266\346\227\266\350\256\276\347\275\256", nullptr));
        groupBox->setTitle(QApplication::translate("DelaySettingClass", "\345\273\266\346\227\266\350\256\276\347\275\256", nullptr));
        groupBox_2->setTitle(QApplication::translate("DelaySettingClass", "\345\273\266\346\227\266\345\231\2501", nullptr));
        labelDisNumOne->setText(QString());
        groupBox_3->setTitle(QApplication::translate("DelaySettingClass", "\345\273\266\346\227\266\345\231\2502", nullptr));
        labelDisNumTwo->setText(QString());
        buttonSwitch->setText(QApplication::translate("DelaySettingClass", "\345\210\207\346\215\242", nullptr));
        buttonClear->setText(QApplication::translate("DelaySettingClass", "\346\270\205\351\231\244", nullptr));
        buttonThree->setText(QApplication::translate("DelaySettingClass", "3", nullptr));
        buttonTwo->setText(QApplication::translate("DelaySettingClass", "2", nullptr));
        buttonOne->setText(QApplication::translate("DelaySettingClass", "1", nullptr));
        buttonSeven->setText(QApplication::translate("DelaySettingClass", "7", nullptr));
        buttonEight->setText(QApplication::translate("DelaySettingClass", "8", nullptr));
        buttonFour->setText(QApplication::translate("DelaySettingClass", "4", nullptr));
        buttonFive->setText(QApplication::translate("DelaySettingClass", "5", nullptr));
        buttonSix->setText(QApplication::translate("DelaySettingClass", "6", nullptr));
        buttonNine->setText(QApplication::translate("DelaySettingClass", "9", nullptr));
        buttonZero->setText(QApplication::translate("DelaySettingClass", "0", nullptr));
        buttonSure->setText(QApplication::translate("DelaySettingClass", "\347\241\256\345\256\232", nullptr));
    } // retranslateUi

};

namespace Ui {
    class DelaySettingClass: public Ui_DelaySettingClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_DELAYSETTING_H
