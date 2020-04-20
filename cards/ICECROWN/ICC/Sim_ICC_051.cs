using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_051",
  "name": [
    "虫群德鲁伊",
    "Druid of the Swarm"
  ],
  "text": [
    "<b>抉择：</b>将该随从变形成为1/2并具有<b>剧毒</b>；或者将该随从变形成为1/5并具有<b>嘲讽</b>。",
    "<b>Choose One -</b> Transform into a 1/2 with <b>Poisonous</b>; or a 1/5 with <b>Taunt</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42651
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_051 : SimTemplate //* Druid of the Swarm
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (p.ownFandralStaghelm > 0)
            {
                p.minionTransform(own, CardIds.NonCollectible.Druid.DruidoftheSwarm_DruidOfTheSwarmToken3);
            }
            else
            {
                switch (choice)
                {
                    case 1: p.minionTransform(own, CardIds.NonCollectible.Druid.DruidoftheSwarm_DruidOfTheSwarmToken1); break;
                    case 2: p.minionTransform(own, CardIds.NonCollectible.Druid.DruidoftheSwarm_DruidOfTheSwarmToken2); break;
                }
            }
        }
    }
}