using System;
using System.Linq;
using Autofac;
using MiniAppExample.ConsoleApp.Abstract;

namespace MiniAppExample.ConsoleApp.Dependencies
{
    public class DependencyHelper
    {
        private static IContainer _container;

        private DependencyHelper()
        {
        }

        public static IContainer Container
        {
            get { return _container = _container ?? Configure(); }
            private set { _container = value; }
        }

        public static IContainer Configure()
        {
            var builder = new Autofac.ContainerBuilder();

            builder
                .RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.GetInterfaces().Any(i => i.IsAssignableFrom(typeof (IMiniApp))))
                .AsImplementedInterfaces()
                .Named<IMiniApp>(type=>type.Name)
                .InstancePerDependency();

            return _container = builder.Build();
        }
    }
}