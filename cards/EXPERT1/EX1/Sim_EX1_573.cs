using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_573",
  "name": [
    "塞纳留斯",
    "Cenarius"
  ],
  "text": [
    "<b>抉择：</b>使你的所有其他随从获得+2/+2；或者召唤两个2/2并具有<b>嘲讽</b>的树人。",
    "<b>Choose One -</b> Give your other minions +2/+2; or Summon two 2/2 Treants with <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 36
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_573 : SimTemplate //* Cenarius
    {
        //Choose One - Give your other minions +2/+2; or Summon two 2/2 Treants with Taunt.

        Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_573t); //special treant

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
                foreach (Minion m in temp)
                {
                    if (own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 2, 2);
                }
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.callKid(kid, own.zonepos, own.own, false);
                p.callKid(kid, own.zonepos - 1, own.own);
            }
		}
	}
}