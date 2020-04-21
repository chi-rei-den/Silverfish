using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;


/* _BEGIN_TEMPLATE_
{
  "id": "ULD_217",
  "name": [
    "微型木乃伊",
    "Micro Mummy"
  ],
  "text": [
    "<b>复生</b>\n在你的回合结束时，随机使另一个友方随从获得+1攻击力。",
    "[x]<b>Reborn</b>\nAt the end of your turn, give\nanother random friendly\nminion +1 Attack."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "ULDUM",
  "collectible": true,
  "dbfId": 53445
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_ULD_217 : SimTemplate //* 微型木乃伊 Micro Mummy
	{
		//[x]<b>Reborn</b>At the end of your turn, giveanother random friendlyminion +1 Attack.
		//<b>复生</b>在你的回合结束时，随机使另一个友方随从获得+1攻击力。
		public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
{
if (triggerEffectMinion.own == turnEndOfOwner && p.ownMinions.Count>1)
{
List<Minion> minions = p.ownMinions;
Minion a = p.searchRandomMinion(minions, SearchMode.LowHealth);
p.minionGetBuffed(a, 1, 0);
}



	}
}
}