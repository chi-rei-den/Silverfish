using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "BOT_909",
  "name": [
    "水晶学",
    "Crystology"
  ],
  "text": [
    "从你的牌库中抽两张攻击力为1的随从牌。",
    "[x]Draw two 1-Attack\nminions from your deck."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 48985
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BOT_909 : SimCard //* 水晶学 Crystology
	{
		//[x]Draw two 1-Attackminions from your deck.
		//从你的牌库中抽两张攻击力为1的随从牌。
     public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)


{


p.drawACard(CardDB.cardIDEnum.None, ownplay);


p.drawACard(CardDB.cardIDEnum.None, ownplay);


}


	}
}