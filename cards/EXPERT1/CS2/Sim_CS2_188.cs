

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_188",
  "name": [
    "叫嚣的中士",
    "Abusive Sergeant"
  ],
  "text": [
    "<b>战吼：</b>\n本回合中，使一个随从获得+2攻击力。",
    "<b>Battlecry:</b> Give a minion +2 Attack this turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 242
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_188 : SimTemplate //abusivesergeant
    {
//    kampfschrei:/ verleiht einem diener +2 angriff in diesem zug.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetTempBuff(target, 2, 0);
            }
        }
    }
}