using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA01_2",
  "name": [
    "干杯！",
    "Pile On!"
  ],
  "text": [
    "<b>英雄技能</b>\n从双方的牌库中\n各将一个随从\n置入战场。",
    "<b>Hero Power</b>\nPut a minion from each deck into the battlefield."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2314
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA01_2 : SimTemplate //* Pile On!
    {
        // Hero Power: Put a minion from each deck into the battlefield.

        SimCard kid = CardIds.NonCollectible.Neutral.NerubianEgg_NerubianToken; //4/4Nerubian

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (p.ownDeckSize > 0)
            {
                p.callKid(this.kid, p.ownMinions.Count, true, false);
                p.ownDeckSize--;
            }

            if (p.enemyDeckSize > 0)
            {
                p.callKid(this.kid, p.enemyMinions.Count, false, false);
                p.enemyDeckSize--;
            }
        }
    }
}