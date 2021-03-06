using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_237",
  "name": [
    "饥饿的秃鹫",
    "Starving Buzzard"
  ],
  "text": [
    "每当你召唤一个野兽，抽一张牌。",
    "Whenever you summon a Beast, draw a card."
  ],
  "CardClass": "HUNTER",
  "type": "MINION",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 1241
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_237 : SimTemplate //starvingbuzzard
    {
//    zieht jedes mal eine karte, wenn ihr ein wildtier herbeiruft.
        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own && summonedMinion.handcard.card.Race == Race.PET)
            {
                p.drawACard(SimCard.None, triggerEffectMinion.own);
            }
        }
    }
}