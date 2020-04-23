using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_008a",
  "name": [
    "古老的教诲",
    "Ancient Teachings"
  ],
  "text": [
    "抽一张牌。",
    "Draw a card."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 7,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 313
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_008a : SimTemplate //* Ancient Teachings
    {
        //Draw a card.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);
        }
    }
}