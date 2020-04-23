

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_236",
  "name": [
    "神圣之灵",
    "Divine Spirit"
  ],
  "text": [
    "使一个随从的生命值翻倍。",
    "Double a minion's Health."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "HOF",
  "collectible": true,
  "dbfId": 1361
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_236 : SimTemplate //divinespirit
    {
//    verdoppelt das leben eines dieners.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 0, target.Hp);
        }
    }
}