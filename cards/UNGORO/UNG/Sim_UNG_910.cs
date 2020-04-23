

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_910",
  "name": [
    "凶残撕咬",
    "Grievous Bite"
  ],
  "text": [
    "对一个随从造成$2点伤害，并对其相邻的随从\n造成$1点伤害。",
    "Deal $2 damage to a minion and $1 damage to adjacent ones."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41350
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_910 : SimTemplate //* Grievous Bite
    {
        //Deal $2 damage to a minion and $1 damage to adjacent ones.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmgMain = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            var dmgAdj = ownplay ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            var temp = target.own ? p.ownMinions : p.enemyMinions;
            p.minionGetDamageOrHeal(target, dmgMain);
            foreach (var m in temp)
            {
                if (m.zonepos + 1 == target.zonepos || m.zonepos - 1 == target.zonepos)
                {
                    p.minionGetDamageOrHeal(m, dmgAdj);
                }
            }
        }
    }
}