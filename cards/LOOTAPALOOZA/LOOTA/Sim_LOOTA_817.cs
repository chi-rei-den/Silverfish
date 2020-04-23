/* _BEGIN_TEMPLATE_
{
  "id": "LOOTA_817",
  "name": [
    "始生之杖",
    "Primordial Wand"
  ],
  "text": [
    "<b>进化</b>一个友方随从。在本次冒险中每打败过一个首领，就重复一次。",
    "[x]<b>Adapt</b> a friendly minion.\nRepeat for each boss\nyou've defeated this run."
  ],
  "cardClass": "NEUTRAL",
  "type": "SPELL",
  "cost": 4,
  "rarity": null,
  "set": "LOOTAPALOOZA",
  "collectible": null,
  "dbfId": 46421
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOOTA_817 : SimTemplate //* 始生之杖 Primordial Wand
    {
        //<b>Adapt</b> a friendly minion {0} |4(time, times).
        //使一个友方随从<b>进化</b>{0}次。
    }
}