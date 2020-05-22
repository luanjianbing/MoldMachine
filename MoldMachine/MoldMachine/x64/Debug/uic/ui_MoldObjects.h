/********************************************************************************
** Form generated from reading UI file 'MoldObjects.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MOLDOBJECTS_H
#define UI_MOLDOBJECTS_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MoldObjectClass
{
public:
    QGridLayout *gridLayout;
    QPushButton *buttonApply;
    QSpacerItem *horizontalSpacer;
    QGroupBox *groupBox;
    QGridLayout *gridLayout_2;
    QLabel *labelObjName;
    QComboBox *comboBoxObjName;
    QLabel *labelObjId;
    QLabel *labelObjIdDisplay;

    void setupUi(QWidget *MoldObjectClass)
    {
        if (MoldObjectClass->objectName().isEmpty())
            MoldObjectClass->setObjectName(QString::fromUtf8("MoldObjectClass"));
        MoldObjectClass->resize(450, 150);
        gridLayout = new QGridLayout(MoldObjectClass);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        buttonApply = new QPushButton(MoldObjectClass);
        buttonApply->setObjectName(QString::fromUtf8("buttonApply"));

        gridLayout->addWidget(buttonApply, 1, 1, 1, 1);

        horizontalSpacer = new QSpacerItem(325, 25, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout->addItem(horizontalSpacer, 1, 0, 1, 1);

        groupBox = new QGroupBox(MoldObjectClass);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        gridLayout_2 = new QGridLayout(groupBox);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        labelObjName = new QLabel(groupBox);
        labelObjName->setObjectName(QString::fromUtf8("labelObjName"));

        gridLayout_2->addWidget(labelObjName, 0, 0, 1, 1);

        comboBoxObjName = new QComboBox(groupBox);
        comboBoxObjName->setObjectName(QString::fromUtf8("comboBoxObjName"));

        gridLayout_2->addWidget(comboBoxObjName, 0, 1, 1, 1);

        labelObjId = new QLabel(groupBox);
        labelObjId->setObjectName(QString::fromUtf8("labelObjId"));

        gridLayout_2->addWidget(labelObjId, 1, 0, 1, 1);

        labelObjIdDisplay = new QLabel(groupBox);
        labelObjIdDisplay->setObjectName(QString::fromUtf8("labelObjIdDisplay"));

        gridLayout_2->addWidget(labelObjIdDisplay, 1, 1, 1, 1);


        gridLayout->addWidget(groupBox, 0, 0, 1, 2);


        retranslateUi(MoldObjectClass);

        QMetaObject::connectSlotsByName(MoldObjectClass);
    } // setupUi

    void retranslateUi(QWidget *MoldObjectClass)
    {
        MoldObjectClass->setWindowTitle(QApplication::translate("MoldObjectClass", "\346\250\241\345\205\267\345\257\271\350\261\241", nullptr));
        buttonApply->setText(QApplication::translate("MoldObjectClass", "\347\241\256\345\256\232", nullptr));
        groupBox->setTitle(QApplication::translate("MoldObjectClass", "\345\275\223\345\211\215\346\250\241\345\205\267\351\200\211\346\213\251", nullptr));
        labelObjName->setText(QApplication::translate("MoldObjectClass", "\345\257\271\350\261\241", nullptr));
        labelObjId->setText(QApplication::translate("MoldObjectClass", "Id", nullptr));
        labelObjIdDisplay->setText(QApplication::translate("MoldObjectClass", "to display", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MoldObjectClass: public Ui_MoldObjectClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MOLDOBJECTS_H
