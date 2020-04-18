using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_029",
  "name": [
    "先祖召唤",
    "Ancestor's Call"
  ],
  "text": [
    "每个玩家从手牌中随机将一个随从置入战场。",
    "Put a random minion from each player's hand into the battlefield."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1998
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_029 : SimTemplate //* Ancestor's Call
    {

        //    Put a random minion from each player's hand into the battlefield.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            Handmanager.Handcard c = null;
            int sum = 10000;
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.type == Chireiden.Silverfish.SimCardtype.MOB)
                {
                    int s = hc.card.Health + hc.card.Attack + ((hc.card.Taunt) ? 1 : 0) + ((hc.card.DivineShield) ? 1 : 0);
                    if (s < sum)
                    {
                        c = hc;
                        sum = s;
                    }
                }
            }
            if (sum < 9999)
            {
                p.callKid(c.card, p.ownMinions.Count, true, false);
                p.removeCard(c);
                p.triggerCardsChanged(true);
            }

            if (p.enemyAnzCards >= 2)
            {
                p.callKid(c.card, p.enemyMinions.Count, false, false);
                p.enemyAnzCards--;
                p.triggerCardsChanged(false);
            }
        }
    }
}