#include "Adam6060.h"

Adam6060::Adam6060() {
	CoInitialize(NULL);
	HRESULT hr = CLSIDFromProgID(OLESTR("Adam6060Com.Adam6060Operate"), &clsid);
	hr = CoCreateInstance(clsid, NULL, CLSCTX_INPROC_SERVER, __uuidof(Adam6060Com::DoAdam6060), (LPVOID*)&ptr);
}

bool Adam6060::Adam6060Init(std::string Adam_IP, int Adam_Port) {
	bool res = ptr->Adam6060Init(Adam_IP.c_str(), (long)Adam_Port);
	if (res) {
		std::cout << "Adam6060 Init Success" << std::endl;
	}
	else {
		std::cout << "Adam6060 Init Fail" << std::endl;
	}
	return res;
}

void Adam6060::Adam6060SingleSetOut(int Adam_out, bool Adam_status) {
	ptr->Adam6060SingleSetOut(Adam_out, Adam_status);
}

bool Adam6060::Adam6060ReadStatus(int Adam_in) {
	bool res = ptr->Adam6060ReadStatus(Adam_in);
	return res;
}

int Adam6060::Adam6060ReadAllStatus(int mask) {
	// 读出来的这个数是将每个口（1-6）视为二进制位的一位
	// 即二进制编码为十进制得到的数值
	// 如111111 -> 63
	int readRes = ptr->Adam6060ReadAllStatus();
	// mask为所需要的掩码，与&运算
	// 如需要读入后两位，那么mask = 000011 = 3
	// res = mask & readRes = 0000xx，结果res可能为0-3中的某一数值
	int res = readRes & mask;
	return res;
}

Adam6060::~Adam6060() {
	CoUninitialize();
	ptr->Adam6060DisConnect();
	//delete ptr;
}