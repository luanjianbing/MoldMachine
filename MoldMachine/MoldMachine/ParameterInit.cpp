#include "ParameterInit.h"

ParamInit::ParamInit() {

}

// cycle times saving
void ParamInit::CycleTimesParamSaving(const char *times) {
	sql_con.updateData("cycle_cnt_delay_val", times, "value", "name", "cycle_times", 0);
}

// counter saving
void ParamInit::CounterParamSaving(const char *counter_1, const char *counter_2) {
	sql_con.updateData("cycle_cnt_delay_val", counter_1, "value", "name", "counter_1", 0);
	sql_con.updateData("cycle_cnt_delay_val", counter_2, "value", "name", "counter_2", 0);
}

//delay saving
void ParamInit::DelayParamSaving(const char *delay_1, const char *delay_2) {
	sql_con.updateData("cycle_cnt_delay_val", delay_1, "value", "name", "delay_1", 0);
	sql_con.updateData("cycle_cnt_delay_val", delay_2, "value", "name", "delay_2", 0);
}

// io saving
void ParamInit::IOServiceParamSaving(std::map<std::string, std::string> map_modify_1, std::map<std::string, std::string> map_modify_2, std::map<std::string, std::string> map_modify_3) {
	for (std::map<std::string, std::string>::iterator iter = map_modify_1.begin(); iter != map_modify_1.end(); iter++) {
		sql_con.updateData("ioservice_name", (iter->second).c_str(), "value", "name", (iter->first).c_str(), 1);
	}
	for (std::map<std::string, std::string>::iterator iter = map_modify_2.begin(); iter != map_modify_2.end(); iter++) {
		sql_con.updateData("ioservice_status", (iter->second).c_str(), "status", "name", (iter->first).c_str(), 1);
	}
	for (std::map<std::string, std::string>::iterator iter = map_modify_3.begin(); iter != map_modify_3.end(); iter++) {
		sql_con.updateData("ioservice_enet", (iter->second).c_str(), "addr", "name", (iter->first).c_str(), 1);
	}
}

// cycle saving (totalStep = 11)
void ParamInit::CycleStepParamSaving(std::vector<std::vector<std::string>> vec_modify, int moldId) {
	// vec_modify: row col data
	std::vector<std::string> colName;
	sql_con.queryAllColName(colName, "'cycle_step'");
	// 储存修改后的数据
	for (int i = 0; i < vec_modify.size(); i++) {
		sql_con.updateIdData("cycle_step", vec_modify[i][2].c_str(), colName[atoi(vec_modify[i][0].c_str())].c_str(), "id", vec_modify[i][1].c_str(), 1, moldId);
	}
}

// cycle step new col
void ParamInit::CycleStepDetAndNew(std::vector<std::vector<std::string>> vec_modify, int moldId) {
	sql_con.detStepIdAndNewData("cycle_step", vec_modify, moldId);

	//sql_con.detAndNewData("cycle_step", vec_modify);
}

void ParamInit::CycleStepManualParamSaving(std::vector<std::vector<std::string>> mName, std::vector<std::vector<std::string>> manualStep
	, std::map<int, int> relationIdx, int moldId, int runMode) {
	sql_con.detManualNameAndNewData("manual_ioname", mName);

	for (int i = 0; i < relationIdx.size() - 1; i++) {
		std::vector<std::vector<std::string>> toSaveVect;
		for (int j = relationIdx[i]; j < relationIdx[i + 1]; j++) {
			toSaveVect.push_back(manualStep[j]);
		}
		sql_con.detStepIdAndNewData("cycle_step_manual", toSaveVect, i);
	}
	sql_con.updateData("cycle_cnt_delay_val", std::to_string(runMode).c_str(), "value", "name", "run_Mode", 0);
}

// cycle times init
void ParamInit::CycleTimesParamInit(std::string &times) {
	times = sql_con.queryData("cycle_cnt_delay_val", "value", "name", "cycle_times");
}

// counter init
void ParamInit::CounterParamInit(std::string &counter_1, std::string &counter_2) {
	counter_1 = sql_con.queryData("cycle_cnt_delay_val", "value", "name", "counter_1");
	counter_2 = sql_con.queryData("cycle_cnt_delay_val", "value", "name", "counter_2");
}

// delay init
void ParamInit::DelayParamInit(std::string &delay_1, std::string &delay_2) {
	delay_1 = sql_con.queryData("cycle_cnt_delay_val", "value", "name", "delay_1");
	delay_2 = sql_con.queryData("cycle_cnt_delay_val", "value", "name", "delay_2");
}

