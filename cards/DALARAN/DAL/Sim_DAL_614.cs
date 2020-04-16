using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "DAL_614",
  "name": [
    "狗头人跟班",
    "Kobold Lackey"
  ],
  "text": [
    "<b>战吼：</b>造成2点伤害。",
    "<b>Battlecry:</b> Deal 2 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "DALARAN",
  "collectible": null,
  "dbfId": 53161
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{ 

public class Sim_DAL_614: SimTemplate 
{ 



public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice) 
{ 
int dmg = 2; 
p.minionGetDamageOrHeal(target, dmg); 
} 
} 
}

