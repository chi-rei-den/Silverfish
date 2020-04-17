using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_109",
  "name": [
    "小个子法师",
    "Mini-Mage"
  ],
  "text": [
    "<b>潜行，法术伤害+1</b>",
    "<b>Stealth</b>\n<b>Spell Damage +1</b>"
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2077
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_109 : SimCard //Mini-Mage
    {

        //   Stealth Spell Damage +1
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