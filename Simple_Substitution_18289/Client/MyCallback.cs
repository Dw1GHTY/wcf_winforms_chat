using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class MyCallback : Proxy.IChatServiceCallback
    {
        private FormChat _form;
        SimpleSubstitution decryptionMachine = new SimpleSubstitution();

        public MyCallback(FormChat form)
        {
            _form = form;
        }

        public void RecieveMessage(string user, string message)
        {
            string decryptedMessage = decryptionMachine.Decrypt(message);
            _form.UpdateChatRoom(user.ToUpper() + ": " + decryptedMessage);
        }
    }
}
