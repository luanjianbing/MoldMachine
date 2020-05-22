#include "ImageProcessing.h"

ImageProcessing::ImageProcessing(cv::Mat &mat, cv::Mat &now_mat, std::vector<std::vector<int>> block)
:mat(mat), now_mat(now_mat), blockint(block){
	//blockint.resize(blockstr.size());
	//for (int i = 0; i < blockstr.size(); i++){
	//	for (int j = 1; j < blockstr[i].size(); j++) {
	//		blockint[i].push_back(atoi(blockstr[i][j].c_str()));
	//	}
	//}
	//// 将一系列区域标记出来
	//for (int i = 0; i < blockint.size(); i++) {
	//	cv::rectangle(now_mat, cv::Rect(blockint[i][0], blockint[i][1],
	//		blockint[i][2], blockint[i][3]), CvScalar(255, 0, 0), 8, cv::LINE_8, 0);
	//}
}

//void ImageProcessing::GammaTransform(cv::Mat &inputImage) {
//	cv::Mat imageGamma;
//	inputImage.convertTo(imageGamma, CV_64F, 1.0 / 255, 0);
//	double gamma = 2.2;
//	pow(imageGamma, gamma, inputImage);
//	inputImage.convertTo(inputImage, CV_8U, 255, 0);
//}

