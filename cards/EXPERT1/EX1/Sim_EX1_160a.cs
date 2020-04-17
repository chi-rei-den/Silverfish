using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_160a",
  "name": [
    "召唤猎豹",
    "Summon a Panther"
  ],
  "text": [
    "召唤一个3/2的猎豹。",
    "Summon a 3/2 Panther."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 60
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_160a : SimCard //* summonapanther
	{
        //Summon a 3/2 Panther.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_160t);//panther

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
		}
	}
}