

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_017",
  "name": [
    "鱼人杀手蟹",
    "Hungry Crab"
  ],
  "text": [
    "<b>战吼：</b>消灭一个鱼人，并获得+2/+2。",
    "<b>Battlecry:</b> Destroy a Murloc and gain +2/+2."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 443
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_017 : SimTemplate //Hungry Crab
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetDestroyed(target);
                p.minionGetBuffed(own, 2, 2);
            }
        }
    }
}