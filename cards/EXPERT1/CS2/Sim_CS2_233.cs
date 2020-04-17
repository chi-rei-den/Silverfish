using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_233",
  "name": [
    "剑刃乱舞",
    "Blade Flurry"
  ],
  "text": [
    "摧毁你的武器，对所有敌方随从\n造成等同于其攻击力的伤害。",
    "Destroy your weapon and deal its damage to all enemy minions."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1064
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_233 : SimCard //* Blade Flurry
    {
        //Destroy your weapon and deal its damage to all enemy minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int damage = (ownplay) ? p.getSpellDamageDamage(p.ownWeapon.Angr) : p.getEnemySpellDamageDamage(p.enemyWeapon.Angr);

            p.allMinionOfASideGetDamage(!ownplay, damage);
            //destroy own weapon
            p.lowerWeaponDurability(1000, true);
        }
    }
}
