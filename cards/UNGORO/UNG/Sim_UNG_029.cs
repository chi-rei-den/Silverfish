using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_029",
  "name": [
    "暗影视界",
    "Shadow Visions"
  ],
  "text": [
    "从你的牌库中<b>发现</b>一张法术牌的复制。",
    "<b>Discover</b> a copy of a spell in your deck."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41169
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_029 : SimTemplate //* Shadow Visions
    {
        //Discover a copy of a spell in your deck.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardIds.Collectible.Priest.ShadowWordDeath, ownplay, true);
            p.drawACard(CardIds.Collectible.Priest.HolyNova, ownplay, true);
            p.owncarddraw--;
        }
    }
}