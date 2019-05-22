using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ServerForGameTest
{
    public class LobbyHub : Hub
    {
        BaseClientInf clientInf = new BaseClientInf();
        public async void RegisterInLobby(string clientId,
                                          string connectId,
                                          float x,float y,float z,
                                          float colorR,float colorG,
                                          float colorB,float colorA)
        {
           
           await Task.Run(()=> 
           {
               //Clients.Caller.initClientInScene(clientInf.GetAllClients());
               clientInf.AddNewClient(clientId, connectId,new Vector3(x, y, z));
               //Clients.Others.broadcastPosition(clientId,new Vector3(x,y,z));
               
               Clients.Others.broadcastRegClient(clientId, x, y, z,colorR,colorG,colorB,colorA);

           });
        }


        public async void SetNewPosition(string connectId, float x, float y, float z)
        {
            
            await Task.Run(() =>
            {
                clientInf.SetNewPosForClient(connectId, x,y,z);
                Clients.Others.broadcastPosition(clientInf.GetClient(connectId).clientId, x, y, z);
            });
        }

        public override Task OnConnected()
        { 

            return base.OnConnected();
        }

        
    }
}