std::vector<double> ImageProcessing::compareFacesByHist(cv::Mat pic1, cv::Mat pic2)
{	
	// pic1 : 已有对比图像
	// pic2 : 当前抓取图像
	// 先对整幅图进行配准，再对每个区域计算相似度
	std::vector<double> resSimilarity;

	cv::Mat pic1_clone = pic1.clone();
	cv::Mat pic2_clone = pic2.clone();
	// 转换成灰度图
	cv::cvtColor(pic1_clone, pic1_clone, cv::COLOR_RGB2GRAY);
	cv::cvtColor(pic2_clone, pic2_clone, cv::COLOR_RGB2GRAY);
	// 1. 规定原大图三个区域用于检测角点
	clock_t t = clock();
	// 三个区域用于角点检测
	cv::Mat pic1ToDetect[3], pic2ToDetect[3];
	// 规定范围 pic1ToDetect
	pic1ToDetect[0] = pic1_clone(cv::Range(10, 40), cv::Range(15, 40));
	pic1ToDetect[1] = pic1_clone(cv::Range(10, 40), cv::Range(110, 140));
	pic1ToDetect[2] = pic1_clone(cv::Range(110, 140), cv::Range(80, 110));
	// 规定范围 pic2ToDetect
	pic2ToDetect[0] = pic1_clone(cv::Range(10, 40), cv::Range(15, 40));
	pic2ToDetect[1] = pic1_clone(cv::Range(10, 40), cv::Range(110, 140));
	pic2ToDetect[2] = pic1_clone(cv::Range(110, 140), cv::Range(80, 110));
	cv::Point2f point1[3], point2[3];
	for (int i = 0; i < 3; i++)	// 标准图像
	{
		point1[i] = detectCorners(pic1ToDetect[i]);
	}
	for (int i = 0; i < 3; i++)	// 即时图像
	{
		point2[i] = detectCorners(pic2ToDetect[i]);
	}
	cv::Mat site_mat = getAffineTransform(point2, point1);
	cv::Mat imageTransform;
	warpAffine(pic1_clone, imageTransform, site_mat, pic1_clone.size());
	// 至此得到三个点
	std::cout << "rigistration : " << double(clock() - t) / CLOCKS_PER_SEC << std::endl;

	//// 提取特征点及配准
	//std::vector<cv::KeyPoint> keyPoints_1, keyPoints_2;
	//cv::Mat descriptors_1, descriptors_2;
	//cv::Ptr<cv::FeatureDetector> detector = cv::ORB::create();
	//cv::Ptr<cv::DescriptorExtractor> descriptor = cv::ORB::create();
	//cv::Ptr<cv::DescriptorMatcher> matcher = cv::DescriptorMatcher::create("BruteForce-Hamming");
	////cv::Ptr<cv::ORB> orb = cv::ORB::create();

	//// 第一步检测Oriented角点位置
	//detector->detect(pic1_clone, keyPoints_1);
	//detector->detect(pic2_clone, keyPoints_2);
	////orb->detect(pic1_clone, keyPoints_1);
	////orb->detect(pic2_clone, keyPoints_2);

	//// 第二步根据角点位置计算BRIEF描述子
	//descriptor->compute(pic1_clone, keyPoints_1, descriptors_1);
	//descriptor->compute(pic2_clone, keyPoints_2, descriptors_2);
	////orb->compute(pic1_clone, keyPoints_1, descriptors_1);
	////orb->compute(pic2_clone, keyPoints_2, descriptors_2);

	////cv::Mat outImg;
	////cv::drawKeypoints(pic1_cut, keyPoints_1, outImg, cv::Scalar::all(-1), cv::DrawMatchesFlags::DEFAULT);
	////cv::imshow("ORB特征点", outImg);
	////cv::waitKey(0);

	//// 第三步对两幅图像中的BRIEF描述子进行匹配，使用Hamming距离
	//std::vector<cv::DMatch> matches;
	//matcher->match(descriptors_1, descriptors_2, matches);
	////cv::BFMatcher bfmatcher(cv::NORM_HAMMING);
	////bfmatcher.match(descriptors_1, descriptors_2, matches);

	//// 第四步匹配点对筛选
	//double min_dist = 10000, max_dist = 0;
	//for (int i = 0; i < descriptors_1.rows; i++) {
	//	double dist = matches[i].distance;
	//	if (dist < min_dist) min_dist = dist;
	//	if (dist > max_dist) max_dist = dist;
	//}

	//// 当描述子之间的距离大于两倍最小距离时，即认为匹配有误，但有时距离会非常小，设置经验值30作为下线
	//std::vector < cv::DMatch > good_matches;
	//for (int i = 0; i < descriptors_1.rows; i++) {
	//	if (matches[i].distance <= std::max(2 * min_dist, 30.0)) {
	//		good_matches.push_back(matches[i]);
	//	}
	//}

	////// 第五步绘制匹配结果
	////cv::Mat img_goodmatch;
	////cv::drawMatches(pic1_cut, keyPoints_1, pic2_cut, keyPoints_2, good_matches, img_goodmatch);
	//////cv::imshow("优化后匹配点对", img_goodmatch);
	//////cv::waitKey(0);

	//// 图像配准
	//std::vector<cv::Point2f> imagePoints1, imagePoints2;
	//for (int i = 0; i < good_matches.size(); i++) {
	//	imagePoints1.push_back(keyPoints_1[good_matches[i].queryIdx].pt);
	//	imagePoints2.push_back(keyPoints_2[good_matches[i].trainIdx].pt);
	//}

	//cv::Mat homo = cv::findHomography(imagePoints2, imagePoints1, CV_RANSAC);
	//CalcCorners(homo, pic2_clone);
	//std::cout << "left_top:" << corners.left_top << std::endl;
	//std::cout << "left_bottom:" << corners.left_bottom << std::endl;
	//std::cout << "right_top:" << corners.right_top << std::endl;
	//std::cout << "right_bottom:" << corners.right_bottom << std::endl;
	//cv::Mat imageTransform;
	//cv::warpPerspective(pic2_clone, imageTransform, homo, cv::Size(corners.right_bottom.x, corners.right_bottom.y));
	////cv::imshow("直接经过透视矩阵变换", imageTransform);
	////cv::imshow("pic1_cut", pic1_clone);
	////cv::waitKey(0);

	////int dst_width = imageTransform.cols;  //取最右点的长度为拼接图的长度
	////int dst_height = pic1_clone.rows;

	////cv::Mat dst(dst_height, dst_width, CV_8UC3);
	////dst.setTo(0);

	////// 图像融合(去裂缝处理)
	////OptimizeSeam(pic1_clone, imageTransform, dst);
	////cv::imwrite("./Resources/image/toUpdateImg.png", dst);

	//// 直接取配准完毕后的图像作为标准图像
	//cv::imwrite("./Resources/image/toUpdateImg.png", imageTransform);

	// 
	for (int i = 0; i < blockint.size(); i++) {
		// blockint中i=0-3为顶点及长宽，i=4为blockid，i=5为shapeid
		cv::Mat pic1_cut = pic1_clone(cv::Rect(blockint[i][0], blockint[i][1], blockint[i][2], blockint[i][3]));
		cv::Mat pic2_cut = imageTransform(cv::Rect(blockint[i][0], blockint[i][1], blockint[i][2], blockint[i][3]));

		if (blockint[i][5] != 0) {	// 不为矩形需要做处理
			roiCutInShapeId(pic1_cut, pic2_cut, i);
		}

		double dSimilarity = 0;

		//cv::Mat gray_pic1_cut, gray_pic2_cut;
		//cv::cvtColor(pic1_cut, gray_pic1_cut, cv::COLOR_RGB2GRAY);
		//cv::cvtColor(pic2_cut, gray_pic2_cut, cv::COLOR_RGB2GRAY);
		// 灰度
		clock_t t = clock();
		//dSimilarity = similarityGrayMatrix(pic1_cut, pic2_cut, 9);
		dSimilarity = simpleMatchAHash(pic1_cut, pic2_cut);
		std::cout << "dSimilarity : " << double(clock() - t) / CLOCKS_PER_SEC  << " : " << pic2_cut.size() << std::endl;

		resSimilarity.push_back(dSimilarity);

		switch (blockint[i][4])		// block id	: 工具框功能
		{
			case 1:
			{
				break;
			}
			case 2:
			{
				break;
			}
			case 3:
			{
				break;
			}
			case 4:
			{
				break;
			}
			case 5:
			{
				break;
			}
			case 6:
			{
				break;
			}
			case 7:
			{
				break;
			}
			case 8:
			{
				break;
			}
			case 9:
			{
				break;
			}
			case 10:
			{
				break;
			}
			case 11:
			{
				break;
			}
			case 12:		// 区域残留物检测
			{
				bool res = residueDetection(pic1_cut, pic2_cut);
				resSimilarity[resSimilarity.size() - 1] = res;
				break;
			}
			default:
				break;
			}

	}
	std::cout << "all processing : " << double(clock() - t) / CLOCKS_PER_SEC << std::endl;
	return resSimilarity;
	
}

