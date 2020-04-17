using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_114",
  "name": [
    "斯尼德的伐木机",
    "Sneed's Old Shredder"
  ],
  "text": [
    "<b>亡语：</b>随机召唤一个<b>传说</b>随从。",
    "<b>Deathrattle:</b> Summon a random <b>Legendary</b> minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2082
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_114 : SimCard //* Sneed's Old Shredder
    {

        // Deathrattle: Summon a random legendary minion.
		
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_014);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos - 1, m.own); 
        }
    }
}