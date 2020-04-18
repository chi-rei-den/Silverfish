using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_003",
  "name": [
    "心灵视界",
    "Mind Vision"
  ],
  "text": [
    "随机复制对手手牌中的一张牌，将其置入你的手牌。",
    "Put a copy of a random card in your opponent's hand into your hand."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1099
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_003 : SimTemplate//Mind Vision
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int anz = (ownplay) ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 1)
            {
                p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay,true);
            }
        }

    }
}
