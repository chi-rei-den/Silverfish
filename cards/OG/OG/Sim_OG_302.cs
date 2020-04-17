using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_302",
  "name": [
    "渡魂者",
    "Usher of Souls"
  ],
  "text": [
    "每当一个友方随从死亡时，使你的克苏恩\n获得+1/+1<i>（无论它在哪里）。</i>",
    "Whenever a friendly minion dies, give your C'Thun +1/+1\n<i>(wherever it is).</i>"
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38898
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_302 : SimCard //* Usher of Souls
	{
		//Whenever a friendly minion dies, give your C'Thun +1/+1 (wherever it is).
		
        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            int diedMinions = p.tempTrigger.ownMinionsDied;
            if (diedMinions == 0) return;
            int residual = (p.pID == m.pID) ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            p.cthunGetBuffed(residual, residual, 0);
        }
	}
}