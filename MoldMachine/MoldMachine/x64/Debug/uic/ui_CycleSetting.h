/********************************************************************************
** Form generated from reading UI file 'CycleSetting.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CYCLESETTING_H
#define UI_CYCLESETTING_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_CycleClass
{
public:
    QGridLayout *gridLayout;
    QGroupBox *groupBox;
    QWidget *widget;
    QLabel *labelDisNum;
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

    void setupUi(QWidget *CycleClass)
    {
        if (CycleClass->objectName().isEmpty())
            CycleClass->setObjectName(QString::fromUtf8("CycleClass"));
        CycleClass->resize(350, 350);
        gridLayout = new QGridLayout(CycleClass);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        groupBox = new QGroupBox(CycleClass);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        widget = new QWidget(groupBox);
        widget->setObjectName(QString::fromUtf8("widget"));
        widget->setGeometry(QRect(0, 19, 311, 51));
        labelDisNum = new QLabel(widget);
        labelDisNum->setObjectName(QString::fromUtf8("labelDisNum"));
        labelDisNum->setGeometry(QRect(10, 10, 161, 31));
        labelDisNum->setAutoFillBackground(true);
        labelDisNum->setFrameShape(QFrame::StyledPanel);
        labelDisNum->setMargin(0);
        buttonClear = new QPushButton(widget);
        buttonClear->setObjectName(QString::fromUtf8("buttonClear"));
        buttonClear->setGeometry(QRect(210, 10, 101, 31));
        widget_2 = new QWidget(groupBox);
        widget_2->setObjectName(QString::fromUtf8("widget_2"));
        widget_2->setGeometry(QRect(-1, 79, 321, 241));
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


        gridLayout->addWidget(groupBox, 0, 0, 1, 1);


        retranslateUi(CycleClass);

        QMetaObject::connectSlotsByName(CycleClass);
    } // setupUi

    void retranslateUi(QWidget *CycleClass)
    {
        CycleClass->setWindowTitle(QApplication::translate("CycleClass", "\345\276\252\347\216\257\350\256\241\346\225\260\350\256\276\347\275\256", nullptr));
        groupBox->setTitle(QApplication::translate("CycleClass", "\345\276\252\347\216\257\350\256\241\346\225\260\350\256\276\347\275\256", nullptr));
        labelDisNum->setText(QString());
        buttonClear->setText(QApplication::translate("CycleClass", "\346\270\205\351\231\244", nullptr));
        buttonThree->setText(QApplication::translate("CycleClass", "3", nullptr));
        buttonTwo->setText(QApplication::translate("CycleClass", "2", nullptr));
        buttonOne->setText(QApplication::translate("CycleClass", "1", nullptr));
        buttonSeven->setText(QApplication::translate("CycleClass", "7", nullptr));
        buttonEight->setText(QApplication::translate("CycleClass", "8", nullptr));
        buttonFour->setText(QApplication::translate("CycleClass", "4", nullptr));
        buttonFive->setText(QApplication::translate("CycleClass", "5", nullptr));
        buttonSix->setText(QApplication::translate("CycleClass", "6", nullptr));
        buttonNine->setText(QApplication::translate("CycleClass", "9", nullptr));
        buttonZero->setText(QApplication::translate("CycleClass", "0", nullptr));
        buttonSure->setText(QApplication::translate("CycleClass", "\347\241\256\345\256\232", nullptr));
    } // retranslateUi

};

namespace Ui {
    class CycleClass: public Ui_CycleClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CYCLESETTING_H
