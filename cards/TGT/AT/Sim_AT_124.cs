

/* _BEGIN_TEMPLATE_
{
  "id": "AT_124",
  "name": [
    "博尔夫·碎盾",
    "Bolf Ramshield"
  ],
  "text": [
    "每当你的英雄受到伤害，便会由该随从来承担。",
    "Whenever your hero takes damage, this minion takes it instead."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2595
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_124 : SimTemplate //* Bolf Ramshield
    {
        //Whenever your hero takes damage, this minion takes it instead.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnBolfRamshield++;
            }
            else
            {
                p.anzEnemyBolfRamshield++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnBolfRamshield--;
            }
            else
            {
                p.anzEnemyBolfRamshield--;
            }
        }
    }
}