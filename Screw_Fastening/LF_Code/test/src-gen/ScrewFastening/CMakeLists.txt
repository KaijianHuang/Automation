cmake_minimum_required(VERSION 3.5)
project(ScrewFastening VERSION 0.0.0 LANGUAGES CXX)



set(LF_MAIN_TARGET ScrewFastening)

add_executable(${LF_MAIN_TARGET}
    ScrewFastening/automation_control.cc
    ScrewFastening/vision.cc
    ScrewFastening/robot.cc
    ScrewFastening/ScrewFastening.cc
    ScrewFastening/_lf_preamble.cc
    main.cc
)
target_include_directories(${LF_MAIN_TARGET} PUBLIC
    "${LF_SRC_PKG_PATH}/src"
    "${PROJECT_SOURCE_DIR}"
    "${PROJECT_SOURCE_DIR}/__include__"
)
target_link_libraries(${LF_MAIN_TARGET} reactor-cpp-default)

if(MSVC)
  target_compile_options(${LF_MAIN_TARGET} PRIVATE /W4)
else()
  target_compile_options(${LF_MAIN_TARGET} PRIVATE -Wall -Wextra -pedantic)
endif()

install(TARGETS ${LF_MAIN_TARGET}
        RUNTIME DESTINATION ${CMAKE_INSTALL_BINDIR}
        OPTIONAL
)

# Cache a list of the include directories for use with tools external to CMake and Make.
# This will only work if the subdirectory that sets up the library target has already been visited.
get_target_property(TARGET_INCLUDE_DIRECTORIES ${LF_MAIN_TARGET} INCLUDE_DIRECTORIES)
get_target_property(REACTOR_CPP_INCLUDE_DIRECTORIES reactor-cpp-default INCLUDE_DIRECTORIES)
list(APPEND TARGET_INCLUDE_DIRECTORIES ${REACTOR_CPP_INCLUDE_DIRECTORIES})
set(TARGET_INCLUDE_DIRECTORIES_ScrewFastening ${TARGET_INCLUDE_DIRECTORIES} CACHE STRING "Directories included in the main target." FORCE)
set(CXX_COMPILER_ID ${CMAKE_CXX_COMPILER_ID} CACHE STRING "The name of the C++ compiler." FORCE)

include("/home/cct/lf-workspace/test/src/LibraryImport.cmake")