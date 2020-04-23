using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_006",
  "name": [
    "小鬼首领",
    "Imp Gang Boss"
  ],
  "text": [
    "每当该随从受到伤害，召唤一个1/1的\n小鬼。",
    "Whenever this minion takes damage, summon a 1/1 Imp."
  ],
  "CardClass": "WARLOCK",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2288
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_006 : SimTemplate //* Imp Gang Boss
    {
        // Whenever this minion takes damage, summon a 1/1 Imp.

        SimCard kid = CardIds.NonCollectible.Warlock.ImpGangBoss_ImpToken; //imp

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0)
            {
                var tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (var i = 0; i < tmp; i++)
                {
                    var pos = m.zonepos;
                    p.callKid(this.kid, pos, m.own);
                }
            }
        }
    }
}