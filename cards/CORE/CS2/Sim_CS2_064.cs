using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_064",
  "name": [
    "恐惧地狱火",
    "Dread Infernal"
  ],
  "text": [
    "<b>战吼：</b>对所有其他角色造成1点伤害。",
    "<b>Battlecry:</b> Deal 1 damage to ALL other characters."
  ],
  "CardClass": "WARLOCK",
  "type": "MINION",
  "cost": 6,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1019
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_064 : SimTemplate //* Dread Infernal
	{
        // Battlecry: Deal 1 damage to ALL other characters.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.allCharsGetDamage(1, own.entitiyID);
		}
	}
}