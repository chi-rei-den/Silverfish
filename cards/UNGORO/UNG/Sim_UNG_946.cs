using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_946",
  "name": [
    "贪食软泥怪",
    "Gluttonous Ooze"
  ],
  "text": [
    "<b>战吼：</b>摧毁对手的武器，并获得等同于其攻击力的护甲值。",
    "<b>Battlecry:</b> Destroy your opponent's weapon and gain Armor equal to its Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41683
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_946 : SimCard //* Gluttonous Ooze
	{
		//Battlecry: Destroy your opponent's weapon and gain Armor equal to its Attack.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			int num = p.enemyWeapon.Angr;
            if (!own.own) num = p.ownWeapon.Angr;
            p.lowerWeaponDurability(1000, !own.own);
            p.minionGetArmor(own.own ? p.ownHero : p.enemyHero, num);	
		}
	}
}