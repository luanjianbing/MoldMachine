#include <iostream>

#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include <opencv2/core/core.hpp>

#include <time.h>

// 输入为灰度图像

// 两张图像作相关
double Correlation(cv::Mat tmplateImg, cv::Mat toMatchImg) {
	cv::Scalar mean, stddev;
	double avg1 = 0, dev1 = 0, avg2 = 0, dev2 = 0;
	int tmpRow = 0, tmpCol = 0;
	tmpRow = tmplateImg.rows;
	tmpCol = tmplateImg.cols;

	// 计算均值和标准差
	cv::meanStdDev(tmplateImg, mean, stddev);
	avg1 = mean.val[0];		// 均值
	dev1 = stddev.val[0];	// 标准差
	//cv::meanStdDev(img2, mean, stddev);
	//avg2 = mean.val[0];		// 均值
	//dev2 = stddev.val[0];	// 标准差

	// 计算相关系数
	long double dotMul = 0;
	for (int i = 0; i < tmpRow; ++i) {
		for (int j = 0; j < tmpCol; ++j) {
			dotMul += abs((long double(tmplateImg.at<uchar>(i, j)) - avg1)*(long double(tmplateImg.at<uchar>(i, j)) - avg1));
		}
	}
	double dotMulAvg = dotMul / (tmpRow * tmpCol);
	double pearsonCorrelationCoefficientTmp = dotMulAvg / (dev1*dev1);

	cv::meanStdDev(toMatchImg, mean, stddev);
	avg2 = mean.val[0];		// 均值
	dev2 = stddev.val[0];	// 标准差
	dotMul = 0;
	for (int i = 0; i < tmpRow; ++i) {
		for (int j = 0; j < tmpCol; ++j) {
			dotMul += abs((long double(tmplateImg.at<uchar>(i, j)) - avg1)*(long double(toMatchImg.at<uchar>(i, j)) - avg2));
		}
	}
	dotMulAvg = dotMul / (tmpRow * tmpCol);
	double pearsonCorrelationCoefficientCur = dotMulAvg / (dev1*dev2);

	double similarity = pearsonCorrelationCoefficientCur / pearsonCorrelationCoefficientTmp;

	return similarity;
}

// 互信息熵
// 单幅图像信息熵计算
double Entropy(cv::Mat img)
{
	double temp[256] = { 0.0 };

	// 计算每个像素的累积值
	for (int m = 0; m<img.rows; m++)
	{// 有效访问行列的方式
		const uchar* t = img.ptr<uchar>(m);
		for (int n = 0; n<img.cols; n++)
		{
			int i = t[n];
			temp[i] = temp[i] + 1;
		}
	}

	// 计算每个像素的概率
	for (int i = 0; i<256; i++)
	{
		temp[i] = temp[i] / (img.rows*img.cols);
	}

	double result = 0;
	// 计算图像信息熵
	for (int i = 0; i<256; i++)
	{
		if (temp[i] == 0.0)
			result = result;
		else
			result = result - temp[i] * (log(temp[i]) / log(2.0));
	}

	return result;

}
// 两幅图像联合信息熵计算
double ComEntropy(cv::Mat img1, cv::Mat img2)
{
	double img1_entropy, img2_entropy;
	double temp[256][256] = { 0.0 };

	// 计算联合图像像素的累积值
	for (int m1 = 0, m2 = 0; m1 < img1.rows, m2 < img2.rows; m1++, m2++)
	{    // 有效访问行列的方式
		const uchar* t1 = img1.ptr<uchar>(m1);
		const uchar* t2 = img2.ptr<uchar>(m2);
		for (int n1 = 0, n2 = 0; n1 < img1.cols, n2 < img2.cols; n1++, n2++)
		{
			int i = t1[n1], j = t2[n2];
			temp[i][j] = temp[i][j] + 1;
		}
	}

	// 计算每个联合像素的概率
	for (int i = 0; i < 256; i++)
	{
		for (int j = 0; j < 256; j++)

		{
			temp[i][j] = temp[i][j] / (img1.rows*img1.cols);
		}
	}

	double result = 0.0;
	//计算图像联合信息熵
	for (int i = 0; i < 256; i++)
	{
		for (int j = 0; j < 256; j++)

		{
			if (temp[i][j] == 0.0)
				result = result;
			else
				result = result - temp[i][j] * (log(temp[i][j]) / log(2.0));
		}
	}

	//得到两幅图像的互信息熵
	img1_entropy = Entropy(img1);
	img2_entropy = Entropy(img2);
	result = img1_entropy + img2_entropy - result;

	return result;

}

