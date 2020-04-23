using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA07_2",
  "name": [
    "猛砸",
    "ME SMASH"
  ],
  "text": [
    "<b>英雄技能</b>\n随机消灭一个受伤的敌方随从。",
    "<b>Hero Power</b>\nDestroy a random damaged enemy minion."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 1,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2338
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA07_2 : SimTemplate //* ME SMASH
    {
        // Hero Power: Destroy a random damaged enemy minion

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var temp = ownplay ? new List<Minion>(p.enemyMinions) : new List<Minion>(p.ownMinions);
            temp.Sort((a, b) => a.Angr.CompareTo(b.Angr));
            foreach (var m in temp)
            {
                if (m.wounded)
                {
                    p.minionGetDestroyed(m);
                    break;
                }
            }
        }
    }
}