using System;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314t3",
  "name": [
    "末日契约",
    "Doom Pact"
  ],
  "text": [
    "消灭所有随从。每消灭一个随从，移除你的牌库顶的\n一张牌。",
    "[x]Destroy all minions. \nRemove the top card \nfrom your deck for each\nminion destroyed."
  ],
  "cardClass": "DEATHKNIGHT",
  "type": "SPELL",
  "cost": 5,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 42587
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314t3 : SimTemplate //* Doom Pact
    {
        // Destroy all minions. Remove the top card from your deck for each minion destroyed.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var anz = p.ownMinions.Count + p.enemyMinions.Count;
            p.allMinionsGetDestroyed();
            if (ownplay)
            {
                p.ownDeckSize = Math.Max(0, p.ownDeckSize - anz);
            }
            else
            {
                p.enemyDeckSize = Math.Max(0, p.enemyDeckSize - anz);
            }
        }
    }
}