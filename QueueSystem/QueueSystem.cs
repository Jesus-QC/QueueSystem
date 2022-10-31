using System;
using System.Collections.Generic;
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
        public override Version Version { get; } = new (1, 0, 1);
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

        private readonly HashSet<string> _playersAlerted = new ();

        private void OnPreAuthenticating(PreAuthenticatingEventArgs ev)
        {
            if (ev.IsAllowed || !ev.ServerFull || ReservedSlot.HasReservedSlot(ev.UserId))
                return;

            if (!_playersAlerted.Contains(ev.UserId))
            {
                _playersAlerted.Add(ev.UserId);
                ev.Reject("Server Full\n" + Config.AlertMessage, false);
            }
            
            ev.IsAllowed = true;
            ev.Delay(Config.Delay, true);
        }
    }
}