#include<iostream>
#include<opencv2/highgui.hpp>
#include<opencv2/core.hpp>
#include<opencv2/imgcodecs.hpp>
#include<opencv2/opencv.hpp>
using namespace std;
using namespace cv;

const int gray_level = 16;

void getglcm_horison(Mat& input, Mat& dst)//0�ȻҶȹ�������
{
	Mat src = input;
	CV_Assert(1 == src.channels());
	src.convertTo(src, CV_32S);
	int height = src.rows;
	int width = src.cols;
	int max_gray_level = 0;
	for (int j = 0; j < height; j++)//Ѱ�����ػҶ����ֵ
	{
		int* srcdata = src.ptr<int>(j);
		for (int i = 0; i < width; i++)
		{
			if (srcdata[i] > max_gray_level)
			{
				max_gray_level = srcdata[i];
			}
		}
	}
	max_gray_level++;//���ػҶ����ֵ��1��Ϊ�þ�����ӵ�еĻҶȼ���
	if (max_gray_level > 16)//���Ҷȼ�������16����ͼ��ĻҶȼ���С��16������С�Ҷȹ�������Ĵ�С��
	{
		for (int i = 0; i < height; i++)
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width; j++)
			{
				srcdata[j] = (int)srcdata[j] / gray_level;
			}
		}

		dst.create(gray_level, gray_level, CV_32SC1);
		dst = Scalar::all(0);
		for (int i = 0; i < height; i++)
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width - 1; j++)
			{
				int rows = srcdata[j];
				int cols = srcdata[j + 1];
				dst.ptr<int>(rows)[cols]++;
			}
		}
	}
	else//���Ҷȼ���С��16����������Ӧ�ĻҶȹ�������
	{
		dst.create(max_gray_level, max_gray_level, CV_32SC1);
		dst = Scalar::all(0);
		for (int i = 0; i < height; i++)
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width - 1; j++)
			{
				int rows = srcdata[j];
				int cols = srcdata[j + 1];
				dst.ptr<int>(rows)[cols]++;
			}
		}
	}
}


void getglcm_vertical(Mat& input, Mat& dst)//90�ȻҶȹ�������
{
	Mat src = input;
	CV_Assert(1 == src.channels());
	src.convertTo(src, CV_32S);
	int height = src.rows;
	int width = src.cols;
	int max_gray_level = 0;
	for (int j = 0; j < height; j++)
	{
		int* srcdata = src.ptr<int>(j);
		for (int i = 0; i < width; i++)
		{
			if (srcdata[i] > max_gray_level)
			{
				max_gray_level = srcdata[i];
			}
		}
	}
	max_gray_level++;
	if (max_gray_level > 16)
	{
		for (int i = 0; i < height; i++)//��ͼ��ĻҶȼ���С��16������С�Ҷȹ�������Ĵ�С��
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width; j++)
			{
				srcdata[j] = (int)srcdata[j] / gray_level;
			}
		}

		dst.create(gray_level, gray_level, CV_32SC1);
		dst = Scalar::all(0);
		for (int i = 0; i < height - 1; i++)
		{
			int*srcdata = src.ptr<int>(i);
			int*srcdata1 = src.ptr<int>(i + 1);
			for (int j = 0; j < width; j++)
			{
				int rows = srcdata[j];
				int cols = srcdata1[j];
				dst.ptr<int>(rows)[cols]++;
			}
		}
	}
	else
	{
		dst.create(max_gray_level, max_gray_level, CV_32SC1);
		dst = Scalar::all(0);
		for (int i = 0; i < height - 1; i++)
		{
			int*srcdata = src.ptr<int>(i);
			int*srcdata1 = src.ptr<int>(i + 1);
			for (int j = 0; j < width; j++)
			{
				int rows = srcdata[j];
				int cols = srcdata1[j];
				dst.ptr<int>(rows)[cols]++;
			}
		}
	}
}


