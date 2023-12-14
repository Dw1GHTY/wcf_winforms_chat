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

        private string _currentCryptionAlgorithm;
        #endregion

        public MyCallback(FormChat form)
        {
            _form = form;
        }

        public void SetCryptionAlgorithm(string cryptionAlgorithm)
        {
            _currentCryptionAlgorithm = cryptionAlgorithm;
        }

        public void RecieveMessage(string user, string message, string cryptionAlgorithm)
        {
            string decryptedMessage = null;

            SetCryptionAlgorithm(cryptionAlgorithm);        

            if (_currentCryptionAlgorithm == "Simple substitution")
            {
                decryptedMessage = SimpleSubDecryptionMachine.Decrypt(message);
                _form.UpdateChatRoom(user.ToUpper() + ": " + decryptedMessage, _currentCryptionAlgorithm);
            }
            else if (_currentCryptionAlgorithm == "A5/2")
            {
                byte[] messageToBytes = Encoding.UTF8.GetBytes(message);
                decryptedMessage = A52DecryptionMachine.Decrypt(messageToBytes);

                
                string[] hexValues = decryptedMessage.Split('-');

                
                byte[] byteArray = new byte[hexValues.Length];
                for (int i = 0; i < hexValues.Length; i++)
                {
                    byteArray[i] = Convert.ToByte(hexValues[i], 16);
                }

                
                string resultString = Encoding.UTF8.GetString(byteArray);

                _form.UpdateChatRoom(user.ToUpper() + ": " + resultString, _currentCryptionAlgorithm);
            }
        }
    }
}
