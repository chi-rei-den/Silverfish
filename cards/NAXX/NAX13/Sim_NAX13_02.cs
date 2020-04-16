using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX13_02",
  "name": [
    "极性转换",
    "Polarity Shift"
  ],
  "text": [
    "<b>英雄技能</b>\n使所有随从的攻击力和生命值互换。",
    "<b>Hero Power</b>\nSwap the Attack and Health of all minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1897
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX13_02 : SimTemplate //* Polarity Shift
	{
		//Hero Power: Swap the Attack and Health of all minions.
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            foreach (Minion m in p.ownMinions)
            {
				p.minionSwapAngrAndHP(m);
            }
            foreach (Minion m in p.enemyMinions)
            {
				p.minionSwapAngrAndHP(m);
            }
        }
    }
}