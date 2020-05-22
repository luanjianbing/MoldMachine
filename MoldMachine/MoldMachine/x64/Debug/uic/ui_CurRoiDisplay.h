/********************************************************************************
** Form generated from reading UI file 'CurRoiDisplay.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_CURROIDISPLAY_H
#define UI_CURROIDISPLAY_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_DisplayBolckClass
{
public:
    QGridLayout *gridLayout;
    QGroupBox *groupBox;
    QGridLayout *gridLayout_2;
    QLabel *labelDis;
    QSpacerItem *horizontalSpacer;
    QPushButton *buttonSure;

    void setupUi(QWidget *DisplayBolckClass)
    {
        if (DisplayBolckClass->objectName().isEmpty())
            DisplayBolckClass->setObjectName(QString::fromUtf8("DisplayBolckClass"));
        DisplayBolckClass->resize(600, 500);
        gridLayout = new QGridLayout(DisplayBolckClass);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        groupBox = new QGroupBox(DisplayBolckClass);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        gridLayout_2 = new QGridLayout(groupBox);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        labelDis = new QLabel(groupBox);
        labelDis->setObjectName(QString::fromUtf8("labelDis"));

        gridLayout_2->addWidget(labelDis, 0, 0, 1, 1);


        gridLayout->addWidget(groupBox, 0, 0, 1, 2);

        horizontalSpacer = new QSpacerItem(498, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout->addItem(horizontalSpacer, 1, 0, 1, 1);

        buttonSure = new QPushButton(DisplayBolckClass);
        buttonSure->setObjectName(QString::fromUtf8("buttonSure"));

        gridLayout->addWidget(buttonSure, 1, 1, 1, 1);


        retranslateUi(DisplayBolckClass);

        QMetaObject::connectSlotsByName(DisplayBolckClass);
    } // setupUi

    void retranslateUi(QWidget *DisplayBolckClass)
    {
        DisplayBolckClass->setWindowTitle(QApplication::translate("DisplayBolckClass", "\345\275\223\345\211\215\351\200\211\344\270\255\345\214\272\345\237\237\345\233\276\345\203\217\346\230\276\347\244\272", nullptr));
        groupBox->setTitle(QApplication::translate("DisplayBolckClass", "ROI\345\233\276\345\203\217\346\230\276\347\244\272", nullptr));
        labelDis->setText(QApplication::translate("DisplayBolckClass", "DisPlay", nullptr));
        buttonSure->setText(QApplication::translate("DisplayBolckClass", "\347\241\256\345\256\232", nullptr));
    } // retranslateUi

};

namespace Ui {
    class DisplayBolckClass: public Ui_DisplayBolckClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_CURROIDISPLAY_H
