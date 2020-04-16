using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_324",
  "name": [
    "白眼大侠",
    "White Eyes"
  ],
  "text": [
    "<b>嘲讽，亡语：</b>\n将风暴守护者洗入你的牌库。",
    "<b>Taunt</b>\n<b>Deathrattle:</b> Shuffle\n'The Storm Guardian' into your deck."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40486
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_324 : SimTemplate //* White Eyes
	{
		// Taunt. Deathrattle: Shuffle 'The Storm Guardian' into your deck.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (m.own) p.ownDeckSize++;
            else p.enemyDeckSize++;
        }
    }
}