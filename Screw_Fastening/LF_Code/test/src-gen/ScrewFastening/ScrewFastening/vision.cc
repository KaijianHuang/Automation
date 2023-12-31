/*
 * This file was autogenerated by the Lingua Franca Compiler.
 *
 * Source: platform:/resource/test/src/ScrewFastening.lf
 */

#include "ScrewFastening/vision.hh"

using namespace reactor::operators;

  // private preamble

// outer constructor
vision::vision(const std::string& name, reactor::Environment* __lf_environment, Parameters&& __lf_parameters)
  : reactor::Reactor(name, __lf_environment)
  , __lf_inner(this, std::forward<Parameters>(__lf_parameters))
  //reactor instances
  // timers
  // actions
  , ready{"ready", this, reactor::Duration::zero()}
  , interval{"interval", this, reactor::Duration::zero()}
            
  // reaction views
  
  
{
            
            
  // reaction views
  
  
}
vision::vision(const std::string& name, reactor::Reactor* __lf_container, Parameters&& __lf_parameters)
  : reactor::Reactor(name, __lf_container)
  , __lf_inner(this, std::forward<Parameters>(__lf_parameters))
  //reactor instances
  // timers
  // actions
  , ready{"ready", this, reactor::Duration::zero()}
  , interval{"interval", this, reactor::Duration::zero()}
            
  // reaction views
  
  
{
            
            
  // reaction views
  
  
}

// inner constructor
vision::Inner::Inner(::reactor::Reactor* reactor, Parameters&& __lf_parameters)
  : LFScope(reactor)
  , Parameters(std::forward<Parameters>(__lf_parameters))
  // state variables
  , tf(0)
  , td(0)
{}

void vision::assemble() {
  // r0
  r0.declare_trigger(&startup);
          
  r0.declare_schedulable_action(&ready);
          
  
  // r1
  r1.declare_trigger(&ready);
  r1.declare_trigger(&interval);
          
  r1.declare_antidependency(&error_x);
  r1.declare_antidependency(&error_y);
  r1.declare_antidependency(&detection_num);
  r1.declare_schedulable_action(&interval);
  // connections
}

// methods


// reaction reaction_1

void vision::Inner::r0_body(
  [[maybe_unused]] const reactor::StartupTrigger& startup,
  reactor::LogicalAction<void>& ready)  {
  OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive", -1, "default", 
    -1, "false", "default", "000748eb0dd2_TheImagingSourceEuropeGmbH_DFK33GX264e", 
    0, -1, &hv_AcqHandle);
  GrabImageStart(hv_AcqHandle, -1);
  tf = tag36h11_create();
  td = apriltag_detector_create();
  apriltag_detector_add_family(td, tf);
  std::cout << "vision "<< std::endl;
  ready.schedule(period);
}

// reaction reaction_2

void vision::Inner::r1_body(
  [[maybe_unused]] const reactor::LogicalAction<void>& ready,
  reactor::Output<double>& error_x,
  reactor::Output<double>& error_y,
  reactor::Output<int>& detection_num,
  reactor::LogicalAction<void>& interval)  {
          HObject  ho_Image;
          GrabImageAsync(&ho_Image, hv_AcqHandle, 0.5);  
          cv::Mat matColor = HImageToMat(ho_Image); 
          cv::Mat gray;      
          cv::cvtColor(matColor, gray, cv::COLOR_BGR2GRAY);
          image_u8_t im = {gray.cols, gray.rows, gray.cols, gray.data};  
  
          zarray_t *detections = apriltag_detector_detect(td, &im);
          int detect_number = zarray_size(detections);
          bool b_non_sense = false;
          if(detect_number > 0){
              apriltag_detection_t *det;
              zarray_get(detections, 0, &det);
              double object_x = det->c[0];
              double object_y = det->c[1];
              double t_error_x = object_x - desired_x;
              double t_error_y = object_y - desired_y;
              if(abs(t_error_y) < 100.0){
  
                 error_x.set(object_x - desired_x);
                 error_y.set(object_y - desired_y);
              }
              else{
                  std::cout << "detect non-sense value"<< std::endl;
                  b_non_sense = true;
              }
              std::cout << "errorX: "<<object_x - desired_x  << " errorY: "<< object_y - desired_y <<"detect number: "<< detect_number<< endl;
  
          }
          apriltag_detections_destroy(detections);
          if(!b_non_sense)
              detection_num.set(detect_number);
  //        std::cout  << "vision detect: Logical time is " << get_logical_time() << " Microstep: " << get_microstep() <<std::endl;
          interval.schedule(period);
}

        
