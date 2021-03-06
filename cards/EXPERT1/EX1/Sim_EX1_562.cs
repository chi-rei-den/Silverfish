using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_562",
  "name": [
    "奥妮克希亚",
    "Onyxia"
  ],
  "text": [
    "<b>战吼：</b>召唤数个1/1的雏龙，直到你的随从数量达到上限。",
    "<b>Battlecry:</b> Summon 1/1 Whelps until your side of the battlefield is full."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 363
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_562 : SimTemplate //onyxia
    {
        SimCard kid = CardIds.NonCollectible.Neutral.LeeroyJenkins_WhelpToken; //whelp

//    kampfschrei:/ ruft welplinge (1/1) herbei, bis eure seite des schlachtfelds voll ist.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var kids = 7 - p.ownMinions.Count;

            for (var i = 0; i < kids; i++)
            {
                p.callKid(this.kid, own.zonepos, own.own);
            }
        }
    }
}