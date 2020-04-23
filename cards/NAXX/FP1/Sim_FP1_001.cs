

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_001",
  "name": [
    "肉用僵尸",
    "Zombie Chow"
  ],
  "text": [
    "<b>亡语：</b>为敌方英雄恢复#5点生命值。",
    "<b>Deathrattle:</b> Restore #5 Health to the enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1753
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_001 : SimTemplate //zombiechow
    {
        //    todesröcheln:/ stellt beim feindlichen helden 5 leben wieder her.
        public override void onDeathrattle(Playfield p, Minion m)
        {
            var heal = m.own ? p.getMinionHeal(5) : p.getEnemyMinionHeal(5);

            p.minionGetDamageOrHeal(m.own ? p.enemyHero : p.ownHero, -heal);
        }
    }
}