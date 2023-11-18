using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{

    //implementacija Callbacka
    public class MyCallback : Proxy.IChatServiceCallback
    {
        //Primanje poruke
        public void RecieveMessage(string user, string message)
        {
            Console.WriteLine("{0}: {1}", user, message);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new MyCallback());
            Proxy.ChatServiceClient server = new Proxy.ChatServiceClient(context);

            Console.WriteLine("Enter username: ");
            var userName = Console.ReadLine();
            server.Join(userName);


            Console.WriteLine("Send message: ");
            Console.WriteLine("Type /exit to exit");

            var message = Console.ReadLine();
            Console.WriteLine();
            while (message != "/exit") 
            {
                if (!string.IsNullOrEmpty(message))
                    server.SendMessage(message);
                message = Console.ReadLine();                
            }
        }
    }
}
