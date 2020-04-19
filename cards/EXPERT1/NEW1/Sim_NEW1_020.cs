using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_020",
  "name": [
    "狂野炎术师",
    "Wild Pyromancer"
  ],
  "text": [
    "在你施放一个法术后，对所有随从造成1点伤害。",
    "After you cast a spell, deal 1 damage to ALL minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1014
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NEW1_020 : SimTemplate //* Wild Pyromancer
	{
		// After you cast a spell, deal 1 damage to ALL minions.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.Type == CardType.SPELL) p.allMinionsGetDamage(1);
        }
	}
}