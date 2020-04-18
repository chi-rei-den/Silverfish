using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_102",
  "name": [
    "工匠镇技师",
    "Tinkertown Technician"
  ],
  "text": [
    "<b>战吼：</b>如果你控制一个机械，便获得+1/+1并将一张<b>零件</b>牌置入你的手牌。",
    "<b>Battlecry:</b> If you have a Mech, gain +1/+1 and add a <b>Spare Part</b> to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2070
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_102 : SimTemplate //Tinkertown Technician
    {

        // Battlecry: If you have a Mech, gain +1/+1 and add a Spare Part to your hand.  

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions;

            foreach (Minion m in temp)
            {
                if ((TAG_RACE)m.handcard.card.Race == TAG_RACE.MECHANICAL)
                {
                    p.minionGetBuffed(own, 1, 1);
                    p.drawACard(CardIds.NonCollectible.Neutral.ArmorPlating, own.own, true);
                    return;
                }
            }
        }

    }

}