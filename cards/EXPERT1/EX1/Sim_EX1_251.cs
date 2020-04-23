using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_251",
  "name": [
    "叉状闪电",
    "Forked Lightning"
  ],
  "text": [
    "随机对两个敌方随从造成$2点伤害，<b>过载：</b>（2）",
    "Deal $2 damage to 2 random enemy minions. <b>Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 299
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_251 : SimTemplate //forkedlightning
    {
//    fügt zwei zufälligen feindlichen dienern $2 schaden zu. überladung:/ (2)
        //todo list
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var damage = ownplay ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            var temp2 = new List<Minion>(p.enemyMinions);
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

            if (ownplay)
            {
                p.ueberladung += 2;
            }
        }
    }
}