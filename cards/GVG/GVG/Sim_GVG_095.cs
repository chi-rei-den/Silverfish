

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_095",
  "name": [
    "地精工兵",
    "Goblin Sapper"
  ],
  "text": [
    "如果你对手的手牌数量大于或等于6张，便具有+4攻击力。",
    "Has +4 Attack while your opponent has 6 or more cards in hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2063
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_095 : SimTemplate //Goblin Sapper
    {
        //  Has +4 Attack while your opponent has 6 or more cards in hand. 

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var anz = own.own ? p.enemyAnzCards : p.owncards.Count;
            if (anz >= 6)
            {
                p.minionGetBuffed(own, 4, 0);
            }
        }
    }
}