void ImageProcessing::roiCutInShapeId(cv::Mat &roiCutImg_1, cv::Mat &roiCutImg_2, int iD) {
	cv::Mat mask = cv::Mat::zeros(roiCutImg_1.size(), CV_8UC1);	// 同等大小全黑图像

	switch (blockint[iD][5])	// shapeId
	{
		case 1:		// 圆形
		{
			int cX = blockint[iD][2] / 2;
			int cY = blockint[iD][3] / 2;
			int lAxis = cX;
			int sAxis = cY;
			cv::ellipse(mask, cv::Point(cX, cY), cv::Size(lAxis, sAxis), 0, 0, 360, CvScalar(255, 255, 255), 8, cv::LINE_8);
			floodFill(mask, cv::Point(cX, cY), 255, NULL, cvScalarAll(0), cvScalarAll(0), CV_FLOODFILL_FIXED_RANGE);

			cv::Mat res1, res2;
			roiCutImg_1.copyTo(res1, mask);
			res1.copyTo(roiCutImg_1);
			roiCutImg_2.copyTo(res2, mask);
			res2.copyTo(roiCutImg_2);
			break;
		}
		case 2:		// 三角形
		{
			cv::Point points[1][3];
			points[0][0] = cv::Point(0, blockint[iD][3]);
			points[0][1] = cv::Point(blockint[iD][2] / 2, 0);
			points[0][2] = cv::Point(blockint[iD][2], blockint[iD][3]);
			const cv::Point *pts[1] = { points[0] };
			int npt[] = { 3 };
			cv::polylines(mask, pts, npt, 1, true, cv::Scalar(255, 255, 255), 8);
			floodFill(mask, cv::Point(blockint[iD][2] / 2, blockint[iD][3] / 2), 255, NULL, cvScalarAll(0), cvScalarAll(0), CV_FLOODFILL_FIXED_RANGE);

			cv::Mat res1, res2;
			roiCutImg_1.copyTo(res1, mask);
			res1.copyTo(roiCutImg_1);
			roiCutImg_2.copyTo(res2, mask);
			res2.copyTo(roiCutImg_2);
			break;
		}
		case 3:		// 菱形
		{
			cv::Point points[1][4];
			points[0][0] = cv::Point(0, blockint[iD][3] / 2);
			points[0][1] = cv::Point(blockint[iD][2] / 2, 0);
			points[0][2] = cv::Point(blockint[iD][2], blockint[iD][3] / 2);
			points[0][3] = cv::Point(blockint[iD][2] / 2, blockint[iD][3]);
			const cv::Point *pts[1] = { points[0] };
			int npt[] = { 4 };
			cv::polylines(mask, pts, npt, 1, true, cv::Scalar(255, 255, 255), 8);
			floodFill(mask, cv::Point(blockint[iD][2] / 2, blockint[iD][3] / 2), 255, NULL, cvScalarAll(0), cvScalarAll(0), CV_FLOODFILL_FIXED_RANGE);

			cv::Mat res1, res2;
			roiCutImg_1.copyTo(res1, mask);
			res1.copyTo(roiCutImg_1);
			roiCutImg_2.copyTo(res2, mask);
			res2.copyTo(roiCutImg_2);

			break;
		}
		default:
			break;
	}
}

