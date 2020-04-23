using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX3_02_TB",
  "name": [
    "裹体之网",
    "Web Wrap"
  ],
  "text": [
    "<b>英雄技能</b>\n随机将一个敌方随从移回对手的\n手牌。",
    "<b>Hero Power</b>\nReturn a random enemy minion to your opponent's hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 36743
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX3_02_TB : SimTemplate //* Web Wrap
    {
        // Hero Power: Return a random enemy minion to your opponent's hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var temp = ownplay ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);

            if (temp.Count > 0)
            {
                if (ownplay)
                {
                    temp.Sort((a, b) => b.Angr.CompareTo(a.Angr));
                }
                else
                {
                    temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));
                }

                target = temp[0];
                if (ownplay && temp.Count >= 2 && !target.taunt && temp[1].taunt)
                {
                    target = temp[1];
                }

                p.minionReturnToHand(target, !ownplay, 0);
            }
        }
    }
}