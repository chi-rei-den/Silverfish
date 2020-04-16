using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_010",
  "name": [
    "维伦的恩泽",
    "Velen's Chosen"
  ],
  "text": [
    "使一个随从获得+2/+4和<b>法术伤害+1</b>。",
    "Give a minion +2/+4 and <b>Spell Damage +1</b>."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1935
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_010 : SimTemplate //Velen's Chosen
    {

        //    Give a minion +2/+4 and Spell Damage +1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 2, 4);
            target.spellpower++;
            if (target.own) p.spellpower++;
            else p.enemyspellpower++;

        }


    }

}