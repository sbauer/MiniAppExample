using System;
using MiniAppExample.ConsoleApp.Abstract;

namespace MiniAppExample.ConsoleApp.Apps
{
    public class ThirdApp : MiniAppBase
    {
        public override int AppId => 3;

        public override string AppName => "This is yet another App";

        protected override void RunMiniApp()
        {
            Console.WriteLine("No logic to be found here I'm afraid.");
        }
    }
}