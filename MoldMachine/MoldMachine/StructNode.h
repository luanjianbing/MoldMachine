#pragma once
#include <iostream>

// �ֶ����벽����
struct Node {
	int idx;	// ��ǰ�ڵ�ID
	std::string cmd;	// ��ǰ�ڵ�ָ��
	int nextIdx;	// ��һ�ڵ�ID
};