#include <iostream>

#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include <opencv2/core/core.hpp>

#include <opencv2/features2d.hpp>
#include <opencv2/opencv.hpp>

#include <vector>
#include <ctime>

using namespace cv;
using namespace std;

void cvThin(cv::Mat& src, cv::Mat& dst, int intera);

void separateGaussianFilter(const Mat &src, Mat &dst, int ksize, double sigma) {
	CV_Assert(src.channels() == 1 || src.channels() == 3); //只处理单通道或者三通道图像
														   //生成一维的
	double *matrix = new double[ksize];
	double sum = 0;
	int origin = ksize / 2;
	for (int i = 0; i < ksize; i++) {
		double g = exp(-(i - origin) * (i - origin) / (2 * sigma * sigma));
		sum += g;
		matrix[i] = g;
	}
	for (int i = 0; i < ksize; i++) matrix[i] /= sum;
	int border = ksize / 2;
	copyMakeBorder(src, dst, border, border, border, border, BORDER_CONSTANT);
	int channels = dst.channels();
	int rows = dst.rows - border;
	int cols = dst.cols - border;
	//水平方向
	for (int i = border; i < rows; i++) {
		for (int j = border; j < cols; j++) {
			double sum[3] = { 0 };
			for (int k = -border; k <= border; k++) {
				if (channels == 1) {
					sum[0] += matrix[border + k] * dst.at<uchar>(i, j + k);
				}
				else if (channels == 3) {
					Vec3b rgb = dst.at<Vec3b>(i, j + k);
					sum[0] += matrix[border + k] * rgb[0];
					sum[1] += matrix[border + k] * rgb[1];
					sum[2] += matrix[border + k] * rgb[2];
				}
			}
			for (int k = 0; k < channels; k++) {
				if (sum[k] < 0) sum[k] = 0;
				else if (sum[k] > 255) sum[k] = 255;
			}
			if (channels == 1)
				dst.at<Vec3b>(i, j) = static_cast<uchar>(sum[0]);
			else if (channels == 3) {
				Vec3b rgb = { static_cast<uchar>(sum[0]), static_cast<uchar>(sum[1]), static_cast<uchar>(sum[2]) };
				dst.at<Vec3b>(i, j) = rgb;
			}
		}
	}
	//竖直方向
	for (int i = border; i < rows; i++) {
		for (int j = border; j < cols; j++) {
			double sum[3] = { 0 };
			for (int k = -border; k <= border; k++) {
				if (channels == 1) {
					sum[0] += matrix[border + k] * dst.at<uchar>(i + k, j);
				}
				else if (channels == 3) {
					Vec3b rgb = dst.at<Vec3b>(i + k, j);
					sum[0] += matrix[border + k] * rgb[0];
					sum[1] += matrix[border + k] * rgb[1];
					sum[2] += matrix[border + k] * rgb[2];
				}
			}
			for (int k = 0; k < channels; k++) {
				if (sum[k] < 0) sum[k] = 0;
				else if (sum[k] > 255) sum[k] = 255;
			}
			if (channels == 1)
				dst.at<Vec3b>(i, j) = static_cast<uchar>(sum[0]);
			else if (channels == 3) {
				Vec3b rgb = { static_cast<uchar>(sum[0]), static_cast<uchar>(sum[1]), static_cast<uchar>(sum[2]) };
				dst.at<Vec3b>(i, j) = rgb;
			}
		}
	}
	delete[] matrix;
}

