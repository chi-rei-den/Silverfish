using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_070",
  "name": [
    "驯兽师",
    "Houndmaster"
  ],
  "text": [
    "<b>战吼：</b>使一个友方野兽获得+2/+2和<b>嘲讽</b>。",
    "<b>Battlecry:</b> Give a friendly Beast +2/+2 and <b>Taunt</b>."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1003
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_DS1_070 : SimTemplate //* houndmaster
	{
        //Battlecry: Give a friendly Beast +2/+2 and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (target != null)
            {
                p.minionGetBuffed(target, 2, 2);
                if (!target.taunt)
                {
                    target.taunt = true;
                    if (target.own) p.anzOwnTaunt++;
                    else p.anzEnemyTaunt++;
                }
            }
		}
	}
}