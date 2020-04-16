using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_094",
  "name": [
    "火焰杂耍者",
    "Flame Juggler"
  ],
  "text": [
    "<b>战吼：</b>随机对一个敌人造成1点伤害。",
    "<b>Battlecry:</b> Deal 1 damage to a random enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2580
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_094 : SimTemplate //* Flame Juggler
	{
		//Deal 1 damage to a random enemy.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                target = p.getEnemyCharTargetForRandomSingleDamage(1);
            }
            else
            {
                target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); //damage the Highest (pessimistic)
                if (target == null) target = p.ownHero;
            }
            p.minionGetDamageOrHeal(target, 1);
        }
    }
}