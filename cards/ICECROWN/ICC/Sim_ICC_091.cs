using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_091",
  "name": [
    "亡者之牌",
    "Dead Man's Hand"
  ],
  "text": [
    "复制你的手牌并洗入你的牌库。",
    "Shuffle a copy of your hand into your deck."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42766
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_091: SimTemplate //* Dead Man's Hand
    {
        // Shuffle a copy of your hand into your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.ownDeckSize += p.owncards.Count;
            else p.enemyDeckSize += p.enemyAnzCards;
        }
    }
}