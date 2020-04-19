using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX11_02H",
  "name": [
    "毒云",
    "Poison Cloud"
  ],
  "text": [
    "<b>英雄技能</b>\n对所有敌人造成2点伤害。每死亡一个随从，召唤一个泥浆怪。",
    "<b>Hero Power</b>\nDeal 2 damage to all enemies. If any die, summon a slime."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2135
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX11_02H : SimTemplate //* Poison Cloud
	{
		// Hero Power: Deal 2 damage to all enemies. If any die, summon a slime.
		
		Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.FalloutSlime;//Fallout Slime

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.allMinionOfASideGetDamage(!ownplay, dmg);
			
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            foreach (Minion m in ownplay ? p.enemyMinions : p.ownMinions)
            {
				if (m.Hp <= 0) p.callKid(kid, place, ownplay);
			}
		}
	}
}