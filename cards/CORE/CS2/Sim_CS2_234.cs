using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_234",
  "name": [
    "暗言术：痛",
    "Shadow Word: Pain"
  ],
  "text": [
    "消灭一个攻击力小于或等于3的随从。",
    "Destroy a minion with 3 or less Attack."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1367
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_234 : SimCard //shadowwordpain
	{

//    vernichtet einen diener mit max. 3 angriff.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.minionGetDestroyed(target);
		}


	}
}