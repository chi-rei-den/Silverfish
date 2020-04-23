using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_099",
  "name": [
    "科多兽骑手",
    "Kodorider"
  ],
  "text": [
    "<b>激励：</b>召唤一个3/5的作战科多兽。",
    "<b>Inspire:</b> Summon a 3/5 War Kodo."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2598
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_099 : SimTemplate //* Kodorider
    {
        //Inspire: Summon a 3/5 War Kodo.

        SimCard kid = CardIds.NonCollectible.Neutral.Kodorider_WarKodoToken; //War Kodo

        public override void onInspire(Playfield p, Minion m, bool own)
        {
            if (m.own == own)
            {
                p.callKid(this.kid, m.zonepos, own);
            }
        }
    }
}