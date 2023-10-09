#include <iostream>
#include <fstream>
#include <iomanip>
#include <string>
#include "apriltag.h"
#include "apriltag_pose.h"
#include "common/getopt.h"
#include "common/homography.h"
#include "tag16h5.h"
#include "tag25h9.h"
#include "tag36h11.h"
#include "tagCircle21h7.h"
#include "tagCircle49h12.h"
#include "tagCustom48h12.h"
#include "tagStandard41h12.h"
#include "tagStandard52h13.h"
#include "HalconCpp.h"
#include "HDevThread.h"
#include <opencv2/opencv.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/videoio.hpp>
#include<sstream>
#include <ur_rtde/rtde_control_interface.h>
#include <thread>
#include <chrono>
#include <ctime>
#include <time.h>

using namespace ur_rtde;
using namespace std::chrono;
using namespace HalconCpp;
using namespace std;

cv::Mat HImageToMat(HalconCpp::HObject &H_img)
{
	cv::Mat cv_img;
	HalconCpp::HTuple channels, w, h;
	HalconCpp::ConvertImageType(H_img, &H_img, "byte");
	HalconCpp::CountChannels(H_img, &channels);
if (channels.I() == 1)
	{
		HalconCpp::HTuple pointer;
GetImagePointer1(H_img, &pointer, nullptr, &w, &h);
int width = w.I(), height = h.I();
int size = width * height;
		cv_img = cv::Mat::zeros(height, width, CV_8UC1);
memcpy(cv_img.data, (void*)(pointer.L()), size);
		cout << "Gray" << endl;
	}
else if (channels.I() == 3)
	{
		HalconCpp::HTuple pointerR, pointerG, pointerB;
		HalconCpp::GetImagePointer3(H_img, &pointerR, &pointerG, &pointerB, nullptr, &w, &h);
int width = w.I(), height = h.I();
int size = width * height;
		cv_img = cv::Mat::zeros(height, width, CV_8UC3);
		uchar* R = (uchar*)(pointerR.L());
		uchar* G = (uchar*)(pointerG.L());
		uchar* B = (uchar*)(pointerB.L());
for (int i = 0; i < height; ++i)
		{
			uchar *p = cv_img.ptr<uchar>(i);
for (int j = 0; j < width; ++j)
			{
				p[3 * j] = B[i * width + j];
				p[3 * j + 1] = G[i * width + j];
				p[3 * j + 2] = R[i * width + j];
			}
		}
		cout << "RGB" << endl;
	}
return cv_img;
}

int main(){
  RTDEControlInterface rtde_control("10.192.50.146");
  HObject  ho_Image;
  const double desired_x = 683;
  const double desired_y = 489;
  double base_speed = 0.03;
  double object_x, object_y, error_x, error_y, speed_x, speed_y;
  // Local control variables
  HTuple  hv_AcqHandle;
  OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive", -1, "default", 
      -1, "false", "default", "0007482f371b_TheImagingSourceEuropeGmbH_DFK33GP1300", 
      0, -1, &hv_AcqHandle);
  GrabImageStart(hv_AcqHandle, -1);
  cv::Mat img;
  vector<pair<double,double>> position_history;
    while (true)
    {
      GrabImageAsync(&ho_Image, hv_AcqHandle, 0.5);
      cv::Mat matColor = HImageToMat(ho_Image);
      //cv::waitKey(10);
      getopt_t *getopt = getopt_create();
      getopt_add_string(getopt, 'f', "family", "tag36h11", "Tag family to use");

      cv::Mat gray;

      apriltag_family_t *tf = NULL;
      tf = tag36h11_create();

      apriltag_detector_t *td = apriltag_detector_create();
      apriltag_detector_add_family(td, tf);

      cv::cvtColor(matColor, gray, cv::COLOR_BGR2GRAY);

      // Make an image_u8_t header for the Mat data
      image_u8_t im = {gray.cols, gray.rows, gray.cols, gray.data};

      zarray_t *detections = apriltag_detector_detect(td, &im);

      int detectionNumber = zarray_size(detections);
      if (detectionNumber == 0){
        cout<<"Not detected" <<endl;
        rtde_control.speedL({0,0,0,0,0,0},0.5,1);
      }else{

      apriltag_detection_t *det;
      zarray_get(detections, 0, &det);
      std::cout << det->c[0] << " : " << det->c[1] << std::endl;
      object_x = det->c[0];
      object_y = det->c[1];

      usleep(10000);
      }
      apriltag_detections_destroy(detections);
      


    }
    
    cv::destroyAllWindows(); //关闭所有窗口
}

