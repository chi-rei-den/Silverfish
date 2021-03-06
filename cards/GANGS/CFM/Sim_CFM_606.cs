using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_606",
  "name": [
    "法力晶簇",
    "Mana Geode"
  ],
  "text": [
    "每当该随从获得治疗时，便召唤一颗2/2的水晶。",
    "Whenever this minion is healed, summon a 2/2 Crystal."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40381
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_606 : SimTemplate //* Mana Geode
    {
        // Whenever this minion is healed, summon a 2/2 Crystal.

        SimCard kid = CardIds.NonCollectible.Priest.ManaGeode_CrystalToken; //2/2 Crystal

        public override void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, int minionsGotHealed)
        {
            if (triggerEffectMinion.anzGotHealed > 0)
            {
                var tmp = triggerEffectMinion.anzGotHealed;
                triggerEffectMinion.anzGotHealed = 0;
                for (var i = 0; i < tmp; i++)
                {
                    p.callKid(this.kid, triggerEffectMinion.zonepos, triggerEffectMinion.own);
                }
            }
        }
    }
}