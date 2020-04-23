

/* _BEGIN_TEMPLATE_
{
  "id": "AT_028",
  "name": [
    "影踪骁骑兵",
    "Shado-Pan Rider"
  ],
  "text": [
    "<b>连击：</b>\n获得+3攻击力。",
    "<b>Combo:</b> Gain +3 Attack."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2765
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_028 : SimTemplate //* Shado-Pan Rider
    {
        //Combo: +3 Attack

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.cardsPlayedThisTurn > 0)
            {
                p.minionGetBuffed(own, 3, 0);
            }
        }
    }
}