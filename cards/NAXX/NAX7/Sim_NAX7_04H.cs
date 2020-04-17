using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX7_04H",
  "name": [
    "符文巨剑",
    "Massive Runeblade"
  ],
  "text": [
    "对英雄造成双倍伤害。",
    "Deals double damage to heroes."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2130
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX7_04H : SimCard //* 10/2 Massive Runeblade
	{
		//Deals double damage to heroes.
		//Handled in minionAttacksMinion()

		CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NAX7_04H);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(weapon, ownplay);
		}
	}
}