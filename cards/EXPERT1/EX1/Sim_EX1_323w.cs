using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_323w",
  "name": [
    "血怒",
    "Blood Fury"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "WARLOCK",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1660
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_323w : SimTemplate //* Blood Fury
	{
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_323w);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}