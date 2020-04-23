

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_706",
  "name": [
    "蛛魔拆解者",
    "Nerubian Unraveler"
  ],
  "text": [
    "法术的法力值消耗增加（2）点。",
    "Spells cost (2) more."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42791
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_706 : SimTemplate //* Nerubian Unraveler
    {
        // Spells cost (2) more.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            p.ownSpelsCostMore += 2;
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            p.ownSpelsCostMore -= 2;
        }
    }
}