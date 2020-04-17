using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_468",
  "name": [
    "失心农夫",
    "Wretched Tiller"
  ],
  "text": [
    "每当该随从进行攻击，对敌方英雄造成2点伤害。",
    "Whenever this minion attacks, deal 2 damage to the enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42398
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_468: SimCard //* Wretched Tiller
    {
        // Whenever this minion attacks, deal 2 damage to the enemy hero.
        //done in triggerAMinionIsGoingToAttack

    }
}