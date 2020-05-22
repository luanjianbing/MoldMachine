#pragma once
#include <iostream>

// 手动输入步骤用
struct Node {
	int idx;	// 当前节点ID
	std::string cmd;	// 当前节点指令
	int nextIdx;	// 下一节点ID
};