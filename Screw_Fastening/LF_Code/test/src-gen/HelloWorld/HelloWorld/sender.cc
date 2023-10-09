/*
 * This file was autogenerated by the Lingua Franca Compiler.
 *
 * Source: platform:/resource/test/src/HelloWorld.lf
 */

#include "HelloWorld/sender.hh"

using namespace reactor::operators;

  // private preamble

// outer constructor
sender::sender(const std::string& name, reactor::Environment* __lf_environment, Parameters&& __lf_parameters)
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
sender::sender(const std::string& name, reactor::Reactor* __lf_container, Parameters&& __lf_parameters)
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
sender::Inner::Inner(::reactor::Reactor* reactor, Parameters&& __lf_parameters)
  : LFScope(reactor)
  , Parameters(std::forward<Parameters>(__lf_parameters))
  // state variables
{}

void sender::assemble() {
  // r0
  r0.declare_trigger(&startup);
          
  r0.declare_schedulable_action(&ready);
          
  
  // r1
  r1.declare_trigger(&ready);
          
  r1.declare_antidependency(&a);
  r1.declare_antidependency(&b);
  // connections
}

// methods


// reaction reaction_1

void sender::Inner::r0_body(
  [[maybe_unused]] const reactor::StartupTrigger& startup,
  reactor::LogicalAction<void>& ready)  {
  cout<<"start in sender"<<endl;
}

// reaction reaction_2

void sender::Inner::r1_body(
  [[maybe_unused]] const reactor::LogicalAction<void>& ready,
  reactor::Output<double>& a,
  reactor::Output<double>& b)  {
  cout<<"send a and b"<<endl;
}

        
