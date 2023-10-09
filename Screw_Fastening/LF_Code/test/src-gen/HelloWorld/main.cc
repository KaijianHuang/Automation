/*
 * This file was autogenerated by the Lingua Franca Compiler.
 *
 * Source: platform:/resource/test/src/HelloWorld.lf
 */

#include <chrono>
#include <thread>
#include <memory>

#include "reactor-cpp/reactor-cpp.hh"

using namespace std::chrono_literals;
using namespace reactor::operators;


#include "HelloWorld/HelloWorld.hh"

#include "time_parser.hh"

int main(int argc, char **argv) {
  cxxopts::Options options("HelloWorld", "Reactor Program");

  unsigned workers = std::thread::hardware_concurrency();
  bool fast{false};
  bool keepalive{false};
  reactor::Duration timeout = reactor::Duration::max();
  
  // the timeout variable needs to be tested beyond fitting the Duration-type 
  options
    .set_width(120)
    .add_options()
      ("w,workers", "the number of worker threads used by the scheduler", cxxopts::value<unsigned>(workers)->default_value(std::to_string(workers)), "'unsigned'")
      ("o,timeout", "Time after which the execution is aborted.", cxxopts::value<reactor::Duration>(timeout)->default_value(time_to_string(timeout)), "'FLOAT UNIT'")
      ("k,keepalive", "Continue execution even when there are no events to process.", cxxopts::value<bool>(keepalive)->default_value("false"))
      ("f,fast", "Allow logical time to run faster than physical time.", cxxopts::value<bool>(fast)->default_value("false"))
      ("help", "Print help");
      
        

  cxxopts::ParseResult result{};
  bool parse_error{false};
  try {
    result = options.parse(argc, argv);
  } catch (const cxxopts::OptionException& e) {
    reactor::log::Error() << e.what();
    parse_error = true;
  }
  
  // if parameter --help was used or there was a parse error, print help
  if (parse_error || result.count("help"))
  {
       std::cout << options.help({""});
       return parse_error ? -1 : 0;
  }

  reactor::Environment e{workers, keepalive, fast, timeout};

  // instantiate the main reactor
  auto main = std ::make_unique<HelloWorld> ("HelloWorld", &e, HelloWorld::Parameters{});

  // assemble reactor program
  e.assemble();
        
        

  // start execution
  auto thread = e.startup();
  thread.join();
  return 0;
}
