using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_054",
  "name": [
    "传播瘟疫",
    "Spreading Plague"
  ],
  "text": [
    "召唤一只1/5并具有<b>嘲讽</b>的甲虫。如果你的对手拥有的随从更多，则再次施放该法术。",
    "Summon a 1/5 Scarab with <b>Taunt</b>. If your opponent has more minions, cast this again."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 6,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42656
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_054: SimTemplate //* Spreading Plague
    {
        // Summon a 1/5 Scarab with Taunt. If your opponent has more minions, cast this again.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Druid.MalfurionthePestilent_ScarabBeetleToken; //Scarab Beetle

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                do
                {
                    p.callKid(kid, p.ownMinions.Count, ownplay);
                }
                while (p.enemyMinions.Count > p.ownMinions.Count);
            }
        }
    }
}