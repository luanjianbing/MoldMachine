#include <iostream>

#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include <opencv2/core/core.hpp>

//cv::RNG rng(12345);


bool residueDetection(cv::Mat imgNorm, cv::Mat &imgAbNorm) {
	cv::Mat imgNormClone = imgNorm.clone();
	cv::Mat imgAbNormClone = imgAbNorm.clone();


	//cv::imshow("imgNorm", imgNormClone);
	//cv::imshow("imgAbNorm", imgAbNormClone);
	// 图像平滑（高斯模糊）
	cv::Mat blurNorm, blurAbNorm;
	cv::GaussianBlur(imgNormClone, blurNorm, cv::Size(11, 11), 4, 4);
	cv::GaussianBlur(imgAbNormClone, blurAbNorm, cv::Size(11, 11), 4, 4);

	// 模板匹配

	// 光照补偿
	

	// 图像差分
	//cv::Mat differ = imgAbNormClone - imgNormClone;
	//cv::imshow("differ", differ);
	// 阈值分割
	// 二值化
	cv::Mat grayNorm, grayAbNorm;
	cv::cvtColor(blurNorm, grayNorm, CV_RGB2GRAY);
	cv::cvtColor(blurAbNorm, grayAbNorm, CV_RGB2GRAY);
	cv::threshold(grayNorm, grayNorm, 128, 255, CV_THRESH_BINARY | CV_THRESH_OTSU);
	cv::threshold(grayAbNorm, grayAbNorm, 128, 255, CV_THRESH_BINARY | CV_THRESH_OTSU);
	//cv::imshow("grayNorm", grayNorm);
	//cv::imshow("grayAbNorm", grayAbNorm);

	cv::equalizeHist(grayNorm, grayNorm);
	cv::equalizeHist(grayAbNorm, grayAbNorm);
	// 计算差分图像
	cv::Mat differ = abs(grayAbNorm - grayNorm);
	//cv::imshow("differ", differ);

	// 形态学运算
	// 腐蚀
	cv::Mat kernel = cv::getStructuringElement(cv::MORPH_RECT, cv::Size(7, 7));
	cv::erode(differ, differ, kernel);
	//cv::imshow("erode", differ);
	// 开操作
	cv::morphologyEx(differ, differ, cv::MORPH_OPEN, kernel);
	//cv::imshow("morphologyEx", differ);

	// 残留区域测量
	cv::Mat labels = cv::Mat::zeros(imgAbNormClone.size(), CV_32S);
	cv::Mat stats, centroids;
	int num_labels = connectedComponentsWithStats(differ, labels, stats, centroids, 8, 4);
	printf("total labels : %d\n", (num_labels - 1));

	std::vector<cv::Vec3b> colors(num_labels);

	// background color
	colors[0] = cv::Vec3b(0, 0, 0);

	// object color
	//int b = rng.uniform(0, 256);
	//int g = rng.uniform(0, 256);
	//int r = rng.uniform(0, 256);
	for (int i = 1; i < num_labels; i++) {
		colors[i] = cv::Vec3b(0, 165, 255);
	}

	// render result
	//cv::Mat dst = cv::Mat::zeros(imgAbNormClone.size(), CV_8UC3);
	cv::Mat dst = imgAbNormClone.clone();
	//dst.convertTo(dst, CV_8UC3);
	for (int row = 0; row < imgAbNormClone.rows; row++) {
		for (int col = 0; col < imgAbNormClone.cols; col++) {
			int label = labels.at<int>(row, col);
			if (label == 0) continue;
			dst.at<cv::Vec3b>(row, col) = colors[label];
		}
	}

	for (int i = 1; i < num_labels; i++) {
		cv::Vec2d pt = centroids.at<cv::Vec2d>(i, 0);
		int x = stats.at<int>(i, cv::CC_STAT_LEFT);
		int y = stats.at<int>(i, cv::CC_STAT_TOP);
		int width = stats.at<int>(i, cv::CC_STAT_WIDTH);
		int height = stats.at<int>(i, cv::CC_STAT_HEIGHT);
		int area = stats.at<int>(i, cv::CC_STAT_AREA);
		printf("area : %d, center point(%.2f, %.2f)\n", area, pt[0], pt[1]);
		//circle(dst, cv::Point(pt[0], pt[1]), 2, cv::Scalar(0, 0, 255), -1, 8, 0);
		//rectangle(dst, cv::Rect(x, y, width, height), cv::Scalar(255, 0, 255), 1, 8, 0);
	}
	//cv::imshow("ccla-demo", dst);

	

	if (num_labels == 0) {
		
		return 1;
	}
	else {
		imgAbNorm = dst;
		return 0;
	}
}

int main() {
	cv::Mat imgNorm = cv::imread("./img/normal_1.jpg");
	cv::Mat imgAbNorm = cv::imread("./img/abnormal_1.jpg");

	//cv::imshow("imgNorm", imgNorm);
	//cv::imshow("imgAbNorm", imgAbNorm);

	bool res = residueDetection(imgNorm, imgAbNorm);
	cv::imshow("imgNorm", imgNorm);
	cv::imshow("imgAbNorm", imgAbNorm);
	cv::waitKey(0);
	system("pause");
}