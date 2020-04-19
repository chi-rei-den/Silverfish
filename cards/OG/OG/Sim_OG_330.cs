using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_330",
  "name": [
    "幽暗城商贩",
    "Undercity Huckster"
  ],
  "text": [
    "<b>亡语：</b>随机将一张<i>（你对手职业的）</i>卡牌置入你的手牌。",
    "<b>Deathrattle:</b> Add a random card to your hand <i>(from your opponent's class)</i>."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 39026
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_330 : SimTemplate //* Undercity Huckster
	{
		//Deathrattle: Add a random class card to your hand (from your opponent's class).

		public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(SimCard.None, m.own, true);
        }
    }
}