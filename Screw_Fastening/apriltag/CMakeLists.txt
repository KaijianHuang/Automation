cmake_minimum_required(VERSION 3.0.0)
project(captureImage VERSION 0.1.0)

include(CTest)
enable_testing()

# Eigen
include_directories("/usr/include/eigen3")

# 寻找OpenCV库
find_package(OpenCV REQUIRED)
# 寻找Apritag

# 添加头文件
include_directories(${OpenCV_INCLUDE_DIRS})

include_directories(
    /opt/MVS/include 
    /usr/local/include/apriltag
)

link_directories(
    /opt/MVS/lib/64
    /usr/local/lib
)

add_executable(testVision main.cpp capture_image.cpp tcp_server.cpp locate_QRCode.cpp robot_math.cpp pose_estimation.cpp)

add_executable(calibrateIntrinsic calibrateIntrinsic.cpp )

add_executable(fitPlane fit_plane.cpp )

add_executable(findTag find_apriltag.cpp pose_estimation.cpp)

add_executable(calcBucket calculate_bucket.cpp pose_estimation.cpp)

target_link_libraries(testVision
        # 目标库需要链接的库
        ${OpenCV_LIBS} 
        apriltag
        MvCameraControl
        pthread)

target_link_libraries(findTag
        # 目标库需要链接的库
        ${OpenCV_LIBS} 
        apriltag)

target_link_libraries(calibrateIntrinsic
        # 目标库需要链接的库
        ${OpenCV_LIBS} )

target_link_libraries(calcBucket
        # 目标库需要链接的库
        ${OpenCV_LIBS} )


set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
