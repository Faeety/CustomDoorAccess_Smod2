using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoorAccess
{
    class EventHandler : IEventHandlerDoorAccess, IEventHandlerWaitingForPlayers
    {
        private Plugin plugin;

        public EventHandler(Plugin plugin)
        {
            this.plugin = plugin;
        }

        readonly Dictionary<string, string> access = ConfigManager.Manager.Config.GetDictValue("cda_access_set");
        readonly bool revokeAll = ConfigManager.Manager.Config.GetBoolValue("cda_revoke_all", false);
        readonly bool scpAccess = ConfigManager.Manager.Config.GetBoolValue("cda_scp_access", false);
        readonly string[] scpAccessDoors = ConfigManager.Manager.Config.GetListValue("cda_scp_access_doors", new string[] { string.Empty }, false);

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
            if (!ConfigManager.Manager.Config.GetBoolValue("cda_enable", true, false)) plugin.pluginManager.DisablePlugin(plugin);
            plugin.Debug(ConfigManager.Manager.Config.GetBoolValue("cda_enable", true, false).ToString());
        }

        public void OnDoorAccess(PlayerDoorAccessEvent ev)
        {
            Player player = ev.Player;
            foreach (KeyValuePair<string, string> x in access)
            {
                plugin.Debug(x.Key);
                if (ev.Door.Name == x.Key)
                {
                    string trimmedValue = x.Value.Trim();
                    string[] itemIDs = trimmedValue.Split('&');

                    foreach (string eachValue in itemIDs)
                    {
                        int currentItem = player.GetCurrentItemIndex();
                        plugin.Debug(eachValue);
                        if (Int32.TryParse(eachValue, out int itemID))
                        {
                            if (player.GetCurrentItemIndex().Equals(itemID) && !player.GetCurrentItemIndex().Equals(-1))
                            {
                                ev.Allow = true;
                                plugin.Debug(player.GetCurrentItemIndex().ToString());
                            }
                            else if (revokeAll && !itemIDs.Contains(currentItem.ToString()))
                            {
                                ev.Allow = false;
                                if (scpAccess)
                                {
                                    foreach(string scpAccessDoor in scpAccessDoors)
                                    {
                                        if (ev.Door.Name == scpAccessDoor)
                                        {
                                            if (player.TeamRole.Team == Team.SCP)
                                            {
                                                ev.Allow = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            plugin.Error(x.Value + " is not a int.");
                        }
                    }
                }
            }
        }
    }
}
