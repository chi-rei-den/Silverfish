using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "OG_031",
  "name": [
    "暮光神锤",
    "Hammer of Twilight"
  ],
  "text": [
    "<b>亡语：</b>召唤一个4/2的元素随从。",
    "<b>Deathrattle:</b> Summon a 4/2 Elemental."
  ],
  "cardClass": "SHAMAN",
  "type": "WEAPON",
  "cost": 5,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38270
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_031 : SimTemplate //* Hammer of Twilight
    {
        //Deathrattle: Summon a 4/2 Elemental.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(CardIds.Collectible.Shaman.HammerOfTwilight, ownplay);
        }

        public override void onDeathrattle(Playfield p, Minion m)
        {
            var pos = m.own ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(CardIds.NonCollectible.Shaman.HammerofTwilight_TwilightElemental, pos, m.own);
        }
    }
}