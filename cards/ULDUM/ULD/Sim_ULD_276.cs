using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "ULD_276",
  "name": [
    "怪盗图腾",
    "EVIL Totem"
  ],
  "text": [
    "在你的回合结束时，将一张<b>跟班</b>牌置入你的手牌。",
    "At the end of your turn,\nadd a <b>Lackey</b> to your hand."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ULDUM",
  "collectible": true,
  "dbfId": 54009
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
class Sim_ULD_276 : SimTemplate 
{




public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
{
if (turnEndOfOwner == triggerEffectMinion.own)
{
p.drawACard(CardDB.cardIDEnum.None, turnEndOfOwner);
}
}


}
}