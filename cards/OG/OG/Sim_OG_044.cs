

/* _BEGIN_TEMPLATE_
{
  "id": "OG_044",
  "name": [
    "范达尔·鹿盔",
    "Fandral Staghelm"
  ],
  "text": [
    "你的<b>抉择</b>牌和英雄技能可以同时拥有两种效果。",
    "Your <b>Choose One</b> cards and powers have both effects combined."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38318
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_044 : SimTemplate //* Fandral Staghelm
    {
        //Your Choose One cards have both effects combine.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownFandralStaghelm++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.ownFandralStaghelm--;
            }
        }
    }
}