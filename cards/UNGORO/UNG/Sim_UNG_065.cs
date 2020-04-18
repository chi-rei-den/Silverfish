using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_065",
  "name": [
    "“尸魔花”瑟拉金",
    "Sherazin, Corpse Flower"
  ],
  "text": [
    "<b>亡语：</b>进入<b>休眠</b>状态。在一回合中使用四张牌可唤醒该随从。",
    "<b>Deathrattle:</b> Go <b>Dormant</b>. Play 4 cards in a turn to revive this minion."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41218
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_065 : SimTemplate //* Sherazin, Corpse Flower
	{
		//Deathrattle: Go dormant. Play 4 cards in a turn to revive this minion.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Rogue.SherazinCorpseFlower_SherazinSeedToken; //Sherazin, Seed

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos - 1, m.own);
        }
    }
}