using System;
using MiniAppExample.ConsoleApp.Abstract;

namespace MiniAppExample.ConsoleApp.Apps
{
    public class FinalApp : MiniAppBase
    {
        public override int AppId => 44444;
        public override string AppName => "Big Number App";
        protected override void RunMiniApp()
        {
            Console.WriteLine("That's all for me. Thanks for checking it out, and good luck.");
        }
    }
}