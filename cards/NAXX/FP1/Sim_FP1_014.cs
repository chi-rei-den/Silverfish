using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_014",
  "name": [
    "斯塔拉格",
    "Stalagg"
  ],
  "text": [
    "<b>亡语：</b>如果费尔根也在本局对战中死亡，召唤塔迪乌斯。",
    "<b>Deathrattle:</b> If Feugen also died this game, summon Thaddius."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1796
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_FP1_014 : SimTemplate
	{
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.feugenDead)
            {
                p.callKid(CardIds.NonCollectible.Neutral.Stalagg_ThaddiusToken, m.zonepos - 1, m.own);
            }
        }
	}
}