using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_911",
  "name": [
    "哀泣女妖",
    "Keening Banshee"
  ],
  "text": [
    "每当你使用一张牌，便移除你的牌库顶的三张牌。",
    "Whenever you play a card, remove the top 3 cards of your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 46101
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_911: SimTemplate //* Keening Banshee
    {
        // Whenever you play a card, remove the top 3 cards of your deck.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard)
            {
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
}