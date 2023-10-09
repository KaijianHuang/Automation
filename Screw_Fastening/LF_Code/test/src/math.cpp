
#include <opencv2/opencv.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/videoio.hpp>
#include "HalconCpp.h"
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
		// cout << "RGB" << endl;
	}
return cv_img;
}