

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_043",
  "name": [
    "暮光幼龙",
    "Twilight Drake"
  ],
  "text": [
    "<b>战吼：</b>\n你每有一张手牌，便获得+1生命值。",
    "<b>Battlecry:</b> Gain +1 Health for each card in your hand."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1037
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_043 : SimTemplate //twilightdrake
    {
//    kampfschrei:/ erhält +1 leben für jede karte auf eurer hand.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetBuffed(own, 0, own.own ? p.owncards.Count : p.enemyAnzCards);
        }
    }
}