using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_334",
  "name": [
    "暗影狂乱",
    "Shadow Madness"
  ],
  "text": [
    "直到回合结束，获得一个攻击力小于或等于3的敌方随从的控制权。",
    "Gain control of an enemy minion with 3 or less Attack until end of turn."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 220
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_334 : SimCard //shadowmadness
	{

//    übernehmt bis zum ende des zuges die kontrolle über einen feindlichen diener mit max. 3 angriff.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            target.shadowmadnessed = true;
            p.shadowmadnessed++;
            p.minionGetControlled(target, ownplay, true);
		}

	}
}