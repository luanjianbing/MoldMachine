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
	//cv::GaussianBlur(inputImg, inputImg, cv::Size(3, 3), 2, 2);
	//cv::imshow("GaussianBlur", blur);

	cv::Mat gray;
	cv::cvtColor(inputImg, gray, CV_RGB2GRAY);

	//cv::Mat blur;
	//cv::GaussianBlur(gray, gray, cv::Size(3, 3), 0, 0);
	//cv::imshow("GaussianBlur", gray);

	// 增加对比度
	addContrast(gray);
	cv::imshow("addContrast", gray);
	cv::Mat dstImg;
	cv::Canny(gray, dstImg, 50, 150);
	cv::imshow("Canny", dstImg);

	//std::vector< std::vector< cv::Point> > contours;
	//cv::findContours(dstImg, contours, cv::noArray(), cv::RETR_LIST, cv::CHAIN_APPROX_SIMPLE);

	//dstImg = cv::Scalar::all(0);
	//cv::drawContours(dstImg, contours, -1, cv::Scalar::all(255));

	cv::Mat kernel = cv::getStructuringElement(cv::MorphShapes::MORPH_ELLIPSE, cv::Size(3, 3));
	dilate(dstImg, dstImg, kernel);
	morphologyEx(dstImg, dstImg, CV_MOP_CLOSE, kernel, cv::Point(-1, -1), 3);
	morphologyEx(dstImg, dstImg, CV_MOP_CLOSE, kernel);

	cv::imshow("morphologyEx", dstImg);

	cvThin(dstImg, dstImg, 5);
	cv::imshow("cvThin", dstImg);
	// 滤波

	// 连通域测量
}

cv::Mat ideal_lbrf_kernel(cv::Mat &scr, float sigma)
{
	cv::Mat ideal_low_pass(scr.size(), CV_32FC1); //，CV_32FC1
	float d0 = sigma;//半径D0越小，模糊越大；半径D0越大，模糊越小
	for (int i = 0; i<scr.rows; i++) {
		for (int j = 0; j<scr.cols; j++) {
			double d = sqrt(pow((i - scr.rows / 2), 2) + pow((j - scr.cols / 2), 2));//分子,计算pow必须为float型
			if (d <= d0) {
				ideal_low_pass.at<float>(i, j) = 1;
			}
			else {
				ideal_low_pass.at<float>(i, j) = 0;
			}
		}
	}
	std::string name = "理想低通滤波器d0=" + std::to_string(sigma);
	imshow(name, ideal_low_pass);
	return ideal_low_pass;
}

