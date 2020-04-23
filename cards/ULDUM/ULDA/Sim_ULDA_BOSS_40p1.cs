/* _BEGIN_TEMPLATE_
{
  "id": "ULDA_BOSS_40p1",
  "name": [
    "命令咆哮",
    "Commanding Scream"
  ],
  "text": [
    "<b>英雄技能</b>\n在本回合中，你的随从的生命值无法被降到1点以下。",
    "[x]<b>Hero Power</b>\nYour minions can't be\nreduced below 1 Health\nthis turn."
  ],
  "cardClass": "WARRIOR",
  "type": "HERO_POWER",
  "cost": 1,
  "rarity": null,
  "set": "ULDUM",
  "collectible": null,
  "dbfId": 57266
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ULDA_BOSS_40p1 : SimTemplate //* 命令咆哮 Commanding Scream
    {
        //[x]<b>Hero Power</b>Your minions can't bereduced below 1 Healththis turn.
        //<b>英雄技能</b>在本回合中，你的随从的生命值无法被降到1点以下。
    }
}