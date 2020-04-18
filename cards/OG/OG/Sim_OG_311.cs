using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_311",
  "name": [
    "黑暗曙光",
    "A Light in the Darkness"
  ],
  "text": [
    "<b>发现</b>一张随从牌。使其获得+1/+1。",
    "<b>Discover</b> a minion.\nGive it +1/+1."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38913
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_311 : SimTemplate //* A Light in the Darkness
    {
        //Discover a minion. Give it +1/+1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Neutral.LeperGnome, ownplay, true);
            p.owncards[p.owncards.Count - 1].addattack++;
            p.owncards[p.owncards.Count - 1].addHp++;
        }
    }
}