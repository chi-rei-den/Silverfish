using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_021",
  "name": [
    "蒸汽涌动者",
    "Steam Surger"
  ],
  "text": [
    "<b>战吼：</b>如果你在上个回合使用过元素牌，将一张“烈焰喷涌”置入你的手牌。",
    "[x]<b>Battlecry:</b> If you played\nan Elemental last turn,\nadd a 'Flame Geyser'\nto your hand."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41154
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_021 : SimTemplate //* Steam Surger
	{
		//Battlecry: If you played an Elemental last turn add a 'Flame Geyser' to your hand.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.anzOwnElementalsLastTurn > 0 && own.own) p.drawACard(CardIds.Collectible.Mage.FlameGeyser, own.own, true);
        }
    }
}