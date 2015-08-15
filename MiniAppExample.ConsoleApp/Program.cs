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

            IMiniApp selectedApp;

            var matchingApps = apps.Where(x => x.AppId.ToString() == selectedId).ToList();
            if (matchingApps.Count() > 1)
            {
                Console.WriteLine("There are multiple apps with that Id.");
                Console.WriteLine("Please select one from this list:");
                int counter = 1;
                var subList = (from matchingApp in matchingApps select new {Id = counter++, App = matchingApp}).ToList();
                subList.ForEach(x =>
                {
                    Console.WriteLine($"{x.Id} - {x.App.AppName}");
                });
                selectedId = Console.ReadLine();
                selectedApp = subList.FirstOrDefault(x => x.Id.ToString() == selectedId)?.App;
            }
            else
            {
                selectedApp = matchingApps.FirstOrDefault(x => x.AppId.ToString() == selectedId);
            }
            if (selectedApp != null)
            {
                // OPTION 1 - Use existing app
                // selectedApp.Execute(new MiniAppInput(MainMenu));

                // OPTION 2 - Get a fresh instance [for whatever reason]

                var freshInstance = container.ResolveNamed<IMiniApp>(selectedApp.GetType().Name);

                freshInstance.Execute(new MiniAppInput(MainMenu));
            }
            else
            {
                Console.WriteLine($"{selectedId} is not a valid input! Try again, or enter 'q' to quit.");
                MainMenu();
            }
            
        }
    }
}
