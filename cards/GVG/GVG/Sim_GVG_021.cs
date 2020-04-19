using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_021",
  "name": [
    "玛尔加尼斯",
    "Mal'Ganis"
  ],
  "text": [
    "你的其他恶魔获得+2/+2。你的英雄获得<b>免疫</b>。",
    "Your other Demons have +2/+2.\nYour hero is <b>Immune</b>."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1986
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_021 : SimTemplate //Mal'Ganis
    {

        //    Your other Demons have +2/+2.Your hero is Immune;

        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnMalGanis++;
                p.ownHero.immune = true;
                foreach (Minion m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID && (Race)m.handcard.card.Race == Race.DEMON) p.minionGetBuffed(m, 2, 2);
                }
            }
            else
            {
                p.anzEnemyMalGanis++;
                p.enemyHero.immune = true;
                foreach (Minion m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID && (Race)m.handcard.card.Race == Race.DEMON) p.minionGetBuffed(m, 2, 2);
                }
            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnMalGanis--;
                p.ownHero.immune = false;
                foreach (Minion m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID && (Race)m.handcard.card.Race == Race.DEMON) p.minionGetBuffed(m, -2, -2);
                }
            }
            else
            {
                p.anzEnemyMalGanis--;
                p.enemyHero.immune = false;
                foreach (Minion m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID && (Race)m.handcard.card.Race == Race.DEMON) p.minionGetBuffed(m, -2, -2);
                }
            }
        }


    }

}