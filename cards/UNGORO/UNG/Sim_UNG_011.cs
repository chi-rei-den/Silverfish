using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_011",
  "name": [
    "水文学家",
    "Hydrologist"
  ],
  "text": [
    "<b>战吼：</b>\n<b>发现</b>一张<b>奥秘</b>牌。",
    "<b>Battlecry:</b> <b>Discover</b> a <b>Secret</b>."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41139
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_011 : SimTemplate //* Hydrologist
	{
		//Battlecry: Discover a Secret.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, ownplay, true);
        }
    }
}