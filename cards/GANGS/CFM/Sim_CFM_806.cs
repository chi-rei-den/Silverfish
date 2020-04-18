using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_806",
  "name": [
    "拉希奥",
    "Wrathion"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>抽若干数量的牌，直到你抽到一张非龙牌。",
    "<b>Taunt</b>. <b>Battlecry:</b> Draw cards until you draw one that isn't a Dragon."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40603
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_806 : SimTemplate //* Wrathion
	{
		// Taunt. Battlecry: Draw cards until you draw one that isn't a Dragon.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(Chireiden.Silverfish.SimCard.None, m.own);
            p.drawACard(Chireiden.Silverfish.SimCard.None, m.own);
        }
    }
}