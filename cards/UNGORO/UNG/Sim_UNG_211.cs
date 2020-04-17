using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_211",
  "name": [
    "荒蛮之主卡利莫斯",
    "Kalimos, Primal Lord"
  ],
  "text": [
    "<b>战吼：</b>如果你在上个回合使用过元素牌，则施放一个元素祈咒。",
    "[x]<b>Battlecry:</b> If you played an\nElemental last turn, cast an\nElemental Invocation."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41331
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_211 : SimCard //* Kalimos, Primal Lord
	{
		//Battlecry: If you played an Elemental last turn, cast an Elemental Invocation.


        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
			if (p.anzOwnElementalsLastTurn > 0 && own.own) p.evaluatePenality -= 12;
        }
    }
}