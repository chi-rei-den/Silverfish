using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_209",
  "name": [
    "升腾者海纳泽尔",
    "Hallazeal the Ascended"
  ],
  "text": [
    "每当你的法术造成伤害时，为你的英雄恢复等量的生命值。",
    "Whenever your spells deal damage, restore that much Health to your hero."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38722
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_OG_209 : SimTemplate //* Hallazeal the Ascended
	{
		//Whenever your spells deal damage, restore that much Health to your hero.
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool ownplay, Minion m)
        {
            if (m.own == ownplay && hc.card.Type == Chireiden.Silverfish.SimCardtype.SPELL)
            {
                Minion target = (ownplay) ? p.ownHero : p.enemyHero;
                p.minionGetDamageOrHeal(target, -p.prozis.penman.guessTotalSpellDamage(p, hc.card.name, ownplay));
            }
        }
    }
}