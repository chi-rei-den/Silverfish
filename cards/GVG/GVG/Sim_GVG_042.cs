using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_042",
  "name": [
    "耐普图隆",
    "Neptulon"
  ],
  "text": [
    "<b>战吼：</b>随机将四张鱼人牌置入你的手牌，<b>过载：</b>（3）",
    "<b>Battlecry:</b> Add 4 random Murlocs to your hand. <b>Overload:</b> (3)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2010
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_042 : SimTemplate //* Neptulon
    {
        // Battlecry: Add 4 random Murlocs to your hand. Overload: (3)

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            for (int i = 0; i < 4; i++)
            {
                p.drawACard(CardIds.Collectible.Neutral.MurlocRaider, m.own, true);
            }
            if (m.own) p.ueberladung += 3;
        }
    }
}