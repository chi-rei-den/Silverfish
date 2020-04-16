using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_069",
  "name": [
    "吹嘘海盗",
    "Swashburglar"
  ],
  "text": [
    "<b>战吼：</b>随机将一张<i>（你对手职业的）</i>卡牌置入你的手牌。",
    "<b>Battlecry:</b> Add a random card to your hand <i>(from your opponent's class).</i>"
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39698
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_069 : SimTemplate //* Swashburglar
	{
		//Battlecry: Add a random class card to your hand (from your opponent's class).
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, own.own, true);
		}
	}
}