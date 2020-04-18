using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_085",
  "name": [
    "癫狂的唤冰者",
    "Demented Frostcaller"
  ],
  "text": [
    "在你施放一个法术后，随机<b>冻结</b>\n一个敌人。",
    "After you cast a spell, <b>Freeze</b> a random enemy."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "OG",
  "collectible": true,
  "dbfId": 38412
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_085 : SimTemplate //* Demented Frostcaller
	{
		//After you cast a spell, Freeze a random enemy character.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.Type == Chireiden.Silverfish.SimCardtype.SPELL)
            {
                Minion target = null;
                List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
                if (temp.Count > 0) target = p.searchRandomMinion(temp, searchmode.searchLowestHP);
                if (target == null) target = (ownplay) ? p.enemyHero : p.ownHero;
                p.minionGetFrozen(target);
            }
        }
    }
}