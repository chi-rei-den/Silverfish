using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_016",
  "name": [
    "船长的鹦鹉",
    "Captain's Parrot"
  ],
  "text": [
    "<b>战吼：</b>从你的牌库中抽一张海盗牌，并将其置入你的手牌。",
    "<b>Battlecry:</b> Draw a Pirate from your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "HOF",
  "collectible": true,
  "dbfId": 530
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NEW1_016 : SimTemplate //captainsparrot
	{

//    kampfschrei:/ fügt eurer hand einen zufälligen piraten aus eurem deck hinzu.
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, true, true);
		}


	}
}