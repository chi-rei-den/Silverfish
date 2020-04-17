using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_019",
  "name": [
    "恐怖的奴隶主",
    "Grim Patron"
  ],
  "text": [
    "在该随从受到伤害并没有死亡后，召唤另一个恐怖的奴隶主。",
    "After this minion survives damage, summon another Grim Patron."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2279
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_019 : SimCard //* Grim Patron
	{
		// Whenever this minion survives damage, summon another Grim Patron.

		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.BRM_019);//Grim Patron

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0 && m.Hp > 0)
            {
                int tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (int i = 0; i < tmp; i++)
                {
                    p.callKid(kid, m.zonepos, m.own);
                }
            }
        }
	}
}