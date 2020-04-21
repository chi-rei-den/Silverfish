using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ULD_240",
  "name": [
    "对空奥术法师",
    "Arcane Flakmage"
  ],
  "text": [
    "在你使用一张<b>奥秘</b>牌后，对所有敌方随从造成2点伤害。",
    "After you play a <b>Secret</b>, deal 2 damage to all enemy minions."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "ULDUM",
  "collectible": true,
  "dbfId": 53822
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ULD_240 : SimTemplate //* 对空奥术法师 Arcane Flakmage
    {
        //After you play a <b>Secret</b>, deal 2 damage to all enemy minions.
        //在你使用一张<b>奥秘</b>牌后，对所有敌方随从造成2点伤害。
        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool ownplay, Minion m)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
    
            if (m.own == ownplay && hc.card.Secret) p.allMinionOfASideGetDamage(!ownplay, dmg, true);

        }
    }
}