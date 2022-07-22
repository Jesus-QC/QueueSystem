using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Player = Exiled.Events.Handlers.Player;

namespace QueueSystem
{
    public class QueueSystem : Plugin<PluginConfig>
    {
        public override string Author { get; } = "Jesus-QC";
        public override string Name { get; } = "QueueSystem";
        public override string Prefix { get; } = "queue_system";
        public override Version Version { get; } = new (1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new (5, 2, 2);

        public override void OnEnabled()
        {
            Player.PreAuthenticating += OnPreAuthenticating;
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Player.PreAuthenticating -= OnPreAuthenticating;
            
            base.OnDisabled();
        }

        private void OnPreAuthenticating(PreAuthenticatingEventArgs ev)
        {
            Log.Info(ev.UserId + " >> a");
            Log.Info(ev.ServerFull + " " + !ReservedSlot.HasReservedSlot(ev.UserId));
            
            if(ev.ServerFull && !ReservedSlot.HasReservedSlot(ev.UserId))
                ev.Delay(4, true);
        }
    }
}