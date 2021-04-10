using System.Net;

namespace Oxide.Core.RemoteConsole
{
    public abstract class RemoteClient : IRemoteClient
    {
        public abstract IPAddress Address { get; }
        public abstract int Port { get; }

        public abstract void SendRaw(string message);

        public void Send(RemoteMessage message)
        {
            SendRaw(message.ToJSON());
        }
        public void Send(string message, int identifier = -1)
        {
            RemoteMessage remoteMessage = RemoteMessage.CreateMessage(message, identifier);

            SendRaw(remoteMessage.ToJSON());
        }

        public string GetKey() => $"{Address}:{Port}";
    }
}
