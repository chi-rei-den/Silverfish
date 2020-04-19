using Chireiden.Silverfish;
using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_106",
  "name": [
    "炽炎战斧",
    "Fiery War Axe"
  ],
  "text": [
    null,
    null
  ],
  "CardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 401
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_106 : SimTemplate //fierywaraxe
	{
        SimCard card = CardIds.Collectible.Warrior.FieryWarAxe;
//
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(card,ownplay);
		}

	}
}