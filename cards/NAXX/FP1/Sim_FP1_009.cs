using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_009",
  "name": [
    "死亡领主",
    "Deathlord"
  ],
  "text": [
    "<b>嘲讽，亡语：</b>你的对手将一个随从从其牌库置入战场。",
    "<b>Taunt. Deathrattle:</b> Your opponent puts a minion from their deck into the battlefield."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1790
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_009 : SimTemplate //* deathlord
	{
        //Taunt. Deathrattle: Your opponent puts a minion from their deck into the battlefield.
        Chireiden.Silverfish.SimCard c = CardIds.Collectible.Mage.KirinTorMage;//kirintormage

        public override void onDeathrattle(Playfield p, Minion m)
        {
            int place = (m.own) ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(c, place, !m.own, false);
        }
	}
}