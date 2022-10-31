using System.ComponentModel;
using Exiled.API.Interfaces;

namespace QueueSystem
{
    public class PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        
        [Description("The time to tell the client to wait for until trying to connect again. (0-255)")]
        public byte Delay { get; set; } = 4;

        [Description("The first attempt to join of the player will be received with a message.")]
        public string AlertMessage { get; set; } = "Join again to be added to a automatic queue.\nYou will automatically join the server once there is a slot available!";
    }
}