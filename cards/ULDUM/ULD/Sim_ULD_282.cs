/* _BEGIN_TEMPLATE_
{
  "id": "ULD_282",
  "name": [
    "陶罐商人",
    "Jar Dealer"
  ],
  "text": [
    "<b>亡语：</b>随机将一张法力值消耗为（1）的随从牌置入你的手牌。",
    "[x]<b>Deathrattle:</b> Add a random\n1-Cost minion to your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "ULDUM",
  "collectible": true,
  "dbfId": 54013
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ULD_282 : SimTemplate //* 陶罐商人 Jar Dealer
    {
        //[x]<b>Deathrattle:</b> Add a random1-Cost minion to your hand.
        //<b>亡语：</b>随机将一张法力值消耗为（1）点的随从牌置入你的手牌。
    }
}