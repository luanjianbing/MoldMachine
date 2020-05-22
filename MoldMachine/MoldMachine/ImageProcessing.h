#pragma once

#include <iostream>

#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include <opencv2/core/core.hpp>

#include <opencv2/features2d.hpp>
#include <opencv2/opencv.hpp>

#include <time.h>

#include <vector>

typedef struct
{
	cv::Point2f left_top;
	cv::Point2f left_bottom;
	cv::Point2f right_top;
	cv::Point2f right_bottom;
}four_corners_t;

class ImageProcessing {
public:
	// （送过来图像mat，方框坐标(n*4)待处理）
	ImageProcessing(cv::Mat &mat, cv::Mat &now_mat, std::vector<std::vector<int>> block);
	~ImageProcessing();

	std::vector<double> compareFacesByHist(cv::Mat img, cv::Mat orgImg);

private:
	//void GammaTransform(cv::Mat &);

	cv::Mat mat;
	cv::Mat now_mat;
	//std::vector<std::vector<std::string>> blockstr;
	std::vector<std::vector<int>> blockint;

	four_corners_t corners;
	void CalcCorners(const cv::Mat& H, const cv::Mat& src);
	void OptimizeSeam(cv::Mat& img1, cv::Mat& trans, cv::Mat& dst);

	void roiCutInShapeId(cv::Mat &roiCutImg_1, cv::Mat &roiCutImg_2, int iD);
	bool residueDetection(cv::Mat imgNorm, cv::Mat &imgAbNorm);

	// 灰度共生矩阵
	const int gray_level = 16;
	void getglcm_horison(cv::Mat& input, cv::Mat& dst);	// 0
	void getglcm_vertical(cv::Mat& input, cv::Mat& dst);	// 90
	void getglcm_45(cv::Mat& input, cv::Mat& dst);	// 45
	void getglcm_135(cv::Mat& input, cv::Mat& dst);	// 135
	void feature_computer(cv::Mat&src, double& Asm, double& Eng, double& Con, double& Idm);

	double similarityGrayMatrix(cv::Mat img1_gray, cv::Mat img2_gray, int winSize);

	double simpleMatchAHash(cv::Mat tmplateImg, cv::Mat toMatchImg);

	cv::Point2f detectCorners(cv::Mat srcgray);	//测量角点之间距离
};
