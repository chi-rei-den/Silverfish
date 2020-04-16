using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX5_03",
  "name": [
    "心智末日",
    "Mindpocalypse"
  ],
  "text": [
    "每个玩家各抽两张牌，获得一个法力水晶。",
    "Both players draw 2 cards and gain a Mana Crystal."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1855
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX5_03 : SimTemplate //* Mindpocalypse
    {
        // Both players draw 2 cards and gain a Mana Crystal.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, true);
            p.drawACard(CardDB.cardIDEnum.None, true);
            p.drawACard(CardDB.cardIDEnum.None, false);
            p.drawACard(CardDB.cardIDEnum.None, false);
			
			p.mana = Math.Min(10, p.mana+1);
			p.ownMaxMana = Math.Min(10, p.ownMaxMana+1);
			p.enemyMaxMana = Math.Min(10, p.enemyMaxMana+1);
        }
    }
}