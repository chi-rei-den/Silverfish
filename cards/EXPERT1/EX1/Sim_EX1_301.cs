using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_301",
  "name": [
    "恶魔卫士",
    "Felguard"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>摧毁你的一个法力水晶。",
    "<b>Taunt</b>\n<b>Battlecry:</b> Destroy one of your Mana Crystals."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 517
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_301 : SimTemplate //felguard
	{

//    spott/. kampfschrei:/ zerstört einen eurer manakristalle.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                p.ownMaxMana--;
            }
            else
            {
                p.enemyMaxMana--;
            }
		}


	}
}