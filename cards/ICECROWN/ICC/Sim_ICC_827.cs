using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_827",
  "name": [
    "虚空之影瓦莉拉",
    "Valeera the Hollow"
  ],
  "text": [
    "<b>战吼：</b>获得<b>潜行</b>直到你的下个回合。",
    "<b>Battlecry:</b> Gain <b>Stealth</b> until your next turn."
  ],
  "cardClass": "ROGUE",
  "type": "HERO",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43392
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_827: SimCard //* Valeera the Hollow
    {
        // Battlecry: Gain Stealth until your next turn.
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.cardIDEnum.ICC_827p, ownplay); // Death's Shadow
            if (ownplay)
            {
                p.ownHero.armor += 5;
                p.ownHero.stealth = true;
                p.ownHero.conceal = true;
            }
            else
            {
                p.enemyHero.armor += 5;
                p.enemyHero.stealth = true;
                p.enemyHero.conceal = true;
            }
        }
    }
}