using System;
using System.Collections.Generic;
using System.Text;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_810",
  "name": [
    "亡斧惩罚者",
    "Deathaxe Punisher"
  ],
  "text": [
    "<b>战吼：</b>随机使你手牌中一个具有<b>吸血</b>的随从获得+2/+2。",
    "<b>Battlecry:</b> Give a random <b>Lifesteal</b> minion in your hand +2/+2."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 43029
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_810: SimTemplate //* Deathaxe Punisher
    {
        // Battlecry: Give a random Lifesteal minion in your hand +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                Handcard hc = p.searchRandomMinionInHand(p.owncards, SearchMode.LowCost, GameTag.LIFESTEAL);
                if (hc != null)
                {
                    hc.addattack += 2;
                    hc.addHp += 2;
                    p.anzOwnExtraAngrHp += 4;
                }
            }
        }
    }
}