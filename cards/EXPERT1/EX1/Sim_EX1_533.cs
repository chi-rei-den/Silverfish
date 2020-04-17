using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_533",
  "name": [
    "误导",
    "Misdirection"
  ],
  "text": [
    "<b>奥秘：</b>当一个敌人攻击你的英雄时，改为该敌人随机攻击另一个角色。",
    "<b>Secret:</b> When an enemy attacks your hero, instead it attacks another random character."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1091
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_533 : SimCard//Misdirection
    {
        public override void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
            Minion newTarget = null;
            if (ownplay)
            {
                foreach (Minion m in p.enemyMinions)
                {
                    if (target.entitiyID != m.entitiyID && attacker.entitiyID != m.entitiyID)
                    {
                        newTarget = m;
                    }
                }

                if (newTarget == null)
                {
                    foreach (Minion m in p.ownMinions)
                    {
                        if (target.entitiyID != m.entitiyID && attacker.entitiyID != m.entitiyID)
                        {
                            newTarget = m;
                        }
                    }
                }

                if (newTarget == null)
                {
                    newTarget = p.enemyHero;
                }
            }

            else
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (target.entitiyID != m.entitiyID && attacker.entitiyID != m.entitiyID)
                    {
                        newTarget = m;
                    }
                }

                if (newTarget == null)
                {
                    foreach (Minion m in p.enemyMinions)
                    {
                        if (target.entitiyID != m.entitiyID && attacker.entitiyID != m.entitiyID)
                        {
                            newTarget = m;
                        }
                    }
                }

                if (newTarget == null)
                {
                    newTarget = p.ownHero;
                }
            }


            if (newTarget != null)
            {
                number = newTarget.entitiyID;
            }
        }

    }

}
