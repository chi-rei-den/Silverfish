using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_281",
  "name": [
    "灵魂洪炉",
    "Forge of Souls"
  ],
  "text": [
    "从你的牌库中抽两张武器牌。",
    "Draw 2 weapons from your deck."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42998
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_281: SimTemplate //* Forge of Souls
    {
        // Draw 2 weapons from your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Warrior.FieryWarAxe, ownplay);
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
        }
    }
}