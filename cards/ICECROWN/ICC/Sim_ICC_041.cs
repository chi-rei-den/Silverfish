using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_041",
  "name": [
    "亵渎",
    "Defile"
  ],
  "text": [
    "对所有随从造成$1点伤害，如果有随从死亡，则再次施放该法术。",
    "Deal $1 damage to all minions. If any die, cast this again."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42471
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_041: SimCard //* Defile
    {
        // Deal 1 damage to all minions. If any die, cast this again.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            int count = p.tempTrigger.ownMinionsDied + p.tempTrigger.enemyMinionsDied;
            int nextcount = 0;
            bool repeat;
            do
            {
                repeat = false;
                p.allMinionsGetDamage(dmg);
                nextcount = p.tempTrigger.ownMinionsDied + p.tempTrigger.enemyMinionsDied;
                if (nextcount > count) repeat = true;
                count = nextcount;
                if (count == (p.ownMinions.Count + p.enemyMinions.Count)) break;
            }
            while (repeat);
        }
    }
}