using Chireiden.Silverfish;
using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_091",
  "name": [
    "圣光的正义",
    "Light's Justice"
  ],
  "text": [
    null,
    null
  ],
  "CardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 383
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_091 : SimTemplate //lightsjustice
	{

//
        SimCard w = CardIds.Collectible.Paladin.LightsJustice;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(w, ownplay);
        }
	}
}