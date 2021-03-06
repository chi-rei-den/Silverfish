using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_061",
  "name": [
    "作战动员",
    "Muster for Battle"
  ],
  "text": [
    "召唤三个1/1的白银之手新兵，装备一把1/4的武器。",
    "Summon three 1/1 Silver Hand Recruits. Equip a 1/4 Weapon."
  ],
  "cardClass": "PALADIN",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2029
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_061 : SimTemplate //* Muster for Battle
    {
        // Summon three 1/1 Silver Hand Recruits. Equip a 1/4 Weapon.

        SimCard kid = CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken;
        SimCard w = CardIds.Collectible.Paladin.LightsJustice;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;

            p.callKid(this.kid, pos, ownplay, false);
            for (var i = 0; i < 2; i++)
            {
                p.callKid(this.kid, pos, ownplay);
            }

            p.equipWeapon(this.w, ownplay);
        }
    }
}