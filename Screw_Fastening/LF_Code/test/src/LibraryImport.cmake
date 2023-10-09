target_sources(${LF_MAIN_TARGET} PUBLIC ${CMAKE_CURRENT_LIST_DIR}/math.cpp)

include_directories(/opt/halcon/include)
include_directories(/opt/halcon/include/halconcpp)
include_directories(/opt/halcon/include/hdevengine)
include_directories(/usr/local/include/apriltag/)
include_directories( ${OpenCV_INCLUDE_DIRS} )
#link_directories("$ENV{HALCONROOT}/lib/$ENV{HALCONARCH}")
find_package( OpenCV REQUIRED )
find_package( ur_rtde REQUIRED)
target_link_libraries(
    ${LF_MAIN_TARGET}
    #TODO: Lingua Franca don't know how to make link libraries path with relative path
    #halcon
    #halconcpp
    /opt/halcon/lib/x64-linux/libhalcon.so 
    /opt/halcon/lib/x64-linux/libhalconcpp.so
    ${OpenCV_LIBS}
    /usr/local/lib/libapriltag.so
    ur_rtde::rtde
)