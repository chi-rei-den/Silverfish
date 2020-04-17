using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_687",
  "name": [
    "墨水大师索莉娅",
    "Inkmaster Solia"
  ],
  "text": [
    "<b>战吼：</b>在本回合中，如果你的牌库里没有相同的牌，你所施放的下一个法术的法力值消耗为（0）点。",
    "[x]<b>Battlecry:</b> If your deck has\nno duplicates, the next\nspell you cast this turn\ncosts (0)."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40701
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_687 : SimCard //* Inkmaster Solia
	{
		// Battlecry: If your deck has no duplicates, the next spell you cast this turn costs (0).

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own && p.prozis.noDuplicates) p.nextSpellThisTurnCost0 = true;
        }
    }
}