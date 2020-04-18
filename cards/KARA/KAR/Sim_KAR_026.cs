using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_026",
  "name": [
    "保卫国王",
    "Protect the King!"
  ],
  "text": [
    "战场上每有一个敌方随从，便召唤一个1/1并具有<b>嘲讽</b>的\n禁卫。",
    "For each enemy minion, summon a 1/1 Pawn with <b>Taunt</b>."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39495
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_026 : SimTemplate //* Protect the King
	{
		//For each enemy minion, summon a 1/1 Pawn with Taunt
		
        Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.KAR_026t);//Pawn

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int anz = ownplay ? p.enemyMinions.Count : p.ownMinions.Count;
            int pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            
            for (int i = 0; i < anz; i++)
            {
                p.callKid(kid, pos, ownplay);
            }
		}
	}
}