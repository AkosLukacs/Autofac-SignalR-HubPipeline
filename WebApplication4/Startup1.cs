using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using Microsoft.AspNet.SignalR;
using Autofac;
using Autofac.Integration.SignalR;
using WebApplication4.Code;

[assembly: OwinStartup(typeof(WebApplication4.Startup1))]

namespace WebApplication4
{
  public class Startup1
  {
    public void Configuration(IAppBuilder app) {
      // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

      var builder = new ContainerBuilder();

      // STANDARD SIGNALR SETUP:

      // Get your HubConfiguration. In OWIN, you'll create one
      // rather than using GlobalHost.
      var config = new HubConfiguration();

      // Register your SignalR hubs.
      builder.RegisterHubs(Assembly.GetExecutingAssembly());

      // Set the dependency resolver to be Autofac.
      var container = builder.Build();
      //Have to set both to get the HubPipeline module working
      config.Resolver = new Autofac.Integration.SignalR.AutofacDependencyResolver(container);


      // OWIN SIGNALR SETUP:

      // Register the Autofac middleware FIRST, then the standard SignalR middleware.
      app.UseAutofacMiddleware(container);
      app.MapSignalR(config);


      //"the" solution for adding HubPipelineModules with DI: https://github.com/SignalR/SignalR/issues/2226
      var hubPipeline = config.Resolver.Resolve<Microsoft.AspNet.SignalR.Hubs.IHubPipeline>();
      hubPipeline.AddModule(new SignalRExceptionHandler());
    }
  }
}
