/* _BEGIN_TEMPLATE_
{
  "id": "ULDA_114",
  "name": [
    "死亡护盾",
    "Aegis of Death"
  ],
  "text": [
    "你的英雄获得<b>免疫</b>。每个回合损失1点耐久度。<b>亡语：</b>对你的英雄造成100点伤害。",
    "[x]Your hero is <b>Immune</b>.\nEach turn, lose 1 Durabilty.\n<b>Deathrattle:</b> Deal 100\ndamage to your hero."
  ],
  "cardClass": "NEUTRAL",
  "type": "WEAPON",
  "cost": 1,
  "rarity": null,
  "set": "ULDUM",
  "collectible": null,
  "dbfId": 58016
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ULDA_114 : SimTemplate //* 死亡护盾 Aegis of Death
    {
        //[x]Your hero is <b>Immune</b>.Each turn, lose 1 Durabilty.<b>Deathrattle:</b> Deal 100damage to your hero.
        //你的英雄获得<b>免疫</b>。每个回合损失1点耐久度。<b>亡语：</b>对你的英雄造成100点伤害。
    }
}