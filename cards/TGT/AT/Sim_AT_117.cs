using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_117",
  "name": [
    "庆典司仪",
    "Master of Ceremonies"
  ],
  "text": [
    "<b>战吼：</b>如果你控制任何具有<b>法术伤害</b>的随从，便获得+2/+2。",
    "<b>Battlecry:</b> If you have a minion with <b>Spell Damage</b>, gain +2/+2."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2493
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_117 : SimCard //* Master of Ceremonies
    {
		//Battlecry: If you have a minion with Spell Damage, gain +2/+2.
		
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp  = (own.own) ? p.ownMinions : p.enemyMinions;
            int gain = 0;
            foreach (Minion m in temp)
            {
                if (m.spellpower > 0) gain++;
            }
            if(gain>=1) p.minionGetBuffed(own, gain*2, gain*2);
        }
    }
}