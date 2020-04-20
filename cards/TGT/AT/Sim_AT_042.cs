using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_042",
  "name": [
    "刃牙德鲁伊",
    "Druid of the Saber"
  ],
  "text": [
    "<b>抉择：</b>将该随从变形成为2/1并具有<b>冲锋</b>；或者将该随从变形成为3/2并具有<b>潜行</b>。",
    "[x]<b>Choose One -</b> Transform\ninto a 2/1 with <b>Charge</b>;\nor a 3/2 with <b>Stealth</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2783
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_042 : SimTemplate //* Druid of the Saber
	{
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, CardIds.NonCollectible.Druid.FandralStaghelm_DruidOfTheSaber);
            }
            else
            {
                if (choice == 1)
                {
                    p.minionTransform(own, CardIds.NonCollectible.Druid.DruidoftheSaber_DruidOfTheSaberToken1);
                }
                if (choice == 2)
                {
                    p.minionTransform(own, CardIds.NonCollectible.Druid.DruidoftheSaber_DruidOfTheSaberToken2);
                }
            }
		}
	}
}