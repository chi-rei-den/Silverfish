using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_059",
  "name": [
    "鲜血小鬼",
    "Blood Imp"
  ],
  "text": [
    "<b>潜行</b>\n在你的回合结束时，随机使另一个友方随从获得+1生命值。",
    "[x]  <b>Stealth</b>. At the end of your  \nturn, give another random\n friendly minion +1 Health."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 469
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_059 : SimTemplate //* Blood Imp
	{
        // Stealth. At the end of your turn, give another random friendly minion +1 Health.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                List<Minion> tmp = turnEndOfOwner ? p.ownMinions : p.enemyMinions;
                int count = tmp.Count;
                if (count > 1)
                {
                    Minion mnn = null;
                    if (triggerEffectMinion.entitiyID != tmp[0].entitiyID) mnn = tmp[0];
                    else mnn = tmp[1];

                    for (int i = 1; i < count; i++)
                    {
                        if (triggerEffectMinion.entitiyID == tmp[i].entitiyID) continue;
                        if (tmp[i].Hp < mnn.Hp) mnn = tmp[i]; //take the weakest
                    }
                    if (mnn != null) p.minionGetBuffed(mnn, 0, 1);
                }
            }
        }
	}
}