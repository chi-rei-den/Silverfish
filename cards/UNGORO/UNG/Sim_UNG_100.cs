

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_100",
  "name": [
    "苍绿长颈龙",
    "Verdant Longneck"
  ],
  "text": [
    "<b>战吼：</b><b>进化</b>。",
    "<b>Battlecry:</b> <b>Adapt</b>."
  ],
  "cardClass": "DRUID",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 40971
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_100 : SimTemplate //* Verdant Longneck
    {
        //Battlecry: Adapt.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.getBestAdapt(own);
        }
    }
}