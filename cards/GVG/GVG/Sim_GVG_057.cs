using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_057",
  "name": [
    "光明圣印",
    "Seal of Light"
  ],
  "text": [
    "为你的英雄恢复#4点生命值，并在本回合中\n获得+2攻击力。",
    "Restore #4 Health to your hero and gain +2 Attack this turn."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2025
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_057 : SimCard //Seal of Light
    {

        //   Restore #4 Health to your hero and gain +2 Attack this turn.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                int heal = p.getSpellHeal(4);
                p.minionGetDamageOrHeal(p.ownHero, -heal);
                p.minionGetTempBuff(p.ownHero, 2, 0);
            }
            else
            {
                int heal = p.getEnemySpellHeal(4);
                p.minionGetDamageOrHeal(p.enemyHero, -heal);
                p.minionGetTempBuff(p.enemyHero, 2, 0);
            }

        }


    }

}