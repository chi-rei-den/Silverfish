using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_086",
  "name": [
    "巨型蟒蛇",
    "Giant Anaconda"
  ],
  "text": [
    "<b>亡语：</b>从你手牌中召唤一个攻击力大于或等于5的随从。",
    "<b>Deathrattle:</b> Summon a minion from your hand with 5 or more Attack."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 7,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41262
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_086 : SimTemplate //* Giant Anaconda
	{
		//Deathrattle: Summon a minion from your hand with 5 or more Attack.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own)
            {
                foreach (Handcard hc in p.owncards)
                {
					if (hc.card.Attack + hc.addattack >= 5)
                    {
                        p.callKid(hc.card, p.owncards.Count, m.own);
						p.removeCard(hc);
                        break;
                    }
                }
            }
            else p.callKid(CardIds.Collectible.Neutral.SeaGiant, p.enemyMinions.Count, m.own);
        }
	}
}