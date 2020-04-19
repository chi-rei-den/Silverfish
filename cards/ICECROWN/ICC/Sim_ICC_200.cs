using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_200",
  "name": [
    "眼镜蛇陷阱",
    "Venomstrike Trap"
  ],
  "text": [
    "<b>奥秘：</b>当你的随从受到攻击时，召唤一条2/3并具有<b>剧毒</b>的眼镜蛇。",
    "<b>Secret:</b> When one of your minions is attacked, summon a 2/3 <b>Poisonous</b> Cobra."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42525
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_200: SimTemplate //* Venomstrike Trap
    {
        // Secret: When one of your minions is attacked, summon a 2/3 Poisonous Cobra.

        Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Neutral.EmperorCobra; //Emperor Cobra

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(kid, pos, ownplay, false);
        }
    }
}