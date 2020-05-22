#include "dataSource.h"

DataSource::DataSource(QWidget *parent)
	: QWidget(parent)
{
	this->setFixedSize(450, 150);
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);

	// buttonApply->clicked
	connect(ui.buttonApply, SIGNAL(clicked()), this, SLOT(buttonApplyClicked()));

}

void DataSource::buttonApplyClicked() {
	if (ui.radioButtonXML->isChecked()) {
		emit sendDataSrcChosen(1);
	}
	else if (ui.radioButtonSQL->isChecked()) {
		emit sendDataSrcChosen(2);
	}
	this->close();
}

DataSource::~DataSource() {

}