using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_834",
  "name": [
    "天灾领主加尔鲁什",
    "Scourgelord Garrosh"
  ],
  "text": [
    "<b>战吼：</b>装备一把4/3的影之哀伤，影之哀伤同时对其攻击目标相邻的随从造成伤害。",
    "<b>Battlecry</b>: Equip a 4/3 Shadowmourne that also damages adjacent minions."
  ],
  "cardClass": "WARRIOR",
  "type": "HERO",
  "cost": 8,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43423
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_834: SimTemplate //* Scourgelord Garrosh
    {
        // Battlecry: Equip a 4/3 Shadowmourne that also damages adjacent minions.

        SimCard w = CardIds.NonCollectible.Warrior.ScourgelordGarrosh_Shadowmourne; //Shadowmourne

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardIds.NonCollectible.Warrior.BladestormHeroic, ownplay); // Bladestorm
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            p.equipWeapon(w, ownplay);
        }
    }
}