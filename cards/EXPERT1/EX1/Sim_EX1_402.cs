

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_402",
  "name": [
    "铸甲师",
    "Armorsmith"
  ],
  "text": [
    "每当一个友方随从受到伤害，便获得1点护甲值。",
    "Whenever a friendly minion takes damage, gain 1 Armor."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 596
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_402 : SimTemplate //* armorsmith
    {
        // Whenever a friendly minion takes damage, gain 1 Armor.

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            if (m.own)
            {
                for (var i = 0; i < anzOwnMinionsGotDmg - anzOwnHeroGotDmg; i++)
                {
                    p.minionGetArmor(p.ownHero, 1);
                }
            }
            else
            {
                for (var i = 0; i < anzEnemyMinionsGotDmg - anzEnemyHeroGotDmg; i++)
                {
                    p.minionGetArmor(p.enemyHero, 1);
                }
            }
        }
    }
}