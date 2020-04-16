using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314t5",
  "name": [
    "凋零缠绕",
    "Death Coil"
  ],
  "text": [
    "对一个敌人造成$5点伤害，或为一个友方角色恢复#5点\n生命值。",
    "Deal $5 damage to an enemy, or restore #5 Health to a friendly character."
  ],
  "cardClass": "DEATHKNIGHT",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 45384
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314t5 : SimTemplate //* Death Coil
    {
        // Deal $5 damage to an enemy, or restore #5 Health to a friendly character.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = 0;
            if (target.own == ownplay) dmg = -1 * ((ownplay) ? p.getSpellHeal(5) : p.getEnemySpellHeal(5));
            else dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}