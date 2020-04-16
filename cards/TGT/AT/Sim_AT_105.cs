using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_105",
  "name": [
    "受伤的克瓦迪尔",
    "Injured Kvaldir"
  ],
  "text": [
    "<b>战吼：</b>对自身造成3点伤害。",
    "<b>Battlecry:</b> Deal 3 damage to this minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2502
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_105 : SimTemplate //* Injured Kvaldir
	{
		//Battlecry: Deal 3 damage to this minion
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(own, 3);
        }
    }
}