cv::Point2f ImageProcessing::detectCorners(cv::Mat srcgray) {
	std::vector<cv::Point2f> corners;//提供初始角点的坐标位置和精确的坐标的位置
	int maxcorners = 1;
	double qualityLevel = 0.01;  //角点检测可接受的最小特征值
	double minDistance = 20;	//角点之间最小距离
	int blockSize = 3;//计算导数自相关矩阵时指定的领域范围
	double  k = 0.04; //权重系数
	goodFeaturesToTrack(srcgray, corners, maxcorners, qualityLevel, minDistance, cv::Mat(), blockSize, false, k);

	cv::Size winSize = cv::Size(5, 5);  //搜素窗口的一半尺寸
	cv::Size zeroZone = cv::Size(-1, -1);//表示死区的一半尺寸
								 //求角点的迭代过程的终止条件，即角点位置的确定
	cv::TermCriteria criteria = cv::TermCriteria(CV_TERMCRIT_EPS + CV_TERMCRIT_ITER, 40, 0.001);
	cornerSubPix(srcgray, corners, winSize, zeroZone, criteria);
	cv::Point2f point = corners[0];
	return point;
}

void ImageProcessing::CalcCorners(const cv::Mat& H, const cv::Mat& src)
{
	double v2[] = { 0, 0, 1 };//左上角
	double v1[3];//变换后的坐标值
	cv::Mat V2 = cv::Mat(3, 1, CV_64FC1, v2);  //列向量
	cv::Mat V1 = cv::Mat(3, 1, CV_64FC1, v1);  //列向量

	V1 = H * V2;
	//左上角(0,0,1)
	std::cout << "V2: " << V2 << std::endl;
	std::cout << "V1: " << V1 << std::endl;
	corners.left_top.x = v1[0] / v1[2];
	corners.left_top.y = v1[1] / v1[2];

	//左下角(0,src.rows,1)
	v2[0] = 0;
	v2[1] = src.rows;
	v2[2] = 1;
	V2 = cv::Mat(3, 1, CV_64FC1, v2);  //列向量
	V1 = cv::Mat(3, 1, CV_64FC1, v1);  //列向量
	V1 = H * V2;
	corners.left_bottom.x = v1[0] / v1[2];
	corners.left_bottom.y = v1[1] / v1[2];

	//右上角(src.cols,0,1)
	v2[0] = src.cols;
	v2[1] = 0;
	v2[2] = 1;
	V2 = cv::Mat(3, 1, CV_64FC1, v2);  //列向量
	V1 = cv::Mat(3, 1, CV_64FC1, v1);  //列向量
	V1 = H * V2;
	corners.right_top.x = v1[0] / v1[2];
	corners.right_top.y = v1[1] / v1[2];

	//右下角(src.cols,src.rows,1)
	v2[0] = src.cols;
	v2[1] = src.rows;
	v2[2] = 1;
	V2 = cv::Mat(3, 1, CV_64FC1, v2);  //列向量
	V1 = cv::Mat(3, 1, CV_64FC1, v1);  //列向量
	V1 = H * V2;
	corners.right_bottom.x = v1[0] / v1[2];
	corners.right_bottom.y = v1[1] / v1[2];

}

void ImageProcessing::OptimizeSeam(cv::Mat& img1, cv::Mat& trans, cv::Mat& dst)
{
	int start = MIN(corners.left_top.x, corners.left_bottom.x);//开始位置，即重叠区域的左边界  

	double processWidth = img1.cols - start;//重叠区域的宽度  
	int rows = dst.rows;
	int cols = img1.cols; //注意，是列数*通道数
	double alpha = 1;//img1中像素的权重  
	for (int i = 0; i < rows; i++)
	{
		uchar* p = img1.ptr<uchar>(i);  //获取第i行的首地址
		uchar* t = trans.ptr<uchar>(i);
		uchar* d = dst.ptr<uchar>(i);
		for (int j = start; j < cols; j++)
		{
			//如果遇到图像trans中无像素的黑点，则完全拷贝img1中的数据
			if (t[j * 3] == 0 && t[j * 3 + 1] == 0 && t[j * 3 + 2] == 0)
			{
				alpha = 1;
			}
			else
			{
				//img1中像素的权重，与当前处理点距重叠区域左边界的距离成正比，实验证明，这种方法确实好  
				alpha = (processWidth - (j - start)) / processWidth;
			}

			d[j * 3] = p[j * 3] * alpha + t[j * 3] * (1 - alpha);
			d[j * 3 + 1] = p[j * 3 + 1] * alpha + t[j * 3 + 1] * (1 - alpha);
			d[j * 3 + 2] = p[j * 3 + 2] * alpha + t[j * 3 + 2] * (1 - alpha);

		}
	}
}

