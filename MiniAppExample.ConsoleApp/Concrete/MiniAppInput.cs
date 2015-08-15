using System;
using MiniAppExample.ConsoleApp.Abstract;

namespace MiniAppExample.ConsoleApp.Concrete
{
    public class MiniAppInput : IMiniAppInput {
        public Action MainMenuLink { get; private set; }
        public MiniAppInput(Action mainMenuLink) {
            MainMenuLink = mainMenuLink;
        }
    }
}