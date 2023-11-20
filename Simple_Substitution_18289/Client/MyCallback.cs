using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class MyCallback : Proxy.IChatServiceCallback
    {
        private FormChat _form;

        public MyCallback(FormChat form)
        {
            _form = form;
        }

        public void RecieveMessage(string user, string message)
        {
            _form.UpdateChatRoom(user.ToUpper() + ": " + message);
        }
    }
}
