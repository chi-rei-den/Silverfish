using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMC_94",
  "name": [
    "萨弗拉斯",
    "Sulfuras"
  ],
  "text": [
    "<b>亡语：</b>你的英雄技能变为“随机对一个敌人造成8点伤害”。",
    "<b>Deathrattle:</b> Your Hero Power becomes 'Deal 8 damage to a random enemy'."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 2,
  "rarity": null,
  "set": "TB",
  "collectible": null,
  "dbfId": 2691
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BRMC_94 : SimTemplate //* Sulfuras
	{
		// Deathrattle:: Your Hero Power becomes 'Deal 8 damage to a random enemy'.
		
        Chireiden.Silverfish.SimCard weapon = CardIds.NonCollectible.Neutral.Sulfuras;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Neutral.MajordomoExecutus_DieInsectHeroPower, m.own); // DIE, INSECT!
        }
    }
}