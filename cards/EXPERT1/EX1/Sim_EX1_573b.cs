using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_573b",
  "name": [
    "恩师的教诲",
    "Shan'do's Lesson"
  ],
  "text": [
    "召唤两个2/2并具有<b>嘲讽</b>的树人。",
    "Summon two 2/2 Treants with <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 9,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 364
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_573b : SimCard //* shandoslesson
	{
        //Summon two 2/2 Treants with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_573t); //special treant
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
            p.callKid(kid, pos, ownplay);
		}

	}
}