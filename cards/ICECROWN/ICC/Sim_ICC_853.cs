using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_853",
  "name": [
    "瓦拉纳王子",
    "Prince Valanar"
  ],
  "text": [
    "<b>战吼：</b>如果你的牌库里没有法力值消耗为（4）的牌，则获得<b>吸血</b>和 <b>嘲讽</b>。",
    "<b>Battlecry:</b> If your deck has no 4-Cost cards, gain <b>Lifesteal</b> and <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45342
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_853: SimCard //* Prince Valanar
    {
        // Battlecry: If your deck has no 4-Cost cards, gain Lifesteal and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.getDeckCardsForCost(4) == CardDB.cardIDEnum.None)
            {
                own.lifesteal = true;
                own.taunt = true;
                p.anzOwnTaunt++;
            }
        }
    }
}