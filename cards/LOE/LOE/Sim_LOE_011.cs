

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_011",
  "name": [
    "雷诺·杰克逊",
    "Reno Jackson"
  ],
  "text": [
    "<b>战吼：</b>如果你的牌库里没有相同的牌，则为你的英雄恢复所有生命值。",
    "<b>Battlecry:</b> If your deck has no duplicates, fully heal your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "LOE",
  "collectible": true,
  "dbfId": 2883
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_011 : SimTemplate //* Reno Jackson
    {
        //Battlecry: If your deck contains no more than 1 of any card, fully heal your hero.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own && p.prozis.noDuplicates)
            {
                p.minionGetDamageOrHeal(p.ownHero, p.ownHero.Hp - p.ownHero.maxHp);
            }
        }
    }
}