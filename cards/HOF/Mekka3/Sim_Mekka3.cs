using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "Mekka3",
  "name": [
    "壮胆机器人3000型",
    "Emboldener 3000"
  ],
  "text": [
    "在你的回合结束时，随机使一个随从获得+1/+1。",
    "At the end of your turn, give a random minion +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "HOF",
  "collectible": null,
  "dbfId": 52
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_Mekka3 : SimCard //emboldener3000
	{

//    verleiht am ende eures zuges einem zufälligen diener +1/+1.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                Minion tm = null;
                int ges = 1000;
                foreach (Minion m in p.ownMinions)
                {
                    if (m.Angr + m.Hp < ges)
                    {
                        tm = m;
                        ges = m.Angr + m.Hp;
                    }
                }
                foreach (Minion m in p.enemyMinions)
                {
                    if (m.Angr + m.Hp < ges)
                    {
                        tm = m;
                        ges = m.Angr + m.Hp;
                    }
                }
                if (ges <= 999)
                {
                    p.minionGetBuffed(tm, 1, 1);
                }
            }
        }

	}
}