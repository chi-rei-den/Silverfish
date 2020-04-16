using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_116",
  "name": [
    "狂乱传染",
    "Spreading Madness"
  ],
  "text": [
    "造成$9点伤害，随机分配到所有角色身上。",
    "Deal $9 damage randomly split among ALL characters."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38456
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_116 : SimTemplate //* Spreading Madness
	{
		//Deal 9 damage randomly split among ALL characters.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = new List<Minion>(p.enemyMinions);
            temp.AddRange(p.ownMinions);
            temp.Sort((a, b) => a.Hp.CompareTo(b.Hp)); //destroys the weakest first
            int times = (ownplay) ? p.getSpellDamageDamage(9) : p.getEnemySpellDamageDamage(9);

            for (int i = 0; i < times; i++)
            {
                for (int j = 0; j < temp.Count; j++)
                {
                    p.minionGetDamageOrHeal(temp[j], 1);
                    i++;
                    if (i >= times) break;
                }
                p.minionGetDamageOrHeal(p.enemyHero, 1);
                p.minionGetDamageOrHeal(p.ownHero, 1);
                i++;
            }
        }
    }
}