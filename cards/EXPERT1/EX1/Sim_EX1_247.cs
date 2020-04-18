using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_247",
  "name": [
    "雷铸战斧",
    "Stormforged Axe"
  ],
  "text": [
    "<b>过载：</b>（1）",
    "<b>Overload:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 960
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_247 : SimTemplate //stormforgedaxe
	{
        Chireiden.Silverfish.SimCard card = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_247);
        //
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(card,ownplay);
            if (ownplay) p.ueberladung ++;
        }

	}
}