void getglcm_45(Mat& input, Mat& dst)//45�ȻҶȹ�������
{
	Mat src = input;
	CV_Assert(1 == src.channels());
	src.convertTo(src, CV_32S);
	int height = src.rows;
	int width = src.cols;
	int max_gray_level = 0;
	for (int j = 0; j < height; j++)
	{
		int* srcdata = src.ptr<int>(j);
		for (int i = 0; i < width; i++)
		{
			if (srcdata[i] > max_gray_level)
			{
				max_gray_level = srcdata[i];
			}
		}
	}
	max_gray_level++;
	if (max_gray_level > 16)
	{
		for (int i = 0; i < height; i++)//��ͼ��ĻҶȼ���С��16������С�Ҷȹ�������Ĵ�С��
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width; j++)
			{
				srcdata[j] = (int)srcdata[j] / gray_level;
			}
		}

		dst.create(gray_level, gray_level, CV_32SC1);
		dst = Scalar::all(0);
		for (int i = 0; i < height - 1; i++)
		{
			int*srcdata = src.ptr<int>(i);
			int*srcdata1 = src.ptr<int>(i + 1);
			for (int j = 0; j < width - 1; j++)
			{
				int rows = srcdata[j];
				int cols = srcdata1[j + 1];
				dst.ptr<int>(rows)[cols]++;
			}
		}
	}
	else
	{
		dst.create(max_gray_level, max_gray_level, CV_32SC1);
		dst = Scalar::all(0);
		for (int i = 0; i < height - 1; i++)
		{
			int*srcdata = src.ptr<int>(i);
			int*srcdata1 = src.ptr<int>(i + 1);
			for (int j = 0; j < width - 1; j++)
			{
				int rows = srcdata[j];
				int cols = srcdata1[j + 1];
				dst.ptr<int>(rows)[cols]++;
			}
		}
	}
}


void getglcm_135(Mat& input, Mat& dst)//135�ȻҶȹ�������
{
	Mat src = input;
	CV_Assert(1 == src.channels());
	src.convertTo(src, CV_32S);
	int height = src.rows;
	int width = src.cols;
	int max_gray_level = 0;
	for (int j = 0; j < height; j++)
	{
		int* srcdata = src.ptr<int>(j);
		for (int i = 0; i < width; i++)
		{
			if (srcdata[i] > max_gray_level)
			{
				max_gray_level = srcdata[i];
			}
		}
	}
	max_gray_level++;
	if (max_gray_level > 16)
	{
		for (int i = 0; i < height; i++)//��ͼ��ĻҶȼ���С��16������С�Ҷȹ�������Ĵ�С��
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width; j++)
			{
				srcdata[j] = (int)srcdata[j] / gray_level;
			}
		}

		dst.create(gray_level, gray_level, CV_32SC1);
		dst = Scalar::all(0);
		for (int i = 0; i < height - 1; i++)
		{
			int*srcdata = src.ptr<int>(i);
			int*srcdata1 = src.ptr<int>(i + 1);
			for (int j = 1; j < width; j++)
			{
				int rows = srcdata[j];
				int cols = srcdata1[j - 1];
				dst.ptr<int>(rows)[cols]++;
			}
		}
	}
	else
	{
		dst.create(max_gray_level, max_gray_level, CV_32SC1);
		dst = Scalar::all(0);
		for (int i = 0; i < height - 1; i++)
		{
			int*srcdata = src.ptr<int>(i);
			int*srcdata1 = src.ptr<int>(i + 1);
			for (int j = 1; j < width; j++)
			{
				int rows = srcdata[j];
				int cols = srcdata1[j - 1];
				dst.ptr<int>(rows)[cols]++;
			}
		}
	}
}

