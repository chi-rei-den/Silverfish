using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_398",
  "name": [
    "阿拉希武器匠",
    "Arathi Weaponsmith"
  ],
  "text": [
    "<b>战吼：</b>装备一把2/2的武器。",
    "<b>Battlecry:</b> Equip a 2/2 weapon."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 538
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_398 : SimCard//Arathi Weaponsmith
    {
        CardDB.Card wcard = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_398t);//battleaxe

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(wcard,own.own);

        }

    }
}
