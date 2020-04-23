

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_954t1",
  "name": [
    "嘉沃顿",
    "Galvadon"
  ],
  "text": [
    "<b>战吼：</b>\n连续<b>进化</b>五次。",
    "<b>Battlecry:</b> <b>Adapt</b> 5 times."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 5,
  "rarity": null,
  "set": "UNGORO",
  "collectible": null,
  "dbfId": 41946
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_954t1 : SimTemplate //* Galvadon
    {
        //Battlecry: Adapt 5 times.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetBuffed(own, 6, 0);
            p.minionGetBuffed(own, 0, 3);
            own.taunt = true;
            own.divineshild = true;
        }
    }
}