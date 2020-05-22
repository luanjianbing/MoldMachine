#include <iostream>

#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include <opencv2/core/core.hpp>

#include <ctime>

void addContrast(cv::Mat & srcImg) {
	cv::Mat lookUpTable(1, 256, CV_8U);
	double temp = pow(1.1, 5);
	uchar* p = lookUpTable.data;
	for (int i = 0; i < 256; ++i)
		p[i] = cv::saturate_cast<uchar>(i * temp);
	LUT(srcImg, lookUpTable, srcImg);
}


// 骨架原理细化
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

// 形态学检测+边缘提取
void cannyDetect(cv::Mat &inputImg) {
	//cv::Mat blur;
	//cv::GaussianBlur(inputImg, inputImg, cv::Size(3, 3));
	//cv::imshow("GaussianBlur", blur);

	cv::Mat gray;
	cv::cvtColor(inputImg, gray, CV_RGB2GRAY);
	//cv::threshold(gray, gray, 0, 255, CV_THRESH_BINARY | CV_THRESH_OTSU);
	cv::adaptiveThreshold(gray, gray, 255, CV_ADAPTIVE_THRESH_MEAN_C, CV_THRESH_BINARY, 31, 10);
	
	cv::imshow("adaptiveThreshold", gray);

	// 增加对比度
	addContrast(gray);
	cv::imshow("addContrast", gray);

	//cv::Mat blur;
	cv::blur(gray, gray, cv::Size(3, 3));
	cv::imshow("GaussianBlur", gray);


	
	cv::Mat dstImg;
	cv::Canny(gray, dstImg, 50, 150);
	cv::imshow("Canny", dstImg);

	//std::vector< std::vector< cv::Point> > contours;
	//cv::findContours(dstImg, contours, cv::noArray(), cv::RETR_LIST, cv::CHAIN_APPROX_SIMPLE);

	//dstImg = cv::Scalar::all(0);
	//cv::drawContours(dstImg, contours, -1, cv::Scalar::all(255));

	cv::Mat kernel = cv::getStructuringElement(cv::MorphShapes::MORPH_CROSS, cv::Size(3, 3));
	cv::dilate(dstImg, dstImg, kernel);
	cv::imshow("erode", dstImg);
	morphologyEx(dstImg, dstImg, cv::MORPH_OPEN, kernel, cv::Point(-1, -1), 3);
	//morphologyEx(gray, gray, cv::MORPH_OPEN, kernel);

	cv::imshow("morphologyEx", dstImg);

	//cv::Mat dstImg;
	//cv::Canny(gray, dstImg, 50, 150);
	//cv::imshow("Canny", dstImg);

	//cv::imshow("morphologyEx", dstImg);

	cvThin(dstImg, dstImg, 3);
	cv::imshow("cvThin", dstImg);
	// 滤波

	// 连通域测量
	cv::Mat labels = cv::Mat::zeros(inputImg.size(), CV_32S);
	cv::Mat stats, centroids;
	int num_labels = connectedComponentsWithStats(dstImg, labels, stats, centroids, 8, 4);

	std::vector<cv::Vec3b> colors(num_labels);

	// background color
	colors[0] = cv::Vec3b(0, 0, 0);

	// object color
	//int b = rng.uniform(0, 256);
	//int g = rng.uniform(0, 256);
	//int r = rng.uniform(0, 256);
	std::vector<int> error_label;

	for (int i = 1; i < num_labels; i++) {
		if (stats.at<int>(i, cv::CC_STAT_AREA) < 10)	// 面积小于10个像素点视为误判
			error_label.push_back(i);
		else
			colors[i] = cv::Vec3b(0, 0, 255);
	}


	printf("total labels : %d\n", (num_labels - 1 - error_label.size()));

	

	

	// render result
	//cv::Mat dst = cv::Mat::zeros(imgAbNormClone.size(), CV_8UC3);
	cv::Mat dst = inputImg.clone();
	//dst.convertTo(dst, CV_8UC3);
	for (int row = 0; row < inputImg.rows; row++) {
		for (int col = 0; col < inputImg.cols; col++) {
			int label = labels.at<int>(row, col);
			for (int i = 0; i < error_label.size(); i++) {
				if (label == error_label[i])
					label = 0;
			}
			if (label == 0) continue;
			dst.at<cv::Vec3b>(row, col) = colors[label];
		}
	}

	for (int i = 1; i < num_labels; i++) {
		int area = stats.at<int>(i, cv::CC_STAT_AREA);
		if (area < 10) continue;

		cv::Vec2d pt = centroids.at<cv::Vec2d>(i, 0);
		int x = stats.at<int>(i, cv::CC_STAT_LEFT);
		int y = stats.at<int>(i, cv::CC_STAT_TOP);
		int width = stats.at<int>(i, cv::CC_STAT_WIDTH);
		int height = stats.at<int>(i, cv::CC_STAT_HEIGHT);

		printf("area : %d, center point(%.2f, %.2f)\n", area, pt[0], pt[1]);
		std::cout << "伸长度T=" << (double)(width*height) / area << std::endl;
		//circle(dst, cv::Point(pt[0], pt[1]), 2, cv::Scalar(0, 0, 255), -1, 8, 0);
		//rectangle(dst, cv::Rect(x, y, width, height), cv::Scalar(255, 0, 255), 1, 8, 0);
	}
	cv::imshow("ccla-demo", dst);
}

