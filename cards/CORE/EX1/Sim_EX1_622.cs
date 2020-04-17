using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_622",
  "name": [
    "暗言术：灭",
    "Shadow Word: Death"
  ],
  "text": [
    "消灭一个攻击力大于或等于5的随从。",
    "Destroy a minion with 5 or more Attack."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1363
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_622 : SimCard //shadowworddeath
	{

//    vernichtet einen diener mit mind. 5 angriff.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDestroyed(target);
		}

	}
}