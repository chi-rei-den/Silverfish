using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_130",
  "name": [
    "崇高牺牲",
    "Noble Sacrifice"
  ],
  "text": [
    "<b>奥秘：</b>当一个敌人攻击时，召唤一个2/1的防御者，并使其成为攻击的目标。",
    "<b>Secret:</b> When an enemy attacks, summon a 2/1 Defender as the new target."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 584
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_130 : SimTemplate //* noblesacrifice
    {
        //Secret: When an enemy attacks, summon a 2/1 Defender as the new target.

        SimCard kid = CardIds.NonCollectible.Paladin.NobleSacrifice_Defender;

        public override void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
            if (ownplay)
            {
                int pos = p.ownMinions.Count;
                p.callKid(kid, pos, true, true, true);
                if (p.ownMinions.Count >= 1)
                {
                    if (p.ownMinions[p.ownMinions.Count - 1].name == SimCard.defender)
                    {
                        number = p.ownMinions[p.ownMinions.Count - 1].entitiyID;
                    }
                }
            }
            else
            {
                int pos = p.enemyMinions.Count;
                p.callKid(kid, pos, false, true, true);

                if (p.enemyMinions.Count >= 1)
                {
                    if (p.enemyMinions[p.enemyMinions.Count - 1].name == SimCard.defender)
                    {
                        number = p.enemyMinions[p.enemyMinions.Count - 1].entitiyID;
                    }
                }
            }
        }
    }
}