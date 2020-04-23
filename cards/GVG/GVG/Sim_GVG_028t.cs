

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_028t",
  "name": [
    "加里维克斯的幸运币",
    "Gallywix's Coin"
  ],
  "text": [
    "在本回合中，获得一个法力水晶。<i>（不会触发加里维克斯的效果。）</i>",
    "Gain 1 Mana Crystal this turn only.\n<i>(Won't trigger Gallywix.)</i>"
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 0,
  "rarity": null,
  "set": "GVG",
  "collectible": null,
  "dbfId": 2277
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_028t : SimTemplate //Gallywix's Coin
    {
        //    Gain 1 Mana Crystal this turn only.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.mana++;
        }
    }
}