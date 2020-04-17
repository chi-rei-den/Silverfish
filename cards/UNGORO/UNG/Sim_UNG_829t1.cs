using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_829t1",
  "name": [
    "虚空传送门",
    "Nether Portal"
  ],
  "text": [
    "打开一座会永久召唤3/2小鬼的传送门。",
    "Open a permanent portal that summons 3/2 Imps."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41942
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_829t1 : SimCard //* Nether Portal
	{
		//Open a permanent portal that summons 3/2 Imps.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_829t2); //Nether Portal

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
			p.evaluatePenality -= 15;
        }
    }
}