

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_034",
  "name": [
    "光照元素",
    "Radiant Elemental"
  ],
  "text": [
    "你的法术的法力值消耗减少（1）点。",
    "Your spells cost (1) less."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41176
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_034 : SimTemplate //* Radiant Elemental
    {
        // Your spells cost (1) less.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownSpelsCostMore--;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownSpelsCostMore++;
            }
        }
    }
}