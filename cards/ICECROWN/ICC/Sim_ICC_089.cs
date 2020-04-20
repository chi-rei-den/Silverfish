using Chireiden.Silverfish;
using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_089",
  "name": [
    "冰钓术",
    "Ice Fishing"
  ],
  "text": [
    "从你的牌库中抽两张鱼人牌。",
    "Draw 2 Murlocs from your deck."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42763
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_089: SimTemplate //* Ice Fishing
    {
        // Draw 2 Murlocs from your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                SimCard c;
                int count = 0;
                foreach (KeyValuePair<SimCard, int> cid in p.prozis.turnDeck)
                {
                    c = (cid.Key);
                    if ((Race)c.Race == Race.MURLOC)
                    {
                        for (int i = 0; i < cid.Value; i++)
                        {
                            p.drawACard(cid.Key, ownplay);
                            count++;
                            if (count > 1) break;
                        }
                        if (count > 1) break;
                    }
                }
            }
            else
            {
                p.drawACard(SimCard.None, ownplay);
                p.drawACard(SimCard.None, ownplay);
            }
        }
    }
}