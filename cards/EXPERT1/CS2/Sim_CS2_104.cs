

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_104",
  "name": [
    "狂暴",
    "Rampage"
  ],
  "text": [
    "使一个受伤的随从获得+3/+3。",
    "Give a damaged minion +3/+3."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1108
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_104 : SimTemplate //rampage
    {
//    verleiht einem verletzten diener +3/+3.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 3, 3);
        }
    }
}