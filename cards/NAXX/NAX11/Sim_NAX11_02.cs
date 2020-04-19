using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX11_02",
  "name": [
    "毒云",
    "Poison Cloud"
  ],
  "text": [
    "<b>英雄技能</b>\n对所有随从造成1点伤害。每死亡一个随从，召唤一个泥浆怪。",
    "<b>Hero Power</b>\nDeal 1 damage to all minions. If any die, summon a slime."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1888
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX11_02 : SimTemplate //* Poison Cloud
	{
		// Hero Power: Deal 1 damage to all minions. If any die, summon a slime.
		
		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.FalloutSlime;//Fallout Slime

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
			p.allMinionsGetDamage(dmg);
			
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            foreach (Minion m in p.ownMinions)
            {
				if (m.Hp <= 0) p.callKid(kid, place, ownplay);
			}
            foreach (Minion m in p.enemyMinions)
            {
				if (m.Hp <= 0) p.callKid(kid, place, ownplay);
			}
		}
	}
}