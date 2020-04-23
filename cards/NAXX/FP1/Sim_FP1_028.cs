

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_028",
  "name": [
    "送葬者",
    "Undertaker"
  ],
  "text": [
    "每当你召唤一个具有<b>亡语</b>的随从，便获得+1攻击力。",
    "Whenever you summon a minion with <b>Deathrattle</b>, gain +1 Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1910
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_028 : SimTemplate //undertaker
    {
//    Whenever you summon a minion with Deathrattle, gain +1 Attack.

        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.own == summonedMinion.own)
            {
                if (summonedMinion.handcard.card.Deathrattle)
                {
                    p.minionGetBuffed(triggerEffectMinion, 1, 0);
                }
            }
        }
    }
}