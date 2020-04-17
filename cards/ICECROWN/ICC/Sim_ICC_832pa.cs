using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_832pa",
  "name": [
    "甲虫硬壳",
    "Scarab Shell"
  ],
  "text": [
    "+3护甲值。",
    "+3 Armor."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 7,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 46050
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_832pa: SimCard //* Scarab Shell
    {
        // +3 Armor.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay) p.minionGetArmor(p.ownHero, 3);
            else p.minionGetArmor(p.enemyHero, 3);
        }
    }
}