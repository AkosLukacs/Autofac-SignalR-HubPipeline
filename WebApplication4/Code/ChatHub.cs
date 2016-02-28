using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Code
{
  public class ChatHub : Hub
  {
    public void Send(string name, string message) {
      // Call the broadcastMessage method to update clients.
      Clients.All.broadcastMessage(name, message);
    }

    public string Throw(string name, string message) {
      throw new Exception("you said: " + message);
    }
  }
}