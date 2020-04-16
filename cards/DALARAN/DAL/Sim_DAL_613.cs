using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "DAL_613",
  "name": [
    "无面跟班",
    "Faceless Lackey"
  ],
  "text": [
    "<b>战吼：</b>随机召唤一个法力值消耗为（2）的随从。",
    "<b>Battlecry:</b> Summon a random 2-Cost minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "DALARAN",
  "collectible": null,
  "dbfId": 53160
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{ 

public class Sim_DAL_613: SimTemplate 
{ 



public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice) 
{ 
CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_121);
List<Minion> list = (m.own) ? p.ownMinions : p.enemyMinions; 
int anz = list.Count; 
p.callKid(kid, m.zonepos, m.own); 
if (anz < 7 && !list[m.zonepos].taunt) 
{ 
list[m.zonepos].taunt = true; 
if (m.own) 
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