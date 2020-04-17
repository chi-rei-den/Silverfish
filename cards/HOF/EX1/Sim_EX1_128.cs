using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_128",
  "name": [
    "隐藏",
    "Conceal"
  ],
  "text": [
    "直到你的下个回合，使所有友方随从获得<b>潜行</b>。",
    "Give your minions <b>Stealth</b> until your next turn."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 990
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_128 : SimCard //conceal
	{

//    verleiht euren dienern bis zu eurem nächsten zug verstohlenheit/.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (!m.stealth)
                    {
                        m.stealth = true;
                        m.conceal = true;
                    }
                }
            }
            else
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (!m.stealth)
                    {
                        m.stealth = true;
                        m.conceal = true;
                    }
                }
            }
		}

	}

}