// 感知哈希值方法
double simpleMatchPHash(cv::Mat tmplateImg, cv::Mat toMatchImg) {
	cv::Mat matDst1, matDst2;
	tmplateImg = cv::Mat_<double>(tmplateImg);
	toMatchImg = cv::Mat_<double>(toMatchImg);
	cv::resize(tmplateImg, matDst1, cv::Size(8, 8), 0, 0, cv::INTER_CUBIC);
	cv::resize(toMatchImg, matDst2, cv::Size(8, 8), 0, 0, cv::INTER_CUBIC);

	cv::dct(matDst1, matDst1);
	cv::dct(matDst2, matDst2);

	double iAvg1 = 0, iAvg2 = 0;
	int row = 0, col = 0;
	double arr1[64], arr2[64];

	for (int i = 0; i < 8; ++i) {
		row = i * 8;
		for (int j = 0; j < 8; ++j) {
			col = row + j;

			arr1[col] = matDst1.at<double>(i, j);
			arr2[col] = matDst2.at<double>(i, j);

			iAvg1 += arr1[col];
			iAvg2 += arr2[col];
		}
	}

	iAvg1 /= 64;	// /=64
	iAvg2 /= 64;

	for (int i = 0; i < 64; ++i) {
		arr1[i] = (arr1[i] >= iAvg1) ? 1 : 0;
		arr2[i] = (arr2[i] >= iAvg2) ? 1 : 0;
	}

	double similarity = 1.0;
	for (int i = 0; i < 64; ++i) {
		if (arr1[i] != arr2[i])
			similarity = similarity - 1.0 / 64;
	}
	return similarity;
}

// 均值哈希值方法
double simpleMatchAHash(cv::Mat tmplateImg, cv::Mat toMatchImg) {
	cv::Mat matDst1, matDst2;
	cv::resize(tmplateImg, matDst1, cv::Size(8, 8), 0, 0, cv::INTER_CUBIC);
	cv::resize(toMatchImg, matDst2, cv::Size(8, 8), 0, 0, cv::INTER_CUBIC);
	int iAvg1 = 0, iAvg2 = 0;
	int row = 0, col = 0;
	int arr1[64], arr2[64];

	for (int i = 0; i < 8; ++i) {
		uchar* data1 = matDst1.ptr<uchar>(i);
		uchar* data2 = matDst2.ptr<uchar>(i);

		row = i * 8;

		for (int j = 0; j < 8; ++j) {
			col = row + j;

			arr1[col] = data1[j] >> 2;
			arr2[col] = data2[j] >> 2;

			iAvg1 += arr1[col];
			iAvg2 += arr2[col];
		}
	}
	//iAvg1 /= 64;
	//iAvg2 /= 64;
	iAvg1 = iAvg1 >> 6;	// /=64
	iAvg2 = iAvg2 >> 6;

	for (int i = 0; i < 64; ++i) {
		arr1[i] = (arr1[i] >= iAvg1) ? 1 : 0;
		arr2[i] = (arr2[i] >= iAvg2) ? 1 : 0;
	}

	double similarity = 1.0;
	for (int i = 0; i < 64; ++i) {
		if (arr1[i] != arr2[i])
			similarity = similarity - 1.0 / 64;
	}
	return similarity;
}

// 差异哈希值方法
double simpleMatchDHash(cv::Mat tmplateImg, cv::Mat toMatchImg) {
	return 0;
}

