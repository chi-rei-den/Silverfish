using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "NAX10_02H",
  "name": [
    "铁钩",
    "Hook"
  ],
  "text": [
    "<b>风怒</b>，<b>亡语：</b>\n将这把武器移回你的手牌。",
    "<b>Windfury</b>\n<b>Deathrattle:</b> Put this weapon into your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 3,
  "rarity": null,
  "set": "NAXX",
  "collectible": null,
  "dbfId": 2132
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NAX10_02H : SimTemplate //* Hook
    {
        //Windfury. Deathrattle: Put this weapon into your hand.

        SimCard weapon = CardIds.NonCollectible.Neutral.HookHeroic;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(CardIds.NonCollectible.Neutral.HookHeroic, m.own, true);
        }
    }
}