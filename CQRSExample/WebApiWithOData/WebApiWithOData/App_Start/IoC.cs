using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Common;
using Contracts;

namespace WebApiWithOData.App_Start
{
    public static class IoC
    {
        internal static void InitializeIoC(this HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // You can register controllers all at once using assembly scanning...
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<WriteLibrary.TaskManager>();
            builder.RegisterType<EventStore<Task, Guid>>()
                .SingleInstance();

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}