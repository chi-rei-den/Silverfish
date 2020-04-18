using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_235",
  "name": [
    "暗影精华",
    "Shadow Essence"
  ],
  "text": [
    "随机挑选你牌库里的一个随从，召唤一个5/5的复制。",
    "Summon a 5/5 copy of a random minion in your deck."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42804
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_235 : SimTemplate //* Shadow Essence
    {
        // Summon a 5/5 copy of a random minion in your deck.

        Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_014); //King Mukla 5/5

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
        }
    }
}