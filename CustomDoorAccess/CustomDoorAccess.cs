using Smod2;
using Smod2.Attributes;
using System.Collections.Generic;
using System;

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
    version = "1.3.2"
    )]

    public class CustomDoorAccess : Plugin
    {
        public override void Register()
        {
            AddEventHandlers(new EventHandler(this));
            AddConfig(new Smod2.Config.ConfigSetting("cda_access_set", new Dictionary<string, string>(), true, Smod2.Config.SettingType.DICTIONARY, true, "Gives access to the door with the item(s) that you set."));
            AddConfig(new Smod2.Config.ConfigSetting("cda_revoke_all", false, true, Smod2.Config.SettingType.BOOL, true, "If true, all the default keycards will not be able to open the door, just the item that you set."));
            AddConfig(new Smod2.Config.ConfigSetting("cda_scp_access", false, true, Smod2.Config.SettingType.BOOL, true, "Allow SCPs to open doors that you set with cda_scp_access_doors."));
            AddConfig(new Smod2.Config.ConfigSetting("cda_scp_access_doors", new string[] { string.Empty }, Smod2.Config.SettingType.LIST, true, "Set the doors that SCPs can open."));
            AddConfig(new Smod2.Config.ConfigSetting("cda_enable", true, Smod2.Config.SettingType.BOOL, true, "Enable/Disable Plugin."));
        }

        public override void OnEnable()
        {
            Info("Plugin has been Enabled!");
        }

        public override void OnDisable()
        {
            Info("Plugin has beed Disabled.");
        }

    }
}
