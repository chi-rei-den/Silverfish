using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_005",
  "name": [
    "恶魔之怒",
    "Demonwrath"
  ],
  "text": [
    "对所有非恶魔随从造成$2点\n伤害。",
    "[x]Deal $2 damage to all\nminions except Demons."
  ],
  "CardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2301
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_005 : SimTemplate //* Demonwrath
    {
        // Deal 2 damage to all non-Demon minions.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

            foreach (var m in p.ownMinions)
            {
                if (m.handcard.card.Race != Race.DEMON)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }

            foreach (var m in p.enemyMinions)
            {
                if (m.handcard.card.Race != Race.DEMON)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
        }
    }
}