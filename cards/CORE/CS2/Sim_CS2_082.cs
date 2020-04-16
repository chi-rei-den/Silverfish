using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_082",
  "name": [
    "邪恶短刀",
    "Wicked Knife"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "ROGUE",
  "type": "WEAPON",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 485
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_082 : SimTemplate //* wickedknife
	{
        //-

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_082);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}