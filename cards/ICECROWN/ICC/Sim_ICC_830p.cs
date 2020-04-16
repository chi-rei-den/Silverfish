using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_830p",
  "name": [
    "虚空形态",
    "Voidform"
  ],
  "text": [
    "<b>英雄技能</b>\n造成$2点伤害。在你使用一张牌后，复原你的英雄技能。",
    "[x]<b>Hero Power</b>\nDeal $2 damage.\nAfter you play a card,\nrefresh this."
  ],
  "cardClass": "PRIEST",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 45397
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_830p: SimTemplate //* Voidform
    {
        // Hero Power: Deal 2 damage. After you play a card, refresh this.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int dmg = (ownplay) ? p.getHeroPowerDamage(2) : p.getEnemyHeroPowerDamage(2);
            p.minionGetDamageOrHeal(target, dmg);
        }

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Handmanager.Handcard triggerhc)
        {
            if (ownplay) p.ownAbilityReady = true;
            else p.enemyAbilityReady = true;
        }
    }
}