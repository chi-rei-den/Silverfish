

/* _BEGIN_TEMPLATE_
{
  "id": "AT_040",
  "name": [
    "荒野行者",
    "Wildwalker"
  ],
  "text": [
    "<b>战吼：</b>使一个友方野兽获得+3生命值。",
    "<b>Battlecry:</b> Give a friendly Beast +3 Health."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2786
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_040 : SimTemplate //* Wildwalker
    {
        //Battlecry: Give a friendly Beast +3 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetBuffed(target, 0, 3);
            }
        }
    }
}