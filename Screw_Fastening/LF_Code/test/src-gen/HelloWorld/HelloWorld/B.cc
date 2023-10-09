/*
 * This file was autogenerated by the Lingua Franca Compiler.
 *
 * Source: platform:/resource/test/src/HelloWorld.lf
 */

#include "HelloWorld/B.hh"

using namespace reactor::operators;

  // private preamble

// outer constructor
B::B(const std::string& name, reactor::Environment* __lf_environment, Parameters&& __lf_parameters)
  : reactor::Reactor(name, __lf_environment)
  , __lf_inner(this, std::forward<Parameters>(__lf_parameters))
  //reactor instances
  // timers
  // actions
  
            
  // reaction views
  
  
{
            
            
  // reaction views
  
  
}
B::B(const std::string& name, reactor::Reactor* __lf_container, Parameters&& __lf_parameters)
  : reactor::Reactor(name, __lf_container)
  , __lf_inner(this, std::forward<Parameters>(__lf_parameters))
  //reactor instances
  // timers
  // actions
  
            
  // reaction views
  
  
{
            
            
  // reaction views
  
  
}

// inner constructor
B::Inner::Inner(::reactor::Reactor* reactor, Parameters&& __lf_parameters)
  : LFScope(reactor)
  , Parameters(std::forward<Parameters>(__lf_parameters))
  // state variables
{}

void B::assemble() {
  // r0
  r0.declare_trigger(&x);
          
          
          
  
  // r1
  r1.declare_trigger(&startup);
          
  r1.declare_antidependency(&y);
  r1.declare_antidependency(&z);
  // connections
}

// methods


// reaction reaction_1

void B::Inner::r0_body([[maybe_unused]] const reactor::Input<int>& x) {
  // ... something here ...
}

// reaction reaction_2

void B::Inner::r1_body(
  [[maybe_unused]] const reactor::StartupTrigger& startup,
  reactor::Output<int>& y,
  reactor::Output<int>& z)  {
  cout<<"send at B"<<endl;
  y.set(0);
  z.set(1);
}

        
