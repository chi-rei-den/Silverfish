using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_165",
  "name": [
    "利爪德鲁伊",
    "Druid of the Claw"
  ],
  "text": [
    "<b>抉择：</b>将该随从变形成为4/4并具有<b>冲锋</b>；或者将该随从变形成为4/6并具有<b>嘲讽</b>。",
    "[x]<b>Choose One -</b> Transform\ninto a 4/4 with <b>Charge</b>;\nor a 4/6 with <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 692
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_165 : SimTemplate  //* Druid of the Claw
    {
        // Choose One - Charge; or +2 Health and Taunt.

        Chireiden.Silverfish.SimCard cat = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_165t1);
        Chireiden.Silverfish.SimCard bear = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.EX1_165t2);
        Chireiden.Silverfish.SimCard bearcat = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.OG_044a);

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, bearcat);
            }
            else
            {
                if (choice == 1)
                {
                    p.minionTransform(own, cat);
                }
                if (choice == 2)
                {
                    p.minionTransform(own, bear);
                }
            }
		}
	}
}