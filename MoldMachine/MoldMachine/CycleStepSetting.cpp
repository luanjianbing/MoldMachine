#include "CycleStepSetting.h"
#include <QDebug>

CycleStepSetting::CycleStepSetting(int curMoldId, QWidget *parent)
	:curMoldObjId(curMoldId), QWidget(parent)
{
	this->setFixedSize(1150, 950);
	ui.setupUi(this);
	this->setWindowModality(Qt::ApplicationModal);

	// 参数初始化，从数据库中读取totalStep个数据
	CycleStepInitParam();

	// 计算总列数并显示
	colCnt = ui.tableWidget->columnCount();
	ui.labelStepNum->setText(QString::number(colCnt));

	// 计算总行数
	rowCnt = ui.tableWidget->rowCount();

	// 增加/删除列
	connect(ui.buttonColAdd, SIGNAL(clicked()), this, SLOT(onButtonAddCol()));
	connect(ui.buttonColDelete, SIGNAL(clicked()), this, SLOT(onButtonDeleteCol()));

	// UP/DOWN/LEFT/RIGHT
	connect(ui.buttonUp, SIGNAL(clicked()), this, SLOT(onButtonUp()));
	connect(ui.buttonDown, SIGNAL(clicked()), this, SLOT(onButtonDown()));
	connect(ui.buttonLeft, SIGNAL(clicked()), this, SLOT(onButtonLeft()));
	connect(ui.buttonRight, SIGNAL(clicked()), this, SLOT(onButtonRight()));

	// buttonSure
	connect(ui.buttonSure, SIGNAL(clicked()), this, SLOT(onButtonSure()));

	// 修改触发
	connect(ui.tableWidget, SIGNAL(cellChanged(int, int)), this, SLOT(onItemChanged(int, int)));

	// button "+"，使单元格处于修改编辑状态
	connect(ui.buttonAdd, SIGNAL(clicked()), this, SLOT(onButtonAdd()));

	// button "-"，清除该单元格数据
	connect(ui.buttonMinus, SIGNAL(clicked()), this, SLOT(onButtonMinus()));

	// 运行模式from table or manual
	connect(ui.comboBox, SIGNAL(currentIndexChanged(int)), this, SLOT(onRunModeFrom(int)));
}

void CycleStepSetting::onButtonAdd() {
	// 使选中的单元格处于编辑状态
	ui.tableWidget->editItem(ui.tableWidget->item(ui.tableWidget->currentRow(), ui.tableWidget->currentColumn()));
}

void CycleStepSetting::onButtonMinus() {
	// 清除当前选中的单元格数据内容
	ui.tableWidget->setItem(ui.tableWidget->currentRow(), ui.tableWidget->currentColumn(), new QTableWidgetItem(""));
}

void CycleStepSetting::onItemChanged(int row, int col) {
	std::cout << "onItemChanged has triggered";
	// 修改：只能相应修改totalStep = 数据库行数 的情况，
	// 当用户有情况需要增加/减少列的情况下需要另行讨论
	if (ui.tableWidget->item(row, col)->text().toStdString() == "") {
		std::vector<std::string> _vec_modify = { std::to_string(row + 1), std::to_string(col + 1), "/" };
		vec_modify.push_back(_vec_modify);		// 得到修改的row, col, data
	}
	else {
		std::vector<std::string> _vec_modify = { std::to_string(row + 1), std::to_string(col + 1), ui.tableWidget->item(row, col)->text().toStdString() };
		vec_modify.push_back(_vec_modify);		// 得到修改的row, col, data
	}
	cycleParam.CycleStepParamSaving(vec_modify, curMoldObjId);	// 检测到有修改的地方后就更新数据库中的数据了
}

void CycleStepSetting::onButtonAddCol() {
	// 需要取消关联
	disconnect(ui.tableWidget, SIGNAL(cellChanged(int, int)), this, SLOT(onItemChanged(int, int)));

	ui.tableWidget->insertColumn(ui.tableWidget->currentColumn() + 1);
	// 给增加的列赋值""，不然在sureclick会报错
	for (int i = 0; i < rowCnt; i++)
	{
		ui.tableWidget->setItem(i, ui.tableWidget->currentColumn() + 1, new QTableWidgetItem(""));
	}

	// 更新当前列数
	colCnt = ui.tableWidget->columnCount();
	ui.labelStepNum->setText(QString::number(colCnt));

	connect(ui.tableWidget, SIGNAL(cellChanged(int, int)), this, SLOT(onItemChanged(int, int)));
}

void CycleStepSetting::onButtonDeleteCol() {
	ui.tableWidget->removeColumn(ui.tableWidget->currentColumn());
	// 更新当前列数
	colCnt = ui.tableWidget->columnCount();
	ui.labelStepNum->setText(QString::number(colCnt));
}

void CycleStepSetting::onButtonUp() {
	ui.tableWidget->setCurrentCell(current_row, current_col, QItemSelectionModel::Clear);
	ui.tableWidget->setCurrentCell(current_row - 1, current_col, QItemSelectionModel::Select);
	updateCurColRow();
}

void CycleStepSetting::onButtonDown() {
	ui.tableWidget->setCurrentCell(current_row, current_col, QItemSelectionModel::Clear);
	ui.tableWidget->setCurrentCell(current_row + 1, current_col, QItemSelectionModel::Select);
	updateCurColRow();
}

void CycleStepSetting::onButtonLeft() {
	ui.tableWidget->setCurrentCell(current_row, current_col, QItemSelectionModel::Clear);
	ui.tableWidget->setCurrentCell(current_row, current_col - 1, QItemSelectionModel::Select);
	updateCurColRow();
}

void CycleStepSetting::onButtonRight() {
	ui.tableWidget->setCurrentCell(current_row, current_col, QItemSelectionModel::Clear);
	ui.tableWidget->setCurrentCell(current_row, current_col + 1, QItemSelectionModel::Select);
	updateCurColRow();
}

