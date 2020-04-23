

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_005",
  "name": [
    "王牌猎人",
    "Big Game Hunter"
  ],
  "text": [
    "<b>战吼：</b>\n消灭一个攻击力大于或等于7的随从。",
    "<b>Battlecry:</b> Destroy a minion with 7 or more Attack."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1657
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_005 : SimTemplate //biggamehunter
    {
//    kampfschrei:/ vernichtet einen diener mit mind. 7 angriff.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
            }
        }
    }
}