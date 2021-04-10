using System.Net;

namespace Oxide.Core.RemoteConsole
{
    public interface IRemoteClient
    {
        IPAddress Address { get; }
        int Port { get; }

        void SendRaw(string message);

        void Send(RemoteMessage message);
        void Send(string message, int identifier = -1);

        string GetKey();
    }
}
