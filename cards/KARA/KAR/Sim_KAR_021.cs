using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

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

        SimCard searing = CardIds.NonCollectible.Shaman.SearingTotem;
        SimCard healing = CardIds.NonCollectible.Shaman.HealingTotem;
        SimCard wrathofair = CardIds.NonCollectible.Shaman.WrathOfAirTotem;

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.Type == CardType.SPELL)
            {
                SimCard kid;
                var otherTotems = 0;
                var wrath = false;
                foreach (var m in wasOwnCard ? p.ownMinions : p.enemyMinions)
                {
                    switch (m.name.CardId)
                    {
                        case CardIds.NonCollectible.Shaman.SearingTotem:
                            otherTotems++;
                            continue;
                        case CardIds.NonCollectible.Shaman.StoneclawTotem:
                            otherTotems++;
                            continue;
                        case CardIds.NonCollectible.Shaman.HealingTotem:
                            otherTotems++;
                            continue;
                        case CardIds.NonCollectible.Shaman.WrathOfAirTotem:
                            wrath = true;
                            continue;
                    }
                }

                if (p.isLethalCheck)
                {
                    if (otherTotems == 3 && !wrath)
                    {
                        kid = this.wrathofair;
                    }
                    else
                    {
                        kid = this.healing;
                    }
                }
                else
                {
                    if (!wrath)
                    {
                        kid = this.wrathofair;
                    }
                    else
                    {
                        kid = this.searing;
                    }
                }

                p.callKid(kid, triggerEffectMinion.zonepos, wasOwnCard);
            }
        }
    }
}