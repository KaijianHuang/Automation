#include <opencv2/opencv.hpp>
#include <iomanip>
#include <iostream>

#include "locate_QRCode.h"
#include "robot_math.h"

#include "apriltag.h"
#include "tag36h11.h"
#include "tag25h9.h"
#include "tag16h5.h"
#include "tagCircle21h7.h"
#include "tagCircle49h12.h"
#include "tagCustom48h12.h"
#include "tagStandard41h12.h"
#include "tagStandard52h13.h"
#include "common/getopt.h"
#include "apriltag_pose.h"
#include "common/homography.h"

using namespace Eigen;

VectorXd GetQRCodePosition(std::string filePath, Eigen::Vector4d cameraParam, double tagSize) {
    VectorXd qrcodePosition(6);

    getopt_t *getopt = getopt_create();
    getopt_add_string(getopt, 'f', "family", "tag36h11", "Tag family to use");

    cv::Mat rawImage = cv::imread("img2.png");
    cv::Mat gray;

    apriltag_family_t *tf = NULL;
    tf = tag36h11_create();

    apriltag_detector_t *td = apriltag_detector_create();
    apriltag_detector_add_family(td, tf);

    apriltag_detection_info_t info;
    info.tagsize = tagSize;
    info.fx = cameraParam(0);
    info.fy = cameraParam(1);
    // opencv4
    info.cx = cameraParam(2);
    info.cy = cameraParam(3);

    cv::cvtColor(rawImage, gray, cv::COLOR_BGR2GRAY);
    cv::imshow("gray", gray);
    cv::waitKey(0);
	cv::destroyWindow("gray");

    // opencv4
    // cvtColor(Cam_Frame, Cam_Frame, CV_RGB2BGRA);

    // Make an image_u8_t header for the Mat data
    image_u8_t im = { gray.cols,
                        gray.rows,
                        gray.cols,
                        gray.data
    };

    zarray_t *detections = apriltag_detector_detect(td, &im);

    int detectionNumber = zarray_size(detections);

    Vector3d ori_relative_P;
    Matrix3d ori_rotation_matrix3d;
    
    if(detectionNumber == 1) {
        apriltag_detection_t *det;
        zarray_get(detections, 0, &det);
        info.det = det;
        apriltag_pose_t pose;
        // estimate_pose_for_tag_homography(&info, &pose);
        estimate_tag_pose(&info, &pose);
        
        memcpy(&ori_relative_P, pose.t->data, sizeof(Vector3d));
        memcpy(&ori_rotation_matrix3d, pose.R->data, sizeof(Matrix3d));

    } else {
        std::cout << "detection error" << std::endl;
    }
 
    apriltag_detections_destroy(detections);

    qrcodePosition(0) = ori_relative_P(0);
    qrcodePosition(1) = ori_relative_P(1);
    qrcodePosition(2) = ori_relative_P(2);

    Vector3d rpyVector = RotationMatrixToRPYInAngleHalcon(ori_rotation_matrix3d);
    qrcodePosition(3) = rpyVector(0);
    qrcodePosition(4) = rpyVector(1);
    qrcodePosition(5) = rpyVector(2);
    

    return qrcodePosition;
}