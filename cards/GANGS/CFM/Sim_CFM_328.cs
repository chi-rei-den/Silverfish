using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_328",
  "name": [
    "竞技推广员",
    "Fight Promoter"
  ],
  "text": [
    "<b>战吼：</b>如果你控制一个生命值大于或等于6的随从，抽两张牌。",
    "[x]<b>Battlecry:</b> If you control\na minion with 6 or more\n Health, draw two cards."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40617
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_328 : SimTemplate //* Fight Promoter
	{
		// Battlecry: If you control a minion with 6 or more Health, draw two cards.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.Hp >= 6)
                {
                    p.drawACard(SimCard.None, m.own);
                    p.drawACard(SimCard.None, m.own);
                    break;
                }
            }
        }
    }
}