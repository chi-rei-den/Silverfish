

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_013",
  "name": [
    "克尔苏加德",
    "Kel'Thuzad"
  ],
  "text": [
    "在每个回合结束时，召唤所有在本回合中死亡的友方随从。",
    "At the end of each turn, summon all friendly minions that died this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1794
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_013 : SimTemplate //* Kel'Thuzad
    {
        // At the end of each turn, summon all friendly minions that died this turn.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            foreach (var gyi in p.diedMinions.ToArray()) // toArray() because a knifejuggler could kill a minion due to the summon :D
            {
                if (gyi.own == triggerEffectMinion.own)
                {
                    var card = gyi.cardid;
                    var pos = triggerEffectMinion.own ? p.ownMinions.Count : p.enemyMinions.Count;
                    p.callKid(card, p.ownMinions.Count, gyi.own);
                }
            }
        }
    }
}