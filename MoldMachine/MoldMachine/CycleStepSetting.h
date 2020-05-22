#pragma once

#include <QWidget>
#include "ui_CycleStepSetting.h"
#include "ParameterInit.h"

#include <QHeaderView>
#include <QTableWidget>
#include <QMessageBox>
#include <QButtonGroup>
#include <sstream>

//#include "StructNode.h"

class CycleStepSetting : public QWidget
{
	Q_OBJECT

	public:
		CycleStepSetting(int curMoldId, QWidget *parent = Q_NULLPTR);
		~CycleStepSetting();

	private:
		int curMoldObjId = 0;

		Ui::CycleStepClass ui;

		ParamInit cycleParam;
		void CycleStepInitParam();

		int totalStep =0;		// total step 11
		std::vector<std::vector<std::string>> vect;	// vect中存放的是从数据库中读取的数据

		int colCnt;	// 总列数
		int rowCnt; // 总行数
		int current_col;
		int current_row;

		void updateCurColRow();
		
		std::vector<std::vector<std::string>> vec_modify;

		// 手动输入方式动作
		std::vector<std::string> stepManualInput;
		//void sMIConnectAll();

		void sMIAllInit();	// 文字编辑初始化
		void sMITabNormalInit();	// 文字编辑正常步骤初始化
		void sMITabInsertInit();	// 文字编辑插入步骤初始化
		void sMITabSubInit();	// 文字编辑子步骤初始化
		void sMITabMoreInit();	// 文字编辑更多初始化

		int ioNum;
		std::vector<std::vector<std::string>> manualNameVect;
		int allConditionNum = 3;	// 暂时规定通过传递一个参数来分别访问数据库表
		std::map<int, int> mRelation;
		int normalSize = 0;
		std::vector<std::vector<std::string>> manualStep;	//读取表中所有数据
		std::vector<std::vector<std::string>> manualStepModify;	//读取表中所有数据
		int normalSelectedIdx = 0;
		std::vector<std::vector<std::string>> manualSubCmd;	// 子程序保存指令
		//std::vector<std::vector<std::string>> manualNameVectModify;
		//bool flagNormOrAbNorm = 1;	// 默认为Norm

		std::vector<std::string> split(std::string s, char delim);	// 按照单个字符串分割字符串

		bool runFromTableOrManual = 0; // 默认为0按照table运行

		int selectRow = 0;
		QButtonGroup *btnGroup;
		QButtonGroup *btnGroupImg;
		//bool isOn = true;		// 默认radioButton是勾选在On状态
		QString radioBtnStatus = "ON";
		QString radioBtnImage = "顶出前";
		std::string curDisCmd, curDisStus;
		int curInputNum = 0, curOutputNum = 0;

		
		//std::vector<int> Graph;		// 使用id与next_id构建简单图
		//int abNormIdx = 0;

	private slots:
		void onButtonAddCol();
		void onButtonDeleteCol();

		void onButtonUp();
		void onButtonDown();
		void onButtonLeft();
		void onButtonRight();

		void onButtonSure();

		void onButtonAdd();
		void onButtonMinus();

		void onItemChanged(int row, int col);

		// 运行模式
		void onRunModeFrom(int modIdx);

		// 标准IO点击事件
		void sMIDealStdListClicked(QListWidgetItem *);

		// radiobutton on or off
		void onBtnGroupToggled(int id, bool status);

		// 自定义IO添加按钮
		void onButtonAddIOClicked();

		// 响应表格修改事件
		void onTableWidgetItemChanged(QTableWidgetItem *);

		// 添加/删除I/O指令
		void onButtonIOCmdAdd();
		void onButtonIOCmdDelete();

		// sub input label NUM
		void onLineEditInputLabelNum(const QString &);
		void onLineEditInputLabelNumEditFinish();

		// jump list
		void sMIDealJumpListClicked(QListWidgetItem *);
		void sMIDealSubListClicked(QListWidgetItem *);

		// sub add and delete
		void onButtonSubAdd();
		void onButtonSubDelete();

		// list normal
		void sMIDealNormalListClicked(QListWidgetItem *);

		// line edit delay
		void onLineEditDelay();

		// radiobutton img before or after
		void onBtnGroupImgToggled(int id, bool status);

		// combobox image
		void onComboxImgChanged(int idx);

		// img add and delete
		void onButtonImgAdd();
		void onButtonImgDelete();

		//// toolWidget 切换
		//void sMINormOrAbNormChg(int chgIndex);

		//// 清除输入缓存
		//void sMISureIONum();
		//// 输入
		//void sMIInput();
		//// 输出
		//void sMIOutput();
		//// 计数
		////void sMICount();
		//// 延时
		//void sMIDelay();
		//// 顶出前图像
		//void sMIImgBeforeInject();
		//// 顶出后图像
		//void sMIImgAfterInject();
		//// 日志
		//void sMILog();
		//// 删除指令
		//void sMIDetLast();
		//// ioNum修改响应
		//void sMIPerIOSetting();

		//void sMIDealDoubleClicked(QListWidgetItem *item);
	signals:
		void sendRunFromTableOrManual(int);
};
