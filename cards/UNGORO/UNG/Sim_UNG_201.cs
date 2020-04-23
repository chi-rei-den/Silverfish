using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_201",
  "name": [
    "蛮鱼图腾",
    "Primalfin Totem"
  ],
  "text": [
    "在你的回合结束时，召唤一个1/1的鱼人。",
    "At the end of your turn, summon a 1/1 Murloc."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41105
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_201 : SimTemplate //* Primalfin Totem
    {
        //At the end of your turn, summon a 1/1 Murloc.

        SimCard kid = CardIds.NonCollectible.Neutral.PrimalfinTotem_PrimalfinToken; //Primalfin

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                var pos = triggerEffectMinion.zonepos;
                p.callKid(this.kid, pos, triggerEffectMinion.own);
            }
        }
    }
}