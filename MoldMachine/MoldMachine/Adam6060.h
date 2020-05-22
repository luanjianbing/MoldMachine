#pragma once

#include <iostream>
#include <Windows.h>
#import "./Adam6060/Adam6060Com.tlb"

class Adam6060 {
public:
	Adam6060();
	~Adam6060();

	bool Adam6060Init(std::string Adam_IP, int Adam_Port);

	void Adam6060SingleSetOut(int Adam_out, bool Adam_status);

	bool Adam6060ReadStatus(int Adam_in);

	int Adam6060ReadAllStatus(int mask);

private:
	CLSID clsid;
	HRESULT hr;
	Adam6060Com::DoAdam6060 *ptr;
};