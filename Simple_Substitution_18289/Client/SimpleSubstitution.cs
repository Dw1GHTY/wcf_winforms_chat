using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class SimpleSubstitution
    {
        public string alphabet;
        public string key;

        public SimpleSubstitution(string alphabet, string key) 
        {
            this.alphabet = alphabet;
            this.key = key;
        }

        public Dictionary<char, char> CryptionSubGenerator()
        {
            Dictionary<char, char> cryptionSubstitutes = new Dictionary<char, char>();

            for (int i = 0; i < 26; i++)
            {
                cryptionSubstitutes.Add(alphabet[i], key[i]);
            }

            return cryptionSubstitutes;
        }
        public Dictionary<char, char> DecryptionSubGenerator()
        {
            Dictionary<char, char> cryptionSubstitutes = new Dictionary<char, char>();

            for (int i = 0; i < 26; i++)
            {
                cryptionSubstitutes.Add(key[i], alphabet[i]);
            }

            return cryptionSubstitutes;
        }

        public string Encrypt(string inputMessage)
        {
            Dictionary<char, char> substitutes = CryptionSubGenerator();

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
            Dictionary<char, char> substitutes = DecryptionSubGenerator();

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
