using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_809",
  "name": [
    "野猪骑士塔纳利",
    "Tanaris Hogchopper"
  ],
  "text": [
    "<b>战吼：</b>如果你的对手没有手牌，便获得\n<b>冲锋</b>。",
    "[x]<b>Battlecry:</b> If your opponent's\nhand is empty, gain <b>Charge</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40611
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_809 : SimTemplate //* Tanaris Hogchopper
	{
		// Battlecry: If your opponent's hand is empty, gain Charge.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            int anz = (m.own) ? p.enemyAnzCards : p.owncards.Count;
            if (anz < 1) p.minionGetCharge(m);
        }
    }
}