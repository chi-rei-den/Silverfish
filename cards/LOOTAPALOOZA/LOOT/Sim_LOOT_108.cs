using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "LOOT_108",
  "name": [
    "艾露尼斯",
    "Aluneth"
  ],
  "text": [
    "在你的回合结束时，抽三张牌。",
    "At the end of your turn, draw 3 cards."
  ],
  "cardClass": "MAGE",
  "type": "WEAPON",
  "cost": 6,
  "rarity": "LEGENDARY",
  "set": "LOOTAPALOOZA",
  "collectible": true,
  "dbfId": 43426
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOOT_108 : SimTemplate //* 艾露尼斯 Aluneth
    {
        //At the end of your turn, draw 3 cards.
        //在你的回合结束时，抽三张牌。
        SimCard weapon = CardIds.Collectible.Mage.Aluneth;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.weapon, ownplay);
        }
    }
}