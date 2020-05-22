#include "xmlFileSetting.h"

XMLFile::XMLFile(const char *xmlFileName)
{
	m_xmlFileName = new char[30];
	strcpy(m_xmlFileName, xmlFileName);
	m_pDocument = NULL;
	m_pDeclaration = NULL;
}

XMLFile::~XMLFile()
{
	if (m_xmlFileName != NULL)
		delete m_xmlFileName;

	if (m_pDocument != NULL)
		delete m_pDocument;

	//if (m_pDeclaration != NULL)			// create XML时需要将这里注释
	//	delete m_pDeclaration;
}

void XMLFile::CreateXML(std::vector<std::vector<int>> block, int moldId) {
	std::string _name[5] = { "BlockId", "PointX", "PointY", "Width", "Height"};
	std::vector<std::string> block_name(_name, _name + 5);

	//创建XML文档指针
	m_pDocument = new TiXmlDocument(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return;
	}

	//声明XML
	m_pDeclaration = new TiXmlDeclaration("1.0", "UTF-8", "");
	if (NULL == m_pDeclaration)
	{
		return;
	}
	m_pDocument->LinkEndChild(m_pDeclaration);

	//创建根节点
	std::string xmlFileName = m_xmlFileName;
	std::string rootName = (xmlFileName.substr(0, xmlFileName.find(".")));//根节点元素名为文件名去掉.xml
	TiXmlElement *pRoot = new TiXmlElement(rootName.c_str());
	if (NULL == pRoot)
	{
		return;
	}
	//关联XML文档，成为XML文档的根节点
	m_pDocument->LinkEndChild(pRoot);

	TiXmlText *pText = new TiXmlText("CycleStep");
	pRoot->LinkEndChild(pText);
	pRoot->SetAttribute("MoldObjId", moldId);

	//for (int i = 0; i < vec_modify.size(); i++) {
	//	for (int j = 0; j < vec_modify[i].size(); j++)
	//	{
	//		std::cout << vec_modify[i][j] << " ";
	//	}
	//	std::cout << std::endl;
	//}

	for (int i = 0; i < block.size(); i++) {
		TiXmlElement *pId = new TiXmlElement(_name[0].c_str());
		TiXmlText *pIdText = new TiXmlText(std::to_string(i + 1).c_str());
		pId->LinkEndChild(pIdText);
		pRoot->LinkEndChild(pId);
		for (int j = 0; j < block[i].size(); j++)
		{
			TiXmlElement *pBlock = new TiXmlElement(_name[j + 1].c_str());
			TiXmlText *pBlockText = new TiXmlText(std::to_string(block[i][j]).c_str());
			pBlock->LinkEndChild(pBlockText);
			pId->LinkEndChild(pBlock);
		}
	}

	m_pDocument->SaveFile(m_xmlFileName);
}

void XMLFile::CreateXML(std::vector<std::vector<std::string>> vec_modify, int moldId) {
	std::string _name[37] = { "CurrentStep", "clear_input_buffer", "step_input_1", "step_input_2", "step_input_3", "step_input_4",
		"step_input_5", "step_input_6", "step_overlook_without_input", "step_button",
		"step_counter", "step_overlook_CNT_0", "step_output_1", "step_output_2", "step_output_3", "step_output_4",
		"step_output_5", "step_output_6", "step_delay", "step_img_1", "step_img_2",
		"step_img_3", "step_img_4", "step_img_5", "step_img_6", "step_check_img",
		"step_overlook_stop", "step_run", "step_cycle", "step_log", "next_step" };

	std::vector<std::string> step_name(_name, _name + 37);

	//创建XML文档指针
	m_pDocument = new TiXmlDocument(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return;
	}

	//声明XML
	m_pDeclaration = new TiXmlDeclaration("1.0", "UTF-8", "");
	if (NULL == m_pDeclaration)
	{
		return;
	}
	m_pDocument->LinkEndChild(m_pDeclaration);

	//创建根节点
	std::string xmlFileName = m_xmlFileName;
	std::string rootName = (xmlFileName.substr(0, xmlFileName.find(".")));//根节点元素名为文件名去掉.xml
	TiXmlElement *pRoot = new TiXmlElement(rootName.c_str());
	if (NULL == pRoot)
	{
		return;
	}
	//关联XML文档，成为XML文档的根节点
	m_pDocument->LinkEndChild(pRoot);

	TiXmlText *pText = new TiXmlText("CycleStep");
	pRoot->LinkEndChild(pText);
	pRoot->SetAttribute("MoldObjId", moldId);

	//for (int i = 0; i < vec_modify.size(); i++) {
	//	for (int j = 0; j < vec_modify[i].size(); j++)
	//	{
	//		std::cout << vec_modify[i][j] << " ";
	//	}
	//	std::cout << std::endl;
	//}

	for (int i = 0; i < vec_modify.size(); i++) {
		TiXmlElement *pId = new TiXmlElement(_name[0].c_str());
		TiXmlText *pIdText = new TiXmlText(std::to_string(i + 1).c_str());
		pId->LinkEndChild(pIdText);
		pRoot->LinkEndChild(pId);
		for (int j = 0; j < vec_modify[i].size(); j++)
		{
			TiXmlElement *pStep = new TiXmlElement(_name[j + 1].c_str());
			TiXmlText *pStepText = new TiXmlText(vec_modify[i][j].c_str());
			pStep->LinkEndChild(pStepText);
			pId->LinkEndChild(pStep);
		}
	}

	m_pDocument->SaveFile(m_xmlFileName);
}

