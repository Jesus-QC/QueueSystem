using Exiled.API.Interfaces;

namespace QueueSystem
{
    public class PluginConfig : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}