// cycle step init
void ParamInit::CycleStepParamInit(std::vector<std::vector<std::string>> &vect, std::map<std::string, std::string> &m, int &cnt, int moldId) {
	m = sql_con.queryAllData("ioservice_name", "name", "value");
	vect = sql_con.tabId2Vector("cycle_step", moldId, 31);
	cnt = sql_con.queryIdRowCnt("cycle_step", moldId);
}

// cycle step manual init
void ParamInit::CycleStepManualParamInit(std::vector<std::vector<std::string>> &vectName, std::vector<std::vector<std::string>> &manualStep, std::vector<std::vector<std::string>> &manualSubCmd, 
	int moldId, int allNum, std::map<int, int> &relationIdx) {
	vectName = sql_con.tab2VectorOrderById("manual_ioname", 3);

	manualStep = sql_con.tabId2Vector("cycle_step_manual", 0, 3);	// 目前先定义0为正常的步骤

	manualSubCmd = sql_con.tab2VectorOrderById("manual_sub_cmd", 4);

	relationIdx[0] = 0;	// 用来记录每一段从哪里开始

	for (int i = 1; i < allNum; ++i) {
		relationIdx[i] = manualStep.size();
		std::vector<std::vector<std::string>> tmp;
		tmp = sql_con.tabId2Vector("cycle_step_manual", i, 3);
		manualStep.insert(manualStep.end(), tmp.begin(), tmp.end());
	}
}

// io init
void ParamInit::IOServiceParamInit(std::map<std::string, std::string> &m1_init, std::map<std::string, std::string> &m2_init, std::map<std::string, std::string> &m3_init) {
	// IO Service Param (3)
	m1_init = sql_con.queryAllData("ioservice_name", "name", "value");
	m2_init = sql_con.queryAllData("ioservice_status", "name", "status");
	m3_init = sql_con.queryAllData("ioservice_enet", "name", "addr");
}

// block saving
void ParamInit::blockSaving(std::vector<std::vector<int>> block, int moldId) {
	std::vector<std::string> _block_to_string;
	std::vector<std::vector<std::string>> block_to_string;

	for (int i = 0; i < block.size(); i++) {
		for (int j = 0; j < block[i].size(); j++) {
			_block_to_string.push_back(std::to_string(block[i][j]));
		}
		block_to_string.push_back(_block_to_string);
		while (!_block_to_string.empty())
		{
			_block_to_string.pop_back();
		}
	}
	sql_con.detMoldIdAndNewData("image_block", block_to_string, moldId);
}

// block init(读出用户已画的框的坐标)
void ParamInit::blockInit(std::vector<std::vector<int>> &block, int moldId) {
	std::vector<std::vector<std::string>> _block = sql_con.tabId2Vector("image_block", moldId, 7);
	std::vector<int> tmp;
	// 把string类型的二维vector转化成int类型的vector
	for (int i = 0; i < _block.size(); i++) {
		for (int j = 1; j < _block[i].size(); j++) {
			tmp.push_back(atoi(_block[i][j].c_str()));
		}
		block.push_back(tmp);
		while (!tmp.empty())
		{
			tmp.pop_back();
		}
	}
}

// XML_File data read and write
// cycle times init
void ParamInit::xml_CycleTimesParamInit(std::string &times) {
	const char *strText;
	XMLFile xmlFile("CycleCntDelayValue.xml");
	xmlFile.GetNodeText("CycleTimes", strText);
	times = strText;
	//delete strText;
}

void ParamInit::xml_CounterParamInit(std::string &counter_1, std::string &counter_2) {
	const char *strText1, *strText2;
	XMLFile xmlFile("CycleCntDelayValue.xml");
	xmlFile.GetNodeText("Counter1", strText1);
	xmlFile.GetNodeText("Counter2", strText2);
	counter_1 = strText1;
	counter_2 = strText2;
	//delete strText1, strText2;
}

void ParamInit::xml_DelayParamInit(std::string &delay_1, std::string &delay_2) {
	const char *strText1, *strText2;
	XMLFile xmlFile("CycleCntDelayValue.xml");
	xmlFile.GetNodeText("Delay1", strText1);
	xmlFile.GetNodeText("Delay2", strText2);
	delay_1 = strText1;
	delay_2 = strText2;
	//delete strText1, strText2;
}

