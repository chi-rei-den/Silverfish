/* _BEGIN_TEMPLATE_
{
  "id": "LOOT_535",
  "name": [
    "巨龙召唤者奥兰纳",
    "Dragoncaller Alanna"
  ],
  "text": [
    "<b>战吼：</b>在本局对战中，你每施放过一个法力值消耗大于或等于（5）点的法术，便召唤一个5/5的龙。",
    "<b>Battlecry:</b> Summon a 5/5 Dragon for each spell you cast this game that costs (5) or more."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 9,
  "rarity": "LEGENDARY",
  "set": "LOOTAPALOOZA",
  "collectible": true,
  "dbfId": 46499
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOOT_535 : SimTemplate //* 巨龙召唤者奥兰纳 Dragoncaller Alanna
    {
        //<b>Battlecry:</b> Summon a 5/5 Dragon for each spell you cast this game that costs (5) or more.
        //<b>战吼：</b>在本局对战中，你每施放过一个法力值消耗大于或等于（5）的法术，便召唤一个5/5的龙。
    }
}