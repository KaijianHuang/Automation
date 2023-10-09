/*
 * This file was autogenerated by the Lingua Franca Compiler.
 *
 * Source: platform:/resource/test/src/HelloWorld.lf
 */
 
#pragma once

#include "reactor-cpp/reactor-cpp.hh"
#include "lfutil.hh"

using namespace std::chrono_literals;

#include "HelloWorld/_lf_preamble.hh"

        

// public preamble


class robot: public reactor::Reactor {
public:
  struct Parameters {
    using __lf_period_t = reactor::Duration;
    const __lf_period_t period = __lf_period_t(100ms);
  };

 private:
        

  class Inner: public lfutil::LFScope, public Parameters {
    using Parameters::period;
    // state variable
    RTDEControlInterface* rtde_control;
    RTDEReceiveInterface* rtde_receive;
    // methods
    
    // reaction bodies
    void r0_body(
      [[maybe_unused]] const reactor::StartupTrigger& startup,
      reactor::LogicalAction<void>& ready); 
    void r1_body(
      [[maybe_unused]] const reactor::LogicalAction<void>& ready,
      reactor::Output<double>& position_oz,
      reactor::LogicalAction<void>& interval); 
    void r2_body(
      [[maybe_unused]] const reactor::Input<float>& speed_x,
      [[maybe_unused]] const reactor::Input<float>& speed_y,
      [[maybe_unused]] const reactor::Input<float>& speed_z); 
    void r3_body(
      [[maybe_unused]] const reactor::Input<double>& position_x,
      [[maybe_unused]] const reactor::Input<double>& position_y,
      [[maybe_unused]] const reactor::Input<double>& position_z); 
    void r4_body([[maybe_unused]] const reactor::ShutdownTrigger& shutdown);
    // deadline handlers
    

    Inner(reactor::Reactor* reactor, Parameters&& parameters);

   friend robot;
  };

  Inner __lf_inner;

  const typename Parameters::__lf_period_t& period = __lf_inner.period;
  // reactor instances
  // timers
  
  // actions
  reactor::LogicalAction<void> ready;
  reactor::LogicalAction<void> interval;
  // default actions
  reactor::StartupTrigger startup {"startup", this};
  reactor::ShutdownTrigger shutdown {"shutdown", this};
  // reaction views
  
  
  
  
  
  // reactions
  void r0_body() { __lf_inner.r0_body(startup, ready); }
  reactor::Reaction r0{"startup", 1, this, [this]() { r0_body(); }}; 
  void r1_body() { __lf_inner.r1_body(ready, position_oz, interval); }
  reactor::Reaction r1{"get_tcp_pose", 2, this, [this]() { r1_body(); }}; 
  void r2_body() { __lf_inner.r2_body(speed_x, speed_y, speed_z); }
  reactor::Reaction r2{"control speed", 3, this, [this]() { r2_body(); }}; 
  void r3_body() { __lf_inner.r3_body(position_x, position_y, position_z); }
  reactor::Reaction r3{"control position", 4, this, [this]() { r3_body(); }}; 
  void r4_body() { __lf_inner.r4_body(shutdown); }
  reactor::Reaction r4{"shutdown", 5, this, [this]() { r4_body(); }}; 

 public:
  // input ports
  reactor::Input<float> speed_x{"speed_x", this};
  reactor::Input<float> speed_y{"speed_y", this};
  reactor::Input<float> speed_z{"speed_z", this};
  reactor::Input<double> position_x{"position_x", this};
  reactor::Input<double> position_y{"position_y", this};
  reactor::Input<double> position_z{"position_z", this};
  // output ports
  reactor::Output<double> position_oz{"position_oz", this};
  robot(const std::string& name, reactor::Environment* __lf_environment, Parameters&& __lf_parameters);
  robot(const std::string& name, reactor::Reactor* __lf_container, Parameters&& __lf_parameters);

  void assemble() override;
 
 private:
  // connections 
  
};

        
