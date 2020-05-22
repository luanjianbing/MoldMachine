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

class LaplacianBlending {
private:
	Mat leftImg;
	Mat rightImg;
	Mat blendMask;

	//Laplacian Pyramids
	vector<Mat> leftLapPyr, rightLapPyr, resultLapPyr;
	Mat leftHighestLevel, rightHighestLevel, resultHighestLevel;
	//maskΪ��ͨ������������
	vector<Mat> maskGaussianPyramid;

	int levels;

	void buildPyramids()
	{
		buildLaplacianPyramid(leftImg, leftLapPyr, leftHighestLevel);
		buildLaplacianPyramid(rightImg, rightLapPyr, rightHighestLevel);
		buildGaussianPyramid();
	}

	void buildGaussianPyramid()
	{
		//����������Ϊÿһ�����ģ
		assert(leftLapPyr.size()>0);

		maskGaussianPyramid.clear();
		Mat currentImg;
		cvtColor(blendMask, currentImg, CV_GRAY2BGR);
		//����mask��������ÿһ��ͼ��
		maskGaussianPyramid.push_back(currentImg); //0-level

		currentImg = blendMask;
		for (int l = 1; l<levels + 1; l++) {
			Mat _down;
			if (leftLapPyr.size() > l)
				pyrDown(currentImg, _down, leftLapPyr[l].size());
			else
				pyrDown(currentImg, _down, leftHighestLevel.size()); //lowest level

			Mat down;
			cvtColor(_down, down, CV_GRAY2BGR);
			//add color blend mask into mask Pyramid
			maskGaussianPyramid.push_back(down);
			string winName = to_string(l);
			imshow(winName, down);
			currentImg = _down;
		}
	}

	void buildLaplacianPyramid(const Mat& img, vector<Mat>& lapPyr, Mat& HighestLevel)
	{
		lapPyr.clear();
		Mat currentImg = img;
		for (int l = 0; l<levels; l++) {
			Mat down, up;
			pyrDown(currentImg, down);
			pyrUp(down, up, currentImg.size());
			Mat lap = currentImg - up;
			lapPyr.push_back(lap);
			currentImg = down;
		}
		currentImg.copyTo(HighestLevel);
	}

	Mat reconstructImgFromLapPyramid()
	{
		//������laplacianͼ��ƴ�ɵ�resultLapPyr��������ÿһ��
		//���ϵ��²�ֵ�Ŵ���в���ӣ�����blendͼ����
		Mat currentImg = resultHighestLevel;
		for (int l = levels - 1; l >= 0; l--)
		{
			Mat up;
			pyrUp(currentImg, up, resultLapPyr[l].size());
			currentImg = up + resultLapPyr[l];
		}
		return currentImg;
	}

	void blendLapPyrs()
	{
		//���ÿ���������ֱ����������ͼLaplacian�任ƴ�ɵ�ͼ��resultLapPyr
		resultHighestLevel = leftHighestLevel.mul(maskGaussianPyramid.back()) +
			rightHighestLevel.mul(Scalar(1.0, 1.0, 1.0) - maskGaussianPyramid.back());
		for (int l = 0; l<levels; l++)
		{
			Mat A = leftLapPyr[l].mul(maskGaussianPyramid[l]);
			//Mat antiMask = Scalar(1.0, 1.0, 1.0) - maskGaussianPyramid[l];
			Mat antiMask = maskGaussianPyramid[l];
			Mat B = rightLapPyr[l].mul(antiMask);
			Mat blendedLevel = A + B;

			resultLapPyr.push_back(blendedLevel);
		}
	}

public:
	LaplacianBlending(const Mat& _left, const Mat& _right, const Mat& _blendMask, int _levels) ://construct function, used in LaplacianBlending lb(l,r,m,4);
		leftImg(_left), rightImg(_right), blendMask(_blendMask), levels(_levels)
	{
		assert(_left.size() == _right.size());
		assert(_left.size() == _blendMask.size());
		//����������˹�������͸�˹������
		buildPyramids();
		//ÿ�������ͼ��ϲ�Ϊһ��
		blendLapPyrs();
	};

	Mat blend()
	{
		//�ؽ�������˹������
		return reconstructImgFromLapPyramid();
	}
};

Mat LaplacianBlend(const Mat &left, const Mat &right, const Mat &mask)
{
	LaplacianBlending laplaceBlend(left, right, mask, 10);
	return laplaceBlend.blend();
}

int main() {
	Mat leftImg = imread("./before_ejection.png");
	Mat rightImg = imread("./lowLight.png");

	int hight = leftImg.rows;
	int width = leftImg.cols;

	clock_t startTime, endTime;
	
	startTime = clock();	// ��ʱ��ʼ

	Mat leftImg32f, rightImg32f;
	leftImg.convertTo(leftImg32f, CV_32F);
	rightImg.convertTo(rightImg32f, CV_32F);

	//�������ڻ�ϵ���Ĥ���������м���л��
	Mat mask = Mat::zeros(hight, width, CV_32FC1);
	mask(Range::all(), Range(0, mask.cols)) = 0.5;

	Mat blendImg = LaplacianBlend(leftImg32f, rightImg32f, mask);

	blendImg.convertTo(blendImg, CV_8UC3);

	imshow("left", leftImg);
	imshow("right", rightImg);
	imshow("blended", blendImg);
	cv::imwrite("./res.png", blendImg);

	endTime = clock();	// ��ʱ����
	std::cout << "The run time is : "
		<< (double)(endTime - startTime) / CLOCKS_PER_SEC << "s" << std::endl;

	waitKey(0);
	return 0;
}

//int main() {
//	cv::Mat pic1 = cv::imread("./before_ejection.png");	//3840 * 2160
//	cv::Mat pic2 = cv::imread("./grabImageBefore.png");
//
//	clock_t startTime, endTime;
//
//	startTime = clock();	// ��ʱ��ʼ
//
//	
//
//	endTime = clock();	// ��ʱ����
//	std::cout << "The run time is : "
//		<< (double)(endTime - startTime) / CLOCKS_PER_SEC << "s" << std::endl;
//
//
//	cv::waitKey(0);
//	system("pause");
//	return 0;
//}