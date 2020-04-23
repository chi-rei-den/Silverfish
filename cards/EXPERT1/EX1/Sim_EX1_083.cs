using System.Collections.Generic;
using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_083",
  "name": [
    "工匠大师欧沃斯巴克",
    "Tinkmaster Overspark"
  ],
  "text": [
    "<b>战吼：</b>\n随机使另一个随从变形成为一个5/5的魔暴龙或一个1/1的松鼠。",
    "[x]<b>Battlecry:</b> Transform\nanother random minion\ninto a 5/5 Devilsaur\n or a 1/1 Squirrel."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 570
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_083 : SimTemplate //tinkmasteroverspark
    {
        SimCard card1 = CardIds.NonCollectible.Neutral.Devilsaur; // rex

        SimCard card2 = CardIds.NonCollectible.Neutral.Squirrel; // squirrel

        //todo better
//    kampfschrei:/ verwandelt einen anderen zufälligen diener in einen teufelssaurier (5/5) oder ein eichhörnchen (1/1).
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var oc = p.ownMinions.Count;
            var ec = p.enemyMinions.Count;
            if (oc == 0 && ec == 0)
            {
                return;
            }

            if (oc > ec)
            {
                var temp = new List<Minion>(p.ownMinions);
                temp.AddRange(p.enemyMinions);
                temp.Sort((a, b) => a.Hp.CompareTo(b.Hp)); //transform the weakest
                foreach (var m in temp)
                {
                    p.minionTransform(m, this.card1);
                    break;
                }
            }
            else
            {
                var temp = new List<Minion>(p.ownMinions);
                temp.AddRange(p.enemyMinions);
                temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp)); //transform the strongest
                foreach (var m in temp)
                {
                    p.minionTransform(m, this.card2);
                    break;
                }
            }
        }
    }
}