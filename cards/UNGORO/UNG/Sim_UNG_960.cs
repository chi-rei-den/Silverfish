using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_960",
  "name": [
    "迷失丛林",
    "Lost in the Jungle"
  ],
  "text": [
    "召唤两个1/1的白银之手新兵。",
    "Summon two 1/1 Silver Hand Recruits."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41912
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_960 : SimTemplate //* Lost in the Jungle
    {
        //Summon two 1/1 Silver Hand Recruits.

        SimCard kid = CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
            p.callKid(this.kid, pos, ownplay);
        }
    }
}