using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_408",
  "name": [
    "瓦格里摄魂者",
    "Val'kyr Soulclaimer"
  ],
  "text": [
    "在该随从受到伤害并没有死亡后，召唤一个2/2的食尸鬼。",
    "[x]After this minion\nsurvives damage,\nsummon a 2/2 Ghoul."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42671
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_408: SimTemplate //* Val'kyr Soulclaimer
    {
        // Whenever this minion survives damage, summon a 2/2 Ghoul

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.NecroticGeist_GhoulToken; //Ghoul 2/2

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