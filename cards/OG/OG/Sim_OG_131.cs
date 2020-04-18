using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_131",
  "name": [
    "维克洛尔大帝",
    "Twin Emperor Vek'lor"
  ],
  "text": [
    "<b><b>嘲讽</b>，战吼：</b>如果你的克苏恩具有至少10点攻击力，则召唤另一名双子皇帝。",
    "[x]<b><b>Taunt</b>\nBattlecry:</b> If your C'Thun has\nat least 10 Attack, summon\nanother Emperor."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38488
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_131 : SimTemplate //* Twin Emperor Vek'lor
	{
		//Taunt Battlecry:If your C'Thun has at least 10 attack, summon another Emperor.

        Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.OG_319);
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.anzOgOwnCThunAngrBonus + 6 > 9) p.callKid(kid, own.zonepos, own.own);
                else p.evaluatePenality += 5;
            }
		}
	}
}