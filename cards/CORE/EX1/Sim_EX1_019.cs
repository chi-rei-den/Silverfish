using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_019",
  "name": [
    "破碎残阳祭司",
    "Shattered Sun Cleric"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得+1/+1。",
    "<b>Battlecry:</b> Give a friendly minion +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 608
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_019 : SimCard //shatteredsuncleric
    {

        //    kampfschrei:/ verleiht einem befreundeten diener +1/+1.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 1);
        }


    }
}