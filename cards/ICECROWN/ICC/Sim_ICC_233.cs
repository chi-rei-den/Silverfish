using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_233",
  "name": [
    "末日回旋镖",
    "Doomerang"
  ],
  "text": [
    "对一个随从投掷你的武器，对该随从造成等同于该武器攻击力的伤害，随后该武器返回你的手牌。",
    "Throw your weapon at a minion. It deals its damage, then returns to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42801
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_233: SimTemplate //* Doomerang
    {
        // Throw your weapon at a minion. It deals it's damage, then returns to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            Weapon w = ownplay ? p.ownWeapon : p.enemyWeapon;

            p.minionGetDamageOrHeal(target, w.Angr);
            if (w.poisonous) p.minionGetDestroyed(target);

            p.lowerWeaponDurability(1000, ownplay);
            p.drawACard(w.name, ownplay, true);
        }
    }
}