using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_398t",
  "name": [
    "战斧",
    "Battle Axe"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 1,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1707
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_398t : SimTemplate //battleaxe
	{

//
        Chireiden.Silverfish.SimCard wcard = CardIds.NonCollectible.Warrior.ArathiWeaponsmith_BattleAxeToken;
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(wcard, ownplay);
        }
	}
}