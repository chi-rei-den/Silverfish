using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_073",
  "name": [
    "冷血",
    "Cold Blood"
  ],
  "text": [
    "使一个随从获得+2攻击力；<b>连击：</b>改为获得+4攻击力。",
    "Give a minion +2 Attack. <b>Combo:</b> +4 Attack instead."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 268
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_073 : SimCard //coldblood
	{

//    verleiht einem diener +2 angriff. combo:/ stattdessen +4 angriff.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int ag = (p.cardsPlayedThisTurn >= 1 || !ownplay) ? 4 : 2; // we suggest, whether enemy is playing this, it is combo
            p.minionGetBuffed(target, ag, 0);
		}

	}
}