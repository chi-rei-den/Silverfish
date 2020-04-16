/* _BEGIN_TEMPLATE_
{
  "id": "BOT_566",
  "name": [
    "鲁莽的实验者",
    "Reckless Experimenter"
  ],
  "text": [
    "你使用的<b>亡语</b>随从牌的法力值消耗减少（3）点，但会在回合结束时死亡。",
    "[x]<b>Deathrattle</b> minions you\nplay cost (3) less, but die\nat the end of the turn."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "BOOMSDAY",
  "collectible": true,
  "dbfId": 49416
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_BOT_566 : SimTemplate //* 鲁莽的实验者 Reckless Experimenter
	{
		//[x]<b>Deathrattle</b> minions youplay cost (3) less, but die atend of turn. <i>(Cost can't bereduced below 1.)</i>
		//你使用的<b>亡语</b>随从牌的法力值消耗减少（3）点<i>（不能被降至1点以下）</i>，但会在回合结束时死亡。


	}
}