using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_298",
  "name": [
    "炎魔之王拉格纳罗斯",
    "Ragnaros the Firelord"
  ],
  "text": [
    "无法攻击。在你的回合结束时，随机对一个敌人造成8点伤害。",
    "Can't attack. At the end of your turn, deal 8 damage to a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "HOF",
  "collectible": true,
  "dbfId": 374
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_298 : SimCard //* Ragnaros the Firelord
    {
        // Can't Attack. At the end of your turn, deal 8 damage to a random enemy.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                Minion target = null;

                if (turnEndOfOwner)
                {
                    target = p.getEnemyCharTargetForRandomSingleDamage(8);
                }
                else
                {
                    target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
                    if (target == null) target = p.ownHero;
                }
                p.minionGetDamageOrHeal(target, 8, true);
                triggerEffectMinion.stealth = false;
            }
        }
    }
}