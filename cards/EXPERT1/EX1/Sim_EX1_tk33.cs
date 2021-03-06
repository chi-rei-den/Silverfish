using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_tk33",
  "name": [
    "地狱火！",
    "INFERNO!"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个6/6的\n地狱火。",
    "<b>Hero Power</b>\nSummon a 6/6 Infernal."
  ],
  "cardClass": "WARLOCK",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1178
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_tk33 : SimTemplate //* inferno
    {
        //Hero PowerSummon a 6/6 Infernal.

        SimCard kid = CardIds.NonCollectible.Warlock.Infernal; //infernal

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
        }
    }
}