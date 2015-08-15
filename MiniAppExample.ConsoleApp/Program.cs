using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using MiniAppExample.ConsoleApp.Abstract;
using MiniAppExample.ConsoleApp.Concrete;
using MiniAppExample.ConsoleApp.Dependencies;

namespace MiniAppExample.ConsoleApp {
    class Program {
        static void Main(string[] args) {
            MainMenu();
        }

        static void MainMenu()
        {
            var container = DependencyHelper.Container;

            var apps = container.Resolve<IEnumerable<IMiniApp>>().ToList();

            if (!apps.Any())
            {
                Console.WriteLine("No applications found. We out.");
                return;
            }

            Console.WriteLine("Welcome!");
            Console.WriteLine("Please select an App by it's ID");

            foreach (var app in apps.OrderBy(x => x.AppId))
            {
                Console.WriteLine($"{app.AppId} - {app.AppName}");
            }
            var selectedId = Console.ReadLine();

            if (selectedId == "q") return;

            var selectedApp = apps.FirstOrDefault(x => x.AppId.ToString() == selectedId);
            if (selectedApp != null)
            {
                var appToRun = Activator.CreateInstance(selectedApp.GetType()) as IMiniApp;
                appToRun?.Execute(new MiniAppInput(MainMenu));
            }
            else
            {
                Console.WriteLine($"{selectedId} is not a valid input! Try again, or enter 'q' to quit.");
                MainMenu();
            }
        }
    }
}
