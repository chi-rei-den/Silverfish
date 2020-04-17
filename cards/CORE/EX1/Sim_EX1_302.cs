using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_302",
  "name": [
    "死亡缠绕",
    "Mortal Coil"
  ],
  "text": [
    "对一个随从造成$1点伤害。如果“死亡缠绕”消灭该随从，抽一张牌。",
    "Deal $1 damage to a minion. If that kills it, draw a card."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1092
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_302 : SimCard //mortalcoil
	{

//    fügt einem diener $1 schaden zu. zieht eine karte, wenn er dadurch vernichtet wird.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            if (dmg >= target.Hp && !target.divineshild && !target.immune)
            {
                //this.owncarddraw++;
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
            }
            p.minionGetDamageOrHeal(target, dmg);
            
		}

	}
}