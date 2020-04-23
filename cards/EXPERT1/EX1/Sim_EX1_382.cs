

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_382",
  "name": [
    "奥尔多卫士",
    "Aldor Peacekeeper"
  ],
  "text": [
    "<b>战吼：</b>使一个敌方随从的攻击力变为1。",
    "<b>Battlecry:</b> Change an enemy minion's Attack to 1."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1167
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_382 : SimTemplate //* Aldor Peacekeeper
    {
        //Battlecry: Change an enemy minion's Attack to 1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionSetAngrToX(target, 1);
            }
        }
    }
}