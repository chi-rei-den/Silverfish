using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_092",
  "name": [
    "王者祝福",
    "Blessing of Kings"
  ],
  "text": [
    "使一个随从获得+4/+4。<i>（+4攻击力/+4生命值）</i>",
    "Give a minion +4/+4. <i>(+4 Attack/+4 Health)</i>"
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 943
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_092 : SimCard//blessing of kings
    {

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 4, 4);
        }

    }
}
