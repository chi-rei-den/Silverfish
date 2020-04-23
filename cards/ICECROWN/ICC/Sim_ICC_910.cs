

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_910",
  "name": [
    "鬼灵匪贼",
    "Spectral Pillager"
  ],
  "text": [
    "<b>连击：</b>造成伤害，数值等同于在本回合中你使用的其他牌的\n数量。",
    "[x]<b>Combo:</b> Deal damage equal\nto the number of other cards\nyou've played this turn."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45975
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_910 : SimTemplate //* Spectral Pillager
    {
        // Combo: Deal damage equal to the number of other cards you've played this turn.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.cardsPlayedThisTurn > 0)
                {
                    if (target != null)
                    {
                        p.minionGetDamageOrHeal(target, p.cardsPlayedThisTurn);
                    }
                }
            }
        }
    }
}