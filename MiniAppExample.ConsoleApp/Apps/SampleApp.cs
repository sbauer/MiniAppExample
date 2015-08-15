using System;
using MiniAppExample.ConsoleApp.Abstract;

namespace MiniAppExample.ConsoleApp.Apps
{
    public class SampleApp : MiniAppBase {
        public override int AppId => 1;

        public override string AppName => "Sample App";

        protected override void RunMiniApp() {
            Console.WriteLine("Ran SampleApp");
        }
    }
}