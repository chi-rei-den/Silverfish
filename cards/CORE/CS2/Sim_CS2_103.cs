using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_103",
  "name": [
    "冲锋",
    "Charge"
  ],
  "text": [
    "使一个友方随从获得<b>冲锋</b>。在本回合中无法攻击英雄。",
    "Give a friendly minion <b>Charge</b>. It can't attack heroes this turn."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 344
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_103 : SimCard //* Charge
    {
        //Give a friendly minion Charge. It can't attack heroes this turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetCharge(target);
            target.cantAttackHeroes = true;
        }
	}
}