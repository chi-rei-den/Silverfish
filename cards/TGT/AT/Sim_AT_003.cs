

/* _BEGIN_TEMPLATE_
{
  "id": "AT_003",
  "name": [
    "英雄之魂",
    "Fallen Hero"
  ],
  "text": [
    "你的英雄技能会额外造成1点伤害。",
    "Your Hero Power deals 1 extra damage."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2545
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_003 : SimTemplate //* Fallen Hero
    {
        //Your Hero Power deals 1 extra damage.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownHeroPowerExtraDamage++;
            }
            else
            {
                p.enemyHeroPowerExtraDamage++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownHeroPowerExtraDamage--;
            }
            else
            {
                p.enemyHeroPowerExtraDamage--;
            }
        }
    }
}