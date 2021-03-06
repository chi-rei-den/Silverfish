

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_197",
  "name": [
    "食人魔法师",
    "Ogre Magi"
  ],
  "text": [
    "<b>法术伤害+1</b>",
    "<b>Spell Damage +1</b>"
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 995
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_197 : SimTemplate //ogremagi
    {
//    zauberschaden +1/
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower--;
            }
            else
            {
                p.enemyspellpower--;
            }
        }
    }
}