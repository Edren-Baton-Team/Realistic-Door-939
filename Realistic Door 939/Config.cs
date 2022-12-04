using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace Realistic_Door_939.Plugin
{
    public class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Chance of knocking out the door? from 0 to 100")]
        public float Chance { get; set; } = 99;
        [Description("The time when it can be repeated (cooldown)")]
        public float Timing { get; set; } = 20f;

    }
}