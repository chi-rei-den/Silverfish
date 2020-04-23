using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_055",
  "name": [
    "魔瘾者",
    "Mana Addict"
  ],
  "text": [
    "在本回合中，每当你施放一个法术，便获得+2攻击力。",
    "Whenever you cast a spell, gain +2 Attack this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 12
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_055 : SimTemplate //manaaddict
    {
//    erhält jedes mal +2 angriff in diesem zug, wenn ihr einen zauber wirkt.
        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.Type == CardType.SPELL)
            {
                p.minionGetTempBuff(triggerEffectMinion, 2, 0);
            }
        }
    }
}