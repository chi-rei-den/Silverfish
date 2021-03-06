using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_829t2",
  "name": [
    "虚空传送门",
    "Nether Portal"
  ],
  "text": [
    "在你的回合结束时，召唤两个3/2的小鬼。",
    "At the end of your turn, summon two 3/2 Imps."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 11,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 42224
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_829t2 : SimTemplate //* Nether Portal
    {
        //At the end of your turn, summon two 3/2 Imps.

        SimCard kid = CardIds.NonCollectible.Warlock.LakkariSacrifice_NetherImpToken; //Nether Imp

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                p.callKid(this.kid, triggerEffectMinion.zonepos - 1, triggerEffectMinion.own); //1st left
                p.callKid(this.kid, triggerEffectMinion.zonepos, triggerEffectMinion.own);
            }
        }
    }
}