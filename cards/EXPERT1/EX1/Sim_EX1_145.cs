

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_145",
  "name": [
    "伺机待发",
    "Preparation"
  ],
  "text": [
    "在本回合中，你所施放的下一个法术的法力值消耗减少（2）点。",
    "The next spell you cast this turn costs (2) less."
  ],
  "cardClass": "ROGUE",
  "type": "SPELL",
  "cost": 0,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1158
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_145 : SimTemplate //preparation
    {
//    der nächste zauber, den ihr in diesem zug wirkt, kostet (3) weniger.
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.playedPreparation = true;
            }
        }
    }
}