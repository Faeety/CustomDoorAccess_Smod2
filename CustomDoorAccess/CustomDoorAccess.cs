using Smod2;
using Smod2.Attributes;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Collections;

namespace CustomDoorAccess
{
    [PluginDetails(
    author = "Faety",
    description = "Custom your door access, doorid:card",
    id = "faety.door.access",
    name = "Custom Door Access",
    SmodMajor = 3,
    SmodMinor = 0,
    SmodRevision = 0,
    version = "1.2"
    )]

    public class CustomDoorAccess : Plugin
    {
        public override void Register()
        {
            this.AddEventHandlers(new EventHandler(this), Priority.High);
            AddConfig(new Smod2.Config.ConfigSetting("cda_access_set", new Dictionary<string, string>(), true, Smod2.Config.SettingType.DICTIONARY, true, "Set access."));
            AddConfig(new Smod2.Config.ConfigSetting("cda_revoke_all", false, true, Smod2.Config.SettingType.BOOL, true, "Revoke the access for all the other cards ?"));
        }

        public override void OnEnable()
        {
            this.Info("Plugin ready to work!");
        }

        public override void OnDisable()
        {
            this.Info("Plugin disabled.");
        }

    }
}
