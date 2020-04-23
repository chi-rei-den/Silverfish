

/* _BEGIN_TEMPLATE_
{
  "id": "AT_081",
  "name": [
    "纯洁者耶德瑞克",
    "Eadric the Pure"
  ],
  "text": [
    "<b>战吼：</b>使所有敌方随从的攻击力变为1。",
    "<b>Battlecry:</b> Change all enemy minions'\nAttack to 1."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2727
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_081 : SimTemplate //* Eadric the Pure
    {
        //Battlecry: Change all enemy minions' attack to 1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                foreach (var m in p.enemyMinions)
                {
                    p.minionSetAngrToX(m, 1);
                }
            }
            else
            {
                foreach (var m in p.ownMinions)
                {
                    p.minionSetAngrToX(m, 1);
                }
            }
        }
    }
}