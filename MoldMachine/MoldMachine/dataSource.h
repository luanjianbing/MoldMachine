#pragma once

#include <QWidget>
#include <iostream>
#include "ui_DataSource.h"


class DataSource : public QWidget
{
	Q_OBJECT

public:
	DataSource(QWidget *parent = Q_NULLPTR);
	~DataSource();

private:
	Ui::DataSourceClass ui;

private slots:
	void buttonApplyClicked();

signals:
	void sendDataSrcChosen(int);

signals:

};