void ParamInit::xml_IOServiceParamInit(std::map<std::string, std::string> &m1_init, std::map<std::string, std::string> &m2_init, std::map<std::string, std::string> &m3_init) {
	std::map<std::string, std::string> map_all;
	XMLFile xmlFile("IOService.xml");
	xmlFile.XML2Map(map_all);
	m1_init = map_all;
	m2_init = map_all;
	m3_init = map_all;
	//for (std::map<std::string, std::string>::iterator it = mm.begin(); it != mm.end(); it++) {
	//	std::cout << it->first << ":" << it->second << std::endl;
	//}
}

void ParamInit::xml_CycleStepParamInit(std::vector<std::vector<std::string>> &vect, std::map<std::string, std::string> &m, int &cnt) {
	XMLFile xmlFileIO("IOService.xml");
	xmlFileIO.XML2Map(m);

	XMLFile xmlFileCS("CycleStep.xml");
	xmlFileCS.XML2Vect(vect);

	cnt = vect.size();
}

void ParamInit::xml_blockInit(std::vector<std::vector<int>> &block) {
	XMLFile xmlFileCS("ImageBlock.xml");
	std::vector<int> _block;
	std::vector<std::vector<std::string>> block_str;
	xmlFileCS.XML2Vect(block_str);
	for (int i = 0; i < block_str.size(); i++) {
		for (int j = 1; j < block_str[i].size(); j++) {
			_block.push_back(atoi(block_str[i][j].c_str()));
		}
		block.push_back(_block);
		while (!_block.empty())
		{
			_block.pop_back();
		}
	}
}

// cycle time saving
void ParamInit::xml_CycleTimesParamSaving(const char *times) {
	XMLFile xmlFile("CycleCntDelayValue.xml");
	xmlFile.modifyText("cycle_times", times);
}

void ParamInit::xml_CounterParamSaving(const char *counter_1, const char *counter_2) {
	XMLFile xmlFile("CycleCntDelayValue.xml");
	xmlFile.modifyText("counter_1", counter_1);
	xmlFile.modifyText("counter_2", counter_2);
}

void ParamInit::xml_DelayParamSaving(const char *delay_1, const char *delay_2) {
	XMLFile xmlFile("CycleCntDelayValue.xml");
	xmlFile.modifyText("delay_1", delay_1);
	xmlFile.modifyText("delay_2", delay_2);
}

void ParamInit::xml_IOServiceParamSaving(std::map<std::string, std::string> map_modify_1, std::map<std::string, std::string> map_modify_2, std::map<std::string, std::string> map_modify_3) {
	XMLFile xmlFile("IOService.xml");
	//xmlFile.CreateXML(map_modify_1, map_modify_2, map_modify_3);
	for (std::map<std::string, std::string>::iterator it = map_modify_1.begin(); it != map_modify_1.end(); it++) {
		xmlFile.modifyText(it->first, it->second);
	}
	for (std::map<std::string, std::string>::iterator it = map_modify_2.begin(); it != map_modify_2.end(); it++) {
		xmlFile.modifyText(it->first, it->second);
	}
	for (std::map<std::string, std::string>::iterator it = map_modify_3.begin(); it != map_modify_3.end(); it++) {
		xmlFile.modifyText(it->first, it->second);
	}
}

void ParamInit::xml_CycleStepParamSaving(std::vector<std::vector<std::string>> vec_modify, int moldId) {
	XMLFile xmlFile("CycleStep.xml");
	xmlFile.CreateXML(vec_modify, moldId);
}

void ParamInit::xml_blockSaving(std::vector<std::vector<int>> block, int moldId) {
	XMLFile xmlFile("ImageBlock.xml");
	xmlFile.CreateXML(block, moldId);
}

// create xml files
void ParamInit::cycleTimesCountersDelaysCrt() {
	std::map<std::string, std::string> map_tcd;
	map_tcd = sql_con.queryAllData("cycle_cnt_delay_val", "name", "value");
	XMLFile xmlFile("CycleCntDelayValue.xml");
	xmlFile.CreateXML(map_tcd);
}

void ParamInit::cycleStepCrt(int moldId) {
	std::vector<std::vector<std::string>> vect_step;
	std::vector<std::vector<std::string>> vect_step_c1;
	std::vector<std::string> _vect;
	//vect_step_c1 = sql_con.tab2Vector("cycle_step", 37);
	vect_step_c1 = sql_con.tabId2Vector("cycle_step", moldId, 31);
	for (int i = 0; i < vect_step_c1.size(); i++)
	{
		for (int j = 1; j < 31; j++)
		{
			_vect.push_back(vect_step_c1[i][j]);
			
		}
		vect_step.push_back(_vect);
		while (!_vect.empty())
		{
			_vect.pop_back();
		}
	}
	xml_CycleStepParamSaving(vect_step, moldId);
}

