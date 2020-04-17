using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_855",
  "name": [
    "迪菲亚清道夫",
    "Defias Cleaner"
  ],
  "text": [
    "<b>战吼：</b><b>沉默</b>一个具有<b>亡语</b>的随从。",
    "<b>Battlecry:</b> <b>Silence</b> a minion with <b>Deathrattle</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40745
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_855 : SimCard //* Defias Cleaner
	{
		// Battlecry: Silence a minion with Deathrattle.
        
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetSilenced(target);
        }
    }
}