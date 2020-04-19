using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_648",
  "name": [
    "犯罪高手",
    "Big-Time Racketeer"
  ],
  "text": [
    "<b>战吼：</b>召唤一个6/6的食人魔。",
    "<b>Battlecry:</b> Summon a 6/6 Ogre."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40494
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_648 : SimTemplate //* Big-Time Racketeer
	{
		// Battlecry: Summon a 6/6 Ogre.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.BigTimeRacketeer_LittleFriendToken; //6/6 Ogre

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(kid, m.zonepos, m.own);
        }
    }
}