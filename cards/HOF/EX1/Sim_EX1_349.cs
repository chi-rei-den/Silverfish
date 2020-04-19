using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_349",
  "name": [
    "神恩术",
    "Divine Favor"
  ],
  "text": [
    "抽若干数量的牌，直到你的手牌数量等同于你对手的手牌数量。",
    "Draw cards until you have as many in hand as your opponent."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "HOF",
  "collectible": true,
  "dbfId": 679
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_349 : SimTemplate //divinefavor
	{

//    zieht so viele karten, bis ihr genauso viele karten auf eurer hand habt wie euer gegner.
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int diff = (ownplay) ? p.enemyAnzCards - p.owncards.Count :  p.owncards.Count - p.enemyAnzCards;
            if (diff >= 1)
            {
                for (int i = 0; i < diff; i++)
                {
                    //this.owncarddraw++;
                    p.drawACard(SimCard.None, ownplay);
                }
            }
		}

	}
}