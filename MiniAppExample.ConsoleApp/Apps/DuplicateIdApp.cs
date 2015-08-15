using System;
using MiniAppExample.ConsoleApp.Abstract;

namespace MiniAppExample.ConsoleApp.Apps
{
    public class DuplicateIdApp : MiniAppBase
    {
        public override int AppId => 2;
        public override string AppName => "Duplicate App";
        protected override void RunMiniApp()
        {
            Console.WriteLine("Here there be too many with the same Id");
        }
    }
}