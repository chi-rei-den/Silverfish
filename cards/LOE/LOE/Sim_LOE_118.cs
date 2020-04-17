using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_118",
  "name": [
    "诅咒之刃",
    "Cursed Blade"
  ],
  "text": [
    "你的英雄受到的所有伤害效果翻倍。",
    "Double all damage dealt to your hero."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 1,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 35025
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_118 : SimCard //* Cursed Blade
	{
		//Double all damage dealt to your hero.
        //handled in getDamageOrHeal

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_118);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}