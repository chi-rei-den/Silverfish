using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_571",
  "name": [
    "自然之力",
    "Force of Nature"
  ],
  "text": [
    "召唤三个2/2的树人。",
    "Summon three 2/2 Treants."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 5,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 493
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_571 : SimCard //* Force of Nature
	{
        //Summon three 2/2 Treants.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos =(ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, pos, ownplay, false);
            p.callKid(kid, pos, ownplay);
            p.callKid(kid, pos, ownplay);
		}
	}
}