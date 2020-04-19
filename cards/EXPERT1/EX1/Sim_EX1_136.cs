using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_136",
  "name": [
    "救赎",
    "Redemption"
  ],
  "text": [
    "<b>奥秘：</b>当一个友方随从死亡时，使其回到战场，并具有1点生命值。",
    "<b>Secret:</b> When a friendly minion dies, return it to life with 1 Health."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 140
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_136 : SimTemplate //* Redemption
    {
        //Secret: When one of your minions dies, return it to life with 1 Health.

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(ownplay ? p.revivingOwnMinion : p.revivingEnemyMinion);
            List<Minion> tmp = ownplay ? p.ownMinions : p.enemyMinions;
            int pos = tmp.Count;

            p.callKid(kid, pos, ownplay, true, true);
            
            if (tmp.Count >= 1)
            {
                Minion summonedMinion = tmp[pos];
                if (summonedMinion.handcard.card.card.CardId == kid.card.CardId)
                {
                    summonedMinion.Hp = 1;
                    summonedMinion.wounded = false;
                    if (summonedMinion.Hp < summonedMinion.maxHp) summonedMinion.wounded = true;
                }
            }
        }
    }
}