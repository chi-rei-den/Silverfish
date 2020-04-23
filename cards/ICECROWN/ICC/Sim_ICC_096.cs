using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_096",
  "name": [
    "熔火巨像",
    "Furnacefire Colossus"
  ],
  "text": [
    "<b>战吼：</b>弃掉你手牌中所有的武器牌，并获得这些武器的属性值。",
    "<b>Battlecry:</b> Discard all weapons from your hand and gain their stats."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42779
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_096 : SimTemplate //* Furnacefire Colossus
    {
        // Battlecry: Discard all weapons from your hand and gain their stats.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                var atkBuff = 0;
                var hpBuff = 0;

                foreach (var hc in p.owncards.ToArray())
                {
                    if (hc.card.Type == CardType.WEAPON)
                    {
                        atkBuff += hc.card.Attack + hc.addattack;
                        hpBuff += hc.card.Durability + hc.addHp;
                        p.owncards.Remove(hc);
                    }
                }

                if (atkBuff + hpBuff > 0)
                {
                    p.minionGetBuffed(own, atkBuff, hpBuff);
                }
            }
        }
    }
}