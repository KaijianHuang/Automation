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


class control: public reactor::Reactor {
public:
  struct Parameters {
    using __lf_period_t = reactor::Duration;
    const __lf_period_t period = __lf_period_t(100ms);
  };

 private:
        

  class Inner: public lfutil::LFScope, public Parameters {
    using Parameters::period;
    // state variable
    double integral_x;
    double integral_y;
    reactor::Duration period_1;
    reactor::Duration period_2;
    bool b_reset;
    bool already_reset;
    // methods
    
    // reaction bodies
    void r0_body(
      [[maybe_unused]] const reactor::Input<double>& error_x,
      [[maybe_unused]] const reactor::Input<double>& error_y,
      [[maybe_unused]] const reactor::Input<double>& z,
      [[maybe_unused]] const reactor::Input<int>& detectionNumber,
      reactor::Output<float>& speed_x,
      reactor::Output<float>& speed_y,
      reactor::Output<float>& speed_z); 
    void r1_body(
      [[maybe_unused]] const reactor::Input<double>& z,
      [[maybe_unused]] const reactor::Input<int>& detectionNumber,
      reactor::Output<float>& speed_z,
      reactor::LogicalAction<void>& up,
      reactor::LogicalAction<void>& origin); 
    void r2_body(
      [[maybe_unused]] const reactor::LogicalAction<void>& up,
      reactor::Output<float>& speed_z,
      reactor::LogicalAction<void>& origin); 
    void r3_body(
      [[maybe_unused]] const reactor::LogicalAction<void>& origin,
      reactor::Output<double>& position_x,
      reactor::Output<double>& position_y,
      reactor::Output<double>& position_z); 
    // deadline handlers
    

    Inner(reactor::Reactor* reactor, Parameters&& parameters);

   friend control;
  };

  Inner __lf_inner;

  const typename Parameters::__lf_period_t& period = __lf_inner.period;
  // reactor instances
  // timers
  
  // actions
  reactor::LogicalAction<void> up;
  reactor::LogicalAction<void> origin;
  reactor::LogicalAction<void> ready;
  // default actions
  reactor::StartupTrigger startup {"startup", this};
  reactor::ShutdownTrigger shutdown {"shutdown", this};
  // reaction views
  
  
  
  
  // reactions
  void r0_body() { __lf_inner.r0_body(error_x, error_y, z, detectionNumber, speed_x, speed_y, speed_z); }
  reactor::Reaction r0{"pid control", 1, this, [this]() { r0_body(); }}; 
  void r1_body() { __lf_inner.r1_body(z, detectionNumber, speed_z, up, origin); }
  reactor::Reaction r1{"reset control", 2, this, [this]() { r1_body(); }}; 
  void r2_body() { __lf_inner.r2_body(up, speed_z, origin); }
  reactor::Reaction r2{"screwer up", 3, this, [this]() { r2_body(); }}; 
  void r3_body() { __lf_inner.r3_body(origin, position_x, position_y, position_z); }
  reactor::Reaction r3{"go to origin position", 4, this, [this]() { r3_body(); }}; 

 public:
  // input ports
  reactor::Input<int> detectionNumber{"detectionNumber", this};
  reactor::Input<double> error_x{"error_x", this};
  reactor::Input<double> error_y{"error_y", this};
  reactor::Input<double> z{"z", this};
  // output ports
  reactor::Output<float> speed_x{"speed_x", this};
  reactor::Output<float> speed_y{"speed_y", this};
  reactor::Output<float> speed_z{"speed_z", this};
  reactor::Output<double> position_x{"position_x", this};
  reactor::Output<double> position_y{"position_y", this};
  reactor::Output<double> position_z{"position_z", this};
  control(const std::string& name, reactor::Environment* __lf_environment, Parameters&& __lf_parameters);
  control(const std::string& name, reactor::Reactor* __lf_container, Parameters&& __lf_parameters);

  void assemble() override;
 
 private:
  // connections 
  
};

        
