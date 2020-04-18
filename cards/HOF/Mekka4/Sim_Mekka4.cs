using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "Mekka4",
  "name": [
    "变鸡器",
    "Poultryizer"
  ],
  "text": [
    "在你的回合开始时，随机将一个随从变为1/1的小鸡。",
    "At the start of your turn, transform a random minion into a 1/1 Chicken."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "HOF",
  "collectible": null,
  "dbfId": 146
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_Mekka4 : SimTemplate //* poultryizer
	{
        Chireiden.Silverfish.SimCard c = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.Mekka4t);
                                
//    verwandelt zu beginn eures zuges einen zufälligen diener in ein huhn (1/1).

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
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
                    p.minionTransform(tm, c);
                    tm.playedThisTurn = false;
                    tm.Ready = true;
                }
            }
        }

      

	}
}