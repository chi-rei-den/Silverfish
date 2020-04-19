using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_202",
  "name": [
    "泥潭守护者",
    "Mire Keeper"
  ],
  "text": [
    "<b>抉择：</b>召唤一个2/2的泥浆怪；或者获得一个空的法力水晶。",
    "[x]<b>Choose One -</b> Summon a\n2/2 Slime; or Gain an\nempty Mana Crystal."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38718
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_202 : SimTemplate //* Mire Keeper
    {
        //Choose One - Summon a 2/2 Slime; or Gain an empty Mana Crystal.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Neutral.FalloutSlime;

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (choice == 2 || (p.ownFandralStaghelm > 0 && own.own))
            {
                if (own.own)
                {
                    if (p.ownMaxMana > 8) p.evaluatePenality += 15;
                    p.ownMaxMana = Math.Min(10, p.ownMaxMana + 1);
                }
                else p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + 1);
            }
            
            if (choice == 1 || (p.ownFandralStaghelm > 0 && own.own))
            {
                p.callKid(kid, own.zonepos, own.own);
            }
        }
    }
}