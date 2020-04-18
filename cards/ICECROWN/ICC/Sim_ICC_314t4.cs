using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314t4",
  "name": [
    "死亡之握",
    "Death Grip"
  ],
  "text": [
    "从你对手的牌库中偷取一张随从牌，并置入你的手牌。",
    "Steal a minion from your opponent's deck and add it to your hand."
  ],
  "cardClass": "DEATHKNIGHT",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 42590
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314t4 : SimTemplate //* Death Grip
    {
        // Steal a minion from your opponent's deck and add it to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                if (p.enemyDeckSize > 0)
                {
                    p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
                    p.enemyDeckSize--;
                }
            }
            else
            {
                if (p.ownDeckSize > 0)
                {
                    p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
                    p.ownDeckSize--;
                }
            }
        }
    }
}