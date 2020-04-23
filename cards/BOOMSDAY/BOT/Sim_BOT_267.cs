
/* _BEGIN_TEMPLATE_
{
  "id": "BOT_267",
  "name": [
    "载人毁灭机",
    "Piloted Reaper"
  ],
  "text": [
    "<b>亡语：</b>随机从你的手牌中召唤一个法力值消耗小于或等于（2）点的随从。",
    "<b>Deathrattle:</b> Summon a random minion from\nyour hand that costs (2) or less."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "COMMON",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 48223
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BOT_267 : SimTemplate //* 载人毁灭机 Piloted Reaper
    {
        //<b>Deathrattle:</b> Summon a random minion fromyour hand that costs (2) or less.
        //<b>亡语：</b>随机从你的手牌中召唤一个法力值消耗小于或等于（2）的随从。
    }
}