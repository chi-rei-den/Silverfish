

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_116",
  "name": [
    "遗物搜寻者",
    "Reliquary Seeker"
  ],
  "text": [
    "<b>战吼：</b>如果你拥有六个其他随从，便获得+4/+4。",
    "<b>Battlecry:</b> If you have 6 other minions, gain +4/+4."
  ],
  "cardClass": "WARLOCK",
  "type": "MINION",
  "cost": 1,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 13334
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_116 : SimTemplate //* Reliquary Seeker
    {
        //Battlecry: If you have 6 other minions, gain +4/+4.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            var mCount = m.own ? p.ownMinions.Count : p.enemyMinions.Count;
            if (mCount > 6)
            {
                p.minionGetBuffed(m, 4, 4);
            }
        }
    }
}