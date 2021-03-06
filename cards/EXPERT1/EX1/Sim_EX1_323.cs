using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_323",
  "name": [
    "加拉克苏斯大王",
    "Lord Jaraxxus"
  ],
  "text": [
    "<b>战吼：</b>消灭你的英雄，并用加拉克苏斯大王替换之。",
    "<b>Battlecry:</b> Destroy your hero and replace it with Lord Jaraxxus."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 777
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_323 : SimTemplate //* Lord Jaraxxus
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.equipWeapon(CardIds.NonCollectible.Warlock.LordJaraxxus_BloodFury, own.own);
            p.setNewHeroPower(CardIds.NonCollectible.Warlock.Inferno, own.own); // INFERNO!

            if (own.own)
            {
                p.ownHero.Hp = own.Hp;
                p.ownHero.maxHp = own.maxHp;
            }
            else
            {
                p.enemyHero.Hp = own.Hp;
                p.enemyHero.maxHp = own.maxHp;
            }
        }
    }
}