using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "DS1_183",
  "name": [
    "多重射击",
    "Multi-Shot"
  ],
  "text": [
    "随机对两个敌方随从造成$3点\n伤害。",
    "Deal $3 damage to two random enemy minions."
  ],
  "CardClass": "HUNTER",
  "type": "SPELL",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 292
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DS1_183 : SimTemplate //multishot
    {
//    fügt zwei zufälligen feindlichen dienern $3 schaden zu.
        //todo new list
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var damage = ownplay ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
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