void XMLFile::CreateXML(std::map<std::string, std::string> map) {
	//创建XML文档指针
	m_pDocument = new TiXmlDocument(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return;
	}

	//声明XML
	m_pDeclaration = new TiXmlDeclaration("1.0", "UTF-8", "");
	if (NULL == m_pDeclaration)
	{
		return;
	}
	m_pDocument->LinkEndChild(m_pDeclaration);

	//创建根节点
	std::string xmlFileName = m_xmlFileName;
	std::string rootName = (xmlFileName.substr(0, xmlFileName.find(".")));//根节点元素名为文件名去掉.xml
	TiXmlElement *pRoot = new TiXmlElement(rootName.c_str());
	if (NULL == pRoot)
	{
		return;
	}
	//关联XML文档，成为XML文档的根节点
	m_pDocument->LinkEndChild(pRoot);

	TiXmlText *pText = new TiXmlText(rootName.c_str());
	pRoot->LinkEndChild(pText);

	for (std::map<std::string, std::string>::iterator it = map.begin(); it != map.end(); it++) {
		TiXmlElement *pMap = new TiXmlElement(it->first.c_str());
		TiXmlText *pMapText = new TiXmlText(it->second.c_str());
		pMap->LinkEndChild(pMapText);
		pRoot->LinkEndChild(pMap);
	}

	m_pDocument->SaveFile(m_xmlFileName);
}

void XMLFile::CreateXML(std::map<std::string, std::string> ioName, std::map<std::string, std::string> ioStatus, std::map<std::string, std::string> ioEnet) {
	//创建XML文档指针
	m_pDocument = new TiXmlDocument(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return;
	}

	//声明XML
	m_pDeclaration = new TiXmlDeclaration("1.0", "UTF-8", "");
	if (NULL == m_pDeclaration)
	{
		return;
	}
	m_pDocument->LinkEndChild(m_pDeclaration);

	//创建根节点
	std::string xmlFileName = m_xmlFileName;
	std::string rootName = (xmlFileName.substr(0, xmlFileName.find(".")));//根节点元素名为文件名去掉.xml
	TiXmlElement *pRoot = new TiXmlElement(rootName.c_str());
	if (NULL == pRoot)
	{
		return;
	}
	//关联XML文档，成为XML文档的根节点
	m_pDocument->LinkEndChild(pRoot);

	TiXmlText *pText = new TiXmlText("IOService");
	pRoot->LinkEndChild(pText);

	for (std::map<std::string, std::string>::iterator it = ioName.begin(); it != ioName.end(); it++) {
		TiXmlElement *pIOName = new TiXmlElement(it->first.c_str());
		TiXmlText *pIONameText = new TiXmlText(it->second.c_str());
		pIOName->LinkEndChild(pIONameText);
		pRoot->LinkEndChild(pIOName);
	}

	for (std::map<std::string, std::string>::iterator it = ioStatus.begin(); it != ioStatus.end(); it++) {
		TiXmlElement *pIOStatus = new TiXmlElement(it->first.c_str());
		TiXmlText *pIOStatusText = new TiXmlText(it->second.c_str());
		pIOStatus->LinkEndChild(pIOStatusText);
		pRoot->LinkEndChild(pIOStatus);
	}

	for (std::map<std::string, std::string>::iterator it = ioEnet.begin(); it != ioEnet.end(); it++) {
		TiXmlElement *pIOEnet = new TiXmlElement(it->first.c_str());
		TiXmlText *pIOEnetText = new TiXmlText(it->second.c_str());
		pIOEnet->LinkEndChild(pIOEnetText);
		pRoot->LinkEndChild(pIOEnet);
	}
	m_pDocument->SaveFile(m_xmlFileName);
}

