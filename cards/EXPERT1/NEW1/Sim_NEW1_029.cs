

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_029",
  "name": [
    "米尔豪斯·法力风暴",
    "Millhouse Manastorm"
  ],
  "text": [
    "<b>战吼：</b>下个回合敌方法术的法力值消耗为（0）点。",
    "<b>Battlecry:</b> Enemy spells cost (0) next turn."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 855
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_029 : SimTemplate //millhousemanastorm
    {
//    kampfschrei:/ im nächsten zug kosten zauber für euren gegner (0) mana.
        //todo implement the nomanacosts for the enemyturn
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.weHavePlayedMillhouseManastorm = true;
            }
        }
    }
}