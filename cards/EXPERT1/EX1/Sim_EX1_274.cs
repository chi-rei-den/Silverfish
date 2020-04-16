using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_274",
  "name": [
    "虚灵奥术师",
    "Ethereal Arcanist"
  ],
  "text": [
    "如果在你的回合结束时，你控制一个<b>奥秘</b>，该随从便获得+2/+2。",
    "If you control a <b>Secret</b> at the end of your turn, gain +2/+2."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1737
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_EX1_274 : SimTemplate //etherealarcanist
	{

//    erhält +2/+2, wenn ihr am ende eures zuges über ein aktives geheimnis/ verfügt.
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                int b = (turnEndOfOwner) ? p.ownSecretsIDList.Count : p.enemySecretCount;
                if (b >= 1) p.minionGetBuffed(triggerEffectMinion, 2, 2);
 
            }
        }

	}
}