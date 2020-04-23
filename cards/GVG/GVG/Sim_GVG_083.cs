

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_083",
  "name": [
    "高级修理机器人",
    "Upgraded Repair Bot"
  ],
  "text": [
    "<b>战吼：</b>使一个友方机械获得+4生命值。",
    "<b>Battlecry:</b> Give a friendly Mech +4 Health."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2051
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_083 : SimTemplate //Upgraded Repair Bot
    {
        //   Battlecry:&lt;/b&gt; Give a friendly Mech +4 Health.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetBuffed(target, 0, 4);
            }
        }
    }
}