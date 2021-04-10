﻿extern alias References;

using References::Newtonsoft.Json;
using System;

namespace Oxide.Core.RemoteConsole
{
    /// <summary>
    /// Message sent between the server and all connected clients
    /// </summary>
    [Serializable]
    public class RemoteMessage
    {
        public string Message;
        public int Identifier;
        public string Type;
        public string Stacktrace;

        public static RemoteMessage CreateMessage(string message, int identifier = -1, string type = "Generic", string trace = "") => new RemoteMessage
        {
            Message = message,
            Identifier = identifier,
            Type = type,
            Stacktrace = trace
        };

        public static RemoteMessage GetMessage(string text)
        {
            try
            {
                return JsonConvert.DeserializeObject<RemoteMessage>(text);
            }
            catch (JsonReaderException)
            {
                Interface.Oxide.LogError("[Rcon] Failed to parse message, incorrect format");
                return null;
            }
        }

        public string ToJSON() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
