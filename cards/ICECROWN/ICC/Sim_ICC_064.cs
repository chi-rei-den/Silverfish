using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_064",
  "name": [
    "血刃剃刀",
    "Blood Razor"
  ],
  "text": [
    "[x]<b>战吼，亡语：</b>\n对所有随从造成\n1点伤害。",
    "<b>Battlecry and Deathrattle:</b>\nDeal 1 damage to all minions."
  ],
  "cardClass": "WARRIOR",
  "type": "WEAPON",
  "cost": 4,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42700
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_064: SimTemplate //* Blood Razor
    {
        // Battlecry and Deathrattle: Deal 1 damage to all minions.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_064);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);

            p.allMinionsGetDamage(1);
            p.doDmgTriggers();
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.allMinionsGetDamage(1);
            p.doDmgTriggers();
        }
    }
}