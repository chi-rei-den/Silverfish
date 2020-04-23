using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_554",
  "name": [
    "毒蛇陷阱",
    "Snake Trap"
  ],
  "text": [
    "<b>奥秘：</b>当你的随从受到攻击时，召唤三条1/1的蛇。",
    "<b>Secret:</b> When one of your minions is attacked, summon three 1/1 Snakes."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 455
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_554 : SimTemplate //* snaketrap
    {
        //Secret: When one of your minions is attacked, summon three 1/1 Snakes.

        SimCard kid = CardIds.NonCollectible.Hunter.SnakeTrap_SnakeToken; //snake

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(this.kid, pos, ownplay, false);
            p.callKid(this.kid, pos, ownplay);
            p.callKid(this.kid, pos, ownplay);
        }
    }
}