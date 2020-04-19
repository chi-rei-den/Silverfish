using Chireiden.Silverfish;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_154",
  "name": [
    "愤怒",
    "Wrath"
  ],
  "text": [
    "<b>抉择：</b>\n对一个随从造成$3点伤害；或者造成$1点伤害并抽一张牌。",
    "<b>Choose One -</b>\nDeal $3 damage to a minion; or $1 damage\nand draw a card."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 836
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_154 : SimTemplate //* Wrath
	{
        // Choose One - Deal $3 damage to a minion; or $1 damage and draw a card.

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int damage = 0;
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                damage += (ownplay) ? p.getSpellDamageDamage(3) : p.getEnemySpellDamageDamage(3);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                damage += (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
            }

            p.minionGetDamageOrHeal(target, damage);

            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                p.drawACard(SimCard.None, ownplay);
            }
		}
	}
}