using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class SimpleSubstitution
    {
        public static string alphabet = ConfigurationManager.AppSettings["englishAlphabet"];
        public static string key = ConfigurationManager.AppSettings["key"];
        public SimpleSubstitution() 
        {
            
        }
        public string Encrypt(string inputMessage)
        {
            //subs
            Dictionary<char, char> substitutes = new Dictionary<char, char>();
            for (int i = 0; i < 25; i++)
            {
                substitutes.Add(alphabet[i], key[i]);
            }
            //encryption
            StringBuilder encryptedText = new StringBuilder();
            foreach (char letter in inputMessage)
            {
                if (substitutes.ContainsKey(letter))
                {
                    encryptedText.Append(substitutes[letter]);
                }
                else
                {
                    encryptedText.Append(letter);
                }
            }
            
            return encryptedText.ToString();
        }
        public string Decrypt(string cryptedMessage)
        {
            //subs
            Dictionary<char, char> substitutes = new Dictionary<char, char>();
            for (int i = 0; i < 25; i++)
            {
                substitutes.Add(key[i], alphabet[i]);
            }
            //decryption
            StringBuilder decryptedText = new StringBuilder();
            foreach (char letter in cryptedMessage)
            {
                if (substitutes.ContainsKey(letter))
                {
                    decryptedText.Append(substitutes[letter]);
                }
                else
                {
                    decryptedText.Append(letter);
                }

            }
            return decryptedText.ToString();
        }
    }
}
