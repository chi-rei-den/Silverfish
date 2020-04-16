using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "ULD_293",
  "name": [
    "云雾王子",
    "Cloud Prince"
  ],
  "text": [
    "<b>战吼：</b>\n如果你控制一个<b>奥秘</b>，则造成6点伤害。",
    "<b>Battlecry:</b> If you control a <b>Secret</b>, deal 6 damage."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "ULDUM",
  "collectible": true,
  "dbfId": 54493
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ULD_293 : SimTemplate //* 云雾王子 Cloud Prince
    {
        //<b>Battlecry:</b> If you control a <b>Secret</b>, deal 6 damage.
        //<b>战吼：</b>如果你控制一个<b>奥秘</b>，则造成6点伤害。
    public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
    {
        if (target != null) p.minionGetDamageOrHeal(target, 6);
 
    }

    }
}