using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_830",
  "name": [
    "暗影收割者安度因",
    "Shadowreaper Anduin"
  ],
  "text": [
    "<b>战吼：</b>消灭所有攻击力大于或等于5的随从。",
    "<b>Battlecry:</b> Destroy all minions with 5 or more Attack."
  ],
  "cardClass": "PRIEST",
  "type": "HERO",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43408
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_830: SimTemplate //* Shadowreaper Anduin
    {
        // Battlecry: Destroy all minions with 5 or more Attack.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Priest.ShadowreaperAnduin_Voidform, ownplay); // Voidform
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            foreach (Minion m in p.enemyMinions)
            {
                if (m.Angr >= 5) p.minionGetDestroyed(m);
            }
            foreach (Minion m in p.ownMinions)
            {
                if (m.Angr >= 5) p.minionGetDestroyed(m);
            }
        }
    }
}