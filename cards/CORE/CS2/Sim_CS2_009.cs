using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_009",
  "name": [
    "野性印记",
    "Mark of the Wild"
  ],
  "text": [
    "使一个随从获得<b>嘲讽</b>和+2/+2。<i>（+2攻击力/+2生命值）</i>",
    "Give a minion <b>Taunt</b> and +2/+2.<i>\n(+2 Attack/+2 Health)</i>"
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 213
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_009 : SimCard //* Mark of the Wild
    {
        //Give a minion Taunt and +2/+2. (+2 Attack/+2 Health)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 2);
            if (!target.taunt)
            {
                target.taunt = true;
                if (target.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
    }
}
