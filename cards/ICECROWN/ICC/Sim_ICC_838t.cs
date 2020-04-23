using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_838t",
  "name": [
    "被冰封的勇士",
    "Frozen Champion"
  ],
  "text": [
    "<b>亡语：</b>随机将一个<b>传说</b>随从置入你的\n手牌。",
    "[x]<b>Deathrattle:</b> Add a\nrandom <b>Legendary</b> minion\nto your hand."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 46019
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_838t : SimTemplate //* Frozen Champion
    {
        // Deathrattle: Add a random Legendary minion to your hand.

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(SimCard.None, m.own, true);
            p.drawACard(SimCard.None, m.own, true); //bonus
        }
    }
}