/********************************************************************************
** Form generated from reading UI file 'DataSource.ui'
**
** Created by: Qt User Interface Compiler version 5.12.3
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_DATASOURCE_H
#define UI_DATASOURCE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGridLayout>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QRadioButton>
#include <QtWidgets/QSpacerItem>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_DataSourceClass
{
public:
    QGridLayout *gridLayout;
    QGroupBox *groupBox;
    QGridLayout *gridLayout_2;
    QRadioButton *radioButtonXML;
    QRadioButton *radioButtonSQL;
    QSpacerItem *horizontalSpacer;
    QPushButton *buttonApply;

    void setupUi(QWidget *DataSourceClass)
    {
        if (DataSourceClass->objectName().isEmpty())
            DataSourceClass->setObjectName(QString::fromUtf8("DataSourceClass"));
        DataSourceClass->resize(450, 150);
        gridLayout = new QGridLayout(DataSourceClass);
        gridLayout->setObjectName(QString::fromUtf8("gridLayout"));
        groupBox = new QGroupBox(DataSourceClass);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        gridLayout_2 = new QGridLayout(groupBox);
        gridLayout_2->setObjectName(QString::fromUtf8("gridLayout_2"));
        radioButtonXML = new QRadioButton(groupBox);
        radioButtonXML->setObjectName(QString::fromUtf8("radioButtonXML"));
        radioButtonXML->setChecked(false);

        gridLayout_2->addWidget(radioButtonXML, 0, 0, 1, 1);

        radioButtonSQL = new QRadioButton(groupBox);
        radioButtonSQL->setObjectName(QString::fromUtf8("radioButtonSQL"));
        radioButtonSQL->setCheckable(true);
        radioButtonSQL->setChecked(false);

        gridLayout_2->addWidget(radioButtonSQL, 0, 1, 1, 1);


        gridLayout->addWidget(groupBox, 0, 0, 1, 2);

        horizontalSpacer = new QSpacerItem(248, 20, QSizePolicy::Expanding, QSizePolicy::Minimum);

        gridLayout->addItem(horizontalSpacer, 1, 0, 1, 1);

        buttonApply = new QPushButton(DataSourceClass);
        buttonApply->setObjectName(QString::fromUtf8("buttonApply"));

        gridLayout->addWidget(buttonApply, 1, 1, 1, 1);


        retranslateUi(DataSourceClass);

        QMetaObject::connectSlotsByName(DataSourceClass);
    } // setupUi

    void retranslateUi(QWidget *DataSourceClass)
    {
        DataSourceClass->setWindowTitle(QApplication::translate("DataSourceClass", "Data Source", nullptr));
        groupBox->setTitle(QApplication::translate("DataSourceClass", "Data Source From", nullptr));
        radioButtonXML->setText(QApplication::translate("DataSourceClass", "XML File", nullptr));
        radioButtonSQL->setText(QApplication::translate("DataSourceClass", "MySQL DataBase", nullptr));
        buttonApply->setText(QApplication::translate("DataSourceClass", "Apply", nullptr));
    } // retranslateUi

};

namespace Ui {
    class DataSourceClass: public Ui_DataSourceClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_DATASOURCE_H
