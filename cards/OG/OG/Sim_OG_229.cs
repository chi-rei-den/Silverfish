using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_229",
  "name": [
    "光耀之主拉格纳罗斯",
    "Ragnaros, Lightlord"
  ],
  "text": [
    "在你的回合结束时，为一个受伤的友方角色恢复#8点生命值。",
    "At the end of your turn, restore #8 Health to a damaged friendly character."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38758
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_229 : SimTemplate //* Ragnaros, Lightlord
    {
        //At the end of your turn, restore 8 health to a damaged friendly character.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int heal = (turnEndOfOwner) ? p.getMinionHeal(8) : p.getEnemyMinionHeal(8);
                List<Minion> temp = (turnEndOfOwner) ? p.ownMinions : p.enemyMinions;
                if (temp.Count >= 1)
                {
                    bool healed = false;
                    foreach (Minion m in temp)
                    {
                        if (m.wounded)
                        {
                            p.minionGetDamageOrHeal(m, -heal);
                            healed = true;
                            break;
                        }
                    }

                    if (!healed)
                    {
                        p.minionGetDamageOrHeal(turnEndOfOwner ? p.ownHero : p.enemyHero, -heal);
                    }
                }
                else
                {
                    p.minionGetDamageOrHeal(turnEndOfOwner ? p.ownHero : p.enemyHero, -heal);
                }
            }
        }
    }
}