using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_012",
  "name": [
    "淤泥喷射者",
    "Sludge Belcher"
  ],
  "text": [
    "<b>嘲讽，亡语：</b>召唤一个1/2并具有<b>嘲讽</b>的泥浆怪。",
    "<b>Taunt\nDeathrattle:</b> Summon a 1/2 Slime with <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1793
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_012 : SimTemplate //* Sludge Belcher
    {
        //Taunt. Deathrattle: Summon a 1/2 Slime with Taunt.

        SimCard c = CardIds.NonCollectible.Neutral.SludgeBelcher_PutridSlimeToken;

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(this.c, m.zonepos - 1, m.own);
        }
    }
}