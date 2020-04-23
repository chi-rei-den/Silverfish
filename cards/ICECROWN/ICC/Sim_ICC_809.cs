

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_809",
  "name": [
    "瘟疫科学家",
    "Plague Scientist"
  ],
  "text": [
    "<b>连击：</b>使一个友方随从获得<b>剧毒</b>。",
    "<b>Combo:</b> Give a friendly minion <b>Poisonous</b>."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43028
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_809 : SimTemplate //* Plague Scientist
    {
        // Combo: Give a friendly minion Poisonous.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.cardsPlayedThisTurn >= 1 && target != null && own.own)
            {
                target.poisonous = true;
            }
        }
    }
}