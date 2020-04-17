using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_509",
  "name": [
    "鱼人招潮者",
    "Murloc Tidecaller"
  ],
  "text": [
    "每当你召唤一个鱼人，便获得\n+1攻击力。",
    "Whenever you summon a Murloc, gain +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 475
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_509 : SimCard //* Murloc Tidecaller
	{
        //Whenever you summon a Murloc, gain +1 Attack.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own && (TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.MURLOC)
            {
                p.minionGetBuffed(triggerEffectMinion, 1, 0);
            }
        }

	}
}