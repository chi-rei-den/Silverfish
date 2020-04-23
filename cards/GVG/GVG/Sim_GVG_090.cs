using System.Collections.Generic;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_090",
  "name": [
    "疯狂爆破者",
    "Madder Bomber"
  ],
  "text": [
    "<b>战吼：</b>造成6点伤害，随机分配到所有其他角色身上。",
    "<b>Battlecry:</b> Deal 6 damage randomly split between all other characters."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2058
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_090 : SimTemplate //Madder Bomber
    {
        //   Battlecry: Deal 6 damage randomly split between all other characters.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var anz = 6;
            for (var i = 0; i < anz; i++)
            {
                if (p.ownHero.Hp <= anz)
                {
                    p.minionGetDamageOrHeal(p.ownHero, 1);
                    continue;
                }

                var temp = new List<Minion>(p.enemyMinions);
                if (temp.Count == 0)
                {
                    temp.AddRange(p.ownMinions);
                }

                temp.Sort((a, b) => a.Hp.CompareTo(b.Hp)); //destroys the weakest

                foreach (var m in temp)
                {
                    if (m.entitiyID == own.entitiyID)
                    {
                        continue;
                    }

                    p.minionGetDamageOrHeal(m, 1);
                    break;
                }

                p.minionGetDamageOrHeal(p.enemyHero, 1);
            }
        }
    }
}