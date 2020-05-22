#include <iostream>

#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include <opencv2/core/core.hpp>

#include <opencv2/features2d.hpp>
#include <opencv2/opencv.hpp>

#include <vector>
#include <ctime>

void imageMaching(cv::Mat pic1, cv::Mat pic2) {
	// pic1 : ���жԱ�ͼ��
	// pic2 : ��ǰץȡͼ��
	// �ȶ�����ͼ������׼���ٶ�ÿ������������ƶ�
	std::vector<double> resSimilarity;

	cv::Mat pic1_clone = pic1.clone();
	cv::Mat pic2_clone = pic2.clone();


	// ��ȡ�����㼰��׼
	std::vector<cv::KeyPoint> keyPoints_1, keyPoints_2;
	cv::Mat descriptors_1, descriptors_2;
	cv::Ptr<cv::FeatureDetector> detector = cv::ORB::create();
	cv::Ptr<cv::DescriptorExtractor> descriptor = cv::ORB::create();
	cv::Ptr<cv::DescriptorMatcher> matcher = cv::DescriptorMatcher::create("BruteForce-Hamming");
	//cv::Ptr<cv::BRISK> orb = cv::BRISK::create();

	// ��һ�����Oriented�ǵ�λ��
	detector->detect(pic1_clone, keyPoints_1);
	detector->detect(pic2_clone, keyPoints_2);
	//orb->detect(pic1_clone, keyPoints_1);
	//orb->detect(pic2_clone, keyPoints_2);

	// �ڶ������ݽǵ�λ�ü���BRIEF������
	descriptor->compute(pic1_clone, keyPoints_1, descriptors_1);
	descriptor->compute(pic2_clone, keyPoints_2, descriptors_2);
	//orb->compute(pic1_clone, keyPoints_1, descriptors_1);
	//orb->compute(pic2_clone, keyPoints_2, descriptors_2);

	//cv::Mat outImg;
	//cv::drawKeypoints(pic1_cut, keyPoints_1, outImg, cv::Scalar::all(-1), cv::DrawMatchesFlags::DEFAULT);
	//cv::imshow("ORB������", outImg);
	//cv::waitKey(0);

	// ������������ͼ���е�BRIEF�����ӽ���ƥ�䣬ʹ��Hamming����
	std::vector<cv::DMatch> matches;
	matcher->match(descriptors_1, descriptors_2, matches);

	//cv::Ptr<cv::flann::IndexParams> LSH = cv::makePtr<cv::flann::LshIndexParams>(12,20,2);
	//cv::FlannBasedMatcher matcher(LSH);
	//matcher.match(descriptors_1, descriptors_2, matches);

	// ���Ĳ�ƥ����ɸѡ
	double min_dist = 10000, max_dist = 0;
	for (int i = 0; i < descriptors_1.rows; i++) {
		double dist = matches[i].distance;
		if (dist < min_dist) min_dist = dist;
		if (dist > max_dist) max_dist = dist;
	}

	// ��������֮��ľ������������С����ʱ������Ϊƥ�����󣬵���ʱ�����ǳ�С�����þ���ֵ30��Ϊ����
	std::vector < cv::DMatch > good_matches;
	for (int i = 0; i < descriptors_1.rows; i++) {
		if (matches[i].distance <= std::max(2 * min_dist, 30.0)) {
			good_matches.push_back(matches[i]);
		}
	}

	// ���岽����ƥ����
	cv::Mat img_goodmatch;
	cv::drawMatches(pic1_clone, keyPoints_1, pic2_clone, keyPoints_2, good_matches, img_goodmatch);
	//cv::imshow("�Ż���ƥ����", img_goodmatch);

	// ͼ����׼
	std::vector<cv::Point2f> imagePoints1, imagePoints2;
	for (int i = 0; i < good_matches.size(); i++) {
		imagePoints1.push_back(keyPoints_1[good_matches[i].queryIdx].pt);
		imagePoints2.push_back(keyPoints_2[good_matches[i].trainIdx].pt);
	}

	cv::Mat homo = cv::findHomography(imagePoints2, imagePoints1, CV_RANSAC);
	//CalcCorners(homo, pic2_clone);
	//std::cout << "left_top:" << corners.left_top << std::endl;
	//std::cout << "left_bottom:" << corners.left_bottom << std::endl;
	//std::cout << "right_top:" << corners.right_top << std::endl;
	//std::cout << "right_bottom:" << corners.right_bottom << std::endl;
	cv::Mat imageTransform;
	cv::warpPerspective(pic2_clone, imageTransform, homo, cv::Size(pic2_clone.cols, pic2_clone.rows));
}

//void GMSTest(cv::Mat & img_1, cv::Mat & img_2) {
//	cv::Ptr<cv::ORB> orb = cv::ORB::create(5000);
//	orb->setFastThreshold(0);
//
//	std::vector<cv::KeyPoint> keypoints_1, keypoints_2;
//	cv::Mat descriptors_1, descriptors_2;
//
//	//sift->detect(img_1, keypoints_1);
//	//sift->compute(img_1, keypoints_1, descriptors);
//
//	orb->detectAndCompute(img_1, cv::Mat(), keypoints_1, descriptors_1);
//	orb->detectAndCompute(img_2, cv::Mat(), keypoints_2, descriptors_2);
//
//	//orb ->detect(img_1, keypoints_1);
//	//orb ->compute(img_1, keypoints_1, descriptors_1);
//
//	//orb->detect(img_2, keypoints_2);
//	//orb->compute(img_2, keypoints_2, descriptors_2);
//
//	cv::Mat ShowKeypoints1, ShowKeypoints2;
//	cv::drawKeypoints(img_1, keypoints_1, ShowKeypoints1);
//	cv::drawKeypoints(img_2, keypoints_2, ShowKeypoints2);
//	cv::imshow("Result_1", ShowKeypoints1);
//	cv::imshow("Result_2", ShowKeypoints2);
//
//	std::vector<cv::DMatch> matchesAll, matchesGMS;
//	cv::BFMatcher matcher(cv::NORM_HAMMING);
//
//	matcher.match(descriptors_1, descriptors_2, matchesAll);
//	std::cout << "matchesAll: " << matchesAll.size() << std::endl;
//	matchGMS(img_1.size(), img_2.size(), keypoints_1, keypoints_2, matchesAll, matchesGMS);
//	std::cout << "matchesGMS: " << matchesGMS.size() << std::endl;
//
//
//	cv::Mat finalMatches;
//	drawMatches(img_1, keypoints_1, img_2, keypoints_2, matchesGMS, finalMatches, cv::Scalar::all(-1), cv::Scalar::all(-1),
//		std::vector<char>(), cv::DrawMatchesFlags::NOT_DRAW_SINGLE_POINTS);
//	imshow("Matches GMS", finalMatches);
//}

int main() {
	cv::Mat pic1 = cv::imread("./before_ejection.png");	//3840 * 2160
	cv::Mat pic2 = cv::imread("./grabImageBefore.png");

	clock_t startTime, endTime;

	startTime = clock();	// ��ʱ��ʼ

	imageMaching(pic1, pic2);

	endTime = clock();	// ��ʱ����
	std::cout << "The run time is : "
		<< (double)(endTime - startTime) / CLOCKS_PER_SEC << "s" << std::endl;


	cv::waitKey(0);
	system("pause");
	return 0;
}