using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_097",
  "name": [
    "守护者麦迪文",
    "Medivh, the Guardian"
  ],
  "text": [
    "<b>战吼：</b>\n装备埃提耶什，守护者的传说之杖。",
    "<b>Battlecry:</b> Equip Atiesh, Greatstaff of the Guardian."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39841
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_097 : SimTemplate //* Medivh, the Guardian
	{
		//Battlecry: Equip Atiesh, Greatstaff of the Guardian.
		
        Chireiden.Silverfish.SimCard wcard = CardIds.NonCollectible.Neutral.MedivhtheGuardian_AtieshToken;//Atiesh

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(wcard, own.own);
        }
    }
}
