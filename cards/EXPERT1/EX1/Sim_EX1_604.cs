

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_604",
  "name": [
    "暴乱狂战士",
    "Frothing Berserker"
  ],
  "text": [
    "每当一个随从\n受到伤害，便获得+1攻击力。",
    "Whenever a minion takes damage, gain +1 Attack."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 654
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_604 : SimTemplate //* frothingberserker
    {
        // Whenever a minion takes damage, gain +1 Attack.
        // if will be increase attack trigger in the game - rebuild it

        public override void onMinionGotDmgTrigger(Playfield p, Minion m, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            p.minionGetBuffed(m, anzOwnMinionsGotDmg + anzEnemyMinionsGotDmg - anzOwnHeroGotDmg - anzEnemyHeroGotDmg, 0);
        }
    }
}