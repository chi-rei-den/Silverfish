using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_110",
  "name": [
    "砰砰博士",
    "Dr. Boom"
  ],
  "text": [
    "<b>战吼：</b>\n召唤两个1/1的砰砰机器人。<i>警告：该机器人随时可能爆炸。</i>",
    "<b>Battlecry:</b> Summon two 1/1 Boom Bots. <i>WARNING: Bots may explode.</i>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2078
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_110 : SimTemplate //Dr. Boom
    {

        //  Battlecry: Summon two 1/1 Boom Bots. WARNING: Bots may explode. 

        SimCard kid = CardIds.NonCollectible.Neutral.DrBoom_BoomBotToken;//chillwind

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(kid, own.zonepos, own.own);
            p.callKid(kid, own.zonepos - 1, own.own);
        }


    }

}