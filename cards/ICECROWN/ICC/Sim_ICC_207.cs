using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_207",
  "name": [
    "吞噬意志",
    "Devour Mind"
  ],
  "text": [
    "复制你对手的牌库中的三张牌，并将其置入你的手牌。",
    "Copy 3 cards in your opponent's deck and add them to your hand."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 5,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42566
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_207: SimCard //* Devour Mind
    {
        // Copy 3 cards in your opponent's deck and add them to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
        }
    }
}