using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_132",
  "name": [
    "以眼还眼",
    "Eye for an Eye"
  ],
  "text": [
    "<b>奥秘：</b>\n当你的英雄受到伤害时，对敌方英雄造成等量伤害。",
    "<b>Secret:</b> When your hero takes damage, deal that much damage to the enemy hero."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 462
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_132 : SimCard //eyeforaneye
    {
        //todo secret
        //    geheimnis:/ wenn euer held schaden erleidet, wird dem feindlichen helden ebenso viel schaden zugefügt.
        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(number) : p.getEnemySpellDamageDamage(number);

            p.minionGetDamageOrHeal(ownplay ? p.enemyHero : p.ownHero, dmg);
        }

    }

}