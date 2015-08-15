namespace MiniAppExample.ConsoleApp.Abstract
{
    public interface IMiniApp {
        int AppId { get; }
        string AppName { get; }
        void Execute(IMiniAppInput input);
    }
}