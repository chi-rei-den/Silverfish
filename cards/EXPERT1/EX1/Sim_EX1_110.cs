using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_110",
  "name": [
    "凯恩·血蹄",
    "Cairne Bloodhoof"
  ],
  "text": [
    "<b>亡语：</b>召唤一个4/5的贝恩·血蹄。",
    "<b>Deathrattle:</b> Summon a 4/5 Baine Bloodhoof."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 420
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_110 : SimTemplate //* cairnebloodhoof
    {
        //Deathrattle: Summon a 4/5 Baine Bloodhoof.

        SimCard blaine = CardIds.NonCollectible.Neutral.CairneBloodhoof_BaineBloodhoofToken;

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(this.blaine, m.zonepos - 1, m.own);
        }
    }
}