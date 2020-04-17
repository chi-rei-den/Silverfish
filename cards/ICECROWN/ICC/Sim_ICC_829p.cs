using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_829p",
  "name": [
    "天启四骑士",
    "The Four Horsemen"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个2/2的天启骑士。如果你控制所有四个天启骑士，消灭敌方英雄。",
    "[x]<b>Hero Power</b>\nSummon a 2/2 Horseman.\nIf you have all 4, destroy\nthe enemy hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 43013
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_829p: SimCard //* The Four Horsemen
    {
        // Hero Power: Summon a 2/2 Horseman. If you have all 4, destroy the enemy hero.

        CardDB.Card kid1 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_829t2); //Deathlord Nazgrim
        CardDB.Card kid2 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_829t3); //Thoras Trollbane
        CardDB.Card kid3 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_829t4); //Inquisitor Whitemane
        CardDB.Card kid4 = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_829t5); //Darion Mograine

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid1, pos, ownplay, false);
        }
    }
}