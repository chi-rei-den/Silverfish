using System;
using System.Collections.Generic;
using System.Text;
using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_021",
  "name": [
    "毒镖陷阱",
    "Dart Trap"
  ],
  "text": [
    "<b>奥秘：</b>\n在对方使用英雄技能后，随机对一个敌人造成$5点伤害。",
    "<b>Secret:</b> After an opposing Hero Power is used, deal $5 damage to a random enemy."
  ],
  "cardClass": "HUNTER",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2893
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_LOE_021 : SimTemplate //* Dart Trap
	{
		//Secret: When an opposing Hero Power is used, deal 5 damage to a random enemy.

		public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
			Minion target = null;
						
			if (temp.Count > 0) target = p.searchRandomMinion(temp, SearchMode.searchHighAttackLowHP);
			if (target == null || ((ownplay) ? p.enemyHero : p.ownHero).Hp < 6) target = (ownplay) ? p.enemyHero : p.ownHero;
			p.minionGetDamageOrHeal(target, 5);
        }
    }
}