using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_950",
  "name": [
    "斩棘刀",
    "Vinecleaver"
  ],
  "text": [
    "在你的英雄攻击后，召唤两个1/1的白银之手\n新兵。",
    "[x]After your hero attacks,\nsummon two 1/1 Silver\nHand Recruits."
  ],
  "cardClass": "PALADIN",
  "type": "WEAPON",
  "cost": 7,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41859
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_950 : SimTemplate //* Vinecleaver
    {
        //After your hero attacks, summon two 1/1 Silver Hand Recruits.

        SimCard weapon = CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}