using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_021",
  "name": [
    "邪恶的巫医",
    "Wicked Witchdoctor"
  ],
  "text": [
    "每当你施放一个法术，随机召唤一个基础图腾。",
    "Whenever you cast a spell, summon a random basic Totem."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39190
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_021 : SimTemplate // Wicked Witchdoctor
	{
		//Whenever you cast a spell, summon a random basic Totem.

        Chireiden.Silverfish.SimCard searing = CardIds.NonCollectible.Shaman.SearingTotem;
        Chireiden.Silverfish.SimCard healing = CardIds.NonCollectible.Shaman.HealingTotem;
        Chireiden.Silverfish.SimCard wrathofair = CardIds.NonCollectible.Shaman.WrathOfAirTotem;
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.Type == CardType.SPELL)
            {
				Chireiden.Silverfish.SimCard kid;
				int otherTotems = 0;
				bool wrath = false;
                foreach (Minion m in (wasOwnCard) ? p.ownMinions : p.enemyMinions)
				{
					switch (m.name)
					{
						case CardIds.NonCollectible.Shaman.SearingTotem: otherTotems++; continue;
						case CardIds.NonCollectible.Shaman.StoneclawTotem: otherTotems++; continue;
						case CardIds.NonCollectible.Shaman.HealingTotem: otherTotems++; continue;
						case CardIds.NonCollectible.Shaman.WrathOfAirTotem: wrath = true; continue;
					}
				}
				if (p.isLethalCheck)
				{
					if (otherTotems == 3 && !wrath) kid = wrathofair;
					else kid = healing;
				}
				else
				{
					if (!wrath) kid = wrathofair;
					else kid = searing;
				}
                p.callKid(kid, triggerEffectMinion.zonepos, wasOwnCard);
            }
        }
	}
}