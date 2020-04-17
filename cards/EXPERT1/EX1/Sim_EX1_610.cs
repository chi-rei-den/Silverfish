using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_610",
  "name": [
    "爆炸陷阱",
    "Explosive Trap"
  ],
  "text": [
    "<b>奥秘：</b>当你的英雄受到攻击，对所有敌人造成$2点伤害。",
    "<b>Secret:</b> When your hero is attacked, deal $2 damage to all enemies."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 585
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_610 : SimCard //explosivetrap
	{
        //todo secret
//    geheimnis:/ wenn euer held angegriffen wird, erleiden alle feinde $2 schaden.
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
        }

	}

}