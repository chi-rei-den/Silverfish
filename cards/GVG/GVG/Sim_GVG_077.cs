

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_077",
  "name": [
    "心能魔像",
    "Anima Golem"
  ],
  "text": [
    "在每个回合结束时，如果该随从是你唯一的随从，则消灭\n该随从。",
    "At the end of each turn, destroy this minion if it's your only one."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2045
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_077 : SimTemplate //Anima Golem
    {
        //  At the end of each turn, destroy this minion if it's your only one. 

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own)
            {
                if (p.ownMinions.Count == 1)
                {
                    p.minionGetDestroyed(triggerEffectMinion);
                }
            }
            else
            {
                if (p.enemyMinions.Count == 1)
                {
                    p.minionGetDestroyed(triggerEffectMinion);
                }
            }
        }
    }
}