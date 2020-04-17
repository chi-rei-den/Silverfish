using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_070",
  "name": [
    "托维尔塑石师",
    "Tol'vir Stoneshaper"
  ],
  "text": [
    "<b>战吼：</b>如果你在上个回合使用过元素牌，则获得<b>嘲讽</b>和<b>圣盾</b>。",
    "[x]<b>Battlecry:</b> If you played an\nElemental last turn, gain\n <b>Taunt</b> and <b>Divine Shield</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41241
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_070 : SimCard //* Tol'vir Stoneshaper
	{
		//Battlecry: If you played an Elemental last turn, gain Taunt and Divine Shield.


        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own)
			{
				own.divineshild = true;
				own.taunt = true;
                p.anzOwnTaunt++;
			}
        }
    }
}