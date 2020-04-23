using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_926",
  "name": [
    "身陷绝境的哨卫",
    "Cornered Sentry"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>\n为你的对手召唤三只1/1的迅猛龙。",
    "<b>Taunt</b>. <b>Battlecry:</b> Summon three 1/1 Raptors for your opponent."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41406
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_926 : SimTemplate //* Cornered Sentry
    {
        //Taunt. Battlecry: Summon three 1/1 Raptors for your opponent.

        SimCard kid = CardIds.NonCollectible.Neutral.Eggnapper_RaptorToken; //1/1 Raptor

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var pos = own.own ? p.enemyMinions.Count : p.ownMinions.Count;
            p.callKid(this.kid, pos, !own.own);
            p.callKid(this.kid, pos, !own.own);
            p.callKid(this.kid, pos, !own.own);
        }
    }
}