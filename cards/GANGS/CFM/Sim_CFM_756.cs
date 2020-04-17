using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_756",
  "name": [
    "兽人铸甲师",
    "Alley Armorsmith"
  ],
  "text": [
    "<b>嘲讽</b>\n每当该随从造成伤害时，获得等量的护甲值。",
    "[x]<b>Taunt</b>\nWhenever this minion\ndeals damage, gain\nthat much Armor."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40574
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_756 : SimCard //* Alley Armorsmith
	{
        // Taunt. Whenever this minion deal damage, gain that much Armor.
        //done in triggerAMinionDealedDmg (Playfield)
	}
}