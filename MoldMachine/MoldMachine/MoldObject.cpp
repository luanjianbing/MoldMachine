#include "MoldObject.h"

MoldObject::MoldObject(QWidget *parent)
	: QWidget(parent)
{
	this->setFixedSize(450, 150);
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);

	moldObjParamInit();

	// buttonApply->clicked
	connect(ui.buttonApply, SIGNAL(clicked()), this, SLOT(buttonApplyClicked()));

	// combobox
	connect(ui.comboBoxObjName, SIGNAL(currentIndexChanged(int)), this, SLOT(onComboxChanged(int)));
}

void MoldObject::onComboxChanged(int id){
	curMoldId = id + 1;
	switch (id + 1)
	{
		case 1:
		{
			ui.labelObjIdDisplay->setText("1");
			break;
		}
		case 2:
		{
			ui.labelObjIdDisplay->setText("2");
			break;
		}
		default:
			break;
	}
}

void MoldObject::moldObjParamInit() {
	ParamInit objParam;
	std::map<std::string, std::string> mapObj;
	objParam.moldObjParamRead(mapObj);
	//for (std::map<std::string, std::string>::iterator iter = mapObj.begin(); iter != mapObj.end(); ++iter) {
	//	std::cout << iter->first << ":" << iter->second << std::endl;
	//}
	for (std::map<std::string, std::string>::iterator iter = mapObj.begin(); iter != mapObj.end(); ++iter) {
		ui.comboBoxObjName->addItem(QString::fromStdString(iter->first));
	}
	ui.labelObjIdDisplay->setText("1");
}

void MoldObject::buttonApplyClicked() {
	emit sendMoldId(curMoldId);
	this->close();
}

MoldObject::~MoldObject() {
	//delete this;
}