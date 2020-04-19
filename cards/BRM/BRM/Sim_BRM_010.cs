using Chireiden.Silverfish;
using HearthDb.Enums;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_010",
  "name": [
    "烈焰德鲁伊",
    "Druid of the Flame"
  ],
  "text": [
    "<b>抉择：</b>将该随从变形成为5/2；或者将该随从变形成为2/5。",
    "<b>Choose One -</b> Transform into a 5/2 minion; or a 2/5 minion."
  ],
  "CardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2292
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_010 : SimTemplate //* Druid of the Flame
    {
		// Choose One - Transform into a 5/2 minion; or a 2/5 minion.
        SimCard fireCat52 = CardIds.NonCollectible.Druid.DruidoftheFlame_DruidOfTheFlameToken1;
        SimCard fireHawk25 = CardIds.NonCollectible.Druid.DruidoftheFlame_DruidOfTheFlameToken12;
        SimCard CatHawk55 = CardIds.NonCollectible.Druid.FandralStaghelm_DruidOfTheFlame;
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, CatHawk55);
            }
            else
            {
                if (choice == 1)
                {
                    p.minionTransform(own, fireCat52);
                }
                else if (choice == 2)
                {
                    p.minionTransform(own, fireHawk25);
                }
            }
		}
	}
}