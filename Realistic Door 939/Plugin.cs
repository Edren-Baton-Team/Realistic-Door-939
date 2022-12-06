using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace Realistic_Door_939.Plugin
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "Rysik5318";
        public override string Name => "Realistic939";
        public override string Prefix => "Realistic939";
        public override System.Version Version => new System.Version(1, 0, 2);
        public static Plugin Singleton;
        public List<Player> BreakingDoorCooldownedPlayers = new List<Player>();
        public override void OnEnabled()
        {
            Singleton = this;
            Exiled.Events.Handlers.Player.InteractingDoor += OnInteractingDoor;
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Singleton = null;
            Exiled.Events.Handlers.Player.InteractingDoor -= OnInteractingDoor;
            base.OnDisabled();
        }

        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (!ev.Door.IsKeycardDoor && ev.Player.Role.Type.Is939() && !BreakingDoorCooldownedPlayers.Contains(ev.Player))
            {
                if (UnityEngine.Random.Range(0, 100) <= Config.BreakingDoorChance)
                    ev.Door.BreakDoor();
                BreakingDoorCooldownedPlayers.Add(ev.Player);
                Timing.CallDelayed(Config.Cooldown, () => BreakingDoorCooldownedPlayers.Remove(ev.Player));
            }
        }
    }
}
