using System.Collections.Generic;

namespace Oxide.Core.RemoteConsole
{
    public class RemoteConsoleManager
    {
        private Dictionary<string, IRemoteClient> _clients = new Dictionary<string, IRemoteClient>();

        public bool TryGetClient(string key, out IRemoteClient client)
        {
            if (_clients.ContainsKey(key))
            {
                client = _clients[key];
                return true;
            }

            client = null;
            return false;
        }

        public void AddClient(IRemoteClient client)
        {
            _clients.Add(client.GetKey(), client);
        }

        public void RemoveClient(IRemoteClient client)
        {
            string key = client.GetKey();
            if (_clients.ContainsKey(key))
            {
                _clients.Remove(key);
            }
        }

        public void RemoveClient(string key)
        {
            if (_clients.ContainsKey(key))
            {
                _clients.Remove(key);
            }
        }
    }
}
