using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_252",
  "name": [
    "冰冷鬼魂",
    "Coldwraith"
  ],
  "text": [
    "<b>战吼：</b>如果有敌人被<b>冻结</b>，抽一张牌。",
    "<b>Battlecry:</b> If an enemy is <b>Frozen</b>, draw a card."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42836
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_252: SimCard //* Coldwraith
    {
        // Battlecry: If an enemy is Frozen, draw a card.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            bool frozen = false;
            if (m.own ? p.enemyHero.frozen : p.ownHero.frozen) frozen = true;

            if (!frozen)
            {
                List<Minion> temp = (m.own) ? p.enemyMinions : p.ownMinions;
                foreach (Minion mnn in temp)
                {
                    if (mnn.frozen)
                    {
                        frozen = true;
                        break;
                    }
                }
            }

            if (frozen) p.drawACard(CardDB.cardIDEnum.None, m.own);
        }
    }
}