using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_688",
  "name": [
    "野猪骑士斯派克",
    "Spiked Hogrider"
  ],
  "text": [
    "<b>战吼：</b>如果一个敌方随从具有<b>嘲讽</b>，便获得<b>冲锋</b>。",
    "<b>Battlecry:</b> If an enemy minion has <b>Taunt</b>, gain <b>Charge</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40700
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_688 : SimTemplate //* Spiked Hogrider
	{
		// Battlecry: If an enemy minion has Taunt, gain Charge.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int anz = m.own ? p.anzEnemyTaunt : p.anzOwnTaunt;
            if (anz > 0) p.minionGetCharge(m);
        }
    }
}