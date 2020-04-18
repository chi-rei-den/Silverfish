using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_050",
  "name": [
    "蛛网",
    "Webweave"
  ],
  "text": [
    "召唤两只1/2并具有<b>剧毒</b>的\n蜘蛛。",
    "Summon two 1/2 <b>Poisonous</b> Spiders."
  ],
  "cardClass": "DRUID",
  "type": "SPELL",
  "cost": 5,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42649
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_050: SimTemplate //* Webweave
    {
        // Summon two 1/2 Poisonous Spiders

        Chireiden.Silverfish.SimCard kid = CardIds.NonCollectible.Druid.DruidoftheSwarm_DruidOfTheSwarmToken1; //Poisonous Spider

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(kid, pos, ownplay, false);
            p.callKid(kid, pos, ownplay);
        }
    }
}