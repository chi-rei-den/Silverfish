

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_108",
  "name": [
    "斩杀",
    "Execute"
  ],
  "text": [
    "消灭一个受伤的敌方随从。",
    "Destroy a damaged enemy minion."
  ],
  "CardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 785
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_108 : SimTemplate //execute
    {
//    vernichtet einen verletzten feindlichen diener.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }
    }
}