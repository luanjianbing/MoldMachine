/********************************************************************************
** Form generated from reading UI file 'Counters.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_COUNTERS_H
#define UI_COUNTERS_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_CounterClass
{
public:
    QGridLayout *gridLayout;
    QGroupBox *groupBox;
    QGridLayout *gridLayout_3;
    QWidget *widget_2;
    QGridLayout *gridLayout_2;
    QPushButton *buttonSeven;
    QPushButton *buttonSure;
    QPushButton *buttonFour;
    QPushButton *buttonZero;
    QPushButton *buttonFive;
    QPushButton *buttonThree;
    QPushButton *buttonEight;
    QPushButton *buttonTwo;
    QPushButton *buttonSix;
    QPushButton *buttonOne;
    QPushButton *buttonNine;
    QWidget *widget;
    QGroupBox *groupBox_2;
    QLabel *labelDisNumOne;
    QGroupBox *groupBox_3;
    QLabel *labelDisNumTwo;
    QPushButton *buttonSwitch;
    QPushButton *buttonClear;

    void setupUi(QWidget *CounterClass)
    {
        if (CounterClass->objectName().isEmpty())
            CounterClass->setObjectName(QString::fromUtf8("CounterClass"));
        CounterClass->resize(361, 350);
        gridLayout = new QGridLayout(CounterClass);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        groupBox = new QGroupBox(CounterClass);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        groupBox->setEnabled(true);
        gridLayout_3 = new QGridLayout(groupBox);
        gridLayout_3->setObjectName(QString::fromUtf8("gridLayout_3"));
        widget_2 = new QWidget(groupBox);
        widget_2->setObjectName(QString::fromUtf8("widget_2"));
        gridLayout_2 = new QGridLayout(widget_2);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        buttonSeven = new QPushButton(widget_2);
        buttonSeven->setObjectName(QString::fromUtf8("buttonSeven"));

        gridLayout_2->addWidget(buttonSeven, 2, 0, 1, 1);

        buttonSure = new QPushButton(widget_2);
        buttonSure->setObjectName(QString::fromUtf8("buttonSure"));

        gridLayout_2->addWidget(buttonSure, 3, 2, 1, 1);

        buttonFour = new QPushButton(widget_2);
        buttonFour->setObjectName(QString::fromUtf8("buttonFour"));

        gridLayout_2->addWidget(buttonFour, 1, 0, 1, 1);

        buttonZero = new QPushButton(widget_2);
        buttonZero->setObjectName(QString::fromUtf8("buttonZero"));

        gridLayout_2->addWidget(buttonZero, 3, 1, 1, 1);

        buttonFive = new QPushButton(widget_2);
        buttonFive->setObjectName(QString::fromUtf8("buttonFive"));

        gridLayout_2->addWidget(buttonFive, 1, 1, 1, 1);

        buttonThree = new QPushButton(widget_2);
        buttonThree->setObjectName(QString::fromUtf8("buttonThree"));

        gridLayout_2->addWidget(buttonThree, 0, 2, 1, 1);

        buttonEight = new QPushButton(widget_2);
        buttonEight->setObjectName(QString::fromUtf8("buttonEight"));

        gridLayout_2->addWidget(buttonEight, 2, 1, 1, 1);

        buttonTwo = new QPushButton(widget_2);
        buttonTwo->setObjectName(QString::fromUtf8("buttonTwo"));

        gridLayout_2->addWidget(buttonTwo, 0, 1, 1, 1);

        buttonSix = new QPushButton(widget_2);
        buttonSix->setObjectName(QString::fromUtf8("buttonSix"));

        gridLayout_2->addWidget(buttonSix, 1, 2, 1, 1);

        buttonOne = new QPushButton(widget_2);
        buttonOne->setObjectName(QString::fromUtf8("buttonOne"));

        gridLayout_2->addWidget(buttonOne, 0, 0, 1, 1);

        buttonNine = new QPushButton(widget_2);
        buttonNine->setObjectName(QString::fromUtf8("buttonNine"));

        gridLayout_2->addWidget(buttonNine, 2, 2, 1, 1);


        gridLayout_3->addWidget(widget_2, 1, 0, 1, 1);

        widget = new QWidget(groupBox);
        widget->setObjectName(QString::fromUtf8("widget"));
        groupBox_2 = new QGroupBox(widget);
        groupBox_2->setObjectName(QString::fromUtf8("groupBox_2"));
        groupBox_2->setGeometry(QRect(9, 9, 161, 51));
        labelDisNumOne = new QLabel(groupBox_2);
        labelDisNumOne->setObjectName(QString::fromUtf8("labelDisNumOne"));
        labelDisNumOne->setGeometry(QRect(10, 22, 141, 21));
        labelDisNumOne->setFrameShape(QFrame::Panel);
        groupBox_3 = new QGroupBox(widget);
        groupBox_3->setObjectName(QString::fromUtf8("groupBox_3"));
        groupBox_3->setGeometry(QRect(10, 60, 161, 51));
        labelDisNumTwo = new QLabel(groupBox_3);
        labelDisNumTwo->setObjectName(QString::fromUtf8("labelDisNumTwo"));
        labelDisNumTwo->setGeometry(QRect(10, 22, 141, 21));
        labelDisNumTwo->setFrameShape(QFrame::Panel);
        buttonSwitch = new QPushButton(widget);
        buttonSwitch->setObjectName(QString::fromUtf8("buttonSwitch"));
        buttonSwitch->setGeometry(QRect(210, 30, 91, 23));
        buttonClear = new QPushButton(widget);
        buttonClear->setObjectName(QString::fromUtf8("buttonClear"));
        buttonClear->setGeometry(QRect(210, 80, 91, 23));

        gridLayout_3->addWidget(widget, 0, 0, 1, 1);


        gridLayout->addWidget(groupBox, 0, 0, 1, 1);


        retranslateUi(CounterClass);

        QMetaObject::connectSlotsByName(CounterClass);
    } // setupUi

    void retranslateUi(QWidget *CounterClass)
    {
        CounterClass->setWindowTitle(QApplication::translate("CounterClass", "\350\256\241\346\225\260\345\231\250\350\256\276\347\275\256", nullptr));
        groupBox->setTitle(QApplication::translate("CounterClass", "\345\244\232\344\270\252\350\256\241\346\225\260\345\231\250\350\256\276\347\275\256", nullptr));
        buttonSeven->setText(QApplication::translate("CounterClass", "7", nullptr));
        buttonSure->setText(QApplication::translate("CounterClass", "\347\241\256\345\256\232", nullptr));
        buttonFour->setText(QApplication::translate("CounterClass", "4", nullptr));
        buttonZero->setText(QApplication::translate("CounterClass", "0", nullptr));
        buttonFive->setText(QApplication::translate("CounterClass", "5", nullptr));
        buttonThree->setText(QApplication::translate("CounterClass", "3", nullptr));
        buttonEight->setText(QApplication::translate("CounterClass", "8", nullptr));
        buttonTwo->setText(QApplication::translate("CounterClass", "2", nullptr));
        buttonSix->setText(QApplication::translate("CounterClass", "6", nullptr));
        buttonOne->setText(QApplication::translate("CounterClass", "1", nullptr));
        buttonNine->setText(QApplication::translate("CounterClass", "9", nullptr));
        groupBox_2->setTitle(QApplication::translate("CounterClass", "\350\256\241\346\225\260\345\231\2501", nullptr));
        labelDisNumOne->setText(QString());
        groupBox_3->setTitle(QApplication::translate("CounterClass", "\350\256\241\346\225\260\345\231\2502", nullptr));
        labelDisNumTwo->setText(QString());
        buttonSwitch->setText(QApplication::translate("CounterClass", "\345\210\207\346\215\242", nullptr));
        buttonClear->setText(QApplication::translate("CounterClass", "\346\270\205\351\231\244", nullptr));
    } // retranslateUi

};

namespace Ui {
    class CounterClass: public Ui_CounterClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_COUNTERS_H
