using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_025",
  "name": [
    "火山喷发",
    "Volcano"
  ],
  "text": [
    "造成$15点伤害，随机分配到所有随从身上。\n<b>过载：</b>（2）",
    "Deal $15 damage randomly split among all minions.\n<b>Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 5,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41159
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_025 : SimTemplate //* Volcano
    {
        //Deal $15 damage randomly split among all minions. Overload: (2)

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var dmg = ownplay ? p.getSpellDamageDamage(15) : p.getEnemySpellDamageDamage(15);

            var temp = new List<Minion>(p.ownMinions);
            temp.AddRange(p.enemyMinions);

            for (var i = 0; i < dmg; i++)
            {
                var surviving = 0;
                foreach (var m in temp.ToArray())
                {
                    if (m.Hp < 1)
                    {
                        continue;
                    }

                    p.minionGetDamageOrHeal(m, 1);
                    i++;
                    surviving++;
                    if (i >= dmg)
                    {
                        break;
                    }
                }

                if (surviving == 0)
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