void XMLFile::CreateXML(const char *times, const char *cnt1, const char *cnt2, const char *delay1, const char *delay2)
{
	//创建XML文档指针
	m_pDocument = new TiXmlDocument(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return;
	}

	//声明XML
	m_pDeclaration = new TiXmlDeclaration("1.0", "UTF-8", "");
	if (NULL == m_pDeclaration)
	{
		return;
	}
	m_pDocument->LinkEndChild(m_pDeclaration);

	//创建根节点
	std::string xmlFileName = m_xmlFileName;
	std::string rootName = (xmlFileName.substr(0, xmlFileName.find(".")));//根节点元素名为文件名去掉.xml
	TiXmlElement *pRoot = new TiXmlElement(rootName.c_str());
	if (NULL == pRoot)
	{
		return;
	}
	//关联XML文档，成为XML文档的根节点
	m_pDocument->LinkEndChild(pRoot);

	TiXmlText *pText = new TiXmlText("CycleCounterDelayValue");
	pRoot->LinkEndChild(pText);

	TiXmlElement *pCycleValue = new TiXmlElement("CycleTimes");
	TiXmlText *pCycleValueText = new TiXmlText(times);
	pCycleValue->LinkEndChild(pCycleValueText);

	TiXmlElement *pCounter1Value = new TiXmlElement("Counter1");
	TiXmlText *pCounter1ValueText = new TiXmlText(cnt1);
	pCounter1Value->LinkEndChild(pCounter1ValueText);

	TiXmlElement *pCounter2Value = new TiXmlElement("Counter2");
	TiXmlText *pCounter2ValueText = new TiXmlText(cnt2);
	pCounter2Value->LinkEndChild(pCounter2ValueText);

	TiXmlElement *pDelay1Value = new TiXmlElement("Delay1");
	TiXmlText *pDelay1ValueText = new TiXmlText(delay1);
	pDelay1Value->LinkEndChild(pDelay1ValueText);

	TiXmlElement *pDelay2Value = new TiXmlElement("Delay2");
	TiXmlText *pDelay2ValueText = new TiXmlText(delay2);
	pDelay2Value->LinkEndChild(pDelay2ValueText);

	pRoot->LinkEndChild(pCycleValue);
	pRoot->LinkEndChild(pCounter1Value);
	pRoot->LinkEndChild(pCounter2Value);
	pRoot->LinkEndChild(pDelay1Value);
	pRoot->LinkEndChild(pDelay2Value);

	m_pDocument->SaveFile(m_xmlFileName);

	//delete m_pDocument;
	//delete m_pDeclaration;
	//delete pRoot;
	//delete pText;
	//delete pCycleValue;
	//delete pCycleValueText;
}

//读取XML文件完整内容
void XMLFile::ReadXML()
{
	// 需要重新分配空间？
	m_pDocument = new TiXmlDocument(m_xmlFileName);

	if (m_xmlFileName == NULL)
	{
		std::cout << " null " << std::endl;
		return;
	}

	m_pDocument->LoadFile(m_xmlFileName);
	m_pDocument->Print();

	//delete m_pDocument;
}

