using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_707",
  "name": [
    "青玉闪电",
    "Jade Lightning"
  ],
  "text": [
    "造成$4点伤害，召唤一个{0}的<b>青玉魔像</b>。",
    "Deal $4 damage. Summon a{1} {0} <b>Jade Golem</b>."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40455
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_707 : SimCard //* Jade Lightning
	{
		// Deal 4 damage. Summon a Jade Golem.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (target != null)
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(4) : p.getEnemySpellDamageDamage(4);
                p.minionGetDamageOrHeal(target, dmg);
            }

            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getNextJadeGolem(ownplay), pos, ownplay);
        }
    }
}