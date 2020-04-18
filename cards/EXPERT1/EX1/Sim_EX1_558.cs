using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_558",
  "name": [
    "哈里森·琼斯",
    "Harrison Jones"
  ],
  "text": [
    "<b>战吼：</b>摧毁对手的武器，并抽数量等同于其耐久度的牌。",
    "<b>Battlecry:</b> Destroy your opponent's weapon and draw cards equal to its Durability."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 912
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_558 : SimTemplate //harrisonjones
	{
//    kampfschrei:/ zerstört die waffe eures gegners. zieht ihrer haltbarkeit entsprechend karten.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                //this.owncarddraw += enemyWeaponDurability;
                for (int i = 0; i < p.enemyWeapon.Durability; i++)
                {
                    p.drawACard(Chireiden.Silverfish.SimCard.None, true);
                }
                p.lowerWeaponDurability(1000, false);
            }
            else
            {
                for (int i = 0; i < p.enemyWeapon.Durability; i++)
                {
                    p.drawACard(Chireiden.Silverfish.SimCard.None, false);
                }
                p.lowerWeaponDurability(1000, true);
            }
		}


	}
}