

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA12_3",
  "name": [
    "龙血之痛：红",
    "Brood Affliction: Red"
  ],
  "text": [
    "如果这张牌在你的手牌中，在你的回合开始时，你的英雄受到1点伤害。",
    "While this is in your hand, take 1 damage at the start of your turn."
  ],
  "CardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2362
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA12_3 : SimTemplate //* Brood Affliction: Red
    {
        //While this is in your hand, take 1 damage at the start of your turn.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetDamageOrHeal(turnStartOfOwner ? p.ownHero : p.enemyHero, 1, true);
            }
        }
    }
}