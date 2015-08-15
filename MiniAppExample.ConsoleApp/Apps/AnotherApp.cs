using System;
using MiniAppExample.ConsoleApp.Abstract;

namespace MiniAppExample.ConsoleApp.Apps
{
    public class AnotherApp : MiniAppBase
    {
        public override int AppId => 2;
        public override string AppName => "Second App Here";
        protected override void RunMiniApp()
        {
            Console.WriteLine("Ran app #2");
        }
    }
}