using Chireiden.Silverfish;
using HearthDb.Enums;
using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "DAL_741",
  "name": [
    "虚灵跟班",
    "Ethereal Lackey"
  ],
  "text": [
    "<b>战吼：</b>\n<b>发现</b>一张法术牌。",
    "<b>Battlecry:</b> <b>Discover</b> a spell."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "DALARAN",
  "collectible": null,
  "dbfId": 52900
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{ 

public class Sim_DAL_741 : SimTemplate 
{ 


public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice) 
{ 
p.drawACard(SimCard.None, own.own, true); 
} 
} 
}
