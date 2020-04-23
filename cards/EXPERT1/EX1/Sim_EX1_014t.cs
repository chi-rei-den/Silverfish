

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_014t",
  "name": [
    "香蕉",
    "Bananas"
  ],
  "text": [
    "使一个随从获得+1/+1。",
    "Give a minion +1/+1."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 1,
  "rarity": null,
  "set": "EXPERT1",
  "collectible": null,
  "dbfId": 1694
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_014t : SimTemplate //bananas
    {
//    verleiht einem diener +1/+1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetBuffed(target, 1, 1);
        }
    }
}