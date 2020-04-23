using Chireiden.Silverfish;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_089",
  "name": [
    "冰钓术",
    "Ice Fishing"
  ],
  "text": [
    "从你的牌库中抽两张鱼人牌。",
    "Draw 2 Murlocs from your deck."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 2,
  "rarity": "COMMON",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42763
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_089 : SimTemplate //* Ice Fishing
    {
        // Draw 2 Murlocs from your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                SimCard c;
                var count = 0;
                foreach (var cid in p.prozis.turnDeck)
                {
                    c = cid.Key;
                    if (c.Race == Race.MURLOC)
                    {
                        for (var i = 0; i < cid.Value; i++)
                        {
                            p.drawACard(cid.Key, ownplay);
                            count++;
                            if (count > 1)
                            {
                                break;
                            }
                        }

                        if (count > 1)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                p.drawACard(SimCard.None, ownplay);
                p.drawACard(SimCard.None, ownplay);
            }
        }
    }
}