void test(cv::Mat &input) {
	cv::Mat gray, binary, result;
	cv::cvtColor(input, gray, cv::COLOR_BGR2GRAY);
	//cv::threshold(gray, binary, 0, 255, cv::THRESH_BINARY_INV | cv::THRESH_OTSU);
	cv::adaptiveThreshold(gray, binary, 255, CV_ADAPTIVE_THRESH_MEAN_C, CV_THRESH_BINARY, 31, 10);
	imshow("binary", binary);

	cv::Mat se = cv::getStructuringElement(cv::MORPH_RECT, cv::Size(3, 3), cv::Point(-1, -1));
	morphologyEx(binary, binary, cv::MORPH_OPEN, se);
	imshow("morphologyEx", binary);

	std::vector<std::vector<cv::Point>> contours;
	std::vector<cv::Vec4i> hierarchy;
	cv::findContours(binary, contours, hierarchy, cv::RETR_LIST, cv::CHAIN_APPROX_SIMPLE);
	int height = input.rows;
	for (size_t t = 0; t < contours.size(); t++) {
		cv::Rect rect = boundingRect(contours[t]);
		double area = contourArea(contours[t]);
		if (rect.height >(height / 2)) {
			continue;
		}
		if (area < 10)
			continue;
		rectangle(input, rect, cv::Scalar(0, 0, 255), 1, 8, 0);
		drawContours(input, contours, t, cv::Scalar(0, 255, 0), 2, 8);
	}
	cv::imshow("result", input);
}

int getPixel(cv::Mat input) {
	int cnt = 0;
	for (int i = 0; i < input.cols; i++) {
		for (int j = 0; j < input.rows; j++) {
			if (input.at<uchar>(i, j) = 255) {
				cnt++;
			}
		}
	}

	return cnt;
}

void shapeFeature(cv::Mat &input, cv::Mat dstImg) {
	//std::vector<std::vector<cv::Point>> contours;
	//std::vector<cv::Vec4i> hierarchy;
	//cv::findContours(dstImg, contours, hierarchy, cv::RETR_LIST, cv::CHAIN_APPROX_SIMPLE);
	//int height = dstImg.rows;

	//for (size_t t = 0; t < contours.size(); t++) {
	//	cv::Rect rect = boundingRect(contours[t]);
	//	double area = cv::contourArea(contours[t]);
	//	double length = cv::arcLength(contours[t], false);
	//	//if (rect.height >(height / 2)) {
	//	//	continue;
	//	//}
	//	//if (area < 5)
	//	//	continue;
	//	//rectangle(input, rect, cv::Scalar(0, 0, 255), 1, 8, 0);

	//	double mT = (double) length / area;
	//	double mC = (double) 4 * 3.14 * area / (length * length);
	//	double mPS = (double)area / length;

	//	std::cout << "label:" << t << " area:" << area
	//		<< " length:" << length << " 伸长度:" << mT
	//		<< " 圆形度:" << mC << " 单位长度缺陷面积:" << mPS
	//		<< std::endl;

	//	rectangle(input, rect, cv::Scalar(255, 0, 0), 2, 8, 0);
	//	drawContours(input, contours, t, cv::Scalar(0, 0, 255));
	//}
	////cv::imshow("result", input);

	cv::Mat labels = cv::Mat::zeros(input.size(), CV_32S);
	cv::Mat stats, centroids;
	int num_labels = connectedComponentsWithStats(dstImg, labels, stats, centroids, 8, 4);

	std::vector<cv::Vec3b> colors(num_labels);

	// background color
	colors[0] = cv::Vec3b(0, 0, 0);

	std::vector<int> error_label;

	for (int i = 1; i < num_labels; i++) {
		if (stats.at<int>(i, cv::CC_STAT_AREA) < 10)	// 面积小于10个像素点视为误判
			error_label.push_back(i);
		else
			colors[i] = cv::Vec3b(0, 0, 255);
	}


	printf("total labels : %d\n", (num_labels - 1 - error_label.size()));

	// render result
	cv::Mat dst = input.clone();
	for (int row = 0; row < input.rows; row++) {
		for (int col = 0; col < input.cols; col++) {
			int label = labels.at<int>(row, col);
			for (int i = 0; i < error_label.size(); i++) {
				if (label == error_label[i])
					label = 0;
			}
			if (label == 0) continue;
			dst.at<cv::Vec3b>(row, col) = colors[label];
		}
	}

	for (int i = 1; i < num_labels; i++) {
		int area = stats.at<int>(i, cv::CC_STAT_AREA);
		if (area < 10) continue;

		cv::Vec2d pt = centroids.at<cv::Vec2d>(i, 0);
		int x = stats.at<int>(i, cv::CC_STAT_LEFT);
		int y = stats.at<int>(i, cv::CC_STAT_TOP);
		int width = stats.at<int>(i, cv::CC_STAT_WIDTH);
		int height = stats.at<int>(i, cv::CC_STAT_HEIGHT);

		//double length = cv::arcLength(input(cv::Rect(x, y, width, height)), false);
		//int length = getPixel(input(cv::Rect(x, y, width, height)));
		double length = 2 * (width + height);

		double mT = (double) length / area;		// 伸长度
		double mC = (double) 4 * 3.14 * area / (length * length);		// 圆形度
		double mPS = (double) area / length;			// 单位长度缺陷面积
		double mRect = (double) (area / (width / 2) * (height / 2));	// 矩形度


		std::cout << "label:" << i << " area:" << area
			<< " length:" << length << " 伸长度:" << mT
			<< " 圆形度:" << mC << " 单位长度缺陷面积:" << mPS
			<< " 矩形度:" << mRect
			<< std::endl;

		//circle(dst, cv::Point(pt[0], pt[1]), 2, cv::Scalar(0, 0, 255), -1, 8, 0);
		rectangle(dst, cv::Rect(x, y, width, height), cv::Scalar(255, 0, 255), 1, 8, 0);
	}
	cv::imshow("ccla-demo", dst);
}

