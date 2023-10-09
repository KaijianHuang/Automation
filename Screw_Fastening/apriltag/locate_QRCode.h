#ifndef HANGAR_LOCATE_QRCODE_H_
#define HANGAR_LOCATE_QRCODE_H_

#include <Eigen/Dense>
#include <iostream>

Eigen::VectorXd GetQRCodePosition(std::string filePath, Eigen::Vector4d cameraParam, double tagSize);

#endif // HANGAR_LOCATE_QRCODE_H_