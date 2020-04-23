using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_672",
  "name": [
    "郭雅夫人",
    "Madam Goya"
  ],
  "text": [
    "<b>战吼：</b>选择一个友方随从，与你牌库中的一个随从交换。",
    "<b>Battlecry:</b> Choose a friendly minion. Swap it with a minion in your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 41841
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_672 : SimTemplate //* Madam Goya
    {
        // Battlecry: Choose a friendly minion. Swap it with a minion in your deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetFrozen(target);
                p.drawACard(CardIds.NonCollectible.Neutral.Aberration, m.own, true);
            }
        }
    }
}