using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_623",
  "name": [
    "强能奥术飞弹",
    "Greater Arcane Missiles"
  ],
  "text": [
    "随机对敌人发射三枚飞弹，每枚飞弹造成$3点伤害。",
    "Shoot three missiles at random enemies that deal $3 damage each."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 7,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40411
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_623 : SimTemplate //* Greater Arcane Missiles
	{
		// Shoot three missiles at random enemies that deal 3 damage each.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int times = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);

            while (times > 0)
            {
                if (ownplay) target = p.getEnemyCharTargetForRandomSingleDamage(3);
                else
                {
                    target = p.searchRandomMinion(p.ownMinions, SearchMode.HighAttack); //damage the Highest (pessimistic)
                    if (target == null) target = p.ownHero;
                }
                p.minionGetDamageOrHeal(target, 3);
                times--;
            }
        }
    }
}