using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA07_2H",
  "name": [
    "猛砸",
    "ME SMASH"
  ],
  "text": [
    "<b>英雄技能</b>\n随机消灭一个敌方随从。",
    "<b>Hero Power</b>\nDestroy a random enemy minion."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2451
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA07_2H : SimTemplate //* ME SMASH
    {
        // Hero Power: Destroy a random enemy minion.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var m = p.searchRandomMinion(ownplay ? p.enemyMinions : p.ownMinions, SearchMode.LowHealth);
            if (m != null)
            {
                p.minionGetDestroyed(m);
            }
        }
    }
}