using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_086",
  "name": [
    "集合石",
    "Summoning Stone"
  ],
  "text": [
    "每当你施放一个法术，随机召唤一个法力值消耗相同的随从。",
    "Whenever you cast a spell, summon a random minion of the same Cost."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2958
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_086 : SimTemplate //* Summoning Stone
    {
        //Whenever you cast a spell, summon a random minion of the same Cost.

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.Type == CardType.SPELL)
            {
                var pos = wasOwnCard ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(p.getRandomCardForManaMinion(hc.manacost), pos, wasOwnCard);
            }
        }
    }
}