void crackDetect(cv::Mat input) {
	cv::imshow("input", input);

	cv::Mat blur1;
	cv::GaussianBlur(input, blur1, cv::Size(5, 5), 0, 0);
	cv::imshow("GaussianBlur", blur1);

	cv::Mat imageLog(blur1.size(), CV_32FC3);
	for (int i = 0; i < blur1.rows; i++)
	{
		for (int j = 0; j < blur1.cols; j++)
		{
			imageLog.at<cv::Vec3f>(i, j)[0] = log(1 + blur1.at<cv::Vec3b>(i, j)[0]);
			imageLog.at<cv::Vec3f>(i, j)[1] = log(1 + blur1.at<cv::Vec3b>(i, j)[1]);
			imageLog.at<cv::Vec3f>(i, j)[2] = log(1 + blur1.at<cv::Vec3b>(i, j)[2]);
		}
	}

	//归一化到0~255    
	normalize(imageLog, imageLog, 0, 255, CV_MINMAX);
	//转换成8bit图像显示    
	convertScaleAbs(imageLog, imageLog);
	cv::imshow("8bit", imageLog);
	
	cv::Mat blur2;
	cv::GaussianBlur(imageLog, blur2, cv::Size(3, 3), 4, 4);
	cv::imshow("GaussianBlur", blur2);

	cv::Mat gray, binary;
	cv::cvtColor(blur2, gray, cv::COLOR_BGR2GRAY);
	cv::imshow("gray", gray);

	cv::Mat canny;
	cv::Canny(gray, canny, 50, 155);
	cv::imshow("Canny", canny);
	//cv::Laplacian(gray, canny, CV_16S, 3, 1, 0, cv::BORDER_DEFAULT);
	//cv::convertScaleAbs(canny, canny);
	//cv::imshow("Canny", canny);

	cv::adaptiveThreshold(gray, binary, 255, CV_ADAPTIVE_THRESH_GAUSSIAN_C, CV_THRESH_BINARY, 15, 10);
	imshow("binary", binary);

	// 形态学操作
	cv::Mat dstImg;

	cv::Mat kernel = cv::getStructuringElement(cv::MorphShapes::MORPH_ELLIPSE, cv::Size(3, 3), cv::Point(-1, -1));
	cv::dilate(canny, dstImg, kernel);
	cv::imshow("dilate", dstImg);
	morphologyEx(dstImg, dstImg, CV_MOP_CLOSE, kernel, cv::Point(-1, -1));
	
	cv::imshow("morphologyEx", dstImg);

	cvThin(dstImg, dstImg, 5);
	cv::imshow("cvThin", dstImg);

	shapeFeature(input, dstImg);
	cv::imshow("result", input);
	//// 连通域测量
	//cv::Mat labels = cv::Mat::zeros(input.size(), CV_32S);
	//cv::Mat stats, centroids;
	//int num_labels = connectedComponentsWithStats(dstImg, labels, stats, centroids, 8, 4);

	//std::vector<cv::Vec3b> colors(num_labels);

	//// background color
	//colors[0] = cv::Vec3b(0, 0, 0);

	//std::vector<int> error_label;

	//for (int i = 1; i < num_labels; i++) {
	//	if (stats.at<int>(i, cv::CC_STAT_AREA) < 10)	// 面积小于10个像素点视为误判
	//		error_label.push_back(i);
	//	else
	//		colors[i] = cv::Vec3b(0, 0, 255);
	//}


	//printf("total labels : %d\n", (num_labels - 1 - error_label.size()));

	//// render result
	//cv::Mat dst = input.clone();
	//for (int row = 0; row < input.rows; row++) {
	//	for (int col = 0; col < input.cols; col++) {
	//		int label = labels.at<int>(row, col);
	//		for (int i = 0; i < error_label.size(); i++) {
	//			if (label == error_label[i])
	//				label = 0;
	//		}
	//		if (label == 0) continue;
	//		dst.at<cv::Vec3b>(row, col) = colors[label];
	//	}
	//}

	//for (int i = 1; i < num_labels; i++) {
	//	int area = stats.at<int>(i, cv::CC_STAT_AREA);
	//	if (area < 10) continue;

	//	cv::Vec2d pt = centroids.at<cv::Vec2d>(i, 0);
	//	int x = stats.at<int>(i, cv::CC_STAT_LEFT);
	//	int y = stats.at<int>(i, cv::CC_STAT_TOP);
	//	int width = stats.at<int>(i, cv::CC_STAT_WIDTH);
	//	int height = stats.at<int>(i, cv::CC_STAT_HEIGHT);

	//	std::cout << "label = " << i << std::endl;
	//	std::cout << "伸长度T = " << (double)(width*height) / area << std::endl;
	//	std::cout << "圆形度 = " << (double)((width+height) *2 * (width + height) * 2 )/ area << std::endl;
	//	std::cout << "单位边界长度缺陷面积 = " << (double)area / (width + height) * 2 << std::endl;
	//	//circle(dst, cv::Point(pt[0], pt[1]), 2, cv::Scalar(0, 0, 255), -1, 8, 0);
	//	//rectangle(dst, cv::Rect(x, y, width, height), cv::Scalar(255, 0, 255), 1, 8, 0);
	//}
	//cv::imshow("ccla-demo", dst);

	//std::vector<std::vector<cv::Point>> contours;
	//std::vector<cv::Vec4i> hierarchy;
	//cv::findContours(dstImg, contours, hierarchy, cv::RETR_LIST, cv::CHAIN_APPROX_SIMPLE);
	//int height = input.rows;
	//for (size_t t = 0; t < contours.size(); t++) {
	//	cv::Rect rect = boundingRect(contours[t]);
	//	double area = cv::contourArea(contours[t]);
	//	double length = cv::arcLength(contours[t], false);
	//	//if (rect.height >(height / 2)) {
	//	//	continue;
	//	//}
	//	//if (area < 10)
	//	//	continue;
	//	//rectangle(input, rect, cv::Scalar(0, 0, 255), 1, 8, 0);
	//	std::cout << area << std::endl;
	//	std::cout << "伸长度T = " << (double) rect.area() / area << std::endl;
	//	std::cout << "边缘特征 = " << (double)length * length / area << std::endl;
	//	drawContours(input, contours, t, cv::Scalar(0, 0, 255));
	//}
	//cv::imshow("result", input);
}

