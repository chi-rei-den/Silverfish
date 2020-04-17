using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_657",
  "name": [
    "暗金教窃歌者",
    "Kabal Songstealer"
  ],
  "text": [
    "<b>战吼：</b>\n<b>沉默</b>一个随从。",
    "[x]<b>Battlecry:</b> <b>Silence</b> a minion."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40929
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_657 : SimCard //* Kabal Songstealer
	{
		// Battlecry: Silence a minion.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null) p.minionGetSilenced(target);
        }
    }
}