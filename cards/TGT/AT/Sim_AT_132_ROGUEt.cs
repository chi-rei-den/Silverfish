using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_ROGUEt",
  "name": [
    "浸毒匕首",
    "Poisoned Dagger"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 1,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2746
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132_ROGUEt : SimTemplate //* Poisoned Dagger
	{
        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_132_ROGUEt);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}