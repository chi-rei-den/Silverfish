using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_202",
  "name": [
    "火羽先锋",
    "Fire Plume Harbinger"
  ],
  "text": [
    "<b>战吼：</b>使你手牌中所有元素牌的法力值消耗减少（1）点。",
    "<b>Battlecry:</b> Reduce the Cost of Elementals in your hand by (1)."
  ],
  "cardClass": "SHAMAN",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41107
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_202 : SimTemplate //* Fire Plume Harbinger
    {
        //Battlecry: Reduce the Cost of Elementals in your hand by (1).

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                foreach (var hc in p.owncards)
                {
                    if (hc.card.Race == Race.ELEMENTAL)
                    {
                        hc.manacost--;
                    }
                }
            }
        }
    }
}