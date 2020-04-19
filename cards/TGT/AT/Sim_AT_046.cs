using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_046",
  "name": [
    "海象人图腾师",
    "Tuskarr Totemic"
  ],
  "text": [
    "<b>战吼：</b>随机召唤一个基础图腾。",
    "<b>Battlecry:</b> Summon a random basic Totem."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2513
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_046 : SimTemplate //* Tuskarr Totemic
    {
        //Battlecry: Summon a random basic Totem.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Shaman.SearingTotem;//Searing Totem

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(kid, own.zonepos, own.own);
        }
    }
}