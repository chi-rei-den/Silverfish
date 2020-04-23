using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_077",
  "name": [
    "疾跑",
    "Sprint"
  ],
  "text": [
    "抽四张牌。",
    "Draw 4 cards."
  ],
  "CardClass": "ROGUE",
  "type": "SPELL",
  "cost": 7,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 630
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_077 : SimTemplate //sprint
    {
//    zieht 4 karten.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(SimCard.None, ownplay);
            p.drawACard(SimCard.None, ownplay);
            p.drawACard(SimCard.None, ownplay);
            p.drawACard(SimCard.None, ownplay);
        }
    }
}