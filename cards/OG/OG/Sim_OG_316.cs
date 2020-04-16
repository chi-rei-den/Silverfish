using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_316",
  "name": [
    "传令官沃拉兹",
    "Herald Volazj"
  ],
  "text": [
    "<b>战吼：</b>召唤所有其他友方随从的复制，他们均为1/1。",
    "<b>Battlecry:</b> Summon a 1/1 copy of each of your other minions."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38922
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_316 : SimTemplate //* Herald Volazj
	{
		//Battlecry: Summon a 1/1 copy of each of your other minions.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;
            int pos = temp.Count;
            if (pos > 1)
            {
                foreach (Minion m in (own.own) ? p.ownMinions.ToArray() : p.enemyMinions.ToArray())
                {
                    if (m.entitiyID == own.entitiyID) continue;
                    pos = (own.own) ? p.ownMinions.Count : p.enemyMinions.Count;
                    if (pos > 6) break;
                    p.callKid(m.handcard.card, pos, own.own);
                    temp = (own.own) ? p.ownMinions : p.enemyMinions;
                    temp[pos].Hp = 1;
                    temp[pos].Angr = 1;
                }
            }
        }
    }
}