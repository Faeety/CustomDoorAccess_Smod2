using Smod2;
using Smod2.API;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CustomDoorAccess
{
    class EventHandler : IEventHandlerDoorAccess
    {
        Plugin plugin;

        public EventHandler(Plugin plugin)
        {
            this.plugin = plugin;
        }

        Dictionary<string, string> access = ConfigManager.Manager.Config.GetDictValue("cda_access_set");
        bool revokeAll = ConfigManager.Manager.Config.GetBoolValue("cda_revoke_all", false);

        public void OnDoorAccess(PlayerDoorAccessEvent ev)
        {
            Player player = ev.Player;
            foreach (KeyValuePair<string, string> x in access)
            {
                if(ev.Door.Name == x.Key)
                {
                    int itemID;
                    if (Int32.TryParse(x.Value, out itemID))
                    {
                        if (player.GetCurrentItemIndex().Equals(itemID) && !player.GetCurrentItemIndex().Equals(-1))
                        {
                            ev.Allow = true;
                        }
                        else if (revokeAll)
                        {
                            ev.Allow = false;
                        }
                    }
                    else
                    {
                        plugin.Info("There was a problem with the ItemID");
                    }
                }
            }
        }
    }
}
