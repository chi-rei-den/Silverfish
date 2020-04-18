using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_220",
  "name": [
    "马尔考罗克",
    "Malkorok"
  ],
  "text": [
    "<b>战吼：</b>随机装备一把武器。",
    "<b>Battlecry:</b> Equip a random weapon."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38739
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_220 : SimTemplate //* Malkorok
	{
		//Battlecry: Equip a random weapon.
		
        Chireiden.Silverfish.SimCard w = CardIds.Collectible.Rogue.AssassinsBlade;

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(w, own.own);
        }
    }
}