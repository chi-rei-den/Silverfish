using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_053",
  "name": [
    "先祖知识",
    "Ancestral Knowledge"
  ],
  "text": [
    "抽两张牌。<b>过载：</b>（2）",
    "Draw 2 cards. <b>Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2514
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_053 : SimTemplate //* Ancestral Knowledge
	{
		//Draw 2 Cards. Overload: (2)
		
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            p.drawACard(SimCard.None, ownplay);
            p.drawACard(SimCard.None, ownplay);
			if (ownplay) p.ueberladung += 2;
		}
	}
}