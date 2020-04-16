using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_538",
  "name": [
    "关门放狗",
    "Unleash the Hounds"
  ],
  "text": [
    "战场上每有一个敌方随从，便召唤一个\n1/1并具有<b>冲锋</b>的猎犬。",
    "For each enemy minion, summon a 1/1 Hound with <b>Charge</b>."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1243
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_538 : SimTemplate //* unleashthehounds
	{
        // For each enemy minion, summon a 1/1 Hound with Charge.
        
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_538t); //hound

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            int anz = (ownplay) ? p.enemyMinions.Count : p.ownMinions.Count;
            if (anz > 0)
            {
                p.callKid(kid, pos, ownplay, false);
                anz--;
                for (int i = 0; i < anz; i++)
                {
                    p.callKid(kid, pos, ownplay);
                }
            }
		}
	}
}