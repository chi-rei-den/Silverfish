using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "tt_010",
  "name": [
    "扰咒术",
    "Spellbender"
  ],
  "text": [
    "<b>奥秘：</b>当一个敌方法术以一个随从为目标时，召唤一个1/3的随从并使其成为新的目标。",
    "<b>Secret:</b> When an enemy casts a spell on a minion, summon a 1/3 as the new target."
  ],
  "cardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 366
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_tt_010 : SimTemplate //spellbender
    {
        //todo secret
        //    geheimnis:/ wenn ein feind einen zauber auf einen diener wirkt, ruft ihr einen diener (1/3) als neues ziel herbei.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Mage.Spellbender_Spellbender;

        public override void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
            if (ownplay)
            {
                int posi = p.ownMinions.Count;
                if (posi > 6) return;
                p.callKid(kid, posi, true);
                if (p.ownMinions.Count >= 1)
                {
                    if (p.ownMinions[p.ownMinions.Count - 1].name == CardIds.Collectible.Mage.Spellbender)
                    {
                        number = p.ownMinions[p.ownMinions.Count - 1].entitiyID;
                    }
                }
            }
            else
            {
                int posi = p.enemyMinions.Count;
                if (posi > 6) return;
                p.callKid(kid, posi, false);

                if (p.enemyMinions.Count >= 1)
                {
                    if (p.enemyMinions[p.enemyMinions.Count - 1].name == CardIds.Collectible.Mage.Spellbender)
                    {
                        number = p.enemyMinions[p.enemyMinions.Count - 1].entitiyID;
                    }
                }
            }

        }

    }

}