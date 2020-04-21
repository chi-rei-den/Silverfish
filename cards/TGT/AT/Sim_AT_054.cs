using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_054",
  "name": [
    "唤雾者伊戈瓦尔",
    "The Mistcaller"
  ],
  "text": [
    "<b>战吼：</b>使你的手牌和牌库里的所有随从获得+1/+1。",
    "<b>Battlecry:</b> Give all minions in your hand and deck +1/+1."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2618
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_054 : SimTemplate //* The Mistcaller
	{
		//Battlecry: Give all minions in your hand and deck +1/+1.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			if (own.own)
			{
				foreach (Handcard hc in p.owncards)
                {
                    if (hc.card.Type == CardType.MINION)
                    {
                        hc.addattack++;
                        hc.addHp++;
                    }
                }
			}
		}
	}
}