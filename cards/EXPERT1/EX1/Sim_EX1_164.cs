using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_164",
  "name": [
    "滋养",
    "Nourish"
  ],
  "text": [
    "<b>抉择：</b>获得两个法力水晶；或者抽三张牌。",
    "<b>Choose One -</b> Gain 2 Mana Crystals; or Draw 3 cards."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 95
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_164 : SimTemplate //* nourish
    {

        //    Choose One - Gain 2 Mana Crystals or Draw 3 cards.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
				if (ownplay)
				{
					p.mana = Math.Min(10, p.mana+2);
					p.ownMaxMana = Math.Min(10, p.ownMaxMana+2);
				}
				else
				{
					p.mana = Math.Min(10, p.mana+2);
					p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+2);
				}
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                //this.owncarddraw+=3;
                p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
                p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
                p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay);
            }
        }

    }


}