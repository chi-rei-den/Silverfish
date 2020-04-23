

/* _BEGIN_TEMPLATE_
{
  "id": "AT_056",
  "name": [
    "强风射击",
    "Powershot"
  ],
  "text": [
    "对一个随从及其相邻的随从造成$2点伤害。",
    "Deal $2 damage to a minion and the minions next to it."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2638
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_056 : SimTemplate //* Powershot
    {
        //Deal 2 damage to a minion and the minions next to it.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            p.minionGetDamageOrHeal(target, dmg);

            var temp = target.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (target.zonepos == m.zonepos + 1 || target.zonepos + 1 == m.zonepos)
                {
                    p.minionGetDamageOrHeal(m, dmg);
                }
            }
        }
    }
}