using HearthDb;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "BRMA13_4H",
  "name": [
    "狂野魔法",
    "Wild Magic"
  ],
  "text": [
    "<b>英雄技能</b>\n随机将一张你对手职业的法术牌置入你的手牌。",
    "<b>Hero Power</b>\nPut a random spell from your opponent's class into your hand."
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 1,
  "rarity": null,
  "set": "BRM",
  "collectible": null,
  "dbfId": 2467
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRMA13_4H : SimTemplate //* Wild Magic
    {
        // Hero Power: Put a random spell from your opponent's class into your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var opponentHeroClass = ownplay ? p.enemyHeroStartClass : p.ownHeroStartClass;

            switch (opponentHeroClass)
            {
                case CardClass.WARRIOR:
                    p.drawACard(CardIds.Collectible.Warrior.ShieldBlock, ownplay, true);
                    break;
                case CardClass.WARLOCK:
                    p.drawACard(CardIds.Collectible.Warlock.BaneOfDoom, ownplay, true);
                    break;
                case CardClass.ROGUE:
                    p.drawACard(CardIds.Collectible.Rogue.Sprint, ownplay, true);
                    break;
                case CardClass.SHAMAN:
                    p.drawACard(CardIds.Collectible.Shaman.FarSight, ownplay, true);
                    break;
                case CardClass.PRIEST:
                    p.drawACard(CardIds.Collectible.Priest.Thoughtsteal, ownplay, true);
                    break;
                case CardClass.PALADIN:
                    p.drawACard(CardIds.Collectible.Paladin.HammerOfWrath, ownplay, true);
                    break;
                case CardClass.MAGE:
                    p.drawACard(CardIds.Collectible.Mage.FrostNova, ownplay, true);
                    break;
                case CardClass.HUNTER:
                    p.drawACard(CardIds.Collectible.Hunter.CobraShot, ownplay, true);
                    break;
                case CardClass.DRUID:
                    p.drawACard(CardIds.Collectible.Druid.WildGrowth, ownplay, true);
                    break;
                //default:
            }
        }
    }
}