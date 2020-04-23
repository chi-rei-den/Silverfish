

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_030",
  "name": [
    "洛欧塞布",
    "Loatheb"
  ],
  "text": [
    "<b>战吼：</b>下个回合敌方法术的法力值消耗增加(5)点。",
    "<b>Battlecry:</b> Enemy spells cost (5) more next turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1914
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_030 : SimTemplate //loatheb
    {
//    kampfschrei:/ im nächsten zug kosten zauber für euren gegner (5) mehr.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.loatheb = true;
        }
    }
}