using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_204",
  "name": [
    "玛瑙主教",
    "Onyx Bishop"
  ],
  "text": [
    "<b>战吼：</b>召唤一个在本局对战中死亡的友方随从。",
    "<b>Battlecry:</b> Summon a friendly minion that died this game."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39374
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_204 : SimTemplate //* Onyx Bishop
	{
		//Battlecry: Summon a friendly minion that died this game.
				
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.OwnLastDiedMinion != CardDB.cardIDEnum.None)
                {
                    p.callKid(CardDB.Instance.getCardDataFromID(p.OwnLastDiedMinion), own.zonepos, own.own);
                }
            }
		}
	}
}