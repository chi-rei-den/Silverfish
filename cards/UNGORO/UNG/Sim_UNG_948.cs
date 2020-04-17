using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_948",
  "name": [
    "熔岩镜像",
    "Molten Reflection"
  ],
  "text": [
    "选择一个友方随从，召唤一个该随从的复制。",
    "Choose a friendly minion. Summon a copy of it."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 4,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41690
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_948 : SimCard //* Molten Reflection
	{
		//Choose a friendly minion. Summon a copy of it.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
            int pos = temp.Count;
            if (pos < 7)
            {
                p.callKid(target.handcard.card, pos, ownplay);
                temp[pos].setMinionToMinion(target);
            }
        }
    }
}