//读取XML声明，例如：<?xml version="1.0" encoding="UTF-8" ?>
void XMLFile::ReadDeclaration(std::string &version, std::string &encoding, std::string &standalone)
{
	m_pDocument = new TiXmlDocument(m_xmlFileName);

	m_pDocument->LoadFile(m_xmlFileName);

	TiXmlNode *pNode = m_pDocument->FirstChild();
	if (NULL != pNode)
	{
		//获取声明指针
		m_pDeclaration = pNode->ToDeclaration();

		if (NULL != m_pDeclaration)
		{
			version = m_pDeclaration->Version();
			encoding = m_pDeclaration->Encoding();
			standalone = m_pDeclaration->Standalone();
		}
	}
}

//根据节点名，判断节点是否存在
bool XMLFile::FindNode(TiXmlElement *pRoot, const std::string nodeName, TiXmlElement *&pNode)
{
	const char *value = pRoot->Value();
	if (strcmp(pRoot->Value(), nodeName.c_str()) == 0)
	{
		pNode = pRoot;
		return true;
	}

	TiXmlElement *p = pRoot;
	for (p = p->FirstChildElement(); p != NULL; p = p->NextSiblingElement())
	{
		if (p->Value() == nodeName) {
			pNode = p;
			return true;
		}
	}
	return false;
}

// 读取XML文件内容，返回一张map(用于ioService)
void XMLFile::XML2Map(std::map<std::string, std::string> &res) {
	// 需要重新分配空间？
	m_pDocument = new TiXmlDocument(m_xmlFileName);
	m_pDocument->LoadFile(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return;
	}
	TiXmlElement *pRoot = m_pDocument->RootElement();
	const char *value = pRoot->Value();
	if (NULL == pRoot)
	{
		return;
	}
	TiXmlElement *p = pRoot;
	for (p = p->FirstChildElement(); p != NULL; p = p->NextSiblingElement())
	{
		res.insert(std::pair <std::string, std::string> (p->Value(), p->GetText()));
	}
}

// 读取XML文件内容，返回一个vector(用于CycleStep)
void XMLFile::XML2Vect(std::vector<std::vector<std::string>> &vect) {
	std::vector<std::string> _vect;
	m_pDocument = new TiXmlDocument(m_xmlFileName);
	m_pDocument->LoadFile(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return;
	}
	TiXmlElement *pRoot = m_pDocument->RootElement();
	const char *value = pRoot->Value();
	
	if (NULL == pRoot)
	{
		return;
	}
	TiXmlElement *p = pRoot;
	for (p = p->FirstChildElement(); p != NULL; p = p->NextSiblingElement())
	{
		_vect.push_back(p->GetText());
		TiXmlElement *step = p;
		for (step = step->FirstChildElement(); step != NULL; step = step->NextSiblingElement())
		{
			_vect.push_back(step->GetText());
		}
		vect.push_back(_vect);
		while(!_vect.empty()){
			_vect.pop_back();
		}
	}

	std::string moldId = pRoot->Attribute("MoldObjId");

	if (vect[0].size() == 5) {	// block
		for (int i = 0; i < vect.size(); i++) {
			vect[i][0] = moldId;
		}
	}
	else {	// step
		for (int i = 0; i < vect.size(); i++) {
			vect[i].push_back(moldId);
		}
	}

	//for (int i = 0; i < vect.size(); i++) {
	//	for (int j = 0; j < vect[i].size(); j++) {
	//		std::cout << vect[i][j] << " ";
	//	}
	//	std::cout << std::endl;
	//}
	//std::cout << pRoot->Attribute("MoldObjId") << std::endl;
}

//根据节点名，获取该节点文本
bool XMLFile::GetNodeText(const std::string nodeName, const char *&text)
{
	// 需要重新分配空间？
	m_pDocument = new TiXmlDocument(m_xmlFileName);

	m_pDocument->LoadFile(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return false;
	}

	TiXmlElement *pRoot = m_pDocument->RootElement();
	const char *value = pRoot->Value();
	if (NULL == pRoot)
	{
		return false;
	}

	TiXmlElement *pNode = NULL;
	if (FindNode(pRoot, nodeName, pNode))
	{
		text = pNode->GetText();
		return true;
	}

	return false;
}