bool ImageProcessing::residueDetection(cv::Mat imgNorm, cv::Mat &imgAbNorm) {
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

void ImageProcessing::getglcm_horison(cv::Mat& input, cv::Mat& dst)//0度灰度共生矩阵
{
	cv::Mat src = input;
	CV_Assert(1 == src.channels());
	src.convertTo(src, CV_32S);
	int height = src.rows;
	int width = src.cols;
	int max_gray_level = 0;
	for (int j = 0; j < height; j++)//寻找像素灰度最大值
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
	max_gray_level++;//像素灰度最大值加1即为该矩阵所拥有的灰度级数
	if (max_gray_level > 16)//若灰度级数大于16，则将图像的灰度级缩小至16级，减小灰度共生矩阵的大小。
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
		dst = cv::Scalar::all(0);
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
	else//若灰度级数小于16，则生成相应的灰度共生矩阵
	{
		dst.create(max_gray_level, max_gray_level, CV_32SC1);
		dst = cv::Scalar::all(0);
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


void ImageProcessing::getglcm_vertical(cv::Mat& input, cv::Mat& dst)//90度灰度共生矩阵
{
	cv::Mat src = input;
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
		for (int i = 0; i < height; i++)//将图像的灰度级缩小至16级，减小灰度共生矩阵的大小。
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width; j++)
			{
				srcdata[j] = (int)srcdata[j] / gray_level;
			}
		}

		dst.create(gray_level, gray_level, CV_32SC1);
		dst = cv::Scalar::all(0);
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
		dst = cv::Scalar::all(0);
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


void ImageProcessing::getglcm_45(cv::Mat& input, cv::Mat& dst)//45度灰度共生矩阵
{
	cv::Mat src = input;
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
		for (int i = 0; i < height; i++)//将图像的灰度级缩小至16级，减小灰度共生矩阵的大小。
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width; j++)
			{
				srcdata[j] = (int)srcdata[j] / gray_level;
			}
		}

		dst.create(gray_level, gray_level, CV_32SC1);
		dst = cv::Scalar::all(0);
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
		dst = cv::Scalar::all(0);
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


void ImageProcessing::getglcm_135(cv::Mat& input, cv::Mat& dst)//135度灰度共生矩阵
{
	cv::Mat src = input;
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
		for (int i = 0; i < height; i++)//将图像的灰度级缩小至16级，减小灰度共生矩阵的大小。
		{
			int*srcdata = src.ptr<int>(i);
			for (int j = 0; j < width; j++)
			{
				srcdata[j] = (int)srcdata[j] / gray_level;
			}
		}

		dst.create(gray_level, gray_level, CV_32SC1);
		dst = cv::Scalar::all(0);
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
		dst = cv::Scalar::all(0);
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

void ImageProcessing::feature_computer(cv::Mat&src, double& Asm, double& Eng, double& Con, double& Idm)//计算特征值
{
	int height = src.rows;
	int width = src.cols;
	int total = 0;
	for (int i = 0; i < height; i++)
	{
		int*srcdata = src.ptr<int>(i);
		for (int j = 0; j < width; j++)
		{
			total += srcdata[j];//求图像所有像素的灰度值的和
		}
	}

	cv::Mat copy;
	copy.create(height, width, CV_64FC1);
	for (int i = 0; i < height; i++)
	{
		int*srcdata = src.ptr<int>(i);
		double*copydata = copy.ptr<double>(i);
		for (int j = 0; j < width; j++)
		{
			copydata[j] = (double)srcdata[j] / (double)total;//图像每一个像素的的值除以像素总和
		}
	}


	for (int i = 0; i < height; i++)
	{
		double*srcdata = copy.ptr<double>(i);
		for (int j = 0; j < width; j++)
		{
			Asm += srcdata[j] * srcdata[j];//能量
			if (srcdata[j]>0)
				Eng -= srcdata[j] * log(srcdata[j]);//熵             
			Con += (double)(i - j)*(double)(i - j)*srcdata[j];//对比度
			Idm += srcdata[j] / (1 + (double)(i - j)*(double)(i - j));//逆差矩
		}
	}
}

double ImageProcessing::similarityGrayMatrix(cv::Mat img1_gray, cv::Mat img2_gray, int winSize) {
	// img1 img2 同等大小
	// 输入为灰度图像
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

// 均值哈希值方法
double ImageProcessing::simpleMatchAHash(cv::Mat tmplateImg, cv::Mat toMatchImg) {
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

ImageProcessing::~ImageProcessing() {

}
