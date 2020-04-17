using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_030",
  "name": [
    "死亡之翼",
    "Deathwing"
  ],
  "text": [
    "<b>战吼：</b>\n消灭所有其他随从，并弃掉你的手牌。",
    "<b>Battlecry:</b> Destroy all other minions and discard your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 834
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_030 : SimCard //* Deathwing
	{
        //Battlecry: Destroy all other minions and discard your hand.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            foreach (Minion m in p.ownMinions)
            {
                if (m.entitiyID != own.entitiyID) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
                if (m.entitiyID != own.entitiyID) p.minionGetDestroyed(m);
            }
            p.discardCards(10, own.own);
		}
	}
}