#pragma once
#include <iostream>
#include "tinyxml.h"
//#include "tinystr.h"
#include <map>
#include <vector>
#include <string>

class XMLFile
{
public:
	XMLFile(const char *xmlFileName);
	~XMLFile();

public:
	// 创建 循环/计数/延迟参数XML
	void CreateXML(const char *times, const char *cnt1, const char *cnt2, const char *delay1, const char *delay2);//创建XML文件
	// 创建 IO服务属性XML
	void CreateXML(std::map<std::string, std::string> ioName, std::map<std::string, std::string> ioStatus, std::map<std::string, std::string> ioEnet);
	// 创建 循环步骤XML
	void CreateXML(std::vector<std::vector<std::string>> vec_modify, int moldId);
	// 创建 图像框XML
	void CreateXML(std::vector<std::vector<int>> block, int moldId);

	void CreateXML(std::map<std::string, std::string> map);

	void ReadXML();//读取XML文件完整内容
	void ReadDeclaration(std::string &version, std::string &encoding, std::string &standalone);//读取XML声明
	bool FindNode(TiXmlElement *pRoot, const std::string nodeName, TiXmlElement *&pNode);//根据节点名，判断节点是否存在
	bool GetNodeText(const std::string nodeName, const char *&text);//根据节点名，获取该节点文本
	bool GetNodeAttribute(const std::string nodeName, std::map<std::string, std::string> &mapAttribute);//获取根据节点名， 获取节点属性
	bool DeleteNode(const std::string nodeName);//根据节点名，删除节点
	bool modifyText(const std::string nodeName, const std::string text);//修改节点文本
	bool modifyAttribution(const std::string nodeName, std::map<std::string, std::string> &mapAttribute);//修改节点属性
	bool AddNode(const std::string nodeName, const char * newNodeName, const char *text);//添加节点

	// 读取XML文件内容，返回一张map(用于ioService)
	void XML2Map(std::map<std::string, std::string> &res);
	// 读取XML文件内容，返回一个vector(用于CycleStep)
	void XML2Vect(std::vector<std::vector<std::string>> &vect);

private:
	char *m_xmlFileName;
	TiXmlDocument *m_pDocument;
	TiXmlDeclaration *m_pDeclaration;
};

