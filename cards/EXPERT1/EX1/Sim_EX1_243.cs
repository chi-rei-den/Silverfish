

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_243",
  "name": [
    "尘魔",
    "Dust Devil"
  ],
  "text": [
    "<b>风怒</b>，<b>过载：</b>（2）",
    "<b>Windfury</b>. <b>Overload:</b> (2)"
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 618
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_243 : SimTemplate //dustdevil
    {
//    windzorn/, überladung:/ (2)
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.ueberladung += 2;
            }
        }
    }
}