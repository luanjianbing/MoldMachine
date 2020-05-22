#include <iostream>

#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include <opencv2/core/core.hpp>

#include <time.h>

using namespace std;
using namespace cv;


Point2f detectCorners(Mat srcgray)//�����ǵ�֮�����
{
	vector<Point2f> corners;//�ṩ��ʼ�ǵ������λ�ú;�ȷ�������λ��
	int maxcorners = 1;
	double qualityLevel = 0.01;  //�ǵ���ɽ��ܵ���С����ֵ
	double minDistance = 20;	//�ǵ�֮����С����
	int blockSize = 3;//���㵼������ؾ���ʱָ��������Χ
	double  k = 0.04; //Ȩ��ϵ��
	goodFeaturesToTrack(srcgray, corners, maxcorners, qualityLevel, minDistance, Mat(), blockSize, false, k);
	//for (unsigned i = 0; i < corners.size(); i++)
	//{
	//	circle(srcgray, corners[i], 4, Scalar(0, 255, 0));
	//	//cout << "�ǵ����꣺" << corners[i] << endl;
	//}
	//imshow("...", srcgray);
	//Ѱ�������ؽǵ�
	Size winSize = Size(5, 5);  //���ش��ڵ�һ��ߴ�
	Size zeroZone = Size(-1, -1);//��ʾ������һ��ߴ�
								 //��ǵ�ĵ������̵���ֹ���������ǵ�λ�õ�ȷ��
	TermCriteria criteria = TermCriteria(CV_TERMCRIT_EPS + CV_TERMCRIT_ITER, 40, 0.001);
	cornerSubPix(srcgray, corners, winSize, zeroZone, criteria);
	Point2f point = corners[0];
	//for (unsigned i = 0; i < 3; i++)
	//{
	//	circle(srcgray, corners[i], 4, Scalar(0, 255, 0));
	//	cout << "�ǵ����꣺" << corners[i] << endl;
	//}
	//imshow("dian", srcgray);
	//cout << point[0] << point[1] << point[2] << endl;
	return point;
	//for (unsigned i = 0; i < corners.size(); i++)
	//{
	//	circle(srcgray, corners[i], 4, Scalar(0, 255, 0));
	//	//cout << "�ǵ����꣺" << corners[i] << endl;
	//}
}
int main(int argc, const char** argv)
{
	clock_t start, finish;
	double time;
	start = clock();

	Mat g_srcImage, g_srcTemp, g_srcImage_dst, grayImage, grayTemp;
	g_srcImage = imread("./after_ejection.png");//363��׼����ͼ.jpg
	//g_srcTemp = imread("C:\\Users\\31317\\Desktop\\zhusuji\\picture_test\\3271��׼ģ��.png");
	cvtColor(g_srcImage, grayImage, COLOR_BGR2GRAY);//�Ҷ� ���ͼ�����
	imshow("grayImage", grayImage);
	//cvtColor(g_srcTemp, grayTemp, COLOR_BGR2GRAY);//�Ҷ� ���ͼ�����
	Mat out[3];
	out[0] = grayImage(Range(10, 40), Range(15, 40));
	out[1] = grayImage(Range(10, 40), Range(110, 140));
	out[2] = grayImage(Range(110, 140), Range(80, 110));
	imshow("out[0]", out[0]);
	imshow("out[1]", out[1]);
	imshow("out[2]", out[2]);
	Point2f pointImage[3];
	for (int i = 0; i < 3; i++)
	{
		pointImage[i] = detectCorners(out[i]);
	}
	//Point2f pointImage0 = detectCorners(out[0]);
	//Point2f pointImage1 = detectCorners(out1);
	//Point2f pointImage2 = detectCorners(out2);

	//Point2f Imagepoint[3] = { pointImage[0] ,pointImage[1] ,pointImage[2] };
	Point2f Imagepoint[3] = { Point2f(pointImage[0].x + 15,pointImage[0].y + 10) ,Point2f(pointImage[1].x + 110,pointImage[1].y + 10) ,Point2f(pointImage[2].x + 80,pointImage[2].y + 110) };
	//Point2f *pointTemp = detectCorners(grayTemp);
	//Point2f Temppoint[3] = { *pointTemp ,*(pointTemp + 1) ,*(pointTemp + 2) };
	//Mat out00 = grayTemp(Range(20, 50), Range(60, 90));
	//Mat out01 = grayTemp(Range(20, 50), Range(160, 190));
	//Mat out02 = grayTemp(Range(120, 150), Range(130, 160));
	//Point2f pointImage00 = detectCorners(out00);
	//Point2f pointImage01 = detectCorners(out01);
	//Point2f pointImage02 = detectCorners(out02);
	Point2f Temppoint[3] = { Point2f(75.8537,36.7989),Point2f(171.591,36.0262),Point2f(143.238,138.855) };
	//ģ���
	 //Point2f Temppoint[3] = { Point2f(pointImage00.x + 60,pointImage00.y + 20) ,Point2f(pointImage01.x + 160,pointImage01.y + 20) ,Point2f(pointImage02.x + 130,pointImage02.y + 120) };
	 //cout << Imagepoint[0]<< Imagepoint[1]<< Imagepoint[2]<<endl;
	//cout << Temppoint[0] << Temppoint[1]<< Temppoint[2]<< endl;
	Mat site_mat = getAffineTransform(Imagepoint, Temppoint);
	warpAffine(g_srcImage, g_srcImage_dst, site_mat, g_srcImage.size());
	imshow("���ͼ", g_srcImage_dst);
	finish = clock();    //����
	time = (double)(finish - start) / CLOCKS_PER_SEC;//��������ʱ��
	cout << "time:" << time << "s";
	//system("pause");
	waitKey(0);
	return 0;
}