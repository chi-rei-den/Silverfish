using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_076",
  "name": [
    "芬利·莫格顿爵士",
    "Sir Finley Mrrgglton"
  ],
  "text": [
    "<b>战吼：发现</b>一个新的基础英雄技能。",
    "<b><b>Battlecry:</b> Discover</b> a new basic Hero Power."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "LEGENDARY",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2948
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_076 : SimTemplate //* Sir Finley Mrrgglton
    {
        //Battlecry: Discover a new Basic Hero Power.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(SimCard.None, own.own, true);
        }
    }
}