using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class MyCallback : Proxy.IChatServiceCallback
    {
        public void RecieveMessage(string user, string message)
        {
            
        }
    }
}
