using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_050",
  "name": [
    "灌魔之锤",
    "Charged Hammer"
  ],
  "text": [
    "<b>亡语：</b>你的英雄技能改为“造成\n2点伤害”。",
    "<b>Deathrattle:</b> Your Hero Power becomes 'Deal 2 damage.'"
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 4,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2617
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_050 : SimTemplate //* Charged Hammer
    {
        //Deathrattle: Your Hero Power becomes 'Deal 2 damage.'

        Chireiden.Silverfish.SimCard weapon = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.AT_050);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.setNewHeroPower(Chireiden.Silverfish.SimCard.AT_050t, m.own); // Lightning Jolt
        }
    }
}