using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_072",
  "name": [
    "瓦里安·乌瑞恩",
    "Varian Wrynn"
  ],
  "text": [
    "<b>战吼：</b>抽三张牌。将抽到的随从牌直接置入战场。",
    "<b>Battlecry:</b> Draw 3 cards.\nPut any minions you drew directly into the battlefield."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 10,
  "rarity": "LEGENDARY",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2760
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_072 : SimTemplate //* Varian Wrynn
    {
        //Battlecry: Draw 3 cards. Put any minion you drew directly into the battlefield.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                var tmpCard = p.owncards.Count;
                p.drawACard(SimCard.None, own.own);
                if (tmpCard < 10)
                {
                    p.owncards.RemoveRange(p.owncards.Count - 1, 1);
                    p.owncarddraw--;
                    p.callKid(CardIds.Collectible.Neutral.RiverCrocolisk, p.ownMinions.Count, own.own, false); //river crocolisk
                }

                p.drawACard(SimCard.None, own.own);
                if (tmpCard < 10)
                {
                    p.owncards.RemoveRange(p.owncards.Count - 1, 1);
                    p.owncarddraw--;
                    p.callKid(CardIds.Collectible.Neutral.Spellbreaker, p.ownMinions.Count, own.own, false); //spellbreaker
                }

                p.drawACard(SimCard.None, own.own);
            }
        }
    }
}