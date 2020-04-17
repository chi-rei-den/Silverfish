using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_021",
  "name": [
    "死亡之咬",
    "Death's Bite"
  ],
  "text": [
    "<b>亡语：</b>对所有随从造成1点伤害。",
    "<b>Deathrattle:</b> Deal 1 damage to all minions."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 4,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1805
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_021 : SimCard//* Death's Bite
    {
        //Deathrattle: Deal 1 damage to all minions.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_021);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
        
        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
            p.doDmgTriggers();
        }
    }
}
