using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    [ServiceContract]
    public interface IChatClient
    {
        [OperationContract(IsOneWay = true)]    
        void RecieveMessage(string user, string message);
    }

    [ServiceContract(CallbackContract = typeof(IChatClient))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = true)]
        void Join(string username);
        [OperationContract(IsOneWay = true)]
        void SendMessage(string message);
    }

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
