using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SimpleSubstitution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string key =      "zyxwvutsrqponmlkjihgfedcba";
            string inputText = "Pozdrav ovo je proba";


            //substitutes generator
            Dictionary<char, char> SubGenerator()
            {
                Dictionary<char, char> substitutes = new Dictionary<char, char>();

                for (int i = 0; i < 26; i++)
                {
                    substitutes.Add(alphabet[i], key[i]);
                }

                return substitutes;
            }

            string Encrypt(string inputMessage) 
            {
                
                Dictionary<char, char> substitutes = SubGenerator();

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


            void Decrypt(string inputMessage) 
            {
                StringBuilder decryptedText = new StringBuilder();
                foreach (char letter in inputMessage) 
                {

                }
            }




            Console.ReadKey();
        }
    }
}
