using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_101",
  "name": [
    "援军",
    "Reinforce"
  ],
  "text": [
    "<b>英雄技能</b>\n召唤一个1/1的白银之手新兵。",
    "<b>Hero Power</b>\nSummon a 1/1 Silver Hand Recruit."
  ],
  "CardClass": "PALADIN",
  "type": "HERO_POWER",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": null,
  "dbfId": 472
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_101 : SimTemplate //* reinforce
    {
        //Hero Power: Summon a 1/1 Silver Hand Recruit.
        SimCard kid = CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken; //silverhandrecruit

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
        }
    }
}