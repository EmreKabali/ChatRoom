using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NetChat2
{
    public class MyHub:Hub
    {

        public static Dictionary<string, string> ListAllConnections = new Dictionary<string, string>();


        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        public override Task OnConnected()
        {
            ListAllConnections.Add(Context.ConnectionId, "");
            Clients.All.BroadCastConnections(ListAllConnections);
            return base.OnConnected();
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            ListAllConnections.Remove(Context.ConnectionId);
            Clients.All.BroadCastConnections(ListAllConnections);
            return base.OnDisconnected(stopCalled);
        }

        public void setConnectionName(string Connectionname)
        {

            ListAllConnections[Context.ConnectionId] = Connectionname;
            Clients.All.BroadCastConnections(ListAllConnections);
        }


    }
}