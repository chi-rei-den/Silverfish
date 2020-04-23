

/* _BEGIN_TEMPLATE_
{
  "id": "OG_271",
  "name": [
    "梦魇之龙",
    "Scaled Nightmare"
  ],
  "text": [
    "在你的回合开始时，该随从的攻击力\n翻倍。",
    "At the start of your turn, double this minion's Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38832
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_271 : SimTemplate //* Scaled Nightmare
    {
        //At the start of your turn, double this minion's Attack.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 2 * triggerEffectMinion.Angr, 0);
            }
        }
    }
}