void ParamInit::imageAddrCrt() {
	std::map<std::string, std::string> map_imageAddr;
	map_imageAddr = sql_con.queryAllData("image_addr", "name", "value");
	XMLFile xmlFile("ImageAddress.xml");
	xmlFile.CreateXML(map_imageAddr);
}

void ParamInit::ioServiceCrt() {
	std::map<std::string, std::string> map_ioName;
	std::map<std::string, std::string> map_ioStatus;
	std::map<std::string, std::string> map_ioEnet;
	IOServiceParamInit(map_ioName, map_ioStatus, map_ioEnet);
	XMLFile xmlFile("IOService.xml");
	xmlFile.CreateXML(map_ioName, map_ioStatus, map_ioEnet);
}

void ParamInit::imageBlockCrt(int moldId) {
	std::vector<std::vector<int>> vect_block;
	blockInit(vect_block, moldId);
	xml_blockSaving(vect_block, moldId);
}

// read XML to sql Data
void ParamInit::readXML2SqlData() {
	std::map<std::string, std::string> cycle_cnt_delay_value;
	std::map<std::string, std::string> io_service;
	std::map<std::string, std::string> image_addr;

	std::vector<std::vector<std::string>> cycle_step;	// n * 32
	std::vector<std::vector<std::string>> step_cor;		// n * 31

	std::vector<std::vector<std::string>> image_block;	// n * 5
	std::vector<std::vector<std::string>> block_cor;	// n * 4 cordination

	// 读stepvalue到sql
	XMLFile xmlFileCCD("CycleCntDelayValue.xml");
	xmlFileCCD.XML2Map(cycle_cnt_delay_value);			// table cycle_cnt_delay_value
	for (std::map<std::string, std::string>::iterator iter = cycle_cnt_delay_value.begin(); iter != cycle_cnt_delay_value.end(); iter++) {
		sql_con.updateData("cycle_cnt_delay_val", (iter->second).c_str(), "value", "name", (iter->first).c_str(), 0);
	}
	
	// 读io到sql
	XMLFile xmlFileIO("IOService.xml");
	xmlFileIO.XML2Map(io_service);
	for (std::map<std::string, std::string>::iterator iter = io_service.begin(); iter != io_service.end(); iter++) {
		if (strstr((iter->first).c_str(), "name") != NULL) {
			sql_con.updateData("ioservice_name", (iter->second).c_str(), "value", "name", (iter->first).c_str(), 1);
		}
		else if (strstr((iter->first).c_str(), "status") != NULL) {
			sql_con.updateData("ioservice_status", (iter->second).c_str(), "status", "name", (iter->first).c_str(), 1);
		}
		else {
			sql_con.updateData("ioservice_enet", (iter->second).c_str(), "addr", "name", (iter->first).c_str(), 1);
		}
	}
	
	// 读step到sql
	XMLFile xmlFileCS("CycleStep.xml");
	xmlFileCS.XML2Vect(cycle_step);
	step_cor.resize(cycle_step.size());
	for (int i = 0; i < cycle_step.size(); i++) {
		for (int j = 1; j < cycle_step[i].size(); j++) {
			step_cor[i].push_back(cycle_step[i][j]);
		}
	}
	sql_con.detStepIdAndNewData("cycle_step", step_cor, atoi(cycle_step[0].back().c_str()));

	// 读addr到addr
	XMLFile xmlFileIA("ImageAddress.xml");
	xmlFileIA.XML2Map(image_addr);
	for (std::map<std::string, std::string>::iterator iter = image_addr.begin(); iter != image_addr.end(); iter++) {
		sql_con.updateData("image_addr", (iter->second).c_str(), "value", "name", (iter->first).c_str(), 1);
	}

	// 读block到sql
	XMLFile xmlFileBlock("ImageBlock.xml");
	xmlFileBlock.XML2Vect(image_block);
	block_cor.resize(image_block.size());
	for (int i = 0; i < image_block.size(); i++) {
		for (int j = 1; j < image_block[i].size(); j++) {
			block_cor[i].push_back(image_block[i][j]);
		}
	}
	sql_con.detMoldIdAndNewData("image_block", block_cor, atoi(image_block[0].front().c_str()));
}

void ParamInit::moldObjParamRead(std::map<std::string, std::string>  &mapObj) {
	mapObj = sql_con.queryAllData("mold_object", "mold_name", "mold_id");
}

ParamInit::~ParamInit() {

}
