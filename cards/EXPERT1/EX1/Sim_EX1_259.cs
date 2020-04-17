using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_259",
  "name": [
    "闪电风暴",
    "Lightning Storm"
  ],
  "text": [
    "对所有敌方随从造成$2到$3点伤害，<b>过载：</b>（2）",
    "Deal $2-$3 damage to all enemy minions. <b>Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 629
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_259 : SimCard//Lightning Storm
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
            if (ownplay) p.ueberladung += 2;
        }

    }
}
