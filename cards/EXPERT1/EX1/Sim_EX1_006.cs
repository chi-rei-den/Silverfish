using System.Collections.Generic;
using Chireiden.Silverfish;
using HearthDb;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_006",
  "name": [
    "报警机器人",
    "Alarm-o-Bot"
  ],
  "text": [
    "在你的回合开始时，随机将你的手牌中的一张随从牌与该随从\n交换。",
    "[x]At the start of your turn,\nswap this minion with a\n   random one in your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1658
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_006 : SimTemplate //* Alarm-o-Bot
    {
        //At the start of your turn, swap this minion with a random one in your hand.

        public override void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            if (turnStartOfOwner && triggerEffectMinion.own == turnStartOfOwner)
            {
                var temp2 = new List<Handcard>();
                foreach (var hc in p.owncards)
                {
                    if (hc.card.Type == CardType.MINION)
                    {
                        temp2.Add(hc);
                    }
                }

                temp2.Sort((a, b) => -a.card.Attack.CompareTo(b.card.Attack)); //damage the stronges
                foreach (var mins in temp2)
                {
                    SimCard c = mins.card.CardId;
                    p.minionTransform(triggerEffectMinion, c);
                    triggerEffectMinion.playedThisTurn = false;
                    triggerEffectMinion.Ready = true;
                    p.removeCard(mins);
                    p.drawACard(CardIds.Collectible.Neutral.AlarmOBot, true, true);
                    break;
                }

                return;
            }

            if (!turnStartOfOwner && triggerEffectMinion.own == turnStartOfOwner)
            {
                p.minionGetBuffed(triggerEffectMinion, 4, 4);
                triggerEffectMinion.Hp = triggerEffectMinion.maxHp;
            }
        }
    }
}