using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_117",
  "name": [
    "加兹鲁维",
    "Gazlowe"
  ],
  "text": [
    "每当你施放一个法力值消耗为（1）的法术，随机将一张机械牌置入你的手牌。",
    "Whenever you cast a 1-Cost spell, add a random Mech to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2085
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_117 : SimTemplate //* Gazlowe
    {

        //   Whenever you cast a 1-mana spell, add a random Mech to your hand.
        //(we have to use current cost)

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
                if (hc.card.type == CardDB.cardtype.SPELL && hc.manacost == 1)
                {
                    p.drawACard(CardDB.cardName.shieldedminibot, wasOwnCard, true);
                }
            }
        }
    }
}