int main() {
	clock_t startTime, endTime;

	cv::Mat lieWen = cv::imread("./liewen.jpg");	// 256 * 341
	cv::Mat lieWen2 = cv::imread("./liewen2.jpg");	// 256 * 341
	cv::Mat lieWen3 = cv::imread("./liewen3.jpg");
	cv::Mat huaHen = cv::imread("./huahen.jpg");	// 256 * 123
	cv::Mat diandu = cv::imread("./diandu.png");	// 256 * 123
	cv::Mat huaHen2 = cv::imread("./huahen2.png");	// 256 * 185
	cv::Mat huaHen3 = cv::imread("./huahen3.jpg");	// 256 * 123
	startTime = clock();	// 计时开始

	//cannyDetect(lieWen);
	//cannyDetect(huaHen);
	//test(lieWen);
	//test(huaHen);
	crackDetect(lieWen);
	std::cout << "-----------------------" << std::endl;
	//crackDetect(huaHen);
	//std::cout << "-----------------------" << std::endl;
	//crackDetect(diandu);
	////crackDetect(huaHen3);
	//std::cout << "-----------------------" << std::endl;
	//crackDetect(lieWen3);

	endTime = clock();	// 计时结束

	std::cout << "The run time is : " 
		<< (double)(endTime - startTime) / CLOCKS_PER_SEC << "s" << std::endl;
	cv::waitKey(0);

	system("pause");
	return 0;
}