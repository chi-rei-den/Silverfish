using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_028",
  "name": [
    "愚者之灾",
    "Fool's Bane"
  ],
  "text": [
    "每个回合攻击次数不限，但无法攻击英雄。",
    "Unlimited attacks each turn. Can't attack heroes."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39417
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_028 : SimTemplate //* Fool's Bane
	{
        //Unlimited attacks each turn. Can't attack heroes.
        // handled in public void getMoveList

        Chireiden.Silverfish.SimCard weapon = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.KAR_028);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}