

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_693",
  "name": [
    "加基森摆渡人",
    "Gadgetzan Ferryman"
  ],
  "text": [
    "<b>连击：</b>将一个友方随从移回你的手牌。",
    "<b>Combo:</b> Return a friendly minion to your hand."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40696
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_693 : SimTemplate //* Gadgetzan Ferryman
    {
        // Combo: Return a friendly minion to your hand.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (p.cardsPlayedThisTurn > 0 && target != null)
            {
                p.minionReturnToHand(target, target.own, 0);
            }
        }
    }
}