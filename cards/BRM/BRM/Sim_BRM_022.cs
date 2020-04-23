using Chireiden.Silverfish;
using HearthDb;

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
  "CardClass": "NEUTRAL",
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

        SimCard kid = CardIds.NonCollectible.Neutral.DragonEgg_BlackWhelpToken; //Black Whelp

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