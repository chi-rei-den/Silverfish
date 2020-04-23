

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_243",
  "name": [
    "巨型尸蛛",
    "Corpse Widow"
  ],
  "text": [
    "你的<b>亡语</b>牌的法力值消耗减少（2）点。",
    "Your <b>Deathrattle</b> cards cost (2) less."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42822
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_243 : SimTemplate //* Corpse Widow
    {
        // Your Deathrattle cards cost (2) less.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownDRcardsCostMore -= 2;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownDRcardsCostMore += 2;
            }
        }
    }
}