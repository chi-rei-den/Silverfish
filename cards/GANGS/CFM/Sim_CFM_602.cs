using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_602",
  "name": [
    "青玉护符",
    "Jade Idol"
  ],
  "text": [
    "<b>抉择：</b>召唤一个{0}的<b>青玉魔像</b>；或者将该牌的三张复制洗入你的牌库。",
    "<b>Choose One -</b> Summon a{1} {0} <b>Jade Golem</b>; or Shuffle 3 copies of this card into your deck."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 1,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40372
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_CFM_602 : SimCard //* Jade Idol
	{
		// Choose One - Summon a Jade Golem; or Shuffle 3 copies of this card into your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(p.getNextJadeGolem(ownplay), pos, ownplay);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                if (ownplay)
                {
                    p.ownDeckSize += 3;
                    p.evaluatePenality -= 11;
                }
                else p.enemyDeckSize += 3;
            }
        }
    }
}