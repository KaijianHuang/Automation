target_sources(${LF_MAIN_TARGET} PUBLIC ${CMAKE_CURRENT_LIST_DIR}/Image.cpp)
include_directories(${CMAKE_CURRENT_LIST_DIR}/.. ${CMAKE_CURRENT_LIST_DIR}/../..)
#include halcon libraries
include_directories("$ENV{HALCONROOT}/include"
                    "$ENV{HALCONROOT}/include/halconcpp")
#link_directories("$ENV{HALCONROOT}/lib/$ENV{HALCONARCH}")
link_directories("/home/zyp/halcon/lib/x64-linux")
message("$ENV{HALCONROOT}/lib/$ENV{HALCONARCH}")
target_link_libraries(
    ${LF_MAIN_TARGET}
    #TODO: Lingua Franca don't know how to make link libraries path with relative path
    #halcon
    #halconcpp
    $ENV{HALCONROOT}/lib/$ENV{HALCONARCH}/libhalcon.so 
    $ENV{HALCONROOT}/lib/$ENV{HALCONARCH}/libhalconcpp.so
)