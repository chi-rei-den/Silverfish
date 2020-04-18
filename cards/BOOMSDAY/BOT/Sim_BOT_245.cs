using System;
using System.Collections.Generic;
using System.Text;


/* _BEGIN_TEMPLATE_
{
  "id": "BOT_245",
  "name": [
    "风暴聚合器",
    "The Storm Bringer"
  ],
  "text": [
    "随机将你的所有随从变形成为<b>传说</b>随从。",
    "Transform your minions into random <b>Legendary</b> minions."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 48161
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
class Sim_BOT_245: SimTemplate //* 风暴聚合器
{
Chireiden.Silverfish.SimCard kid = CardDB.Instance.getCardDataFromID(Chireiden.Silverfish.SimCard.CS2_182);
public override void onCardPlay(Playfield p,bool ownplay,Minion target,int choice)
{
List<Minion> temp = (ownplay) ? p.ownMinions : p.enemyMinions;
foreach(Minion m in temp)
{
p.minionTransform(m,kid);
}
}
}
}
