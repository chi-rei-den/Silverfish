

/* _BEGIN_TEMPLATE_
{
  "id": "OG_082",
  "name": [
    "异变的狗头人",
    "Evolved Kobold"
  ],
  "text": [
    "<b>法术伤害+2</b>",
    "<b>Spell Damage +2</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "OG",
  "collectible": true,
  "dbfId": 38408
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_082 : SimTemplate //* Evolved Kobold
    {
        //Spell Damage +2

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.spellpower += 2;
            }
            else
            {
                p.enemyspellpower += 2;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower -= 2;
            }
            else
            {
                p.enemyspellpower -= 2;
            }
        }
    }
}