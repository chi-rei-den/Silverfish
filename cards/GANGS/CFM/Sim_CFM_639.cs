using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_639",
  "name": [
    "污手街惩罚者",
    "Grimestreet Enforcer"
  ],
  "text": [
    "在你的回合结束时，使你手牌中的所有随从牌获得+1/+1。",
    "At the end of your turn, give all minions in your hand +1/+1."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40469
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_639 : SimTemplate //* Grimestreet Enforcer
    {
        // At the end of your turn, give all minions in your hand +1/+1.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                if (triggerEffectMinion.own)
                {
                    foreach (var hc in p.owncards)
                    {
                        if (hc.card.Type == CardType.MINION)
                        {
                            hc.addattack++;
                            hc.addHp++;
                            p.anzOwnExtraAngrHp += 2;
                        }
                    }
                }
                else
                {
                    if (p.enemyAnzCards > 0)
                    {
                        p.anzEnemyExtraAngrHp += 2 * p.enemyAnzCards - 1;
                    }
                }
            }
        }
    }
}