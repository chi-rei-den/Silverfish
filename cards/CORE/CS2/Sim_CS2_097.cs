using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_097",
  "name": [
    "真银圣剑",
    "Truesilver Champion"
  ],
  "text": [
    "每当你的英雄进攻，便为其恢复#2点生命值。",
    "Whenever your hero attacks, restore #2 Health to it."
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 847
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_097 : SimTemplate //truesilverchampion
	{

        Chireiden.Silverfish.SimCard card = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_097);
        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(card, ownplay);
        }

	}
}