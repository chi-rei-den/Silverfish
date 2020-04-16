using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_603",
  "name": [
    "疯狂药水",
    "Potion of Madness"
  ],
  "text": [
    "直到回合结束，获得一个攻击力小于或等于2的敌方随从的控制权。",
    "Gain control of an enemy minion with 2 or less Attack until end of turn."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40373
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_603 : SimTemplate //* Potion of Madness
	{
		// Gain control of an enemy minion with 2 or less Attack until the end of the turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            target.shadowmadnessed = true;
            p.shadowmadnessed++;
            p.minionGetControlled(target, ownplay, true);
        }
    }
}