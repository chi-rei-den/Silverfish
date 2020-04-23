/* _BEGIN_TEMPLATE_
{
  "id": "TRLA_148",
  "name": [
    "战斗僵尸",
    "Weaponized Zombie"
  ],
  "text": [
    "<b>对战开始时</b>：抽到这张牌。\n<b>亡语：</b>随机使一个友方随从获得+1/+1。",
    "<b>Start of Game:</b> Draw this.\n<b>Deathrattle:</b> Give a random friendly minion +1/+1."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 1,
  "rarity": null,
  "set": "TROLL",
  "collectible": null,
  "dbfId": 52040
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_TRLA_148 : SimTemplate //* 战斗僵尸 Weaponized Zombie
    {
        //<b>Start of Game:</b> Draw this.<b>Deathrattle:</b> Give a random friendly minion +1/+1.
        //<b>对战开始时</b>：抽到这张牌。<b>亡语：</b>随机使一个友方随从获得+1/+1。
    }
}