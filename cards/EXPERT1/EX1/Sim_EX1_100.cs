using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_100",
  "name": [
    "游学者周卓",
    "Lorewalker Cho"
  ],
  "text": [
    "每当一个玩家施放一个法术，复制该法术，将其置入另一个玩家的手牌。",
    "Whenever a player casts a spell, put a copy into the other player’s hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1135
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_100 : SimTemplate //lorewalkercho
	{

//    wenn ein spieler einen zauber wirkt, erhält der andere spieler eine kopie desselben auf seine hand.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (hc.card.Type == CardType.SPELL)
            {
                p.drawACard(hc.card.CardId, !wasOwnCard, true);
            }
        }

	}
}