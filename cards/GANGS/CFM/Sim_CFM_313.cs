using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_313",
  "name": [
    "先到先得",
    "Finders Keepers"
  ],
  "text": [
    "<b>发现</b>一张具有<b>过载</b>的牌。\n<b>过载：</b> （1）",
    "<b>Discover</b> a card with <b>Overload</b>. <b>Overload:</b> (1)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40423
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_313 : SimCard //* Finders Keepers
	{
		// Discover a card with Overload. Overload: (1)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardName.lightningbolt, ownplay);
            if (ownplay) p.ueberladung++;
        }
    }
}