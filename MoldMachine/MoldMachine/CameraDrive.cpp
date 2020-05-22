#include "CameraDrive.h"

Camera::Camera(){
	stop = false;
	if (capture1.open(source1, cv::CAP_FFMPEG)) startthread1();
}


void Camera::startthread1() {

	std::thread task(&video_capture_thread1, (void*)this);

	task.detach();
}

void *Camera::video_capture_thread1(void *arg) {
	Camera *came = (Camera *)arg;

	while (!came->stop)
	{
		came->getImage(1);
	}

	delete came;
	return 0;
}

void Camera::getImage(int threadId) {
	switch (threadId)
	{
	case 1:
		capture1 >> matImg_1;
		break;
	default:
		break;
	}
}

void Camera::cam_stop() {
	stop = true;
}

Camera::~Camera() {
	cam_stop();
}