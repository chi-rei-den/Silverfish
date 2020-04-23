using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_114",
  "name": [
    "顺劈斩",
    "Cleave"
  ],
  "text": [
    "随机对两个敌方随从造成\n$2点伤害。",
    "[x]Deal $2 damage to\ntwo random enemy\nminions."
  ],
  "CardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 940
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_114 : SimTemplate //cleave
    {
//    fügt zwei zufälligen feindlichen dienern $2 schaden zu.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            //TODO delete new list
            var damage = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            var temp2 = ownplay ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp2.Sort((a, b) => a.Hp.CompareTo(b.Hp));
            var i = 0;
            foreach (var enemy in temp2)
            {
                p.minionGetDamageOrHeal(enemy, damage);
                i++;
                if (i == 2)
                {
                    break;
                }
            }
        }
    }
}