using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_033",
  "name": [
    "剽窃",
    "Burgle"
  ],
  "text": [
    "随机将两张<i>（你对手职业的）</i>卡牌置入你的手牌。",
    "Add 2 random cards to your hand <i>(from your opponent's class)</i>."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2770
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_033 : SimTemplate //* Burgle
	{
		//Add 2 random class cards to your hand (From your opponent's class).
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
            p.drawACard(CardDB.cardIDEnum.None, ownplay, true);
        }
    }
}