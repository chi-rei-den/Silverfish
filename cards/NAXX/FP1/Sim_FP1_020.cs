using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_020",
  "name": [
    "复仇",
    "Avenge"
  ],
  "text": [
    "<b>奥秘：</b>当你的随从死亡时，随机使一个友方随从获得+3/+2。",
    "<b>Secret:</b> When one of your minions dies, give a random friendly minion +3/+2."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1804
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_020 : SimTemplate //avenge
    {
        //todo secret
        //    geheimnis:/ wenn einer eurer diener stirbt, erhält ein zufälliger befreundeter diener +3/+2.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            var temp = new List<Minion>();


            if (ownplay)
            {
                var temp2 = new List<Minion>(p.ownMinions);
                temp2.Sort((a, b) => -a.Angr.CompareTo(b.Angr));
                temp.AddRange(temp2);
            }
            else
            {
                var temp2 = new List<Minion>(p.enemyMinions);
                temp2.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                temp.AddRange(temp2);
            }

            if (temp.Count >= 1)
            {
                if (ownplay)
                {
                    var trgt = temp[0];
                    if (temp.Count >= 2 && trgt.taunt && !temp[1].taunt)
                    {
                        trgt = temp[1];
                    }

                    p.minionGetBuffed(trgt, 3, 2);
                }
                else
                {
                    var trgt = temp[0];
                    if (temp.Count >= 2 && !trgt.taunt && temp[1].taunt)
                    {
                        trgt = temp[1];
                    }

                    p.minionGetBuffed(trgt, 3, 2);
                }
            }
        }
    }
}