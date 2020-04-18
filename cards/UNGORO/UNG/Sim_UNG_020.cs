using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_020",
  "name": [
    "秘法学家",
    "Arcanologist"
  ],
  "text": [
    "<b>战吼：</b>从你的牌库中抽一张<b>奥秘</b>牌。",
    "<b>Battlecry:</b> Draw a <b>Secret</b> from your deck."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41153
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_020 : SimTemplate //* Arcanologist
	{
		//Battlecry: Draw a Secret from your deck.

		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(Chireiden.Silverfish.SimCard.None, own.own);
		}
	}
}