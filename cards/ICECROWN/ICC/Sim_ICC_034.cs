using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_034",
  "name": [
    "傲慢的十字军",
    "Arrogant Crusader"
  ],
  "text": [
    "<b>亡语：</b>如果此时是你对手的回合，则召唤一个2/2的食尸鬼。",
    "<b>Deathrattle:</b> If it's your opponent's turn, summon a 2/2 Ghoul."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42462
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_034 : SimTemplate //* Arrogant Crusader
    {
        // Deathrattle: If it's your opponent's turn, summon a 2/2 Ghoul.

        SimCard kid = CardIds.NonCollectible.Neutral.NecroticGeist_GhoulToken; //Ghoul 2/2

        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (!p.isOwnTurn)
            {
                p.callKid(this.kid, m.zonepos, m.own);
            }
        }
    }
}