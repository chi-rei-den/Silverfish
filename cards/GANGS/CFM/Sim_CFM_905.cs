using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_905",
  "name": [
    "三教九流",
    "Small-Time Recruits"
  ],
  "text": [
    "从你的牌库中抽三张法力值消耗为（1）的随从牌。",
    "[x]Draw three 1-Cost\nminions from your deck."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "EPIC",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40634
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_905 : SimTemplate //* Small-Time Recruits
    {
        // Draw three 1-Cost minions from your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                SimCard c;
                var count = 0;
                foreach (var cid in p.prozis.turnDeck)
                {
                    c = cid.Key;
                    if (c.Cost == 1)
                    {
                        for (var i = 0; i < cid.Value; i++)
                        {
                            p.drawACard(c.CardId, true);
                            count++;
                            if (count > 2)
                            {
                                break;
                            }
                        }

                        if (count > 2)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}