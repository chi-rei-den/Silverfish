using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_836",
  "name": [
    "萨瓦丝女王",
    "Clutchmother Zavas"
  ],
  "text": [
    "每当你弃掉这张牌时，使其获得+2/+2，并重新置入你的手牌。",
    "Whenever you discard this, give it +2/+2 and return it to your hand."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 2,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41876
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_836 : SimTemplate //* Clutchmother Zavas
	{
		//Whenever you discard this, give it +2/+2 and return it to your hand.


        public override bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus)
        {
            if (checkBonus) return true;
			if (own != null) return false;

            p.drawACard(CardIds.Collectible.Warlock.ClutchmotherZavas, true, true);
            int i = p.owncards.Count - 1;
            p.owncards[i].addattack = hc.addattack +2;
            p.owncards[i].addHp = hc.addHp + 2;
            return true;
        }
    }
}