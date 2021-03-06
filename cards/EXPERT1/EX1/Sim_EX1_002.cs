

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_002",
  "name": [
    "黑骑士",
    "The Black Knight"
  ],
  "text": [
    "<b>战吼：</b>消灭一个具有<b>嘲讽</b>的敌方随从。",
    "<b>Battlecry:</b> Destroy an enemy minion with <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1656
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_002 : SimTemplate //theblackknight
    {
//    kampfschrei:/ vernichtet einen feindlichen diener mit spott/.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
            }
        }
    }
}