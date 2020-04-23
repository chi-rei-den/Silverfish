using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_405",
  "name": [
    "腐面",
    "Rotface"
  ],
  "text": [
    "在该随从受到伤害并没有死亡后，随机召唤一个<b>传说</b>随从。",
    "[x]After this minion\nsurvives damage,\nsummon a random\n<b>Legendary</b> minion."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42630
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_405 : SimTemplate //* Rotface
    {
        // Whenever this minion survives damage, summon a random Legendary minion.

        SimCard kid = CardIds.Collectible.Neutral.KingMukla; //King Mukla 5/5

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