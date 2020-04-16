using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_900",
  "name": [
    "灵魂歌者安布拉",
    "Spiritsinger Umbra"
  ],
  "text": [
    "在你召唤一个随从后，触发其<b>亡语</b>。",
    "After you summon a minion, trigger its <b>Deathrattle</b> effect."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41289
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_900 : SimTemplate //* Spiritsinger Umbra
	{
		//After you summon a minion, trigger its Deathrattle effect.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
                p.doDeathrattles(new List<Minion>() { summonedMinion });
            }
        }
    }
}