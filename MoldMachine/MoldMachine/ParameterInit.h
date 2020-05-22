#pragma once

#include <QWidget>
#include <map>
#include <vector>
//#include <string>

#include "MysqlSetting.h"
#include "xmlFileSetting.h"
//#include "StructNode.h"


class ParamInit {
public:
	ParamInit();
	~ParamInit();

	/*sql parameter operation*/
	// param init
	void CycleTimesParamInit(std::string &times);
	void CounterParamInit(std::string &counter_1, std::string &counter_2);
	void DelayParamInit(std::string &delay_1, std::string &delay_2);
	void IOServiceParamInit(std::map<std::string, std::string> &m1_init, std::map<std::string, std::string> &m2_init, std::map<std::string, std::string> &m3_init);
	void CycleStepParamInit(std::vector<std::vector<std::string>> &vect, std::map<std::string, std::string> &m, int &cnt, int moldId);
	void CycleStepManualParamInit(std::vector<std::vector<std::string>> &vectName, std::vector<std::vector<std::string>> &manualStep, std::vector<std::vector<std::string>> &manualSubCmd, 
		int moldId, int allNum, std::map<int, int> &relationIdx);
	// block init
	void blockInit(std::vector<std::vector<int>> &block, int moldId);

	// param save
	void CycleTimesParamSaving(const char *times);
	void CounterParamSaving(const char *counter_1, const char *counter_2);
	void DelayParamSaving(const char *delay_1, const char *delay_2);
	void IOServiceParamSaving(std::map<std::string, std::string> map_modify_1, std::map<std::string, std::string> map_modify_2, std::map<std::string, std::string> map_modify_3);
	void CycleStepParamSaving(std::vector<std::vector<std::string>> vec_modify, int moldId);
	void CycleStepDetAndNew(std::vector<std::vector<std::string>> vec_modify, int moldId);
	void CycleStepManualParamSaving(std::vector<std::vector<std::string>> mName, std::vector<std::vector<std::string>> manualStep, std::map<int, int> relationIdx, int moldId, int runMode);

	// block saving(将用户在label上画的框所转换成的实际在图片上的坐标存入库内)
	void blockSaving(std::vector<std::vector<int>> block, int moldId);
	
	/*xml file parameter operation*/
	//param init
	void xml_CycleTimesParamInit(std::string &times);
	void xml_CounterParamInit(std::string &counter_1, std::string &counter_2);
	void xml_DelayParamInit(std::string &delay_1, std::string &delay_2);
	void xml_IOServiceParamInit(std::map<std::string, std::string> &m1_init, std::map<std::string, std::string> &m2_init, std::map<std::string, std::string> &m3_init);
	void xml_CycleStepParamInit(std::vector<std::vector<std::string>> &vect, std::map<std::string, std::string> &m, int &cnt);
	void xml_blockInit(std::vector<std::vector<int>> &);

	//param save
	void xml_CycleTimesParamSaving(const char *times);
	void xml_CounterParamSaving(const char *counter_1, const char *counter_2);
	void xml_DelayParamSaving(const char *delay_1, const char *delay_2);
	void xml_IOServiceParamSaving(std::map<std::string, std::string> map_modify_1, std::map<std::string, std::string> map_modify_2, std::map<std::string, std::string> map_modify_3);
	void xml_CycleStepParamSaving(std::vector<std::vector<std::string>> vec_modify, int moldId);
	void xml_blockSaving(std::vector<std::vector<int>> block, int moldId);

	// create xml files
	void cycleTimesCountersDelaysCrt();
	void cycleStepCrt(int moldId);
	void imageAddrCrt();
	void ioServiceCrt();
	void imageBlockCrt(int moldId);

	// read xml to sql data
	void readXML2SqlData();

	// mold obj read
	void moldObjParamRead(std::map<std::string, std::string>  &mapObj);

private:
	MysqlSetting sql_con;
	//XMLFile *xmlFile;
};
