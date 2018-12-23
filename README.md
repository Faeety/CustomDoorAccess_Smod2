# CustomDoorAccess

Config Setting | Value Type | Default Value | Description
--- | --- | --- | ---
cda_access_set | Dictionary | Empty | **DOORID:ITEMID&ITEMID,DOORID:ITEMID&ITEMID** Gives access to the door with the item(s) that you set.
cda_revoke_all | Bool | false | Revoke the access to all the others cards or not.
cda_scp_access | Bool | false | Allow SCPs to open doors that you set with cda_scp_access_doors.
cda_scp_access_doors | List | Empty | Set the doors that SCPs can open.
cda_enable | Bool | true | Enable/Disable Plugin.

```
Exemple : cda_access_set: 012:1&2,173:1&2

012 and 173 door are only openeable with a Scientist Card, a Major Scientist Card or the Default Cards => if you set revoke_all to false.
```

**Some doors need cda_revoke_all to work because they don't need keycards by default!**
```
Exemple : ESCAPE
```

### Doors List

Doors ID | Room/Door
--- | ---
012 | SCP-012
012_BOTTOM | SCP-012 CONTAINEMENT DOOR
049_ARMORY | SCP-049 ARMORY DOOR
079_FIRST | SCP-079 FIRST BIG DOOR
079_SECOND | SCP-079 SECOND BIG DOOR
096 | SCP-096 CONTAINEMENT DOOR
106_BOTTOM | SCP-106 BOTTOM DOOR
106_PRIMARY | SCP-106 LEFT DOOR
106_SECONDARY | SCP-106 RIGHT DOOR
173 | SCP-173 CONTAINEMENT DOOR
173_ARMORY | SCP-173 ARMORY
372 | SCP-372 CONTAINEMENT DOOR
914 | SCP-914 CONTAINEMENT DOOR
CHECKPOINT_ENT | ENTRANCE CHECKPOINT
CHECKPOINT_LCZ_A | LCZ A CHECKPOINT
CHECKPOINT_LCZ_B | LCZ B CHECKPOINT
ESCAPE | DOOR NEAR THE MTF SPAWN BEFORE ESCAPE
ESCAPE_INNER | SECOND DOOR NEAR THE SPAWN BEFORE ESCAPE
GATE_A | GATE A DOOR
GATE_B | GATE B DOOR
HCZ_ARMORY | HCZ ARMORY
HID | HID DOOR
HID_LEFT | HID LEFT DOOR
HID_RIGHT | HID RIGHT DOOR
INTERCOM | INTERCOM DOOR
LCZ_ARMORY | LCZ ARMORY DOOR
NUKE_ARMORY | NUKE ARMORY DOOR
NUKE_SURFACE | NUKE TOPSITE DOOR
SURFACE_GATE | DOOR BETWEEN MTF/CHAOS
