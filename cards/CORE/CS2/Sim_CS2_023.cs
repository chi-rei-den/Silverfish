using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_023",
  "name": [
    "奥术智慧",
    "Arcane Intellect"
  ],
  "text": [
    "抽两张牌。",
    "Draw 2 cards."
  ],
  "CardClass": "MAGE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 555
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_023 : SimTemplate //arcaneintellect
    {
//    zieht 2 karten.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);
            p.drawACard(SimCard.None, ownplay);
        }
    }
}