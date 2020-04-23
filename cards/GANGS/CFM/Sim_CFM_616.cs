using System;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_616",
  "name": [
    "妙手空空",
    "Pilfered Power"
  ],
  "text": [
    "每控制一个友方随从，便获得一个空的法力水晶。",
    "Gain an empty Mana Crystal for each friendly minion."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40401
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_616 : SimTemplate //* Pilfered Power
    {
        // Gain an empty Mana Crystal for each friendly minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.ownMaxMana = Math.Min(10, p.ownMaxMana + p.ownMinions.Count);
            }
            else
            {
                p.enemyMaxMana = Math.Min(10, p.enemyMaxMana + p.enemyMinions.Count);
            }
        }
    }
}