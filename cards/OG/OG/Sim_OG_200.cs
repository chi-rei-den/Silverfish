

/* _BEGIN_TEMPLATE_
{
  "id": "OG_200",
  "name": [
    "末日践行者",
    "Validated Doomsayer"
  ],
  "text": [
    "在你的回合开始时，将该随从的攻击力\n变为7。",
    "At the start of your turn, set this minion's Attack to 7."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38669
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_200 : SimTemplate //* Validated Doomsayer
    {
        //At the start of your turn, set this minion's Attack to 7.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (triggerEffectMinion.own == turnStartOfOwner)
            {
                if (triggerEffectMinion.Angr != 7)
                {
                    triggerEffectMinion.Angr = 7;
                }
            }
        }
    }
}