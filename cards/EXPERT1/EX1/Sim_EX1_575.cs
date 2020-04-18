using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_575",
  "name": [
    "法力之潮图腾",
    "Mana Tide Totem"
  ],
  "text": [
    "在你的回合结束时，抽一张牌。",
    "At the end of your turn, draw a card."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 513
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_575 : SimTemplate //manatidetotem
	{

//    zieht am ende eures zuges eine karte.
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                p.drawACard(Chireiden.Silverfish.SimCard.None, turnEndOfOwner);
            }
        }

	}
}