using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_037",
  "name": [
    "活体根须",
    "Living Roots"
  ],
  "text": [
    "<b>抉择：</b>造成$2点伤害；或者召唤两个1/1的树苗。",
    "<b>Choose One -</b> Deal $2 damage; or Summon two 1/1 Saplings."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2792
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_AT_037 : SimTemplate //* Living Roots
	{
		//Choose One - Deal 2 damage; or Summon two 1/1 Saplings.

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Druid.LivingRoots_SaplingToken; //Sapling
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (target != null)
                {
                    int damage = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
                    p.minionGetDamageOrHeal(target, damage);
                }
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
				int place = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
				p.callKid(kid, place, ownplay, false);
				p.callKid(kid, place, ownplay);
            }
        }
    }
}