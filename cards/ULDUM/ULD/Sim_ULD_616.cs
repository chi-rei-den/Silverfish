using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "ULD_616",
  "name": [
    "泰坦造物跟班",
    "Titanic Lackey"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得+2生命值和\n<b>嘲讽</b>。",
    "<b>Battlecry:</b> Give a friendly minion +2 Health and <b>Taunt</b>."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "ULDUM",
  "collectible": null,
  "dbfId": 53163
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{ 

public class Sim_ULD_616 : SimTemplate 
{ 

public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice) 
{ 
if (target != null) 
{ 
p.minionGetBuffed(target, 0, 2); 
if (!target.taunt) 
{ 
target.taunt = true; 
if (target.own) 
{ 
p.anzOwnTaunt++; 
} 
else 
{ 
p.anzEnemyTaunt++; 
} 
} 
} 
} 
} 
}