cv::Mat freqfilt(cv::Mat &scr, cv::Mat &blur)
{
	//***********************DFT*******************
	cv::Mat plane[] = { scr, cv::Mat::zeros(scr.size() , CV_32FC1) }; //创建通道，存储dft后的实部与虚部（CV_32F，必须为单通道数）
	cv::Mat complexIm;
	merge(plane, 2, complexIm);//合并通道 （把两个矩阵合并为一个2通道的Mat类容器）
	dft(complexIm, complexIm);//进行傅立叶变换，结果保存在自身

							  //***************中心化********************
	split(complexIm, plane);//分离通道（数组分离）
							//    plane[0] = plane[0](Rect(0, 0, plane[0].cols & -2, plane[0].rows & -2));//这里为什么&上-2具体查看opencv文档
							//    //其实是为了把行和列变成偶数 -2的二进制是11111111.......10 最后一位是0
	int cx = plane[0].cols / 2; int cy = plane[0].rows / 2;//以下的操作是移动图像  (零频移到中心)
	cv::Mat part1_r(plane[0], cv::Rect(0, 0, cx, cy));  //元素坐标表示为(cx,cy)
	cv::Mat part2_r(plane[0], cv::Rect(cx, 0, cx, cy));
	cv::Mat part3_r(plane[0], cv::Rect(0, cy, cx, cy));
	cv::Mat part4_r(plane[0], cv::Rect(cx, cy, cx, cy));

	cv::Mat temp;
	part1_r.copyTo(temp); //左上与右下交换位置(实部)
	part4_r.copyTo(part1_r);
	temp.copyTo(part4_r);

	part2_r.copyTo(temp);  //右上与左下交换位置(实部)
	part3_r.copyTo(part2_r);
	temp.copyTo(part3_r);

	cv::Mat part1_i(plane[1], cv::Rect(0, 0, cx, cy));  //元素坐标(cx,cy)
	cv::Mat part2_i(plane[1], cv::Rect(cx, 0, cx, cy));
	cv::Mat part3_i(plane[1], cv::Rect(0, cy, cx, cy));
	cv::Mat part4_i(plane[1], cv::Rect(cx, cy, cx, cy));

	part1_i.copyTo(temp);  //左上与右下交换位置(虚部)
	part4_i.copyTo(part1_i);
	temp.copyTo(part4_i);

	part2_i.copyTo(temp);  //右上与左下交换位置(虚部)
	part3_i.copyTo(part2_i);
	temp.copyTo(part3_i);

	//*****************滤波器函数与DFT结果的乘积****************
	cv::Mat blur_r, blur_i, BLUR;
	multiply(plane[0], blur, blur_r); //滤波（实部与滤波器模板对应元素相乘）
	multiply(plane[1], blur, blur_i);//滤波（虚部与滤波器模板对应元素相乘）
	cv::Mat plane1[] = { blur_r, blur_i };
	cv::merge(plane1, 2, BLUR);//实部与虚部合并

						   //*********************得到原图频谱图***********************************
	magnitude(plane[0], plane[1], plane[0]);//获取幅度图像，0通道为实部通道，1为虚部，因为二维傅立叶变换结果是复数
	plane[0] += cv::Scalar::all(1);  //傅立叶变换后的图片不好分析，进行对数处理，结果比较好看
	log(plane[0], plane[0]);  // float型的灰度空间为[0，1])
	normalize(plane[0], plane[0], 1, 0, CV_MINMAX);  //归一化便于显示
													 //    imshow("原图像频谱图",plane[0]);

	idft(BLUR, BLUR); //idft结果也为复数
	split(BLUR, plane);//分离通道，主要获取通道
	magnitude(plane[0], plane[1], plane[0]);  //求幅值(模)
	normalize(plane[0], plane[0], 1, 0, CV_MINMAX);  //归一化便于显示
	return plane[0];//返回参数
}

cv::Mat ideal_Low_Pass_Filter(cv::Mat &src, float sigma)
{
	int M = cv::getOptimalDFTSize(src.rows);
	int N = cv::getOptimalDFTSize(src.cols);
	cv::Mat padded;  //调整图像加速傅里叶变换
	copyMakeBorder(src, padded, 0, M - src.rows, 0, N - src.cols, cv::BORDER_CONSTANT, cv::Scalar::all(0));
	padded.convertTo(padded, CV_32FC1); //将图像转换为flaot型

	cv::Mat ideal_kernel = ideal_lbrf_kernel(padded, sigma);//理想低通滤波器
	cv::Mat result = freqfilt(padded, ideal_kernel);
	return result;
}


