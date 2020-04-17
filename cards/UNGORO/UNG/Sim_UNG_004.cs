using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_004",
  "name": [
    "巨化术",
    "Dinosize"
  ],
  "text": [
    "将一个随从的攻击力和生命值变为10。",
    "Set a minion's Attack and Health to 10."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 8,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41130
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_004 : SimCard //* Dinosize
	{
		//Set a minion's Attack and Health to 10.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.minionSetAngrToX(target, 10);
			p.minionSetLifetoX(target, 10);
		}
	}
}