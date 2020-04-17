using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_950",
  "name": [
    "斩棘刀",
    "Vinecleaver"
  ],
  "text": [
    "在你的英雄攻击后，召唤两个1/1的白银之手\n新兵。",
    "[x]After your hero attacks,\nsummon two 1/1 Silver\nHand Recruits."
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 7,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41859
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_950 : SimCard //* Vinecleaver
	{
		//After your hero attacks, summon two 1/1 Silver Hand Recruits.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}