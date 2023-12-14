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

        #region Decryption_Machines
        SimpleSubstitution SimpleSubDecryptionMachine = new SimpleSubstitution();
        A52_CTR A52DecryptionMachine = new A52_CTR();
        #endregion

        public MyCallback(FormChat form)
        {
            _form = form;
        }

        public void RecieveMessage(string user, string message, string cryptionAlgorithm)
        {
            string decryptedMessage = null;

            if (cryptionAlgorithm == "Simple substitution")
            {
                decryptedMessage = SimpleSubDecryptionMachine.Decrypt(message);
                _form.UpdateChatRoom(user.ToUpper() + ": " + decryptedMessage);
            }
            else if (cryptionAlgorithm == "A5/2") 
            {
                //decryptedMessage = A52DecryptionMachine.DecryptCTR(message);      //A I OVDE SI STAOO
                _form.UpdateChatRoom(user.ToUpper() + ": " + decryptedMessage);
            }
        }
    }
}
