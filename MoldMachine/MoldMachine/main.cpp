#include "MoldMachine.h"
#include <QtWidgets/QApplication>

#include "xmlFileSetting.h"
#include <iostream>

int main(int argc, char *argv[])
{
	system("chcp 65001");
	QApplication a(argc, argv);

	MoldMachine w;
	w.show();

	return a.exec();
	return 0;
}
