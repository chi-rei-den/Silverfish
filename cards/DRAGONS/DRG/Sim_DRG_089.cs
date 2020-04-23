/* _BEGIN_TEMPLATE_
{
  "id": "DRG_089",
  "name": [
    "红龙女王阿莱克丝塔萨",
    "Dragonqueen Alexstrasza"
  ],
  "text": [
    "<b>战吼：</b>如果你的牌库里没有相同的牌，则随机将两张其他龙牌置入你的手牌，其法力值消耗为（0）点。",
    "[x]<b>Battlecry:</b> If your deck has\nno duplicates, add 2 other\nrandom Dragons to your\nhand. They cost (0)."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "DRAGONS",
  "collectible": true,
  "dbfId": 55441
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DRG_089 : SimTemplate //* 红龙女王阿莱克丝塔萨 Dragonqueen Alexstrasza
    {
        //<b>Battlecry:</b> If your deck has no duplicates, add 2 random Dragons to your hand. They cost (0).
        //<b>战吼：</b>如果你的牌库里没有相同的牌，则随机将两张龙牌置入你的手牌，其法力值消耗为（0）点。
    }
}