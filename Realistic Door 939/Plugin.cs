using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;

namespace Realistic_Door_939.Plugin
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "Rysik5318";
        public override string Name => "Realistic Destroys Door 939";
        public override string Prefix => "Realistic Destroys Door 939";
        public override System.Version Version => new System.Version(1, 0, 0);
        public static Plugin Singleton;
        public List<string> time939 = new List<string>();
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
            string Id = ev.Player.UserId;
            if (!ev.Door.IsKeycardDoor && ev.Player.Role.Type.Is939() && !time939.Contains(Id))
            {
                if (UnityEngine.Random.Range(0, 100) > Config.Chance)
                    ev.Door.BreakDoor();
                time939.Add(Id);
                Timing.CallDelayed(Config.Timing, () => { time939.Remove(Id); });
            }
        }
    }
}
