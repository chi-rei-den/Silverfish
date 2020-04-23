

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_120",
  "name": [
    "赫米特·奈辛瓦里",
    "Hemet Nesingwary"
  ],
  "text": [
    "<b>战吼：</b>\n消灭一个野兽。",
    "<b>Battlecry:</b> Destroy a Beast."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2088
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_120 : SimTemplate //Hemet Nesingwary
    {
        //   Battlecry: Destroy a Beast.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target == null)
            {
                return;
            }

            p.minionGetDestroyed(target);
        }
    }
}