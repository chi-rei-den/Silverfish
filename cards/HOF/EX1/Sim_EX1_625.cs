using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_625",
  "name": [
    "暗影形态",
    "Shadowform"
  ],
  "text": [
    "你的英雄技能变为“造成2点伤害”，如果已经处于暗影形态下：改为“造成3点伤害”。",
    "Your Hero Power becomes 'Deal 2 damage'. If already in Shadowform: 3 damage."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "HOF",
  "collectible": true,
  "dbfId": 1368
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_625 : SimTemplate //* Shadowform
    {
        // Your Hero Power becomes 'Deal 2 damage'. If already in Shadowform: 3 damage.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            SimCard newHeroPower = CardIds.NonCollectible.Priest.Shadowform_MindSpikeToken; // Mind Spike
            if ((ownplay ? p.ownHeroAblility.card.CardId : p.enemyHeroAblility.card.CardId) == CardIds.NonCollectible.Priest.Shadowform_MindSpikeToken) 
                newHeroPower = CardIds.NonCollectible.Priest.Shadowform_MindShatterToken; // Mind Shatter
            p.setNewHeroPower(newHeroPower, ownplay);
        }
    }
}