Mat MultiScaleDetailBoosting(Mat src, int Radius) {
	int rows = src.rows;
	int cols = src.cols;
	Mat B1, B2, B3;
	separateGaussianFilter(src, B1, Radius, 1.0);
	separateGaussianFilter(src, B2, Radius * 2 - 1, 2.0);
	separateGaussianFilter(src, B3, Radius * 4 - 1, 4.0);
	float w1 = 0.5, w2 = 0.5, w3 = 0.25;
	Mat dst(rows, cols, CV_8UC3);
	for (int i = 0; i < rows; i++) {
		for (int j = 0; j < cols; j++) {
			for (int k = 0; k < 3; k++) {
				int D1 = src.at<Vec3b>(i, j)[k] - B1.at<Vec3b>(i, j)[k];
				int D2 = B1.at<Vec3b>(i, j)[k] - B2.at<Vec3b>(i, j)[k];
				int D3 = B2.at<Vec3b>(i, j)[k] - B3.at<Vec3b>(i, j)[k];
				int sign = D1 > 0 ? 1 : -1;
				dst.at<Vec3b>(i, j)[k] = saturate_cast<uchar>((1 - w1*sign) * D1 - w2 * D2 + w3 * D3 + src.at<Vec3b>(i, j)[k]);
			}
		}
	}
	return dst;
}

void test(cv::Mat & inputImg) {
	cv::Mat enhanceImg = MultiScaleDetailBoosting(inputImg, 2);
	cv::imshow("enhanceImg", enhanceImg);

	cv::Mat gray;
	cv::cvtColor(enhanceImg, gray, CV_RGB2GRAY);

	cv::imshow("gray", gray);

	cv::Mat dstImg;
	cv::Canny(gray, dstImg, 50, 150);
	cv::imshow("Canny", dstImg);

	cv::Mat kernel = cv::getStructuringElement(cv::MORPH_ELLIPSE, cv::Size(3, 3));
	dilate(dstImg, dstImg, kernel);
	morphologyEx(dstImg, dstImg, CV_MOP_CLOSE, kernel, cv::Point(-1, -1), 3);
	morphologyEx(dstImg, dstImg, CV_MOP_CLOSE, kernel);

	kernel = cv::getStructuringElement(cv::MORPH_CROSS, cv::Size(3, 3));
	morphologyEx(dstImg, dstImg, CV_MOP_OPEN, kernel);

	cvThin(dstImg, dstImg, 3);
	cv::imshow("cvThin", dstImg);
}

int main() {
	//cv::Mat src = cv::imread("./liewen.jpg");
	//cv::Mat src = cv::imread("./diandu.png");
	//cv::Mat src = cv::imread("./test2.png");
	cv::Mat src = cv::imread("./liewen4.jpg");
	//cv::Mat src = cv::imread("./liewen2.jpeg");
	cv::imshow("src", src);
	clock_t startTime, endTime;

	startTime = clock();	// 计时开始

	test(src);

	endTime = clock();	// 计时结束
	std::cout << "The run time is : "
		<< (double)(endTime - startTime) / CLOCKS_PER_SEC << "s" << std::endl;

	
	cv::waitKey(0);
	system("pause");
	return 0;
}

