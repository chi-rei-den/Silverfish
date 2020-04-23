

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_205",
  "name": [
    "冰川裂片",
    "Glacial Shard"
  ],
  "text": [
    "<b>战吼：</b>\n<b>冻结</b>一个敌人。",
    "<b>Battlecry:</b> <b>Freeze</b> an enemy."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41111
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_205 : SimTemplate //* Glacial Shard
    {
        //Battlecry: Freeze an enemy.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetFrozen(target);
            }
        }
    }
}