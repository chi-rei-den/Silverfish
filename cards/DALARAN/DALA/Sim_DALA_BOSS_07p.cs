using HearthDb.Enums;
/* _BEGIN_TEMPLATE_
{
  "id": "DALA_BOSS_07p",
  "name": [
    "起飞",
    "Take Flight!"
  ],
  "text": [
    "<b>被动英雄技能</b>\n贝尔纳拉将在受到15点伤害后起飞<i>（还剩下",
    "[x]<b>Passive Hero Power</b>\nAfter taking 15 damage,\nBelnaara will take flight.\n<i>("
  ],
  "CardClass": "NEUTRAL",
  "type": "HERO_POWER",
  "cost": 0,
  "rarity": null,
  "set": "DALARAN",
  "collectible": null,
  "dbfId": 54078
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
	class Sim_DALA_BOSS_07p : SimTemplate //* 起飞 Take Flight!
	{
		//[x]<b>Passive Hero Power</b>After taking 15 damage,Belnaara will take flight.<i>(15 damage remaining)</i>
		//<b>被动英雄技能</b>贝尔纳拉将在受到15点伤害后起飞<i>（还剩下15点伤害）</i>。


	}
}