void cvThin(cv::Mat& src, cv::Mat& dst, int intera)
{
	if (src.type() != CV_8UC1)
	{
		printf("只能处理二值或灰度图像\n");
		return;
	}
	//非原地操作时候，copy src到dst
	if (dst.data != src.data)
	{
		src.copyTo(dst);
	}

	int i, j, n;
	int width, height;
	width = src.cols - 1;
	//之所以减1，是方便处理8邻域，防止越界
	height = src.rows - 1;
	int step = src.step;
	int  p2, p3, p4, p5, p6, p7, p8, p9;
	uchar* img;
	bool ifEnd;
	int A1;
	cv::Mat tmpimg;
	//n表示迭代次数
	for (n = 0; n<intera; n++)
	{
		dst.copyTo(tmpimg);
		ifEnd = false;
		img = tmpimg.data;
		for (i = 1; i < height; i++)
		{
			img += step;
			for (j = 1; j<width; j++)
			{
				uchar* p = img + j;
				A1 = 0;
				if (p[0] > 0)
				{
					if (p[-step] == 0 && p[-step + 1]>0) //p2,p3 01模式
					{
						A1++;
					}
					if (p[-step + 1] == 0 && p[1]>0) //p3,p4 01模式
					{
						A1++;
					}
					if (p[1] == 0 && p[step + 1]>0) //p4,p5 01模式
					{
						A1++;
					}
					if (p[step + 1] == 0 && p[step]>0) //p5,p6 01模式
					{
						A1++;
					}
					if (p[step] == 0 && p[step - 1]>0) //p6,p7 01模式
					{
						A1++;
					}
					if (p[step - 1] == 0 && p[-1]>0) //p7,p8 01模式
					{
						A1++;
					}
					if (p[-1] == 0 && p[-step - 1]>0) //p8,p9 01模式
					{
						A1++;
					}
					if (p[-step - 1] == 0 && p[-step]>0) //p9,p2 01模式
					{
						A1++;
					}
					p2 = p[-step]>0 ? 1 : 0;
					p3 = p[-step + 1]>0 ? 1 : 0;
					p4 = p[1]>0 ? 1 : 0;
					p5 = p[step + 1]>0 ? 1 : 0;
					p6 = p[step]>0 ? 1 : 0;
					p7 = p[step - 1]>0 ? 1 : 0;
					p8 = p[-1]>0 ? 1 : 0;
					p9 = p[-step - 1]>0 ? 1 : 0;
					if ((p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9)>1 && (p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9)<7 && A1 == 1)
					{
						if ((p2 == 0 || p4 == 0 || p6 == 0) && (p4 == 0 || p6 == 0 || p8 == 0)) //p2*p4*p6=0 && p4*p6*p8==0
						{
							dst.at<uchar>(i, j) = 0; //满足删除条件，设置当前像素为0
							ifEnd = true;
						}
					}
				}
			}
		}

		dst.copyTo(tmpimg);
		img = tmpimg.data;
		for (i = 1; i < height; i++)
		{
			img += step;
			for (j = 1; j<width; j++)
			{
				A1 = 0;
				uchar* p = img + j;
				if (p[0] > 0)
				{
					if (p[-step] == 0 && p[-step + 1]>0) //p2,p3 01模式
					{
						A1++;
					}
					if (p[-step + 1] == 0 && p[1]>0) //p3,p4 01模式
					{
						A1++;
					}
					if (p[1] == 0 && p[step + 1]>0) //p4,p5 01模式
					{
						A1++;
					}
					if (p[step + 1] == 0 && p[step]>0) //p5,p6 01模式
					{
						A1++;
					}
					if (p[step] == 0 && p[step - 1]>0) //p6,p7 01模式
					{
						A1++;
					}
					if (p[step - 1] == 0 && p[-1]>0) //p7,p8 01模式
					{
						A1++;
					}
					if (p[-1] == 0 && p[-step - 1]>0) //p8,p9 01模式
					{
						A1++;
					}
					if (p[-step - 1] == 0 && p[-step]>0) //p9,p2 01模式
					{
						A1++;
					}
					p2 = p[-step]>0 ? 1 : 0;
					p3 = p[-step + 1]>0 ? 1 : 0;
					p4 = p[1]>0 ? 1 : 0;
					p5 = p[step + 1]>0 ? 1 : 0;
					p6 = p[step]>0 ? 1 : 0;
					p7 = p[step - 1]>0 ? 1 : 0;
					p8 = p[-1]>0 ? 1 : 0;
					p9 = p[-step - 1]>0 ? 1 : 0;
					if ((p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9)>1 && (p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9)<7 && A1 == 1)
					{
						if ((p2 == 0 || p4 == 0 || p8 == 0) && (p2 == 0 || p6 == 0 || p8 == 0)) //p2*p4*p8=0 && p2*p6*p8==0
						{
							dst.at<uchar>(i, j) = 0; //满足删除条件，设置当前像素为0
							ifEnd = true;
						}
					}
				}
			}
		}

		//如果两个子迭代已经没有可以细化的像素了，则退出迭代
		if (!ifEnd) break;
	}

}
