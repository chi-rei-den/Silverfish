

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_023",
  "name": [
    "地精自动理发装置",
    "Goblin Auto-Barber"
  ],
  "text": [
    "<b>战吼：</b>使你的武器获得+1攻击力。",
    "<b>Battlecry:</b> Give your weapon +1 Attack."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1988
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_023 : SimTemplate //Goblin Auto-Barber
    {
        //    Battlecry: Give your weapon +1 Attack.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Angr += 1;
                    p.minionGetBuffed(p.ownHero, 1, 0);
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 1;
                    p.minionGetBuffed(p.enemyHero, 1, 0);
                }
            }
        }
    }
}