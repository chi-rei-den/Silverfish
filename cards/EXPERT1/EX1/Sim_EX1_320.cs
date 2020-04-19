using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_320",
  "name": [
    "末日灾祸",
    "Bane of Doom"
  ],
  "text": [
    "对一个角色造成$2点伤害。如果“末日灾祸”消灭该角色，随机召唤一个恶魔。",
    "Deal $2 damage to a character. If that kills it, summon a random Demon."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 23
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_320 : SimTemplate //baneofdoom
	{

//    fügt einem charakter $2 schaden zu. beschwört einen zufälligen dämon, wenn der schaden tödlich ist.
        Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Warlock.BloodImp;//bloodimp
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{


            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            bool summondemon = false;

            if (!target.isHero && dmg >= target.Hp && !target.divineshild && !target.immune)
            {
                summondemon = true;
            }

            p.minionGetDamageOrHeal(target, dmg);

            if (summondemon)
            {
                int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                
                if (target.own && ownplay) p.callKid(kid, posi, ownplay);
                else p.callKid(kid, posi, ownplay);
            }

		}

	}
}