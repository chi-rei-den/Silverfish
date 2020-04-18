using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX9_02",
  "name": [
    "女公爵布劳缪克丝",
    "Lady Blaumeux"
  ],
  "text": [
    "使你的英雄获得\n<b>免疫</b>。",
    "Your hero is <b>Immune</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 1879
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_NAX9_02 : SimTemplate //* Lady Blaumeux
	{
        // Your hero is Immune.

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.ownHero.immune = true;
                if (p.ownWeapon.name == Chireiden.Silverfish.SimCard.runeblade && p.anzOwnHorsemen < 1)
                {
                    int bonus = (p.ownWeapon.card.cardIDenum == Chireiden.Silverfish.SimCard.NAX9_05H) ? 6 : 3;
                    p.minionGetBuffed(p.ownHero, -1 * Math.Min(bonus, p.ownWeapon.Angr - 1), 0);
                    p.ownWeapon.Angr = Math.Min(1, p.ownWeapon.Angr - bonus);
                }
                p.anzOwnHorsemen++;
            }
            else
            {
                p.enemyHero.immune = true;
                if (p.enemyWeapon.name == Chireiden.Silverfish.SimCard.runeblade && p.anzEnemyHorsemen < 1)
                {
                    int bonus = (p.enemyWeapon.card.cardIDenum == Chireiden.Silverfish.SimCard.NAX9_05H) ? 6 : 3;
                    p.minionGetBuffed(p.enemyHero, -1 * Math.Min(bonus, p.enemyWeapon.Angr - 1), 0);
                    p.enemyWeapon.Angr = Math.Min(1, p.enemyWeapon.Angr - bonus);
                }
                p.anzEnemyHorsemen++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnHorsemen--;
                if (p.anzOwnHorsemen < 1)
                {
                    p.ownHero.immune = false;
                    if (p.ownWeapon.name == Chireiden.Silverfish.SimCard.runeblade)
                    {
                        int bonus = (p.ownWeapon.card.cardIDenum == Chireiden.Silverfish.SimCard.NAX9_05H) ? 6 : 3;
                        p.minionGetBuffed(p.ownHero, bonus, 0);
                        p.ownWeapon.Angr += bonus;
                    }
                }
            }
            else
            {
                p.anzEnemyHorsemen--;
                if (p.anzEnemyHorsemen < 1)
                {
                    p.enemyHero.immune = false;
                    if (p.enemyWeapon.name == Chireiden.Silverfish.SimCard.runeblade)
                    {
                        int bonus = (p.enemyWeapon.card.cardIDenum == Chireiden.Silverfish.SimCard.NAX9_05H) ? 6 : 3;
                        p.minionGetBuffed(p.enemyHero, bonus, 0);
                        p.enemyWeapon.Angr += bonus;
                    }
                }
            }
        }
    }
}