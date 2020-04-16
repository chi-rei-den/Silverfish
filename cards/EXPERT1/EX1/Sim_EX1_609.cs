using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_609",
  "name": [
    "狙击",
    "Snipe"
  ],
  "text": [
    "<b>奥秘：</b>在你的对手使用一张随从牌后，对该随从造成$4点伤害。",
    "<b>Secret:</b> After your opponent plays a minion, deal $4 damage to it."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 814
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_609 : SimTemplate //snipe
	{
        //todo secret
//    geheimnis:/ wenn euer gegner einen diener ausspielt, werden diesem $4 schaden zugefügt.

        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);

            p.minionGetDamageOrHeal(target, dmg);
        }

	}

}
