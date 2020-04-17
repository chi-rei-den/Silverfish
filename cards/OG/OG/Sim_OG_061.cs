using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_061",
  "name": [
    "搜寻猎物",
    "On the Hunt"
  ],
  "text": [
    "造成$1点伤害。召唤一个1/1的獒犬。",
    "Deal $1 damage.\nSummon a 1/1 Mastiff."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38377
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_061 : SimCard //* On the Hunt
	{
		//Deal 1 damage. Summon a 1/1 Mastiff.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.OG_061t);
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            p.minionGetDamageOrHeal(target, dmg);
			
			int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay);
		}
	}
}