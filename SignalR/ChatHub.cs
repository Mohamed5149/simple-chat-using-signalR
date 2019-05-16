using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR
{
    public class ChatHub : Hub
    {
        public void NewMessage(string name, string message)
        {
            Clients.All.onMessage(name,message);
        }

        public void JoinGroup(string name, string gName)
        {
            Groups.Add(Context.ConnectionId, gName);
            Clients.OthersInGroup(gName).onMessage(name,"Joined Group");
        }

        public void SendToGroup(string name,string gName,string message)
        {
            Clients.Group(gName).onMessage(name,message);
        }
    }
}