// SSIM结构性相似
double simpleMatchSSIM(cv::Mat tmplateImg, cv::Mat toMatchImg) {
	double C1 = 6.5025, C2 = 58.5225;
	int width = tmplateImg.cols;
	int height = tmplateImg.rows;
	int width2 = toMatchImg.cols;
	int height2 = toMatchImg.rows;
	double mean_x = 0;
	double mean_y = 0;
	double sigma_x = 0;
	double sigma_y = 0;
	double sigma_xy = 0;
	for (int v = 0; v < height; v++)
	{
		for (int u = 0; u < width; u++)
		{
			mean_x += tmplateImg.at<uchar>(v, u);
			mean_y += toMatchImg.at<uchar>(v, u);

		}
	}
	mean_x = mean_x / width / height;
	mean_y = mean_y / width / height;
	for (int v = 0; v < height; v++)
	{
		for (int u = 0; u < width; u++)
		{
			sigma_x += (tmplateImg.at<uchar>(v, u) - mean_x)* (tmplateImg.at<uchar>(v, u) - mean_x);
			sigma_y += (toMatchImg.at<uchar>(v, u) - mean_y)* (toMatchImg.at<uchar>(v, u) - mean_y);
			sigma_xy += abs((tmplateImg.at<uchar>(v, u) - mean_x)* (toMatchImg.at<uchar>(v, u) - mean_y));
		}
	}
	sigma_x = sigma_x / (width*height - 1);
	sigma_y = sigma_y / (width*height - 1);
	sigma_xy = sigma_xy / (width*height - 1);
	double fenzi = (2 * mean_x*mean_y + C1) * (2 * sigma_xy + C2);
	double fenmu = (mean_x*mean_x + mean_y * mean_y + C1) * (sigma_x + sigma_y + C2);
	double ssim = fenzi / fenmu;
	return ssim;
}

// MSE均方误差
double simpleMatchMSE(cv::Mat tmplateImg, cv::Mat toMatchImg) {
	int width = tmplateImg.cols;
	int height = tmplateImg.rows;
	//int totalNum = 0;

	double err = 0;

	for (int v = 0; v < height; v++)
	{
		for (int u = 0; u < width; u++)
		{
			err += pow((tmplateImg.at<uchar>(v, u) - toMatchImg.at<uchar>(v, u)), 2);
		}
	}
	err /= double(width * height);

	err /= double(width * height);

	return 1 - err;
}

int main() {
	cv::Mat tmplateImg = cv::imread("./tmplateImg.png");
	cv::Mat toMatchImg = cv::imread("./toMatchImg.png");
	cv::Mat toMatchImgError3x3 = cv::imread("./toMatchImg_error3x3.png");
	cv::Mat toMatchImgError5x5 = cv::imread("./toMatchImg_error5x5.png");
	cv::Mat toMatchImgError10x10 = cv::imread("./toMatchImg_error10x10.png");
	cv::Mat toMatchImgError30x15 = cv::imread("./toMatchImg_error30x15.png");
	cv::Mat toMatchImgError64x64 = cv::imread("./toMatchImg_error64x64.png");

	cvtColor(tmplateImg, tmplateImg, cv::COLOR_BGR2GRAY);
	cvtColor(toMatchImg, toMatchImg, cv::COLOR_BGR2GRAY);
	cvtColor(toMatchImgError3x3, toMatchImgError3x3, cv::COLOR_BGR2GRAY);
	cvtColor(toMatchImgError5x5, toMatchImgError5x5, cv::COLOR_BGR2GRAY);
	cvtColor(toMatchImgError10x10, toMatchImgError10x10, cv::COLOR_BGR2GRAY);
	cvtColor(toMatchImgError30x15, toMatchImgError30x15, cv::COLOR_BGR2GRAY);
	cvtColor(toMatchImgError64x64, toMatchImgError64x64, cv::COLOR_BGR2GRAY);

	clock_t t = clock();
	// 均值哈希方法
	//double res = simpleMatchAHash(tmplateImg, toMatchImgError64x64);
	//double res = simpleMatchAHash(tmplateImg, toMatchImgError30x15);

	// 感知哈希方法
	//double res = simpleMatchPHash(tmplateImg, toMatchImgError64x64);
	//double res = simpleMatchPHash(tmplateImg, toMatchImgError64x64);

	// 计算互信息
	//double res = ComEntropy(tmplateImg, toMatchImgError64x64) / ComEntropy(tmplateImg, tmplateImg);

	// 计算相关
	//double res = Correlation(tmplateImg, toMatchImgError64x64);

	// ssim
	//double res = simpleMatchSSIM(tmplateImg, toMatchImgError64x64);

	// mse
	double res = simpleMatchMSE(tmplateImg, toMatchImgError64x64);

	std::cout << "res : " << res << std::endl;
	std::cout << (double)(clock() - t) / CLOCKS_PER_SEC << std::endl;

	system("pause");
	return 0;
}