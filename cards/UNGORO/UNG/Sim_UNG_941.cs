using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_941",
  "name": [
    "远古雕文",
    "Primordial Glyph"
  ],
  "text": [
    "<b>发现</b>一张法术牌，使其法力值消耗减少（2）点。",
    "<b>Discover</b> a spell. Reduce its Cost by (2)."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41496
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_941 : SimTemplate //* Primordial Glyph
	{
		//Discover a spell. Reduce its Cost by (2).

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Mage.Frostbolt, ownplay, true);
        }
    }
}