

/* _BEGIN_TEMPLATE_
{
  "id": "AT_104",
  "name": [
    "海象人龟骑士",
    "Tuskarr Jouster"
  ],
  "text": [
    "<b>战吼：</b>揭示双方牌库里的一张随从牌。如果你的牌法力值消耗较大，则为你的英雄恢复#7点生命值。",
    "<b>Battlecry:</b> Reveal a minion in each deck. If yours costs more, restore #7 Health to your hero."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2504
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_104 : SimTemplate //* Tuskarr Jouster
    {
        //Battlecry: Reveal a minion in each deck. If yours costs more, restore 7 Health to your hero.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var heal = own.own ? p.getMinionHeal(7) : p.getEnemyMinionHeal(7);
            p.minionGetDamageOrHeal(own.own ? p.ownHero : p.enemyHero, -heal); // optimistic
        }
    }
}