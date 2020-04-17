using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_337",
  "name": [
    "食人鱼喷枪",
    "Piranha Launcher"
  ],
  "text": [
    "在你的英雄攻击后，召唤一个1/1的食人鱼。",
    "[x]After your hero attacks,\nsummon a 1/1 Piranha."
  ],
  "cardClass": "HUNTER",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40683
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_337 : SimCard //* Piranha Launcher
	{
		// Whenever your hero attacks, summon a 1/1 Piranha.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_337);
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}