void feature_computer(Mat&src, double& Asm, double& Eng, double& Con, double& Idm)//��������ֵ
{
	int height = src.rows;
	int width = src.cols;
	int total = 0;
	for (int i = 0; i < height; i++)
	{
		int*srcdata = src.ptr<int>(i);
		for (int j = 0; j < width; j++)
		{
			total += srcdata[j];//��ͼ���������صĻҶ�ֵ�ĺ�
		}
	}

	Mat copy;
	copy.create(height, width, CV_64FC1);
	for (int i = 0; i < height; i++)
	{
		int*srcdata = src.ptr<int>(i);
		double*copydata = copy.ptr<double>(i);
		for (int j = 0; j < width; j++)
		{
			copydata[j] = (double)srcdata[j] / (double)total;//ͼ��ÿһ�����صĵ�ֵ���������ܺ�
		}
	}


	for (int i = 0; i < height; i++)
	{
		double*srcdata = copy.ptr<double>(i);
		for (int j = 0; j < width; j++)
		{
			Asm += srcdata[j] * srcdata[j];//����
			if (srcdata[j]>0)
				Eng -= srcdata[j] * log(srcdata[j]);//��             
			Con += (double)(i - j)*(double)(i - j)*srcdata[j];//�Աȶ�
			Idm += srcdata[j] / (1 + (double)(i - j)*(double)(i - j));//����
		}
	}
}

double similarity(cv::Mat img1_gray, cv::Mat img2_gray, int winSize) {
	// img1 img2 ͬ�ȴ�С
	// ����Ϊ�Ҷ�ͼ��
	if (img1_gray.channels() != 1 || img2_gray.channels() != 1 || img1_gray.size() != img2_gray.size()) {
		return -1;
	}

	cv::Mat img1 = img1_gray.clone();
	cv::Mat img2 = img2_gray.clone();

	cv::Mat dst_horison_1, dst_vertical_1, dst_45_1, dst_135_1;
	cv::Mat dst_horison_2, dst_vertical_2, dst_45_2, dst_135_2;

	int windowSize = winSize;

	double eng_horison_1 = 0, con_horison_1 = 0, idm_horison_1 = 0, asm_horison_1 = 0;
	double eng_horison_2 = 0, con_horison_2 = 0, idm_horison_2 = 0, asm_horison_2 = 0;
	double dist;
	std::vector<double> dist_all;
	double minVal = 1000;
	double maxVal = 0;

	for (int i = 0; i < img1.cols - windowSize; i++) {
		for (int j = 0; j < img1.rows - windowSize; j++) {
			cv::Mat window_1 = img1(cv::Rect(i, j, windowSize, windowSize));
			cv::Mat window_2 = img2(cv::Rect(i, j, windowSize, windowSize));
			getglcm_horison(window_1, dst_horison_1);
			getglcm_horison(window_2, dst_horison_2);
			feature_computer(dst_horison_1, asm_horison_1, eng_horison_1, con_horison_1, idm_horison_1);
			feature_computer(dst_horison_2, asm_horison_2, eng_horison_2, con_horison_2, idm_horison_2);
			//dist = sqrt(pow((asm_horison_1 - asm_horison_2), 2)
			//			+ pow((eng_horison_1 - eng_horison_2), 2)
			//			+ pow((con_horison_1 - con_horison_2), 2)
			//			+ pow((idm_horison_1 - idm_horison_2), 2));
			//dist_all.push_back(dist);
			//if (dist < minVal) minVal = dist;
			//if (dist > maxVal) maxVal = dist;
			dist = (asm_horison_1 * asm_horison_2 + eng_horison_1 * eng_horison_2 + con_horison_1 * con_horison_2 + idm_horison_1 * idm_horison_2);
			dist = dist / (sqrt(pow((asm_horison_1), 2) + pow((eng_horison_1), 2) + pow((con_horison_1), 2) + pow((idm_horison_1), 2))
				* sqrt(pow((asm_horison_2), 2) + pow((eng_horison_2), 2) + pow((con_horison_2), 2) + pow((idm_horison_2), 2)));
			dist_all.push_back(dist);
			if (dist < minVal) minVal = dist;
		}
	}
	double res = minVal;
	return res;
	//getglcm_horison(img1, dst_horison_1);
	//getglcm_vertical(img1, dst_vertical_1);
	//getglcm_45(img1, dst_45_1);
	//getglcm_135(img1, dst_135_1);

	//getglcm_horison(img2, dst_horison_2);
	//getglcm_vertical(img2, dst_vertical_2);
	//getglcm_45(img2, dst_45_2);
	//getglcm_135(img2, dst_135_2);

	//double eng_horison_1 = 0, con_horison_1 = 0, idm_horison_1 = 0, asm_horison_1 = 0;
	//feature_computer(dst_horison_1, asm_horison_1, eng_horison_1, con_horison_1, idm_horison_1);
}

