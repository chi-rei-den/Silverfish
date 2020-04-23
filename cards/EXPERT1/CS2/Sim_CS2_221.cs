

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_221",
  "name": [
    "恶毒铁匠",
    "Spiteful Smith"
  ],
  "text": [
    "该随从受到伤害时使你的武器获得\n+2攻击力。",
    "Your weapon has +2 Attack while this is damaged."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 61
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_221 : SimTemplate //spitefulsmith
    {
//    wutanfall:/ eure waffe hat +2 angriff.
        public override void onEnrageStart(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.minionGetBuffed(p.ownHero, 2, 0);
                    p.ownWeapon.Angr += 2;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 2;
                    p.minionGetBuffed(p.enemyHero, 2, 0);
                }
            }
        }

        public override void onEnrageStop(Playfield p, Minion m)
        {
            if (m.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.minionGetBuffed(p.ownHero, -2, 0);
                    p.ownWeapon.Angr -= 2;
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr -= 2;
                    p.minionGetBuffed(p.enemyHero, -2, 0);
                }
            }
        }
    }
}