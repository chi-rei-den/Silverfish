using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_940",
  "name": [
    "盛气凌人",
    "I Know a Guy"
  ],
  "text": [
    "<b>发现</b>一个具有<b>嘲讽</b>的随从。",
    "<b>Discover</b> a <b>Taunt</b> minion."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40839
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_940 : SimCard //* I Know a Guy
	{
		// Discover a Taunt minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.pompousthespian, ownplay, true);
        }
    }
}