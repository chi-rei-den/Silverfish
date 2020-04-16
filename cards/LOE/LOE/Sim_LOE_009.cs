using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_009",
  "name": [
    "黑曜石毁灭者",
    "Obsidian Destroyer"
  ],
  "text": [
    "在你的回合结束时，召唤一只1/1并具有<b>嘲讽</b>的甲虫。",
    "At the end of your turn, summon a 1/1 Scarab with <b>Taunt</b>."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 7,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2881
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_009 : SimTemplate //* Obsidian Destroyer
	{
		//At the end of your turn, summon a 1/1 Scarab with Taunt.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_009t); //Scarab

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int place = triggerEffectMinion.zonepos;
                p.callKid(kid, place, triggerEffectMinion.own);
            }
        }
	}
}