int main() {

	Mat src1 = imread("./test1.jpg");
	Mat src2 = imread("./test2.jpg");
	Mat src1_gray, src2_gray;
	cvtColor(src1, src1_gray, COLOR_BGR2GRAY);
	cvtColor(src2, src2_gray, COLOR_BGR2GRAY);
	double res = similarity(src1_gray, src2_gray, 9);
	std::cout << res << std::endl;
	system("pause");
	return 0;
}

//int main()
//{
//	Mat dst_horison, dst_vertical, dst_45, dst_135;
//
//	Mat src = imread("./test.jpg");
//	if (src.empty())
//	{
//		return -1;
//	}
//	Mat src_gray;
//	//src.create(src.size(), CV_8UC1);
//	//src_gray = Scalar::all(0);
//	cvtColor(src, src_gray, COLOR_BGR2GRAY);
//
//	//src =( Mat_<int>(6, 6) << 0, 1, 2, 3, 0, 1, 1, 2, 3, 0, 1, 2, 2, 3, 0, 1, 2, 3, 3, 0, 1, 2, 3, 0, 0, 1, 2, 3, 0, 1, 1, 2, 3, 0, 1, 2 );
//	//src = (Mat_<int>(4, 4) << 1, 17, 0, 3,3,2,20,5,26,50,1,2,81,9,25,1);
//	getglcm_horison(src_gray, dst_horison);
//	getglcm_vertical(src_gray, dst_vertical);
//	getglcm_45(src_gray, dst_45);
//	getglcm_135(src_gray, dst_135);
//
//	double eng_horison = 0, con_horison = 0, idm_horison = 0, asm_horison = 0;
//	feature_computer(dst_horison, asm_horison, eng_horison, con_horison, idm_horison);
//
//	cout << "asm_horison:" << asm_horison << endl;
//	cout << "eng_horison:" << eng_horison << endl;
//	cout << "con_horison:" << con_horison << endl;
//	cout << "idm_horison:" << idm_horison << endl;
//
//
//	/*  for (int i = 0; i < dst_horison.rows; i++)
//	{
//	int *data = dst_horison.ptr<int>(i);
//	for (int j = 0; j < dst_horison.cols; j++)
//	{
//	cout << data[j] << " ";
//	}
//	cout << endl;
//	}
//	cout << endl;
//
//	for (int i = 0; i < dst_vertical.rows; i++)
//	{
//	int *data = dst_vertical.ptr<int>(i);
//	for (int j = 0; j < dst_vertical.cols; j++)
//	{
//	cout << data[j] << " ";
//	}
//	cout << endl;
//	}
//	cout << endl;
//
//	for (int i = 0; i < dst_45.rows; i++)
//	{
//	int *data = dst_45.ptr<int>(i);
//	for (int j = 0; j < dst_45.cols; j++)
//	{
//	cout << data[j] << " ";
//	}
//	cout << endl;
//	}
//
//	cout << endl;
//
//	for (int i = 0; i < dst_135.rows; i++)
//	{
//	int *data = dst_135.ptr<int>(i);
//	for (int j = 0; j < dst_135.cols; j++)
//	{
//	cout << data[j] << " ";
//	}
//	cout << endl;
//	}*/
//	system("pause");
//	return 0;
//}