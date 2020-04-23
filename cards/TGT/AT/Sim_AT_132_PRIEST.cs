

/* _BEGIN_TEMPLATE_
{
  "id": "AT_132_PRIEST",
  "name": [
    "治疗术",
    "Heal"
  ],
  "text": [
    "<b>英雄技能</b>\n恢复#4点生命值。",
    "<b>Hero Power</b>\nRestore #4 Health."
  ],
  "cardClass": "PRIEST",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "TGT",
  "collectible": null,
  "dbfId": 2741
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_132_PRIEST : SimTemplate //* Heal
    {
        //Hero Power. Restore 4 Health.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var heal = 4;
            if (ownplay)
            {
                if (p.anzOwnAuchenaiSoulpriest > 0 || p.embracetheshadow > 0)
                {
                    heal = -heal;
                }

                if (p.doublepriest >= 1)
                {
                    heal *= 2 * p.doublepriest;
                }
            }
            else
            {
                if (p.anzEnemyAuchenaiSoulpriest >= 1)
                {
                    heal = -heal;
                }

                if (p.enemydoublepriest >= 1)
                {
                    heal *= 2 * p.enemydoublepriest;
                }
            }

            p.minionGetDamageOrHeal(target, -heal);
        }
    }
}