using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_312",
  "name": [
    "恩佐斯的副官",
    "N'Zoth's First Mate"
  ],
  "text": [
    "<b>战吼：</b>装备一把1/3的锈蚀铁钩。",
    "<b>Battlecry:</b> Equip a 1/3 Rusty Hook."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38914
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_312 : SimTemplate //* N'Zoth's First Mate
	{
		//Battlecry: Equip a 1/3 Rusty Hook.

        SimCard w = CardIds.NonCollectible.Warrior.RustyHook;

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(w, own.own);
        }
    }
}
