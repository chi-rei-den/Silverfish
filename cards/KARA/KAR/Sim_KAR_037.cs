using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_037",
  "name": [
    "鸟禽守护者",
    "Avian Watcher"
  ],
  "text": [
    "<b>战吼：</b>如果你控制一个<b>奥秘</b>，便获得+1/+1和<b>嘲讽</b>。",
    "<b>Battlecry:</b> If you control a <b>Secret</b>, gain +1/+1\nand <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39489
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_KAR_037 : SimTemplate //* Avian Watcher
	{
		//Battlecry: If you control a Secret, gain +1/+1 and Taunt.
		
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
			int num = (own.own) ? p.ownSecretsIDList.Count : p.enemySecretCount;
			if (num > 0)
			{
				p.minionGetBuffed(own, 1, 1);
				own.taunt = true;
			}
		}
	}
}