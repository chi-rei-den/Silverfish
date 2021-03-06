using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_042",
  "name": [
    "亚煞极",
    "Y'Shaarj, Rage Unbound"
  ],
  "text": [
    "在你的回合结束时，将一个随从从你的牌库置入战场。",
    "At the end of your turn, put a minion from your deck into the battlefield."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "OG",
  "collectible": true,
  "dbfId": 38312
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_042 : SimTemplate //* Y'Shaarj, Rage Unbound
    {
        //At the end of your turn, put a minion from your deck into the battlefield.

        SimCard kid = CardIds.Collectible.Priest.TempleEnforcer; //6/6 Temple Enforcer

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                var pos = triggerEffectMinion.own ? p.ownMinions.Count : p.enemyMinions.Count;
                p.callKid(this.kid, pos, triggerEffectMinion.own, false);
                if (triggerEffectMinion.own)
                {
                    p.ownDeckSize--;
                }
                else
                {
                    p.enemyDeckSize--;
                }
            }
        }
    }
}