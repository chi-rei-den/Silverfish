

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_203",
  "name": [
    "铁喙猫头鹰",
    "Ironbeak Owl"
  ],
  "text": [
    "<b>战吼：</b>\n<b>沉默</b>一个随从。",
    "<b>Battlecry:</b> <b>Silence</b> a minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 290
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_203 : SimTemplate //ironbeakowl
    {
//    kampfschrei:/ bringt einen diener zum schweigen/.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetSilenced(target);
            }
        }
    }
}