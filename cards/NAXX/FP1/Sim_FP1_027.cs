

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_027",
  "name": [
    "岩肤石像鬼",
    "Stoneskin Gargoyle"
  ],
  "text": [
    "在你的回合开始时，为该随从恢复所有生命值。",
    "At the start of your turn, restore this minion to full Health."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1861
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_027 : SimTemplate //stoneskingargoyle
    {
//    stellt zu beginn eures zuges das volle leben dieses dieners wieder her.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                var heal = triggerEffectMinion.own ? p.getMinionHeal(triggerEffectMinion.maxHp - triggerEffectMinion.Hp) : p.getEnemyMinionHeal(triggerEffectMinion.maxHp - triggerEffectMinion.Hp);
                p.minionGetDamageOrHeal(triggerEffectMinion, -heal);
            }
        }
    }
}