using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    // Define a duplex service contract.
    // A duplex contract consists of two interfaces.
    // The primary interface is used to send messages from client to service.
    // The callback interface is used to send messages from service back to client.
    // IChatCLient allows one to perform multiple operations on a running result.
    // The result is sent back after each operation on the IChatService interface.
    [ServiceContract]
    public interface IChatClient
    {
        [OperationContract(IsOneWay = true)]    //ovime se oznacava svaka metoda koja je deo javnog contracta
        void RecieveMessage(string user, string message);
    }


    //Callback interfejs -> sadrzi set metoda koje server moze pokrenuti na klijentu
    [ServiceContract(CallbackContract = typeof(IChatClient))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Join(string username);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }

    // Service class which implements a duplex service contract.
    // Use an InstanceContextMode of PerSession to store the result
    // An instance of the service will be bound to each duplex session
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Single,
                    InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        Dictionary<IChatClient, string> _users = new Dictionary<IChatClient, string>();

        public void Join(string username)
        {
            //connection info
            var connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            //konekciji se dodeljuje username
            _users[connection] = username;

        }

        public void SendMessage(string message)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IChatClient>();
            string user;
            if (!_users.TryGetValue(connection, out user))
                return;
            foreach (var client in _users.Keys)
            {
                if (client == connection)
                    continue;
                client.RecieveMessage(user, message);
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ChatService));
            host.Open();
            Console.WriteLine("*******CHAT SERVICE INITIALIZED********");
            Console.ReadLine();
            host.Close();
        }
    }
}
