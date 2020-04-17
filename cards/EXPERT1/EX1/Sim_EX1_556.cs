using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_556",
  "name": [
    "麦田傀儡",
    "Harvest Golem"
  ],
  "text": [
    "<b>亡语：</b>召唤一个2/1的损坏的傀儡。",
    "<b>Deathrattle:</b> Summon a 2/1 Damaged Golem."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 778
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_556 : SimCard //* harvestgolem
	{
        //Deathrattle: Summon a 2/1 Damaged Golem.

        CardDB.Card card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.skele21);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(card, m.zonepos - 1, m.own);
        }
	}
}