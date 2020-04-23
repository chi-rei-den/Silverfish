
/* _BEGIN_TEMPLATE_
{
  "id": "DAL_603",
  "name": [
    "法力飓风",
    "Mana Cyclone"
  ],
  "text": [
    "<b>战吼：</b>你在本回合中每施放过一个法术，便随机将一张法师法术牌置入你的手牌。",
    "[x]<b>Battlecry:</b> For each spell\nyou've cast this turn, add\na random Mage spell\nto your hand."
  ],
  "CardClass": "MAGE",
  "type": "MINION",
  "cost": 2,
  "rarity": "EPIC",
  "set": "DALARAN",
  "collectible": true,
  "dbfId": 52706
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_DAL_603 : SimTemplate //* 法力飓风 Mana Cyclone
    {
        //[x]<b>Battlecry:</b> For each spellyou've cast this turn, adda random Mage spellto your hand.
        //<b>战吼：</b>你在本回合中每施放过一个法术，便随机将一张法师法术牌置入你的手牌。
    }
}