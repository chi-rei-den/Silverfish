using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_023",
  "name": [
    "黑暗教徒",
    "Dark Cultist"
  ],
  "text": [
    "<b>亡语：</b>\n随机使一个友方随从获得+3生命值。",
    "<b>Deathrattle:</b> Give a random friendly minion +3 Health."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1807
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_023 : SimCard// dark cultist
    {
        //todo list
        public override void onDeathrattle(Playfield p, Minion m)
        {
            List<Minion> temp = new List<Minion>();

            if (m.own)
            {
                List<Minion> temp2 = new List<Minion>(p.ownMinions);
                temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                temp.AddRange(temp2);
            }
            else
            {
                List<Minion> temp2 = new List<Minion>(p.enemyMinions);
                temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                temp.AddRange(temp2);
            }

            if (temp.Count >= 1)
            {
                if (m.own)
                {
                    Minion target = temp[0];
                    if (temp.Count >= 2 && target.taunt && !temp[1].taunt) target = temp[1];
                    p.minionGetBuffed(target, 0, 3);
                }
                else
                {

                    Minion target = temp[0];
                    if (temp.Count >= 2 && !target.taunt && temp[1].taunt) target = temp[1];
                    p.minionGetBuffed(target, 0, 3);
                }
            }

        }
        

            
    }
}
