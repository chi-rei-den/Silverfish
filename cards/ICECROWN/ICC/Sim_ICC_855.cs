

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_855",
  "name": [
    "海德尼尔冰霜骑士",
    "Hyldnir Frostrider"
  ],
  "text": [
    "<b>战吼：</b><b>冻结</b>你的其他随从。",
    "<b>Battlecry:</b> <b>Freeze</b> your other minions."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 45377
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_855 : SimTemplate //* Hyldnir Frostrider
    {
        // Battlecry: Freeze your other minions.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                p.minionGetFrozen(m);
            }
        }
    }
}