using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_016",
  "name": [
    "魔能机甲",
    "Fel Reaver"
  ],
  "text": [
    "每当你的对手使用一张卡牌时，便移除你的牌库顶的三张牌。",
    "Whenever your opponent plays a card, remove the top 3 cards of your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1982
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_016 : SimCard //Fel Reaver
    {

        //    Whenever your opponent plays a card, discard the top 3 cards of your deck.

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own) return; //owner of card = owner of minion -> no effect

            if (triggerEffectMinion.own)
            {
                p.ownDeckSize = Math.Max(0, p.ownDeckSize - 3);
            }
            else
            {
                p.enemyDeckSize = Math.Max(0, p.enemyDeckSize - 3);
            }
        }


    }

}