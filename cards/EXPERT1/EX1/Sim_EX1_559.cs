using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_559",
  "name": [
    "大法师安东尼达斯",
    "Archmage Antonidas"
  ],
  "text": [
    "每当你施放一个法术，将一张“火球术”法术牌置入你的手牌。",
    "Whenever you cast a spell, add a 'Fireball' spell to your hand."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1080
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_559 : SimTemplate //archmageantonidas
	{

//    erhaltet jedes mal einen „feuerball“-zauber auf eure hand, wenn ihr einen zauber wirkt.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.Type == CardType.SPELL)
            {
                p.drawACard(CardIds.Collectible.Mage.Fireball, wasOwnCard, true);
            }
        }
	}
}