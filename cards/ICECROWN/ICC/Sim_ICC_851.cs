using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_851",
  "name": [
    "凯雷塞斯王子",
    "Prince Keleseth"
  ],
  "text": [
    "<b>战吼：</b>如果你的牌库里没有法力值消耗为（2）的牌，则你的牌库里所有随从牌获得+1/+1。",
    "<b>Battlecry:</b> If your deck has no 2-Cost cards, give all minions in your deck +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45340
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_851: SimTemplate //* Prince Keleseth
    {
        // Battlecry: If your deck has no 2-cost cards, give all minions in your deck +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own && p.prozis.getDeckCardsForCost(2) == CardDB.cardIDEnum.None) p.evaluatePenality -= 20;
        }
    }
}