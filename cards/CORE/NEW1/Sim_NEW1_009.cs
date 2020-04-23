

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_009",
  "name": [
    "治疗图腾",
    "Healing Totem"
  ],
  "text": [
    "在你的回合结束时，为所有友方随从恢复#1点生命值。",
    "At the end of your turn, restore #1 Health to all friendly minions."
  ],
  "CardClass": "SHAMAN",
  "type": "MINION",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 764
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_009 : SimTemplate //healingtotem
    {
//    stellt am ende eures zuges bei allen befreundeten dienern 1 leben wieder her.

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                var heal = triggerEffectMinion.own ? p.getMinionHeal(1) : p.getEnemyMinionHeal(1);
                p.allMinionOfASideGetDamage(turnEndOfOwner, -heal);
            }
        }
    }
}