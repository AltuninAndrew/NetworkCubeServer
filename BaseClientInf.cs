using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ServerForGameTest
{
    public class BaseClientInf
    {

        static Dictionary<string, GameObjClient> clients = new Dictionary<string, GameObjClient>();
       
        public BaseClientInf()
        {
           
        }

        public async void AddNewClient(string clientId, string connectionId,Vector3 pos)
        {
            await Task.Run(() =>
            {
                clients.Add(connectionId, new GameObjClient(pos, clientId));
            });

        }

        public GameObjClient GetClient(string connectionId)
        {
            bool s = clients.ContainsKey(connectionId);
            return clients[connectionId];
        }

        public async void SetNewPosForClient(string connectionId, float x, float y, float z)
        {
            await Task.Run(() =>
            {
                clients[connectionId].position = new Vector3(x, y, z);
            });
           
        }

        public List<GameObjClient> GetAllClients()
        {
            return clients.Values.ToList();
        }

    }
}