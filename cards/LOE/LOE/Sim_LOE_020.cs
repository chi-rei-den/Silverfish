using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_020",
  "name": [
    "大漠沙驼",
    "Desert Camel"
  ],
  "text": [
    "<b>战吼：</b>从双方的牌库中各将一个法力值消耗为（1）的随从置入战场。",
    "<b>Battlecry:</b> Put a 1-Cost minion from each deck into the battlefield."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2892
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_020 : SimTemplate //* Desert Camel
    {
        //Battlecry: Put a 1-Cost minion from each deck into the battlefield.

        SimCard kid = CardIds.Collectible.Priest.TwilightWhelp; //Twilight Whelp

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.callKid(this.kid, p.ownMinions.Count, true);
            p.callKid(this.kid, p.enemyMinions.Count, false);
        }
    }
}