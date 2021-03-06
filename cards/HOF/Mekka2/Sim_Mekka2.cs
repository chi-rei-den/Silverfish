

/* _BEGIN_TEMPLATE_
{
  "id": "Mekka2",
  "name": [
    "修理机器人",
    "Repair Bot"
  ],
  "text": [
    "在你的回合结束时，为一个受伤的角色恢复#6点生命值。",
    "At the end of your turn, restore #6 Health to a damaged character."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "HOF",
  "collectible": null,
  "dbfId": 329
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_Mekka2 : SimTemplate //repairbot
    {
        //    stellt am ende eures zuges bei einem verletzten charakter 6 leben wieder her.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                Minion tm = null;
                var hl = triggerEffectMinion.own ? p.getMinionHeal(6) : p.getEnemyMinionHeal(6);
                var heal = 0;
                foreach (var m in p.ownMinions)
                {
                    if (m.maxHp - m.Hp > heal)
                    {
                        tm = m;
                        heal = m.maxHp - m.Hp;
                    }
                }

                foreach (var m in p.enemyMinions)
                {
                    if (m.maxHp - m.Hp > heal)
                    {
                        tm = m;
                        heal = m.maxHp - m.Hp;
                    }
                }

                if (heal >= 1)
                {
                    p.minionGetDamageOrHeal(tm, -hl);
                }
                else
                {
                    p.minionGetDamageOrHeal(p.ownHero.Hp < 30 ? p.ownHero : p.enemyHero, -hl);
                }
            }
        }
    }
}