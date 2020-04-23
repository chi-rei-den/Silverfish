

/* _BEGIN_TEMPLATE_
{
  "id": "OG_322",
  "name": [
    "黑水海盗",
    "Blackwater Pirate"
  ],
  "text": [
    "你的武器法力值消耗减少（2）点。",
    "Your weapons cost (2) less."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38960
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_322 : SimTemplate //* Blackwater Pirate
    {
        //Your weapons cost (2) less.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.blackwaterpirate++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.blackwaterpirate--;
            }
        }
    }
}