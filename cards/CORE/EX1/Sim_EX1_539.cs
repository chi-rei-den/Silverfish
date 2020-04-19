using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_539",
  "name": [
    "杀戮命令",
    "Kill Command"
  ],
  "text": [
    "造成$3点伤害。如果你控制一个野兽，则改为造成\n$5点伤害。",
    "Deal $3 damage. If you control a Beast, deal\n$5 damage instead."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 296
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_539 : SimTemplate //killcommand
	{

//    verursacht $3 schaden. verursacht stattdessen $5 schaden, wenn ihr ein wildtier besitzt.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                bool haspet = false;
                foreach (Minion m in p.ownMinions)
                {
                    if ((Race)m.handcard.card.Race == Race.PET)
                    {
                        haspet = true;
                        break;
                    }
                }

                int dmg = (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
                if (haspet) dmg = (ownplay) ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
                p.minionGetDamageOrHeal(target, dmg);
            }
		}

	}
}