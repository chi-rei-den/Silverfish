using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_354",
  "name": [
    "圣疗术",
    "Lay on Hands"
  ],
  "text": [
    "恢复#8点生命值，抽三张牌。",
    "Restore #8 Health. Draw 3 cards."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 8,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 594
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_354 : SimTemplate//lay on hands
    {

        //Stellt #8 Leben wieder her. Zieht 3 Karten.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (ownplay) ? p.getSpellHeal(8) : p.getEnemySpellHeal(8);
            p.minionGetDamageOrHeal(target, -heal);
            for (int i = 0; i < 3; i++)
            {
                //this.owncarddraw++;
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
            }
            
        }

    }
}
