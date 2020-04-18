using System;
using System.Collections.Generic;
using System.Text;

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
        Chireiden.Silverfish.SimCard card1 = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_tk29); // rex
        Chireiden.Silverfish.SimCard card2 = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_tk28); // squirrel
        //todo better
//    kampfschrei:/ verwandelt einen anderen zufälligen diener in einen teufelssaurier (5/5) oder ein eichhörnchen (1/1).
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int oc = p.ownMinions.Count;
            int ec = p.enemyMinions.Count;
            if (oc == 0 && ec == 0) return;
            if (oc > ec)
            {
                List<Minion> temp = new List<Minion>(p.ownMinions);
                temp.AddRange(p.enemyMinions);
                temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));//transform the weakest
                foreach (Minion m in temp)
                {
                    p.minionTransform(m, card1);
                    break;
                }
            }
            else
            {
                List<Minion> temp = new List<Minion>(p.ownMinions);
                temp.AddRange(p.enemyMinions);
                temp.Sort((a, b) => -a.Hp.CompareTo(b.Hp));//transform the strongest
                foreach (Minion m in temp)
                {
                    p.minionTransform(m, card2);
                    break;
                }
            }
		}


	}
}