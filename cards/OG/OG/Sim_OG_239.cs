using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_239",
  "name": [
    "末日降临",
    "DOOM!"
  ],
  "text": [
    "消灭所有随从。每消灭一个随从，便抽一张牌。",
    "Destroy all minions. Draw a card for each."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 10,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38770
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_239 : SimTemplate //* DOOM!
    {
        //Destroy all minions. Draw a card for each.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var anz = p.ownMinions.Count + p.enemyMinions.Count;
            p.allMinionsGetDestroyed();
            for (var i = 0; i < anz; i++)
            {
                p.drawACard(SimCard.None, ownplay);
            }
        }
    }
}