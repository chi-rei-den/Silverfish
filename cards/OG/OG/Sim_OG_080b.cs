using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_080b",
  "name": [
    "皇血草毒素",
    "Kingsblood Toxin"
  ],
  "text": [
    "抽一张牌。",
    "Draw a card."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "OG",
  "collectible": null,
  "dbfId": 38934
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_080b : SimTemplate //* Kingsblood Toxin
    {
        //Draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);
        }
    }
}