using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_062",
  "name": [
    "污手街守护者",
    "Grimestreet Protector"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>使相邻的随从获得<b>圣盾</b>。",
    "[x]<b>Taunt</b>\n<b>Battlecry:</b> Give adjacent\n minions <b>Divine Shield</b>."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 7,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40295
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_062 : SimCard //* Grimestreet Protector
	{
		// Battlecry: Give adjacent minions Divine Shield.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            foreach (Minion mnn in temp)
            {
                if (mnn.zonepos == m.zonepos - 1 || mnn.zonepos == m.zonepos + 1)
                {
                    mnn.divineshild = true;
                }
            }
        }
    }
}