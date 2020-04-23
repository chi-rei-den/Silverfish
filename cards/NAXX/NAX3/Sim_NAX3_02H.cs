using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX3_02H",
  "name": [
    "裹体之网",
    "Web Wrap"
  ],
  "text": [
    "<b>英雄技能</b>\n随机将两个敌方随从移回对手的\n手牌。",
    "<b>Hero Power</b>\nReturn 2 random enemy minions to your opponent's hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2107
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX3_02H : SimTemplate //* Web Wrap
    {
        // Hero Power: Return 2 random enemy minions to your opponent's hand.

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
                if (temp.Count > 1)
                {
                    var target2 = new Minion();
                    target2 = temp[1];
                    p.minionReturnToHand(target2, !ownplay, 0);
                }

                p.minionReturnToHand(target, !ownplay, 0);
            }
        }
    }
}