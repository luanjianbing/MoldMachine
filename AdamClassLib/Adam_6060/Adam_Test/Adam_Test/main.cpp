#include <iostream>
#include <windows.h>

//typedef void (*DLLFunc)(int, int, int);

using namespace std;

int main() {
	//DLLFunc dllFunc;

	IPUBLICCa

	HINSTANCE hInstLibrary = LoadLibrary(L"Advantech.Adam.DLL");

	if (hInstLibrary == NULL) {
		FreeLibrary(hInstLibrary);
		cout << " FreeLibrary_1" << endl;
	}



	//dllFunc = (DLLFunc)GetProcAddress(hInstLibrary, "SetTimeOut");
	//if (dllFunc == NULL) {
	//	FreeLibrary(hInstLibrary);
	//	cout << " FreeLibrary_2" << endl;
	//}
	//dllFunc(1000, 1000, 1000);
	//FreeLibrary(hInstLibrary);

	system("pause");
	return 0;
}