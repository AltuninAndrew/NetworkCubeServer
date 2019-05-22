using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerForGameTest
{
    public class GameObjClient
    {
        public Vector3 position;
        public string clientId;
       
        public GameObjClient(Vector3 pos, string id)
        {
            position = pos;
            clientId = id;
        }
    }
}