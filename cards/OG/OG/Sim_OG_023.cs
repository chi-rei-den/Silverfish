using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_023",
  "name": [
    "原始融合",
    "Primal Fusion"
  ],
  "text": [
    "你每有一个图腾，就使一个随从获得+1/+1。",
    "Give a minion +1/+1 for each of your Totems."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38262
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_023 : SimTemplate //* Primal Fusion
    {
        //Give a minion +1/+1 for each of your Totems.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int gain = 0;
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            foreach (Minion m in temp)
            {
                if ((Race)m.handcard.card.Race == Race.TOTEM) gain++;
            }
            if (gain > 0) p.minionGetBuffed(target, gain, gain);
        }
    }
}