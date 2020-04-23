using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_026",
  "name": [
    "假死",
    "Feign Death"
  ],
  "text": [
    "触发所有友方随从的<b>亡语</b>。",
    "Trigger all <b>Deathrattles</b> on your minions."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1991
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_026 : SimTemplate //Feign Death
    {
        //   Trigger all Deathrattles on your minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.doDeathrattles(new List<Minion>(p.ownMinions));
            }
            else
            {
                p.doDeathrattles(new List<Minion>(p.enemyMinions));
            }
        }
    }
}