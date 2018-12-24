using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoorAccess
{
    class EventHandler : IEventHandlerDoorAccess, IEventHandlerWaitingForPlayers, IEventHandlerRoundStart
    {
        public Dictionary<string,string> access;
        public bool revokeAll;
        public bool scpAccess;
        public string[] scpAccessDoors;

        private Plugin plugin;

        public EventHandler(Plugin plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            access = ConfigManager.Manager.Config.GetDictValue("cda_access_set");
            revokeAll = ConfigManager.Manager.Config.GetBoolValue("cda_revoke_all", false);
            scpAccess = ConfigManager.Manager.Config.GetBoolValue("cda_scp_access", false);
            scpAccessDoors = ConfigManager.Manager.Config.GetListValue("cda_scp_access_doors", new string[] { string.Empty }, false);
        }

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
            if (!ConfigManager.Manager.Config.GetBoolValue("cda_enable", true, false)) plugin.pluginManager.DisablePlugin(plugin);
        }

        public void OnDoorAccess(PlayerDoorAccessEvent ev)
        {
            Player player = ev.Player;
            foreach (KeyValuePair<string, string> x in access)
            {
                if (ev.Door.Name == x.Key)
                {
                    string trimmedValue = x.Value.Trim();
                    string[] itemIDs = trimmedValue.Split('&');

                    foreach (string eachValue in itemIDs)
                    {
                        int currentItem = player.GetCurrentItemIndex();
                        if (Int32.TryParse(eachValue, out int itemID))
                        {
                            if (player.GetCurrentItemIndex().Equals(itemID) && !player.GetCurrentItemIndex().Equals(-1))
                            {
                                ev.Allow = true;
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
