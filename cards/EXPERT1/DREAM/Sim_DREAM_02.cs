using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "DREAM_02",
  "name": [
    "伊瑟拉苏醒",
    "Ysera Awakens"
  ],
  "text": [
    "对除了伊瑟拉之外的所有角色造成$5点伤害。",
    "Deal $5 damage to all characters except Ysera."
  ],
  "cardClass": "DREAM",
  "type": "SPELL",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 301
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DREAM_02 : SimTemplate //yseraawakens
    {
//    fügt allen charakteren mit ausnahme von ysera $5 schaden zu.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(5) : p.getEnemySpellDamageDamage(5);
            foreach (var m in p.ownMinions)
            {
                if (m.name != CardIds.Collectible.Neutral.Ysera)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }

            foreach (var m in p.enemyMinions)
            {
                if (m.name != CardIds.Collectible.Neutral.Ysera)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }

            p.minionGetDamageOrHeal(p.ownHero, dmg);
            p.minionGetDamageOrHeal(p.enemyHero, dmg);
        }
    }
}