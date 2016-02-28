using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApplication4.Code
{
  public class SignalRExceptionHandler : HubPipelineModule
  {
    public SignalRExceptionHandler() {
      Trace.WriteLine("  SignalRExceptionHandler  ctor");
    }


    protected override void OnIncomingError(Microsoft.AspNet.SignalR.Hubs.ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext) {
      Trace.WriteLine("@signalr Err" + exceptionContext.Error.ToString());
      base.OnIncomingError(exceptionContext, invokerContext);
    }

    protected override Boolean OnBeforeIncoming(IHubIncomingInvokerContext context) {
      Trace.WriteLine("@OnBeforeIncoming");
      return base.OnBeforeIncoming(context);
    }
  }
}