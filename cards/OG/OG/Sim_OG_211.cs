using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_211",
  "name": [
    "兽群呼唤",
    "Call of the Wild"
  ],
  "text": [
    "召唤所有三种动物伙伴。",
    "Summon all three Animal Companions."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 8,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38727
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_211 : SimTemplate //* Call of the Wild
    {
        //Summon all 3 Animal Companions.

        SimCard c1 = CardIds.NonCollectible.Hunter.Huffer; //Huffer
        SimCard c2 = CardIds.NonCollectible.Hunter.Leokk; //Leokk
        SimCard c3 = CardIds.NonCollectible.Hunter.Misha; //Misha

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.c1, pos, ownplay, false);
            p.callKid(this.c2, pos, ownplay);
            p.callKid(this.c3, pos, ownplay);
        }
    }
}