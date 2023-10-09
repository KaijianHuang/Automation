/*
 * This file was autogenerated by the Lingua Franca Compiler.
 *
 * Source: platform:/resource/test/src/ScrewFastening.lf
 */
 
#pragma once

#include "reactor-cpp/reactor-cpp.hh"
#include "lfutil.hh"

using namespace std::chrono_literals;

#include "ScrewFastening/_lf_preamble.hh"

#include "ScrewFastening/robot.hh" 
#include "ScrewFastening/vision.hh" 
#include "ScrewFastening/automation_control.hh" 

// public preamble


class ScrewFastening: public reactor::Reactor {
public:
  struct Parameters {
        
  };

 private:
        

  class Inner: public lfutil::LFScope, public Parameters {
        
    // state variable
    
    // methods
    
    // reaction bodies
    
    // deadline handlers
    

    Inner(reactor::Reactor* reactor, Parameters&& parameters);

   friend ScrewFastening;
  };

  Inner __lf_inner;

        
  // reactor instances
  std::unique_ptr<robot> r;
  std::unique_ptr<vision> v;
  std::unique_ptr<automation_control> c;
  // timers
  
  // actions
  
  // default actions
  reactor::StartupTrigger startup {"startup", this};
  reactor::ShutdownTrigger shutdown {"shutdown", this};
  // reaction views
  
  // reactions
  

 public:
  // input ports
  
  // output ports
  
  ScrewFastening(const std::string& name, reactor::Environment* __lf_environment, Parameters&& __lf_parameters);
  ScrewFastening(const std::string& name, reactor::Reactor* __lf_container, Parameters&& __lf_parameters);

  void assemble() override;
 
 private:
  // connections 
  reactor::DelayedConnection<std::remove_reference<decltype(r->position_oz)>::type::value_type> connection_r_position_oz;
};

        
