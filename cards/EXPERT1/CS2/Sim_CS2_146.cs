

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_146",
  "name": [
    "南海船工",
    "Southsea Deckhand"
  ],
  "text": [
    "如果你装备一把武器，该随从具有\n<b>冲锋</b>。",
    "Has <b>Charge</b> while you have a weapon equipped."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 1,
  "rarity": "COMMON",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 724
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_146 : SimTemplate //southseadeckhand
    {
//    hat ansturm/, während ihr eine waffe angelegt habt.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.minionGetCharge(own);
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.minionGetCharge(own);
                }
            }
        }
    }
}