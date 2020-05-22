#pragma once
#ifndef CAMERADRIVE_H
#define CAMERADRIVE_H

#include <iostream>
#include <thread>

#include <opencv2/imgproc/imgproc.hpp>
#include <opencv2/core/core.hpp>
#include <opencv2/highgui/highgui.hpp>

class Camera{
public:
	Camera();
	~Camera();

	cv::Mat matImg_1;

	bool stop;
	void cam_stop();

	void getImage(int threadId);

private:
	std::string source1 = "rtsp://admin:tongxint704@192.168.1.64:554/h265/ch1/main/av_stream/1";

	cv::VideoCapture capture1;

	void startthread1();

	static void *video_capture_thread1(void *arg);
	
};

#endif // CAMERADRIVE_H