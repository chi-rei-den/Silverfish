using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_022",
  "name": [
    "龙蛋",
    "Dragon Egg"
  ],
  "text": [
    "每当该随从受到伤害，便召唤一条2/1的雏龙。",
    "Whenever this minion takes damage, summon a 2/1 Whelp."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2278
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_022 : SimTemplate //* Dragon Egg
	{
		// Whenever this minion takes damage, summon a 2/1 Whelp.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_022t); //Black Whelp

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
					int pos = m.zonepos;
					p.callKid(kid, pos, m.own);
                }
            }
        }
	}
}