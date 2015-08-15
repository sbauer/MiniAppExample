using System;
using MiniAppExample.ConsoleApp.Concrete;

namespace MiniAppExample.ConsoleApp.Abstract
{
    public abstract class MiniAppBase : IMiniApp {
        public abstract int AppId { get; }
        public abstract string AppName { get; }
        private Action _mainMenuLink;
        public virtual void Execute(IMiniAppInput input) {
            _mainMenuLink = input.MainMenuLink;
            RunMiniApp();
            FinalizeMe();
        }
        protected abstract void RunMiniApp();
        protected virtual void FinalizeMe() {
            Console.WriteLine("\n 'r' to try again | 'm' to menu | other keys - quit :: ");
            string finalGet = Console.ReadLine();

            switch (finalGet) {
                case "r":
                    Execute(new MiniAppInput(_mainMenuLink));
                    break;

                case "m":
                    _mainMenuLink();
                    break;

                default:
                    Console.WriteLine(" Bye!");
                    Console.ReadKey();
                    break;
            }
        }
    }
}