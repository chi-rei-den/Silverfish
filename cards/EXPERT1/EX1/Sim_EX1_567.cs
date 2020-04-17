using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_567",
  "name": [
    "毁灭之锤",
    "Doomhammer"
  ],
  "text": [
    "<b>风怒，过载：</b>（2）",
    "<b>Windfury, Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 352
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_567 : SimCard //doomhammer
	{

//    windzorn/, überladung:/ (2)
        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_567);

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.equipWeapon(card, ownplay);
            if (ownplay) p.ueberladung += 2;
		}

	}
}