using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_595",
  "name": [
    "诅咒教派领袖",
    "Cult Master"
  ],
  "text": [
    "在一个友方随从死亡后，抽一张牌。",
    "After a friendly minion dies, draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 811
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_595 : SimTemplate //* cultmaster
	{
        // Whenever one of your other minions dies, draw a card.

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            int diedMinions = (m.own) ? p.tempTrigger.ownMinionsDied : p.tempTrigger.enemyMinionsDied;
            if (diedMinions == 0) return;
            int residual = (p.pID == m.pID) ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            for (int i = 0; i < residual; i++)
            {
                p.drawACard(CardDB.cardIDEnum.None, m.own);
            }
        }
	}
}