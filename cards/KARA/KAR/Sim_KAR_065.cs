using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_065",
  "name": [
    "展览馆守卫",
    "Menagerie Warden"
  ],
  "text": [
    "<b>战吼：</b>选择一个友方野兽，召唤一个它的复制。",
    "<b>Battlecry:</b> Choose a friendly Beast. Summon a copy of it."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 6,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39696
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_065 : SimTemplate //* Menagerie Warden
	{
		//Battlecry: Choose a friendly Beast. Summon a copy of it.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && own.own && p.ownMinions.Count < 7)
            {
                int pos = p.ownMinions.Count;
                p.callKid(own.handcard.card, pos, own.own);
                p.ownMinions[pos].setMinionToMinion(target);
            }
        }
    }
}