/*
 * This file was autogenerated by the Lingua Franca Compiler.
 *
 * Source: platform:/resource/test/src/HelloWorld.lf
 */

#include "HelloWorld/robot.hh"

using namespace reactor::operators;

  // private preamble

// outer constructor
robot::robot(const std::string& name, reactor::Environment* __lf_environment, Parameters&& __lf_parameters)
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
robot::robot(const std::string& name, reactor::Reactor* __lf_container, Parameters&& __lf_parameters)
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
robot::Inner::Inner(::reactor::Reactor* reactor, Parameters&& __lf_parameters)
  : LFScope(reactor)
  , Parameters(std::forward<Parameters>(__lf_parameters))
  // state variables
{}

void robot::assemble() {
  // r0
  r0.declare_trigger(&startup);
          
  r0.declare_schedulable_action(&ready);
          
  
  // r1
  r1.declare_trigger(&ready);
  r1.declare_trigger(&interval);
          
  r1.declare_antidependency(&position_oz);
  r1.declare_schedulable_action(&interval);
          
  
  // r2
  r2.declare_trigger(&speed_x);
  r2.declare_trigger(&speed_y);
  r2.declare_trigger(&speed_z);
          
          
          
  
  // r3
  r3.declare_trigger(&position_x);
  r3.declare_trigger(&position_y);
  r3.declare_trigger(&position_z);
          
          
          
  
  // r4
  r4.declare_trigger(&shutdown);
          
          
  // connections
}

// methods


// reaction startup

void robot::Inner::r0_body(
  [[maybe_unused]] const reactor::StartupTrigger& startup,
  reactor::LogicalAction<void>& ready)  {
  rtde_control = new RTDEControlInterface("10.192.50.146");
  rtde_receive = new RTDEReceiveInterface("10.192.50.146");
  std::cout << "ready "<< std::endl;
  ready.schedule(period);
}

// reaction get_tcp_pose

void robot::Inner::r1_body(
  [[maybe_unused]] const reactor::LogicalAction<void>& ready,
  reactor::Output<double>& position_oz,
  reactor::LogicalAction<void>& interval)  {
  vector<double> Tcp_pose = rtde_receive->getActualTCPPose();
  position_oz.set(Tcp_pose[2]);
  interval.schedule(period);
}

// reaction control speed

void robot::Inner::r2_body(
  [[maybe_unused]] const reactor::Input<float>& speed_x,
  [[maybe_unused]] const reactor::Input<float>& speed_y,
  [[maybe_unused]] const reactor::Input<float>& speed_z)  {
  std::cout << "control speed: *speed_x.get():"<< *speed_x.get() <<"*speed_y.get()"<<*speed_y.get()<<"*speed_z.get()"<<*speed_z.get()<< std::endl;
  rtde_control->speedL({*speed_y.get(), *speed_x.get(), *speed_z.get(),0,0,0},0.5,1);
}

// reaction control position

void robot::Inner::r3_body(
  [[maybe_unused]] const reactor::Input<double>& position_x,
  [[maybe_unused]] const reactor::Input<double>& position_y,
  [[maybe_unused]] const reactor::Input<double>& position_z)  {
  std::cout << "control position" << std::endl;
  while(rtde_control->speedStop(0.5) == false){
    std::this_thread::sleep_for(std::chrono::milliseconds(200));
  }
  rtde_control->moveL({0.367, -0.420, 0.407, 0.021,3.124,0},0.5,1);
  std::this_thread::sleep_for(std::chrono::milliseconds(2000));
  rtde_control->stopL(0.5, false);
}

// reaction shutdown

void robot::Inner::r4_body([[maybe_unused]] const reactor::ShutdownTrigger& shutdown) {
  delete rtde_control;
  delete rtde_receive;
}

        
