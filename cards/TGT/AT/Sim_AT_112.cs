using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_112",
  "name": [
    "大师级枪骑士",
    "Master Jouster"
  ],
  "text": [
    "<b>战吼：</b>揭示双方牌库里的一张随从牌。如果你的牌法力值消耗较大，则获得<b>嘲讽</b>和<b>圣盾</b>。",
    "<b>Battlecry:</b> Reveal a minion in each deck. If yours costs more, gain <b>Taunt</b> and <b>Divine Shield</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2507
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_112 : SimCard //* Master Jouster
	{
		//Battlecry : Reveal a minion in each deck. If yours costs more, gain Taunt and Divine Shield.
			
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			own.divineshild = true; // optimistic
            if (!own.taunt)
            {
                own.taunt = true;
                if (own.own) p.anzOwnTaunt++;
                else p.anzEnemyTaunt++;
            }
        }
	}
}