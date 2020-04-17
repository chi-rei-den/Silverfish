using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_027",
  "name": [
    "管理者埃克索图斯",
    "Majordomo Executus"
  ],
  "text": [
    "<b>亡语：</b>\n用炎魔之王拉格纳罗斯替换你的英雄。",
    "<b>Deathrattle:</b> Replace your hero with Ragnaros the Firelord."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2281
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRM_027 : SimCard //* Majordomo Executus
	{
		//Deathrattle: Replace your hero with Ragnaros, the Firelord.
		        
		public override void onDeathrattle(Playfield p, Minion m)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.BRM_027p, m.own); // DIE, INSECT!

			if (m.own)
            {
                p.ownHeroName = HeroEnum.ragnarosthefirelord;
                p.ownHero.Hp = 8;
                p.ownHero.maxHp = 8;
            }
            else
            {
                p.enemyHeroName = HeroEnum.ragnarosthefirelord;
                p.enemyHero.Hp = 8;
                p.enemyHero.maxHp = 8;
            }
        }
	}
}