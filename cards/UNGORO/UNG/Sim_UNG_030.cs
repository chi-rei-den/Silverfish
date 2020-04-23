

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_030",
  "name": [
    "联结治疗",
    "Binding Heal"
  ],
  "text": [
    "为你的英雄和一个随从恢复#5点生命值。",
    "Restore #5 Health to a minion and your hero."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41170
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_030 : SimTemplate //* Binding Heal
    {
        //Restore #5 Health to a minion and your hero.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var heal = ownplay ? p.getSpellHeal(5) : p.getEnemySpellHeal(5);

            if (target != null)
            {
                p.minionGetDamageOrHeal(target, -heal);
            }

            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -heal);
        }
    }
}