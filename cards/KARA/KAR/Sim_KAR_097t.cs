using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_097t",
  "name": [
    "埃提耶什",
    "Atiesh"
  ],
  "text": [
    "在你施放一个法术后，随机召唤一个法力值消耗相同的随从。\n失去1点耐久度。",
    "[x]After you cast a spell,\nsummon a random\nminion of that Cost.\nLose 1 Durability."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "KARA",
  "collectible": null,
  "dbfId": 40360
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_097t : SimTemplate //* Atiesh
	{
        //After you cast a spell, summon a random minion of that Cost. Lose 1 Durability.

        SimCard weapon = CardIds.NonCollectible.Neutral.MedivhtheGuardian_AtieshToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
	}
}