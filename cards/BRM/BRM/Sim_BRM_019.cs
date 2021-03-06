using Chireiden.Silverfish;
using HearthDb;

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
  "CardClass": "NEUTRAL",
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
    class Sim_BRM_019 : SimTemplate //* Grim Patron
    {
        // Whenever this minion survives damage, summon another Grim Patron.

        SimCard kid = CardIds.Collectible.Neutral.GrimPatron; //Grim Patron

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.anzGotDmg > 0 && m.Hp > 0)
            {
                var tmp = m.anzGotDmg;
                m.anzGotDmg = 0;
                for (var i = 0; i < tmp; i++)
                {
                    p.callKid(this.kid, m.zonepos, m.own);
                }
            }
        }
    }
}