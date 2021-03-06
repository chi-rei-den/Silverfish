using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_005",
  "name": [
    "慈祥的外婆",
    "Kindly Grandmother"
  ],
  "text": [
    "<b>亡语：</b>召唤一只3/2的大灰狼。",
    "<b>Deathrattle:</b> Summon a 3/2 Big Bad Wolf."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39481
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_005 : SimTemplate //* Kindly Grandmother
    {
        //Deathrattle: Summon a 3/2 Big Bad Wolf.

        SimCard kid = CardIds.NonCollectible.Hunter.KindlyGrandmother_BigBadWolf; //Big Bad Wolf

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(this.kid, m.zonepos - 1, m.own);
        }
    }
}