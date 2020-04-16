using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_690",
  "name": [
    "青玉飞镖",
    "Jade Shuriken"
  ],
  "text": [
    "造成$2点伤害。\n<b>连击：</b>召唤一个{0}的<b>青玉魔像</b>。",
    "Deal $2 damage.\n<b>Combo:</b> Summon a{1} {0} <b>Jade Golem</b>."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40698
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_690 : SimTemplate //* Jade Shuriken
	{
        // Deal 2 damage. Combo: Summon a Jade Golem.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);

            if (p.cardsPlayedThisTurn > 0)
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(p.getNextJadeGolem(ownplay), pos, ownplay);
            }
        }
    }
}