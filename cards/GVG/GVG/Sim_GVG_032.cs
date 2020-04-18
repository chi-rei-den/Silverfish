using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_032",
  "name": [
    "林地树妖",
    "Grove Tender"
  ],
  "text": [
    "<b>抉择：</b>使每个玩家获得一个法力水晶；或每个玩家抽一张牌。",
    "<b>Choose One -</b> Give each player a Mana Crystal; or Each player draws a card."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2225
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_032 : SimTemplate //* Grove Tender
    {

        //    Choose One - Give each player a Mana Crystal; or Each player draws a card.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
				p.mana = Math.Min(10, p.mana+1);
				p.ownMaxMana = Math.Min(10, p.ownMaxMana+1);
				p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+1);
            }

            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.drawACard(Chireiden.Silverfish.SimCard.None, true);
                p.drawACard(Chireiden.Silverfish.SimCard.None, false);
            }
        }


    }

}