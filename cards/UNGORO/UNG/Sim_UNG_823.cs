

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_823",
  "name": [
    "浸毒武器",
    "Envenom Weapon"
  ],
  "text": [
    "使你的武器获得<b>剧毒</b>。",
    "Give your weapon <b>Poisonous</b>."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 3,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41834
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_823 : SimTemplate //* Envenom Weapon
    {
        //Give your weapon Poisonous.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.ownWeapon.poisonous = true;
            }
            else
            {
                p.enemyWeapon.poisonous = true;
            }
        }
    }
}