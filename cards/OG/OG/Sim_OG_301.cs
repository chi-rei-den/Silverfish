using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_301",
  "name": [
    "上古之神护卫",
    "Ancient Shieldbearer"
  ],
  "text": [
    "<b>战吼：</b>\n如果你的克苏恩具有至少10点攻击力，则获得10点护甲值。",
    "<b>Battlecry:</b> If your C'Thun has at least 10 Attack, gain 10 Armor."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 7,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38897
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_301 : SimTemplate //* Ancient Shieldbearer
	{
		//Battlecry: If your C'Thun has at least 10 Attack, gain 10 Armor
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.anzOgOwnCThunAngrBonus + 6 > 9) p.minionGetArmor(p.ownHero, 10);
                else p.evaluatePenality += 5;
            }
		}
	}
}