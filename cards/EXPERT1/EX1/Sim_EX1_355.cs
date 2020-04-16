using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_355",
  "name": [
    "受祝福的勇士",
    "Blessed Champion"
  ],
  "text": [
    "使一个随从的攻击力翻倍。",
    "Double a minion's Attack."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 5,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1522
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_355 : SimTemplate //blessedchampion
	{

//    verdoppelt den angriff eines dieners.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetBuffed(target, target.Angr, 0);
		}

	}
}