using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_248",
  "name": [
    "野性狼魂",
    "Feral Spirit"
  ],
  "text": [
    "召唤两只2/3并具有<b>嘲讽</b>的幽灵狼。<b>过载：</b>（2）",
    "Summon two 2/3 Spirit Wolves with <b>Taunt</b>. <b>Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 238
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_248 : SimTemplate //* feralspirit
	{
        //Summon two 2/3 Spirit Wolves with Taunt. Overload: (2)

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Shaman.SpiritWolf;//spiritwolf

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, pos, ownplay, false);
            p.callKid(kid, pos, ownplay);
            if (ownplay) p.ueberladung += 2;
		}
	}
}