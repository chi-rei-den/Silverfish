using HearthDb.Enums;
using Chireiden.Silverfish;
using HearthDb;
using System;
using System.Collections.Generic;
using System.Text;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_026",
  "name": [
    "紫罗兰教师",
    "Violet Teacher"
  ],
  "text": [
    "每当你施放一个法术，召唤一个1/1的紫罗兰学徒。",
    "Whenever you cast a spell, summon a 1/1 Violet Apprentice."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1029
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_026 : SimTemplate //* Violet Teacher
    {
        //Whenever you cast a spell, summon a 1/1 Violet Apprentice.

        public SimCard card = CardIds.NonCollectible.Neutral.VioletTeacher_VioletApprenticeToken;

        public override void onCardIsGoingToBePlayed(Playfield p, Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (wasOwnCard == triggerEffectMinion.own && hc.card.Type == CardType.SPELL)
            {
                p.callKid(card, triggerEffectMinion.zonepos, wasOwnCard);
            }
        }
    }
}
