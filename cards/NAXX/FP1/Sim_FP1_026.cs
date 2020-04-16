using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_026",
  "name": [
    "阿努巴尔伏击者",
    "Anub'ar Ambusher"
  ],
  "text": [
    "<b>亡语：</b>\n随机将一个友方随从移回你的手牌。",
    "<b>Deathrattle:</b> Return a random friendly minion to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1810
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_026 : SimTemplate //anubarambusher
	{

//    todesröcheln:/ lasst einen zufälligen befreundeten diener auf eure hand zurückkehren.

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
                    Minion target = new Minion();
                    target = temp[0];
                    if (temp.Count >= 2 && !target.taunt && temp[1].taunt) target = temp[1];
                    p.minionReturnToHand(target, m.own, 0);
                }
                else
                {
                    Minion target = new Minion();

                    target = temp[0];
                    if (temp.Count >= 2 && target.taunt && !temp[1].taunt) target = temp[1];
                    p.minionReturnToHand(target, m.own, 0);
                }
            }
        }

	}
}