//获取根据节点名， 获取节点属性
bool XMLFile::GetNodeAttribute(const std::string nodeName, std::map<std::string, std::string> &mapAttribute)
{
	m_pDocument->LoadFile(m_xmlFileName);
	if (NULL == m_pDocument)
	{
		return false;
	}

	TiXmlElement *pRoot = m_pDocument->RootElement();
	if (NULL == pRoot)
	{
		return false;
	}

	TiXmlElement *pNode = NULL;
	if (FindNode(pRoot, nodeName, pNode))
	{
		TiXmlAttribute *pAttr = NULL;
		for (pAttr = pNode->FirstAttribute(); pAttr != NULL; pAttr = pAttr->Next())
		{
			std::string name = pAttr->Name();
			std::string value = pAttr->Value();
			mapAttribute.insert(make_pair(name, value));
		}

		return true;
	}

	return false;
}

//删除节点
bool XMLFile::DeleteNode(const std::string nodeName)
{
	m_pDocument->LoadFile(m_xmlFileName);

	TiXmlElement *pRoot = m_pDocument->RootElement();
	if (NULL == pRoot)
	{
		return false;
	}

	TiXmlElement *pNode = NULL;
	if (FindNode(pRoot, nodeName, pNode))
	{
		if (pNode == pRoot)
		{//如果是根节点
			m_pDocument->RemoveChild(pRoot);
			m_pDocument->SaveFile(m_xmlFileName);
			return true;
		}
		else
		{//子节点
			TiXmlNode *parent = pNode->Parent();//找到该节点的父节点
			if (NULL == parent)
			{
				return false;
			}

			TiXmlElement *parentElem = parent->ToElement();
			if (NULL == parentElem)
			{
				return false;
			}
			parentElem->RemoveChild(pNode);
			m_pDocument->SaveFile(m_xmlFileName);
			return true;
		}
	}

	return false;
}

//修改节点文本
bool XMLFile::modifyText(const std::string nodeName, const std::string text)
{
	// 需要重新分配空间？
	m_pDocument = new TiXmlDocument(m_xmlFileName);

	m_pDocument->LoadFile(m_xmlFileName);

	TiXmlElement *pRoot = m_pDocument->RootElement();
	if (NULL == pRoot)
	{
		return false;
	}

	TiXmlElement *pNode = NULL;
	if (FindNode(pRoot, nodeName, pNode))
	{
		pNode->Clear();//删除原节点下的其他元素
		TiXmlText *pText = new TiXmlText(text.c_str());
		pNode->LinkEndChild(pText);
		m_pDocument->SaveFile(m_xmlFileName);
		return true;
	}
	return false;
}

//修改节点属性
bool XMLFile::modifyAttribution(const std::string nodeName, std::map<std::string, std::string> &mapAttribute)
{
	m_pDocument->LoadFile(m_xmlFileName);

	TiXmlElement *pRoot = m_pDocument->RootElement();
	if (NULL == pRoot)
	{
		return false;
	}

	TiXmlElement *pNode = NULL;
	if (FindNode(pRoot, nodeName, pNode))
	{
		TiXmlAttribute *pAttr = pNode->FirstAttribute();
		char *strName = NULL;
		for (; pAttr != NULL; pAttr = pAttr->Next())
		{
			strName = const_cast<char *>(pAttr->Name());
			for (auto it = mapAttribute.begin(); it != mapAttribute.end(); ++it)
			{
				if (strName == it->first)
				{
					pNode->SetAttribute(strName, it->second.c_str());
				}
			}
		}
		m_pDocument->SaveFile(m_xmlFileName);
		return true;
	}

	return false;
}

//在名为nodeName的节点下插入子节点
bool XMLFile::AddNode(const std::string nodeName, const char * newNodeName, const char *text)
{
	m_pDocument->LoadFile(m_xmlFileName);

	TiXmlElement *pRoot = m_pDocument->RootElement();
	if (NULL == pRoot)
	{
		return false;
	}

	TiXmlElement *pNode = NULL;
	if (FindNode(pRoot, nodeName, pNode))
	{
		TiXmlElement *pNewNode = new TiXmlElement(newNodeName);
		TiXmlText *pNewText = new TiXmlText(text);
		pNewNode->LinkEndChild(pNewText);
		pNode->InsertEndChild(*pNewNode);
		m_pDocument->SaveFile(m_xmlFileName);
		return true;
	}

	return false;
}
