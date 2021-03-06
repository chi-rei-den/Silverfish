using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_812",
  "name": [
    "绞肉车",
    "Meat Wagon"
  ],
  "text": [
    "<b>亡语：</b>从你的牌库中召唤一个攻击力小于该随从攻击力的随从。",
    "[x]<b>Deathrattle:</b> Summon a\nminion from your deck\nwith less Attack than\nthis minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43051
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_812 : SimTemplate //* Meat Wagon
    {
        // Deathrattle: Summon a minion from your deck with less Attack than this minion.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            SimCard cId = SimCard.None;
            for (var i = m.Angr - 1; i >= 0; i--)
            {
                cId = p.prozis.getDeckCardsForCost(i);
                if (cId != SimCard.None)
                {
                    break;
                }
            }

            if (cId != SimCard.None)
            {
                var kid = cId;
                p.callKid(kid, m.zonepos - 1, m.own);
            }
        }
    }
}