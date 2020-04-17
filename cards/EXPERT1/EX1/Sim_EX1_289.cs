using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_289",
  "name": [
    "寒冰护体",
    "Ice Barrier"
  ],
  "text": [
    "<b>奥秘：</b>当你的英雄受到攻击时，获得8点护甲值。",
    "<b>Secret:</b> When your\nhero is attacked,\ngain 8 Armor."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 621
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_289 : SimCard //icebarrier
	{

        //todo secret
//    geheimnis:/ wenn euer held angegriffen wird, erhält er 8 rüstung.
        public override void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            
            p.minionGetArmor(target, 8);
        }

	}

}