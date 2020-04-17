using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_022",
  "name": [
    "修补匠的磨刀油",
    "Tinker's Sharpsword Oil"
  ],
  "text": [
    "使你的武器获得+3攻击力。<b>连击：</b>随机使一个友方随从获得+3攻击力。",
    "Give your weapon +3 Attack. <b>Combo:</b> Give a random friendly minion +3 Attack."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 4,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2095
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_022 : SimCard //Tinker's Sharpsword Oil
    {

        //    Give your weapon +3 Attack. Combo: Give a random friendly minion +3 Attack.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.ownWeapon.Angr += 3;
                    p.minionGetBuffed(p.ownHero, 3, 0);
                }
                if (p.cardsPlayedThisTurn >= 1 && p.ownMinions.Count >= 1)
                {
                    // Drew: Null check for searchRandomMinion.
                    var found = p.searchRandomMinion(p.ownMinions, searchmode.searchLowestAttack);
                    if (found != null)
                    {
                        p.minionGetBuffed(found, 3, 0);
                    }
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.enemyWeapon.Angr += 3;
                    p.minionGetBuffed(p.enemyHero, 3, 0);
                }
                if (p.cardsPlayedThisTurn >= 1 && p.enemyMinions.Count >= 1)
                {
                    // Drew: Null check for searchRandomMinion.
                    var found = p.searchRandomMinion(p.enemyMinions, searchmode.searchLowestAttack);
                    if (found != null)
                    {
                        p.minionGetBuffed(found, 3, 0);
                    }
                }
            }
        }


    }

}