void CycleStepSetting::updateCurColRow() {
	current_col = ui.tableWidget->currentColumn();
	current_row = ui.tableWidget->currentRow();

	current_row == -1 ? current_row = 0 : 1;
	current_row > rowCnt ? current_row = rowCnt : 1;
	current_col == -1 ? current_col = 0 : 1;
	current_col > colCnt ? current_col = colCnt : 1;
}

void CycleStepSetting::onButtonSure() {
	// 当user更改列的数量不等于totalStep时
	// 删表重建
	// 1.获取新设置的列数
	colCnt = ui.tableWidget->columnCount();
	if (colCnt != totalStep)
	{
		// 2.获取新列数对应的内容
		std::vector<std::vector<std::string>> vect_chg(colCnt);
		for (int i = 0; i < vect_chg.size(); i++) {
			vect_chg[i].resize(rowCnt + 1);
		}

		for (int i = 0; i < colCnt; i++) {
			for (int j = 0; j < rowCnt; j++) {
				if (ui.tableWidget->item(j, i)->text().toStdString() == "") {
					vect_chg[i][j] = "/";
				}
				else {
					vect_chg[i][j] = ui.tableWidget->item(j, i)->text().toStdString();
				}
			}
			vect_chg[i][rowCnt] = std::to_string(curMoldObjId);
		}
		
		cycleParam.CycleStepDetAndNew(vect_chg, curMoldObjId);
		//// xml文件重新创建(需要一个使用xml还是sql的标志位)
		//cycleParam.xml_CycleStepParamSaving(vect_chg);
	}

	// 去掉第一列idx再保存
	manualStepModify.resize(manualStep.size());
	for (int i = 0; i < manualStepModify.size(); i++) {
		manualStepModify[i].resize(2);
		for (int j = 0; j < manualStepModify[i].size(); j++) {
			manualStepModify[i][j] = manualStep[i][j + 1];	// 取后两列
		}
	}

	cycleParam.CycleStepManualParamSaving(manualNameVect, manualStepModify, mRelation, allConditionNum, runFromTableOrManual);

	emit sendRunFromTableOrManual(runFromTableOrManual);	// 发送运行模式信号
	
	this->close();
}

