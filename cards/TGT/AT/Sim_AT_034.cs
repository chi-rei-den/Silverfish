using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_034",
  "name": [
    "淬毒利刃",
    "Poisoned Blade"
  ],
  "text": [
    "你的英雄技能不会取代该武器，改为+1攻击力。",
    "Your Hero Power gives this weapon +1 Attack instead of replacing it."
  ],
  "cardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 4,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2763
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_034 : SimTemplate //* Poisoned Blade
	{
		//Your Hero Power gives this weapon +1 attack instead of replacing it.
		
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_034);
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

		public override void onInspire(Playfield p, Minion m, bool own)
        {
			if (m.own == own)
			{
				if(own) p.ownWeapon.Angr++;
				else p.enemyWeapon.Angr++; 
			}
        }		
	}
}