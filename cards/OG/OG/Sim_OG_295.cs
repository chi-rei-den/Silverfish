using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_295",
  "name": [
    "邪教药剂师",
    "Cult Apothecary"
  ],
  "text": [
    "<b>战吼：</b>每有一个敌方随从，便为你的英雄恢复#2点生命值。",
    "<b>Battlecry:</b> For each enemy minion, restore #2 Health to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38888
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_295 : SimCard //* Cult Apothecary
	{
		//Battlecry: For each enemy minion, restore 2 Health to your hero.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (own.own) p.minionGetDamageOrHeal(p.ownHero, -p.getMinionHeal(2 * p.enemyMinions.Count));
			else p.minionGetDamageOrHeal(p.enemyHero, -p.getEnemyMinionHeal(2 * p.ownMinions.Count));
        }
    }
}