void CycleStepSetting::CycleStepInitParam() {
	std::map<std::string, std::string> m;
	
	int cnt = 0;

	cycleParam.CycleStepParamInit(vect, m, cnt, curMoldObjId);	// vect中存放的就是cycle_step表中的数据, m中存的是输入和输出的表头
	
	//cycleParam.xml_CycleStepParamInit(vect, m, cnt);
	
	cycleParam.CycleStepManualParamInit(manualNameVect, manualStep, manualSubCmd, curMoldObjId, allConditionNum, mRelation);
	normalSize = mRelation[1];
	//for (int i = 0; i < manualSubCmd.size(); i++) {
	//	for (int j = 0; j < manualSubCmd[i].size(); j++) {
	//		std::cout << manualSubCmd[i][j] << " ";
	//	}
	//	std::cout << std::endl;
	//}

	totalStep = cnt;	// 获取表的行数

	// 添加totalStep - 1列
	ui.tableWidget->setCurrentCell(0, 0, QItemSelectionModel::Select);
	for (int i = 0; i < (totalStep - 1); i++) {
		ui.tableWidget->insertColumn(ui.tableWidget->currentColumn() + 1);
	}

	// 表头数据提取
	ui.tableWidget->setVerticalHeaderItem(1, new QTableWidgetItem(m["input_name_1"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(2, new QTableWidgetItem(m["input_name_2"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(3, new QTableWidgetItem(m["input_name_3"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(4, new QTableWidgetItem(m["input_name_4"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(5, new QTableWidgetItem(m["input_name_5"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(6, new QTableWidgetItem(m["input_name_6"].c_str()));

	ui.tableWidget->setVerticalHeaderItem(11, new QTableWidgetItem(m["output_name_1"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(12, new QTableWidgetItem(m["output_name_2"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(13, new QTableWidgetItem(m["output_name_3"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(14, new QTableWidgetItem(m["output_name_4"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(15, new QTableWidgetItem(m["output_name_5"].c_str()));
	ui.tableWidget->setVerticalHeaderItem(16, new QTableWidgetItem(m["output_name_6"].c_str()));

	// 将vect的数据赋值给tabwidget，共step*(30+1)个数据，1是id,其余分别对应
	for (int i = 0; i < vect.size(); i++)
	{
		for (int j = 1; j < vect[i].size(); j++)
		{
			if (vect[i][j] == "/") {
				ui.tableWidget->setItem(j - 1, i, new QTableWidgetItem(""));
			}
			else {
				ui.tableWidget->setItem(j - 1, i, new QTableWidgetItem(vect[i][j].c_str()));
			}
		}
	}

	// 手动输入界面初始化显示数据
	sMIAllInit();
}

void CycleStepSetting::sMIAllInit() {
	// tab Normal 初始化
	sMITabNormalInit();
	// tab Insert 初始化
	sMITabInsertInit();
	// tab Sub 初始化
	sMITabSubInit();
	// tab More 初始化
	sMITabMoreInit();
}

void CycleStepSetting::sMITabMoreInit() {
	// 初始化标签tab label
	QIcon iconTabMore("./Resources/ico/tabMore.png");
	ui.tabWidgetWord->setTabIcon(3, iconTabMore);		// label on tabMore

	// 初始化tab name
	ui.labelTabMoreName->setText("更多设置");

	// delay 显示
	connect(ui.lineEditDelay, SIGNAL(editingFinished()), this, SLOT(onLineEditDelay()));

	// ratioButton image connect
	btnGroupImg = new QButtonGroup(this);
	btnGroupImg->addButton(ui.radioButtonBeforeEject);
	btnGroupImg->setId(ui.radioButtonBeforeEject, 0);
	btnGroupImg->addButton(ui.radioButtonAfterEject);
	btnGroupImg->setId(ui.radioButtonAfterEject, 1);
	connect(btnGroupImg, SIGNAL(buttonToggled(int, bool)), this, SLOT(onBtnGroupImgToggled(int, bool)));

	// combobox image
	connect(ui.comboBoxImage, SIGNAL(currentIndexChanged(int)), this, SLOT(onComboxImgChanged(int)));

	// add and delete
	connect(ui.buttonAddMore, SIGNAL(clicked()), this, SLOT(onButtonImgAdd()));
	connect(ui.buttonDeleteMore, SIGNAL(clicked()), this, SLOT(onButtonImgDelete()));
}

void CycleStepSetting::sMITabSubInit() {
	// 初始化标签tab label
	QIcon iconTabSub("./Resources/ico/tabSub.png");
	ui.tabWidgetWord->setTabIcon(2, iconTabSub);		// label on tabSub

	// 初始化tab name
	ui.labelTabSubName->setText("子程序设置");

	// 初始化输入标签lineedit规定格式
	// textEdited信号用来规定最小最大
	connect(ui.lineEditInputLabelNum, SIGNAL(textEdited(const QString &)), this, SLOT(onLineEditInputLabelNum(const QString &)));
	connect(ui.lineEditInputLabelNum, SIGNAL(editingFinished()), this, SLOT(onLineEditInputLabelNumEditFinish()));

	// connect单击jump list item指令
	connect(ui.listWidgetJump, SIGNAL(itemClicked(QListWidgetItem *)), this, SLOT(sMIDealJumpListClicked(QListWidgetItem *)));

	// 初始化标签/子程序
	// 从1开始，0为正常部分
	for (int i = 1; i < allConditionNum; i++) {
		// 显示list item
		QListWidgetItem *list = new QListWidgetItem();
		QString msgListLabel = QString("%1").arg(i, 3, 10, QLatin1Char('0'));
		list->setText(msgListLabel);
		list->setFont(QFont(msgListLabel, 15));
		ui.listWidgetSubLabel->addItem(list);
	}
	// connect单击list标签/子程序item指令
	connect(ui.listWidgetSubLabel, SIGNAL(itemClicked(QListWidgetItem *)), this, SLOT(sMIDealSubListClicked(QListWidgetItem *)));

	// 添加/取消子label
	// 添加/删除指令添加按钮点击事件
	connect(ui.buttonAddSub, SIGNAL(clicked()), this, SLOT(onButtonSubAdd()));
	connect(ui.buttonDeleteSub, SIGNAL(clicked()), this, SLOT(onButtonSubDelete()));
}

#define STANDARDIONAME 5	// 定义初始化IOname标准为前5个

void CycleStepSetting::sMITabInsertInit() {
	// 初始化标签tab label
	QIcon iconTabInsert("./Resources/ico/tabInsert.png");
	ui.tabWidgetWord->setTabIcon(1, iconTabInsert);		// label on tabInsert

	// 初始化tab name
	ui.labelTabCmdName->setText("注塑机指令修改");

	// 初始化标准list中的内容，当前规定ioname前5个为固定标准不变
	QString msgIOStd;
	// i = 0为设定的io数量
	for (int i = 1; i <= STANDARDIONAME; i++) {
		QListWidgetItem *list = new QListWidgetItem();
		msgIOStd = QString::fromStdString(manualNameVect[i][1]);
		list->setText(msgIOStd);
		list->setFont(QFont(msgIOStd, 15));
		ui.listWidgetIOStd->addItem(list);
	}
	//delete list;
	// 初始化自动list中的内容，当前规定从第6个开始为自定义内容
	QString msdIOAuto;
	for (int i = STANDARDIONAME + 1; i < manualNameVect.size(); i++) {
		QListWidgetItem *list = new QListWidgetItem();
		msgIOStd = QString::fromStdString(manualNameVect[i][1]);
		list->setText(msgIOStd);
		list->setFont(QFont(msgIOStd, 15));
		ui.listWidgetAutoCmd->addItem(list);
	}

	// 初始化表格
	//ui.tableWidgetManualIOName->setEditTriggers(QAbstractItemView::NoEditTriggers); //设置不可编辑
	// 设置为2列
	ui.tableWidgetManualIOName->setColumnCount(2);
	ui.tableWidgetManualIOName->horizontalHeader()->setSectionResizeMode(QHeaderView::Stretch);	// 拉伸
	// 添加ioNum * 2 + 1行
	ioNum = atoi(manualNameVect[0][1].c_str());
	int rowCnt = (ioNum << 1)+ 1;
	int ioThrd = ioNum + 1;
	for (int i = 0; i < rowCnt; i++) {
		ui.tableWidgetManualIOName->insertRow(ui.tableWidgetManualIOName->currentRow() + 1);
	}
	// 初始化IO数量（第一行）
	QTableWidgetItem *itemIO = new QTableWidgetItem();
	QTableWidgetItem *itemIONum = new QTableWidgetItem();
	itemIO->setText("外围输入/输出口数量");
	itemIO->setFlags(itemIO->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
	ui.tableWidgetManualIOName->setItem(0, 0, itemIO);
	itemIONum->setText(QString::fromStdString(manualNameVect[0][1]));	// 默认可编辑状态
	ui.tableWidgetManualIOName->setItem(0, 1, itemIONum);
	ui.tableWidgetManualIOName->item(0, 0)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
	ui.tableWidgetManualIOName->item(0, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
	
	// 初始化第一列
	for (int i = 1; i < ioThrd; i++) {
		QString iMsg = "输入 ";
		iMsg.append(QString::number(i));
		QTableWidgetItem *itemInput = new QTableWidgetItem();
		itemInput->setText(iMsg);
		itemInput->setFlags(itemInput->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
		ui.tableWidgetManualIOName->setItem(i, 0, itemInput);
		ui.tableWidgetManualIOName->item(i, 0)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
	}
	for (int i = ioThrd; i < rowCnt; i++) {
		QString oMsg = "输出 ";
		oMsg.append(QString::number(i - ioNum));
		QTableWidgetItem *itemOutput = new QTableWidgetItem();
		itemOutput->setText(oMsg);
		itemOutput->setFlags(itemOutput->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
		ui.tableWidgetManualIOName->setItem(i, 0, itemOutput);
		ui.tableWidgetManualIOName->item(i, 0)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
	}
	// 初始化第2列
	// 插入已有标准信息（不可编辑）
	for (int i = 1; i <= STANDARDIONAME; i++) {
		QString ioNameMsg = QString::fromStdString(manualNameVect[i][1]);	// 获取该信息
		if (ioNameMsg.startsWith("允许")) {	// 输出
			curOutputNum++;	// 计数总共当前有多少个输出已经定义
			QTableWidgetItem *itemOutput = new QTableWidgetItem();
			itemOutput->setText(ioNameMsg);
			itemOutput->setFlags(itemOutput->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
			int outputIdx = atoi(manualNameVect[i][2].c_str()) + ioNum;
			ui.tableWidgetManualIOName->setItem(outputIdx, 1, itemOutput);
			ui.tableWidgetManualIOName->item(outputIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
		}
		else if (ioNameMsg.startsWith("等待")) {	// 输入
			curInputNum++;	// 计数总共当前有多少个输入已经定义
			QTableWidgetItem *itemInput = new QTableWidgetItem();
			itemInput->setText(ioNameMsg);
			itemInput->setFlags(itemInput->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
			int inputIdx = atoi(manualNameVect[i][2].c_str());
			ui.tableWidgetManualIOName->setItem(inputIdx, 1, itemInput);
			ui.tableWidgetManualIOName->item(inputIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
		}
	}
	
	// 插入已有非标准信息（可编辑）
	for (int i = STANDARDIONAME + 1; i < manualNameVect.size(); i++) {
		QString ioNameMsg = QString::fromStdString(manualNameVect[i][1]);	// 获取该信息
		if (ioNameMsg.startsWith("允许")) {	// 输出
			curOutputNum++;	// 计数总共当前有多少个输出已经定义
			QTableWidgetItem *itemOutput = new QTableWidgetItem();
			itemOutput->setText(ioNameMsg);
			int outputIdx = atoi(manualNameVect[i][2].c_str()) + ioNum;
			ui.tableWidgetManualIOName->setItem(outputIdx, 1, itemOutput);
			ui.tableWidgetManualIOName->item(outputIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
		}
		else if (ioNameMsg.startsWith("等待")) {	// 输入
			curInputNum++;	// 计数总共当前有多少个输入已经定义
			QTableWidgetItem *itemInput = new QTableWidgetItem();
			itemInput->setText(ioNameMsg);
			int inputIdx = atoi(manualNameVect[i][2].c_str());
			ui.tableWidgetManualIOName->setItem(inputIdx, 1, itemInput);
			ui.tableWidgetManualIOName->item(inputIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
		}
	}
	//再次进行判断对于未有item的单元格设定初始化不可编辑
	for (int i = 1; i < rowCnt; i++) {
		if (ui.tableWidgetManualIOName->item(i, 1) == 0) {	// 判断单元格为空
			QTableWidgetItem *itemNone = new QTableWidgetItem();
			itemNone->setFlags(itemIO->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
			ui.tableWidgetManualIOName->setItem(i, 1, itemNone);
		}
	}

	//// 根据ioNum初始化自定义部分IO下拉框
	//// 目前定义ioNum大于6
	//for (int i = 0; i < ioNum; i++) {
	//	ui.comboBoxIOIdx->addItem(QString::number(i + 1));
	//}

	// connect单击item指令
	connect(ui.listWidgetIOStd, SIGNAL(itemClicked(QListWidgetItem *)), this, SLOT(sMIDealStdListClicked(QListWidgetItem *)));

	// 大于标准数量的时候, connect autoList单击指令
	if (manualNameVect.size() > STANDARDIONAME) {
		connect(ui.listWidgetAutoCmd, SIGNAL(itemClicked(QListWidgetItem *)), this, SLOT(sMIDealStdListClicked(QListWidgetItem *)));
	}

	// ratioButton connect
	btnGroup = new QButtonGroup(this);
	btnGroup->addButton(ui.radioButtonOn);
	btnGroup->setId(ui.radioButtonOn, 0);
	btnGroup->addButton(ui.radioButtonOff);
	btnGroup->setId(ui.radioButtonOff, 1);
	connect(btnGroup, SIGNAL(buttonToggled(int, bool)), this, SLOT(onBtnGroupToggled(int, bool)));

	// connect 自定义IO
	connect(ui.buttonSureAddAutoIO, SIGNAL(clicked()), this, SLOT(onButtonAddIOClicked()));

	// connect 表格编辑事件
	connect(ui.tableWidgetManualIOName, SIGNAL(itemChanged(QTableWidgetItem *)), this, SLOT(onTableWidgetItemChanged(QTableWidgetItem *)));

	// 添加/删除指令添加按钮点击事件
	connect(ui.buttonAddCmd, SIGNAL(clicked()), this, SLOT(onButtonIOCmdAdd()));
	connect(ui.buttonDeleteCmd, SIGNAL(clicked()), this, SLOT(onButtonIOCmdDelete()));
}

void CycleStepSetting::sMITabNormalInit() {
	// 初始化标签tab label
	QIcon iconTabNormal("./Resources/ico/tabNormal.png");
	ui.tabWidgetWord->setTabIcon(0, iconTabNormal);		// label on tabNormal

	// 初始化tab name
	ui.labelTabNormalName->setText("正常循环逻辑");

	bool flagStartWithSharp;
	//int i = 0;	// 正常处理起始点
	// 正常处理步骤数据初始化
	for (int i = 0; i < normalSize; ++i) {
		std::string curCmd = manualStep[i][1];
		flagStartWithSharp = curCmd.find("#");
		QListWidgetItem *list = new QListWidgetItem();
		QString msgNormal = QString("  %1").arg(i, 4, 10, QLatin1Char('0'));

		if (flagStartWithSharp) {	// 没有"#"
			if (curCmd == "跟踪") {
				msgNormal.append("  跟踪");
				list->setText(msgNormal);
				ui.listWidgetNormal->addItem(list);
			}
			else if (curCmd == "保存") {
				msgNormal.append("  保存");
				list->setText(msgNormal);
				ui.listWidgetNormal->addItem(list);
			}
		}
		else {		// 有#：输入、输出、图像
			std::vector<std::string> splitWithSharp = split(curCmd, '#');
			// 分割完了后第一位是空格？
			if (splitWithSharp.size() == 4 + 1) {	// IO操作 
				if (splitWithSharp[1] == "0") {	// 输出口操作;
					msgNormal.append("  允许  IMM :  ").append(QString::fromStdString(splitWithSharp[4])).append("  =  ");
					if (splitWithSharp[3] == "0") {
						msgNormal.append("OFF");
					}
					else {
						msgNormal.append("ON");
					}
					list->setText(msgNormal);
					ui.listWidgetNormal->addItem(list);
				}
				else if (splitWithSharp[1] == "1") {	// 输入口操作;
					msgNormal.append("  等待  IMM :  ").append(QString::fromStdString(splitWithSharp[4])).append("  =  ");
					if (splitWithSharp[3] == "0" ){
						msgNormal.append("OFF");
					}
					else {
						msgNormal.append("ON");
					}
					list->setText(msgNormal);
					ui.listWidgetNormal->addItem(list);
				}
			}
			else if (splitWithSharp.size() == 3 + 1) {	// 延时
				if (splitWithSharp[1] == "延时") {
					msgNormal.append("  延时").append(QString::fromStdString(splitWithSharp[2])).append("  ms");
					//msgDelay.append(" （").append(QString::fromStdString(splitWithSharp[3])).append("）");
					list->setText(msgNormal);
					ui.listWidgetNormal->addItem(list);
				}
			}
			else if (splitWithSharp.size() == 2 + 1) {		// 图像操作/
				if (splitWithSharp[1] == "0") {	// 顶出前图像操作;
					msgNormal.append("  顶出前图像 :  ").append(QString::fromStdString(splitWithSharp[2]));
					list->setText(msgNormal);
					ui.listWidgetNormal->addItem(list);
				}
				else if (splitWithSharp[1] == "1") {	// 顶出后图像操作;
					msgNormal.append("  顶出后图像 :  ").append(QString::fromStdString(splitWithSharp[2]));
					list->setText(msgNormal);
					ui.listWidgetNormal->addItem(list);
				}

			}

			while (!splitWithSharp.empty()) {
				splitWithSharp.pop_back();
			}
		}
		//delete list;
	} 

	// connect normal list 选中用作sub子程序操作
	connect(ui.listWidgetNormal, SIGNAL(itemClicked(QListWidgetItem *)), this, SLOT(sMIDealNormalListClicked(QListWidgetItem *)));
}

// 响应添加IO操作
void CycleStepSetting::sMIDealStdListClicked(QListWidgetItem* item) {
	// 标准指令1 - 5
	selectRow = ui.listWidgetIOStd->row(item);		// 得到点击的某一行的索引 0 - 4
	//ui.labelExplanationCmd->setText(QString::fromStdString(manualNameVect[selectRow][2]));	// 显示说明

	// cmd name display
	// 对于任何IO指令，前两个中文字符为  允许 / 等待
	QString msgIO = item->text();	// 获取内容
	QString msgDisplayCmd;
	if (msgIO.startsWith("允许")) {	// 允许即输出口
		//std::cout << "允许" << std::endl;
		msgDisplayCmd = QString("允许  IMM :  %1  =  %2").arg(msgIO).arg(radioBtnStatus);
	}
	else if (msgIO.startsWith("等待")) {	// 等待即输入口
		//std::cout << "等待" << std::endl;
		msgDisplayCmd = QString("等待  IMM :  %1  =  %2").arg(msgIO).arg(radioBtnStatus);
	}
	ui.labelDisplayCmd->setText(msgDisplayCmd);
	// 目前用作添加指令所用
	curDisCmd = msgIO.toStdString();
	curDisStus = (radioBtnStatus == "ON" ? "1" : "0");
}

void CycleStepSetting::onBtnGroupToggled(int id, bool status) {
	if (status == 1) {	// 选中
		switch (id)
		{
			case 0:		// on
			{
				//isOn = true;
				radioBtnStatus = "ON";
				break;
			}
			case 1:		// off
			{
				//isOn = false;
				radioBtnStatus = "OFF";
				break;
			}
			default:
				break;
		}
		// 更新cmd信息
		if (!ui.labelDisplayCmd->text().isEmpty()) {	// 不为空方才更新信息
			QString cmdMsg = ui.labelDisplayCmd->text();
			QString lastStatus = cmdMsg.right(3);	// 获取上一条指令右边3位
			int cmdLength = cmdMsg.length();
			if (lastStatus == "OFF")
				cmdMsg.resize(cmdLength - 3);
			else
				cmdMsg.resize(cmdLength - 2);	// 删去最后两位
			cmdMsg.append(radioBtnStatus);	// 加上跟新后的radioButton状态
			ui.labelDisplayCmd->setText(cmdMsg);
		}
	}
}

// 自定义添加IO按钮槽函数
void CycleStepSetting::onButtonAddIOClicked() {
	if (!ui.lineEditAddName->text().isEmpty()) {
		// 获取 等待/允许
		QString inOrOutMsg = ui.comboBoxInOrOut->currentText();
		//// 获取 ioidx
		//QString ioIdxMsg = ui.comboBoxIOIdx->currentText();
		// 获取设定的名称
		QString ioNameToAdd = ui.lineEditAddName->text();
		// 更新到list auto中
		// 首先进行字符规范
		QString msgToAddList;
		if (!ioNameToAdd.startsWith(inOrOutMsg)) {
			msgToAddList = inOrOutMsg;
			msgToAddList.append(ioNameToAdd);
		}
		else {
			msgToAddList = ioNameToAdd;
		}

		// 先判断添加的这个是否已经存在
		bool isAliveCmd = false;
		for (int i = 1; i < manualNameVect.size(); i++) {
			if (manualNameVect[i][1] == ioNameToAdd.toStdString()) {
				isAliveCmd = true;
			}
		}
		if (!isAliveCmd) {
			QListWidgetItem *listToAdd = new QListWidgetItem();
			listToAdd->setText(msgToAddList);
			listToAdd->setFont(QFont(msgToAddList, 15));
			ui.listWidgetAutoCmd->addItem(listToAdd);

			// 更新到下方表格中
			int curTabelIdx = 0;
			int curContIdx = 0;	// 用于记录最后保存到数据库中的idx
			if (inOrOutMsg == "等待") {
				// 输入
				curTabelIdx = ++curInputNum;
				QTableWidgetItem *itemOutput = new QTableWidgetItem();
				itemOutput->setText(msgToAddList);
				ui.tableWidgetManualIOName->setItem(curTabelIdx, 1, itemOutput);
				ui.tableWidgetManualIOName->item(curTabelIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
				curContIdx = curInputNum;
			}
			else if (inOrOutMsg == "允许") {
				// 输出
				curTabelIdx = ++curOutputNum + ioNum;
				QTableWidgetItem *itemInput = new QTableWidgetItem();
				itemInput->setText(msgToAddList);
				ui.tableWidgetManualIOName->setItem(curTabelIdx, 1, itemInput);
				ui.tableWidgetManualIOName->item(curTabelIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
				curContIdx = curOutputNum;
			}

			// (TODO) 保存到vector中
			std::vector<std::string> tmp;
			tmp.push_back(std::to_string(manualNameVect.size()));	// id
			tmp.push_back(msgToAddList.toStdString());	// value
			tmp.push_back(std::to_string(curContIdx));	// io_idx
			manualNameVect.push_back(tmp);
		}
		else {
			// 这个命令已经存在
			QMessageBox::about(this, "Warning", "This Cmd is Alive.");
		}
	}
}

void CycleStepSetting::onTableWidgetItemChanged(QTableWidgetItem *itemTableChanged) {
	int tableItemChangedRow = ui.tableWidgetManualIOName->row(itemTableChanged);
	if (tableItemChangedRow == 0) {	// 修改IONum
		int getNum = itemTableChanged->text().toInt();
		if (itemTableChanged->text() < "6" || itemTableChanged->text() > "99") {
			QMessageBox::about(this, "Warning", "I/O number can be Set from 6 to 99 only.");
			itemTableChanged->setText("6");
		}
		else {
			// 删除除第一行外所有行
			for (int i = ioNum * 2 + 1; i > 0; --i) {
				ui.tableWidgetManualIOName->removeRow(i);
			}
			// 添加新的行
			for (int i = 1; i < getNum * 2 + 1; i++) {
				ui.tableWidgetManualIOName->insertRow(ui.tableWidgetManualIOName->currentRow() + 1);
			}
			// 初始化第一列
			for (int i = 1; i < getNum + 1; i++) {
				QString iMsg = "输入 ";
				iMsg.append(QString::number(i));
				QTableWidgetItem *itemInput = new QTableWidgetItem();
				itemInput->setText(iMsg);
				itemInput->setFlags(itemInput->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
				ui.tableWidgetManualIOName->setItem(i, 0, itemInput);
				ui.tableWidgetManualIOName->item(i, 0)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
			}
			for (int i = getNum + 1; i < getNum * 2 + 1; i++) {
				QString oMsg = "输出 ";
				oMsg.append(QString::number(i - getNum));
				QTableWidgetItem *itemOutput = new QTableWidgetItem();
				itemOutput->setText(oMsg);
				itemOutput->setFlags(itemOutput->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
				ui.tableWidgetManualIOName->setItem(i, 0, itemOutput);
				ui.tableWidgetManualIOName->item(i, 0)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
			}
			int stdOutCnt = 0, stdInCnt = 0;
			// 插入已有标准信息（不可编辑）
			for (int i = 1; i <= STANDARDIONAME; i++) {
				QString ioNameMsg = QString::fromStdString(manualNameVect[i][1]);	// 获取该信息
				if (ioNameMsg.startsWith("允许")) {	// 输出
					stdOutCnt++;	// 计数总共当前有多少个输出已经定义
					QTableWidgetItem *itemOutput = new QTableWidgetItem();
					itemOutput->setText(ioNameMsg);
					itemOutput->setFlags(itemOutput->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
					int outputIdx = atoi(manualNameVect[i][2].c_str()) + getNum;
					ui.tableWidgetManualIOName->setItem(outputIdx, 1, itemOutput);
					ui.tableWidgetManualIOName->item(outputIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
				}
				else if (ioNameMsg.startsWith("等待")) {	// 输入
					stdInCnt++;	// 计数总共当前有多少个输入已经定义
					QTableWidgetItem *itemInput = new QTableWidgetItem();
					itemInput->setText(ioNameMsg);
					itemInput->setFlags(itemInput->flags() & (~Qt::ItemIsEditable));	// 设置不可编辑
					int inputIdx = atoi(manualNameVect[i][2].c_str());
					ui.tableWidgetManualIOName->setItem(inputIdx, 1, itemInput);
					ui.tableWidgetManualIOName->item(inputIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
				}
			}

			// 插入已有非标准信息（可编辑）
			for (int i = STANDARDIONAME + 1; i < manualNameVect.size(); i++) {
				QString ioNameMsg = QString::fromStdString(manualNameVect[i][1]);	// 获取该信息
				if (ioNameMsg.startsWith("允许")) {	// 输出
					stdOutCnt++;	// 计数总共当前有多少个输出已经定义
					QTableWidgetItem *itemOutput = new QTableWidgetItem();
					itemOutput->setText(ioNameMsg);
					int outputIdx = atoi(manualNameVect[i][2].c_str()) + getNum;
					ui.tableWidgetManualIOName->setItem(outputIdx, 1, itemOutput);
					ui.tableWidgetManualIOName->item(outputIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
				}
				else if (ioNameMsg.startsWith("等待")) {	// 输入
					stdInCnt++;	// 计数总共当前有多少个输入已经定义
					QTableWidgetItem *itemInput = new QTableWidgetItem();
					itemInput->setText(ioNameMsg);
					int inputIdx = atoi(manualNameVect[i][2].c_str());
					ui.tableWidgetManualIOName->setItem(inputIdx, 1, itemInput);
					ui.tableWidgetManualIOName->item(inputIdx, 1)->setTextAlignment(Qt::AlignHCenter | Qt::AlignVCenter);
				}
			}
			// 更新ioNum
			ioNum = getNum;
		}
	}
	else {	// 修改外围输入输出的名称
		// 只能修改自定义的名称
		// 注意list中还要能够对应变化
		if (tableItemChangedRow <= ioNum) {	// 修改输入
			for (int i = STANDARDIONAME + 1; i < manualNameVect.size(); i++) {
				if (QString::fromStdString(manualNameVect[i][1]).startsWith("等待")) {
					if (manualNameVect[i][2] == std::to_string(tableItemChangedRow)) {
						// 更新list
						int autoListRowCnt = ui.listWidgetAutoCmd->count();
						for (int j = 0; j < autoListRowCnt; j++) {
							if (ui.listWidgetAutoCmd->item(j)->text() == QString::fromStdString(manualNameVect[i][1])) {
								ui.listWidgetAutoCmd->item(j)->setText(itemTableChanged->text());
								break;
							}
						}
						// 更新vector
						manualNameVect[i][1] = itemTableChanged->text().toStdString();
					}
				}
			}
		}
		else {	// 修改输出
			std::cout << "检测输出修改" << std::endl;
			int ioIdx = tableItemChangedRow - ioNum;
			for (int i = STANDARDIONAME + 1; i < manualNameVect.size(); i++) {
				if (QString::fromStdString(manualNameVect[i][1]).startsWith("允许")) {
					if (manualNameVect[i][2] == std::to_string(ioIdx)) {
						// 更新list
						int autoListRowCnt = ui.listWidgetAutoCmd->count();
						for (int j = 0; j < autoListRowCnt; j++) {
							if (ui.listWidgetAutoCmd->item(j)->text() == QString::fromStdString(manualNameVect[i][1])) {
								ui.listWidgetAutoCmd->item(j)->setText(itemTableChanged->text());
								std::cout << j << std::endl;
								break;
							}
						}
						// 更新vector
						manualNameVect[i][1] = itemTableChanged->text().toStdString();
					}
				}
			}
		}
	}
}

// 添加IO指令
void CycleStepSetting::onButtonIOCmdAdd() {
	QString curCmdTxt = ui.labelDisplayCmd->text();
	if (!curCmdTxt.isEmpty()) {
		std::string cmdToAdd = "#";
		// 将消息转化为指令压入vector
		// 指令格式为#输入(1)/输出(0)#IO索引#IO状态#IO名称#
		// label on display cmd格式为	QString("允许  IMM :  %1  =  %2").arg(msgIO).arg(radioBtnStatus)
		//								QString("等待  IMM :  %1  =  %2").arg(msgIO).arg(radioBtnStatus)
		// 先找到I/O索引，根据ioName来找
		std::string ioIdxToAdd;

		for (int i = 0; i < manualNameVect.size(); i++) {
			if (curDisCmd == manualNameVect[i][1]) {
				ioIdxToAdd = manualNameVect[i][2];	// 得到输入/输出的索引
				break;
			}
		}
		if (curCmdTxt.startsWith("允许")) {	// 输出
			cmdToAdd.append("0#");
			cmdToAdd.append(ioIdxToAdd).append("#");
			cmdToAdd.append(curDisStus).append("#");
			cmdToAdd.append(curDisCmd).append("#");
		}
		else if (curCmdTxt.startsWith("等待")) {	// 输出
			cmdToAdd.append("1#");
			cmdToAdd.append(ioIdxToAdd).append("#");
			cmdToAdd.append(curDisStus).append("#");
			cmdToAdd.append(curDisCmd).append("#");
		}
		// 将组合成的指令压入manualStep
		std::vector<std::string> toAddVect;
		int tmpSize = ++normalSize;
		toAddVect.push_back(std::to_string(tmpSize));
		toAddVect.push_back(cmdToAdd);
		toAddVect.push_back("0");
		manualStep.push_back(toAddVect);
		// 添加到listNormal末尾并更新显示
		QListWidgetItem *listToAdd = new QListWidgetItem();
		QString msgToAdd = QString("  %1  ").arg(tmpSize - 1, 4, 10, QLatin1Char('0'));
		msgToAdd.append(curCmdTxt);
		listToAdd->setText(msgToAdd);
		ui.listWidgetNormal->addItem(listToAdd);
	}
}
// 删除IO指令
void CycleStepSetting::onButtonIOCmdDelete() {
	// 判断vector是否已经为空，不为空直接弹出最后一个
	if (!manualStep.empty()) {
		manualStep.pop_back();
		// 更新listNormal
		QListWidgetItem *item = ui.listWidgetNormal->takeItem(ui.listWidgetNormal->count() - 1);
		ui.listWidgetNormal->removeItemWidget(item);
	}
}

// 响应输入sub label num规定大小
void CycleStepSetting::onLineEditInputLabelNum(const QString &text) {
	if (text == "Label -") {	// 最小
		// 不准往下删除了
		ui.lineEditInputLabelNum->setText("Label - ");
	}
	else if (text.size() > 11){	// 最大
		// 超过3位标签数字位
		QString maxText = text;
		maxText.resize(11);
		ui.lineEditInputLabelNum->setText(maxText);
	}
	// 这里其实还要防止第9.10.11位中含有不为数字的情况
}
// 设定正文为数字
void CycleStepSetting::onLineEditInputLabelNumEditFinish() {
	QString labelTxt = ui.lineEditInputLabelNum->text();
	if (labelTxt.size() != 11) {	// 这里其实还要防止第9.10.11位中含有不为数字的情况
		QString partOfNum = labelTxt.mid(8);	// 从第9位开始是数字
		partOfNum = QString("%1").arg(partOfNum.toInt(), 3, 10, QLatin1Char('0'));	//规定格式
		QString newModifyLabelNum = "Label - ";
		newModifyLabelNum.append(partOfNum);
		ui.lineEditInputLabelNum->setText(newModifyLabelNum);
	}
	// 更新显示
}

// jumpList
void CycleStepSetting::sMIDealJumpListClicked(QListWidgetItem *item) {
	QString msgJump = item->text();	// 获取jump list内容
	QString labelNum = ui.lineEditInputLabelNum->text();	// 获取label num内容
	msgJump.append("  ").append(labelNum);
	//if (msgJump == "跳跃") {

	//}
	//else if (msgJump == "结束") {

	//}
	// 设置label display jump
	ui.labelDisplayJumpDst->setText(msgJump);
}
// sub list
void CycleStepSetting::sMIDealSubListClicked(QListWidgetItem *item) {
	QString msgSubNum = item->text();	// 获取sub list内容

	ui.labelExplanationSub->setText(msgSubNum);
}

// sub add and delete
void CycleStepSetting::onButtonSubAdd() {
	QString msgSub = ui.labelDisplayJumpDst->text();
	if (!msgSub.isEmpty() && normalSelectedIdx) {	// 如果信息不为空，并且normal List中已经存在点击选中状况
		// 显示说明
		QString msgExp = QString("上一步: %1   %2").arg(normalSelectedIdx).arg(msgSub);
		ui.labelExplanationSub->setText(msgExp);
		// normal list 中显示
		QString msgModify = ui.listWidgetNormal->item(normalSelectedIdx)->text();
		msgModify.append("      (").append(msgSub).append(")");
		ui.listWidgetNormal->item(normalSelectedIdx)->setText(msgModify);
		// 获取索引idx
		std::string subIdx = msgSub.mid(13).toStdString();
		// 两种情况
		std::vector<std::string> tmp;
		tmp.push_back(std::to_string(normalSelectedIdx));	// 起点索引
		if (msgSub.startsWith("跳跃")) {
			// 添加进vector
			tmp.push_back("jump");		// 动作
			tmp.push_back(subIdx);	// 子程序索引
			tmp.push_back("缺角");		// 条件（TODO）
			manualSubCmd.push_back(tmp);
		}
		else if (msgSub.startsWith("结束")) {
			// 添加进vector
			tmp.push_back("over");		// 动作
			tmp.push_back(subIdx);	// 子程序索引
			tmp.push_back("人工干预");		// 条件（TODO）
			manualSubCmd.push_back(tmp);
		}
	}
	else if (!msgSub.isEmpty() && !normalSelectedIdx) {
		ui.labelExplanationSub->setText("请选中需要插入子程序的起点位置");
	}
	else {
		ui.labelExplanationSub->setText("无更多说明");
	}
}
void CycleStepSetting::onButtonSubDelete() {
	if (!manualSubCmd.empty()) {
		if (manualSubCmd.size() == 1) {
			ui.labelExplanationSub->setText("无更多说明");
			manualSubCmd.pop_back();
		}
		else {
			manualSubCmd.pop_back();
			// 显示说明
			QString msgExp;
			if (manualSubCmd[manualSubCmd.size() - 1][1] == "jump") {
				msgExp = QString("上一步: %1   跳跃  Label - %2").arg(QString::fromStdString(manualSubCmd[manualSubCmd.size() - 1][0]))
					.arg(atoi(manualSubCmd[manualSubCmd.size() - 1][2].c_str()), 3, 10, QLatin1Char('0'));
			}
			else if (manualSubCmd[manualSubCmd.size() - 1][1] == "over") {
				msgExp = QString("上一步: %1   结束  Label - %2").arg(QString::fromStdString(manualSubCmd[manualSubCmd.size() - 1][0]))
					.arg(atoi(manualSubCmd[manualSubCmd.size() - 1][2].c_str()), 3, 10, QLatin1Char('0'));
			}
			
			ui.labelExplanationSub->setText(msgExp);
		}
	}
	else {
		ui.labelExplanationSub->setText("无更多说明");
	}
}

void CycleStepSetting::sMIDealNormalListClicked(QListWidgetItem *item) {
	normalSelectedIdx = ui.listWidgetNormal->row(item);
}

// 延时显示指令
void CycleStepSetting::onLineEditDelay() {
	QString msgDelay = "延时  ";
	msgDelay.append(ui.lineEditDelay->text()).append("  ms");
	ui.labelExplanationMore->setText(msgDelay);
}

// 图像指令显示
void CycleStepSetting::onBtnGroupImgToggled(int id, bool status) {
	if (status == 1) {	// 选中
		QString msgImg = "图像  ";
		//std::cout << id << std::endl;
			switch (id)
			{
			case 0:		// before inject
			{
				radioBtnImage = "顶出前";
				//msgImg.append("顶出前  :  ");
				break;
			}
			case 1:		// after inject
			{
				radioBtnImage = "顶出后";
				//msgImg.append("顶出后  :  ");
				break;
			}
			default:
				break;
			}
		msgImg.append("  :  ").append(ui.comboBoxImage->currentText());
		ui.labelExplanationMore->setText(msgImg);
	}
}
void CycleStepSetting::onComboxImgChanged(int idx) {
	QString msgImg ="图像  ";
	msgImg.append(radioBtnImage).append("  :  ");
	switch (idx)
	{
		case 0:		// 检查
		{
			msgImg.append("检查");
			break;
		}
		case 1:		// 显示
		{
			msgImg.append("显示");
			break;
		}
		case 2:		// 暂停
		{
			msgImg.append("暂停");
			break;
		}
		case 3:		// 清除
		{
			msgImg.append("清除");
			break;
		}
		default:
			break;
	}
	ui.labelExplanationMore->setText(msgImg);
}

// more cmd add and delete
void CycleStepSetting::onButtonImgAdd() {
	if (ui.labelExplanationMore->text().startsWith("延时")) {

	}
	else if (ui.labelExplanationMore->text().startsWith("图像")) {

	}
}
void CycleStepSetting::onButtonImgDelete() {

}

// 按单个字符分割字符串
std::vector<std::string> CycleStepSetting::split(std::string s, char delim) {
	std::vector<std::string> v;
	std::stringstream stringstream1(s);
	std::string tmp;
	while (getline(stringstream1, tmp, delim)) {
		v.push_back(tmp);
	}
	return v;
}

void CycleStepSetting::onRunModeFrom(int modIdx) {
	runFromTableOrManual = modIdx;
}

CycleStepSetting::~CycleStepSetting() {
	delete btnGroup;
	delete btnGroupImg;
}
