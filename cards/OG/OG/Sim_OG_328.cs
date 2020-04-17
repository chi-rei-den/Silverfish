using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_328",
  "name": [
    "异变之主",
    "Master of Evolution"
  ],
  "text": [
    "<b>战吼：</b>将一个友方随从随机变形成为一个法力值消耗增加（1）点的随从。",
    "<b>Battlecry:</b> Transform a friendly minion into a random one that costs (1) more."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 39008
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_328 : SimCard //* Master of Evolution
    {
        //Battlecry: Transform a friendly minion into a random one that costs (1) more.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if(target == null) return;
            p.minionTransform(target, p.getRandomCardForManaMinion(target.handcard.card.cost + 1));
        }
    }
}