// 划痕检测
void scratchDetect(cv::Mat& inputImg) {
	cv::Mat gray;
	cv::cvtColor(inputImg, gray, CV_RGB2GRAY);

	//cv::Mat blur;
	//cv::GaussianBlur(gray, gray, cv::Size(3, 3), 2, 2);
	//cv::imshow("GaussianBlur", gray);

	//! [expand]
	cv::Mat padded;
	//expand input image to optimal size， 将输入图像扩展到最佳大小
	int m = cv::getOptimalDFTSize(gray.rows);
	int n = cv::getOptimalDFTSize(gray.cols);

	// on the border add zero values，在边框上添加零值，使用copyMakeBorder函数
	cv::copyMakeBorder(gray, padded, 0, m - gray.rows, 0, n - gray.cols, cv::BORDER_CONSTANT, cv::Scalar::all(0));
	//! [expand]

	//! [complex_and_real] 实部和虚部
	cv::Mat planes[] = { cv::Mat_<float>(padded), cv::Mat::zeros(padded.size(), CV_32F) }; //Mat 数组储存图像的实部和虚部
	cv::Mat complexI;
	merge(planes, 2, complexI);         // Add to the expanded another plane with zeros，用零添加到扩展的另一平面

										//! [complex_and_real]

										//! [dft]
										//离散傅里叶变换
	dft(complexI, complexI);            // this way the result may fit in the source matrix，这种方式的结果可能适合在源矩阵

										//! [dft]

										// compute the magnitude and switch to logarithmic scale，计算幅度并映射到对数刻度
										//公式 => log(1 + sqrt(Re(DFT(I))^2 + Im(DFT(I))^2)) 
										//! [magnitude] 幅度
	split(complexI, planes);                   // planes[0] = Re(DFT(I), planes[1] = Im(DFT(I)),分离实部和虚部
	magnitude(planes[0], planes[1], planes[0]);// planes[0] = magnitude，计算幅度且存放到planes[0]
	cv::Mat magI = planes[0]; //幅度 
						  //! [magnitude]

						  //! [log]
	magI += cv::Scalar::all(1);                    // switch to logarithmic scale，映射到对数刻度
	log(magI, magI);
	//! [log]

	//! [crop_rearrange]裁剪重新排列
	// crop the spectrum, if it has an odd number of rows or columns， 裁剪频谱, 如果它有奇数行或列数
	magI = magI(cv::Rect(0, 0, magI.cols & -2, magI.rows & -2));

	// rearrange the quadrants of Fourier image  so that the origin is at the image center
	//重新排列傅立叶图像的象限, 使原点位于图像中心
	int cx = magI.cols / 2;
	int cy = magI.rows / 2;

	//每个象限新建一个ROI
	cv::Mat q0(magI, cv::Rect(0, 0, cx, cy));   // Top-Left - Create a ROI per quadrant， 左上，第二象限
	cv::Mat q1(magI, cv::Rect(cx, 0, cx, cy));  // Top-Right， 右上，第一象限
	cv::Mat q2(magI, cv::Rect(0, cy, cx, cy));  // Bottom-Left，左下，第三象限
	cv::Mat q3(magI, cv::Rect(cx, cy, cx, cy)); // Bottom-Right， 右下，第四象限

	cv::Mat tmp;                           // swap quadrants (Top-Left with Bottom-Right)，交换左上和右下象限
	q0.copyTo(tmp);
	q3.copyTo(q0);
	tmp.copyTo(q3);

	q1.copyTo(tmp);                    // swap quadrant (Top-Right with Bottom-Left)，交换右上和左下象限
	q2.copyTo(q1);
	tmp.copyTo(q2);
	//! [crop_rearrange]

	//! [normalize]
	//归一化，像素值都映射到[0,1]之间
	normalize(magI, magI, 0, 1, cv::NORM_MINMAX); // Transform the matrix with float values into a
											  // viewable image form (float between values 0 and 1).
											  //! [normalize]

											  //显示结果
	cv::imshow("Input Image", gray);    // Show the result
	cv::imshow("spectrum magnitude", magI);

	

	ideal_Low_Pass_Filter(gray, 50);
	addContrast(gray);
	cv::imshow("ideal_Low_Pass_Filter", gray);    // Show the result

	cv::Mat zhijie;
	cv::threshold(gray, zhijie, 32, 255, CV_THRESH_BINARY);
	cv::imshow("zhijie", zhijie);    // Show the result

	cv::threshold(gray, gray, 32, 255, CV_THRESH_BINARY);
	cv::imshow("threshold", gray);    // Show the result

	cv::Mat res;
	cvThin(gray, res, 3);
	cv::imshow("cvThin", res);

	// 拟合
	// (TODO)
}


int main() {
	clock_t startTime, endTime;
	//cv::Mat src = cv::imread("./crack.jpg");	// 256 * 192
	//cv::Mat src = cv::imread("./huahen.jpg");	// 256 * 192
	cv::Mat src = cv::imread("./diandu.png");	// 256 * 192
	cv::imshow("src", src);
	startTime = clock();	// 计时开始
	cannyDetect(src);
	//scratchDetect(src);
	endTime = clock();	// 计时结束

	std::cout << "The run time is : "
		<< (double)(endTime - startTime) / CLOCKS_PER_SEC << "s" << std::endl;
	cv::waitKey(0);
	system("pause");
	return 0;
}