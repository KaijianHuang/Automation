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


class sender: public reactor::Reactor {
public:
  struct Parameters {
        
  };

 private:
        

  class Inner: public lfutil::LFScope, public Parameters {
        
    // state variable
    
    // methods
    
    // reaction bodies
    void r0_body(
      [[maybe_unused]] const reactor::StartupTrigger& startup,
      reactor::LogicalAction<void>& ready); 
    void r1_body(
      [[maybe_unused]] const reactor::LogicalAction<void>& ready,
      reactor::Output<double>& a,
      reactor::Output<double>& b); 
    // deadline handlers
    

    Inner(reactor::Reactor* reactor, Parameters&& parameters);

   friend sender;
  };

  Inner __lf_inner;

        
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
  reactor::Reaction r0{"reaction_1", 1, this, [this]() { r0_body(); }}; 
  void r1_body() { __lf_inner.r1_body(ready, a, b); }
  reactor::Reaction r1{"reaction_2", 2, this, [this]() { r1_body(); }}; 

 public:
  // input ports
  
  // output ports
  reactor::Output<double> a{"a", this};
  reactor::Output<double> b{"b", this};
  sender(const std::string& name, reactor::Environment* __lf_environment, Parameters&& __lf_parameters);
  sender(const std::string& name, reactor::Reactor* __lf_container, Parameters&& __lf_parameters);

  void assemble() override;
 
 private:
  // connections 
  
};

        
