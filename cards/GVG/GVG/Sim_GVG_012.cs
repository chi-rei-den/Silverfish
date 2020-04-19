using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_012",
  "name": [
    "纳鲁之光",
    "Light of the Naaru"
  ],
  "text": [
    "恢复#3点生命值。如果该目标仍处于受伤状态，则召唤一个圣光护卫者。",
    "Restore #3 Health. If the target is still damaged, summon a Lightwarden."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 1933
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_012 : SimTemplate //Light of the Naaru
    {

        //    Restore #3 Health. If the target is still damaged, summon a Lightwarden.

        Chireiden.Silverfish.SimCard kid = CardIds.Collectible.Neutral.Lightwarden;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int heal = (ownplay) ? p.getSpellHeal(3) : p.getEnemySpellHeal(3);
            p.minionGetDamageOrHeal(target, -heal);
            if (target.Hp < target.maxHp)
            {
                int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(kid, posi, ownplay);
            }
        }


    }

}