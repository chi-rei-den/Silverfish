using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_833h",
  "name": [
    "冰冷触摸",
    "Icy Touch"
  ],
  "text": [
    "<b>英雄技能</b>\n造成$1点伤害。如果该英雄技能消灭了一个随从，则召唤一个水元素。",
    "<b>Hero Power</b>\n Deal $1 damage. If this kills a minion, summon a Water Elemental."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 42944
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_833h: SimTemplate //* Icy Touch
    {
        // Hero Power: Deal 1 damage. If this kills a minion, summon a Water Elemental.

        Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Mage.WaterElemental; //Water Elemental

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(1) : p.getEnemyHeroPowerDamage(1);
            p.minionGetDamageOrHeal(target, dmg);

            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            if (target.Hp <= 0) p.callKid(kid, place, ownplay);
		}
	}
}