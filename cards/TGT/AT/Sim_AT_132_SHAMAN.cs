using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_SHAMAN",
  "name": [
    "图腾崇拜",
    "Totemic Slam"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个你想要的图腾。",
    "<b>Hero Power</b>\nSummon a Totem of your choice."
  ],
  "cardClass": "SHAMAN",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2742
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_132_SHAMAN : SimTemplate //* Totemic Slam
	{
		//Hero Power. Summon a Totem of your choice.

        Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_051);//Stoneclaw Totem
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, place, ownplay, false);
        }
    }

}