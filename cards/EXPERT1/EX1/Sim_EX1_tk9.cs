

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_tk9",
  "name": [
    "树人",
    "Treant"
  ],
  "text": [
    null,
    null
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 358
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_tk9 : SimTemplate //treant
    {
//    ansturm/. vernichtet diesen diener am ende des zuges.


        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                p.minionGetDestroyed(triggerEffectMinion);
            }
        }
    }
}