

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_052",
  "name": [
    "重碾",
    "Crush"
  ],
  "text": [
    "消灭一个随从。如果你控制任何受伤的随从，该法术的法力值消耗减少（4）点。",
    "Destroy a minion. If you have a damaged minion, this costs (4) less."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 7,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2020
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_052 : SimTemplate //Crush
    {
        //   Destroy a minion. If you have a damaged minion, this costs (4) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionGetDestroyed(target);
        }
    }
}