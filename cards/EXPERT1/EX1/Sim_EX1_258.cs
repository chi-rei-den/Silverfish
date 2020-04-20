using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_258",
  "name": [
    "无羁元素",
    "Unbound Elemental"
  ],
  "text": [
    "每当你使用一张具有<b>过载</b>的牌，便获得+1/+1。",
    "Whenever you play a card with <b>Overload</b>, gain +1/+1."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 774
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_258 : SimTemplate//Unbound Elemental
    {
        // erhält jedes Mal +1/+1, wenn Ihr eine Karte mit uberladung&lt; ausspielt.
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.Overload > 0)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 1);
            }
        }

    }
}
