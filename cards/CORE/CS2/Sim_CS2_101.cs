using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_101",
  "name": [
    "援军",
    "Reinforce"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个1/1的白银之手新兵。",
    "<b>Hero Power</b>\nSummon a 1/1 Silver Hand Recruit."
  ],
  "cardClass": "PALADIN",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 472
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CS2_101 : SimCard //* reinforce
	{
        //Hero Power: Summon a 1/1 Silver Hand Recruit.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t);//silverhandrecruit

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
        }

	}
}