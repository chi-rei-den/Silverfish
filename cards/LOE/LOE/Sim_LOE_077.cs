

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_077",
  "name": [
    "布莱恩·铜须",
    "Brann Bronzebeard"
  ],
  "text": [
    "你的<b>战吼</b>会触发\n两次。",
    "Your <b>Battlecries</b> trigger twice."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "LEGENDARY",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2949
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_077 : SimTemplate //* Brann Bronzebeard
    {
        //Your Battlecries trigger twice.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownBrannBronzebeard++;
            }
            else
            {
                p.enemyBrannBronzebeard++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownBrannBronzebeard--;
            }
            else
            {
                p.enemyBrannBronzebeard--;
            }
        }
    }
}