using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_828",
  "name": [
    "死亡猎手雷克萨",
    "Deathstalker Rexxar"
  ],
  "text": [
    "<b>战吼：</b>\n对所有敌方随从造成2点伤害。",
    "[x]<b>Battlecry:</b> Deal 2 damage\nto all enemy minions."
  ],
  "cardClass": "HUNTER",
  "type": "HERO",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43398
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_828: SimTemplate //* Deathstalker Rexxar
    {
        // Battlecry: Deal 2 damage to all enemy minions.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(Chireiden.Silverfish.SimCard.ICC_828p, ownplay); // Build-a-Beast
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            p.allMinionOfASideGetDamage(!ownplay, 2);
        }
    }
}