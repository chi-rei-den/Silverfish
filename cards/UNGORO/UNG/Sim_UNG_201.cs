using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_201",
  "name": [
    "蛮鱼图腾",
    "Primalfin Totem"
  ],
  "text": [
    "在你的回合结束时，召唤一个1/1的鱼人。",
    "At the end of your turn, summon a 1/1 Murloc."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41105
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_UNG_201 : SimTemplate //* Primalfin Totem
	{
		//At the end of your turn, summon a 1/1 Murloc.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_201t); //Primalfin

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int pos = triggerEffectMinion.zonepos;
                p.callKid(kid, pos, triggerEffectMinion.own);
            }
        }
	}
}