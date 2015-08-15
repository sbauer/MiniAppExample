using System;

namespace MiniAppExample.ConsoleApp.Abstract
{
    public interface IMiniAppInput {
        Action MainMenuLink { get; }
    }
}