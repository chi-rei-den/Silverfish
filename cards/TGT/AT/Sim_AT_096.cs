using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_096",
  "name": [
    "发条骑士",
    "Clockwork Knight"
  ],
  "text": [
    "<b>战吼：</b>使一个友方机械获得+1/+1。",
    "<b>Battlecry:</b> Give a friendly Mech +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2500
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_096 : SimCard //* Clockwork Knight
    {
		//Battlecry: Give a friendly Mech +1/+1.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null) p.minionGetBuffed(target, 1, 1);
        }
    }
}