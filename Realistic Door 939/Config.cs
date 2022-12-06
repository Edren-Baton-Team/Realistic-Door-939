using Exiled.API.Interfaces;
using System.ComponentModel;

namespace Realistic_Door_939.Plugin
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Chance of breaking the door when playing as 939 (from 0 to 100)")]
        public float BreakDoorChance { get; set; } = 1;
        [Description("The time when it can be repeated after (cooldown)")]
        public float Cooldown { get; set; } = 20f;
    }
}
