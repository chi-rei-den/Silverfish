using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "NEW1_036",
  "name": [
    "命令怒吼",
    "Commanding Shout"
  ],
  "text": [
    "在本回合中，你的随从的生命值无法被降到1点以下。抽一张牌。",
    "Your minions can't be reduced below 1 Health this turn. Draw a card."
  ],
  "cardClass": "WARRIOR",
  "type": "SPELL",
  "cost": 2,
  "rarity": "RARE",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 1026
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_NEW1_036 : SimTemplate //commanding shout
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var temp = ownplay ? p.ownMinions : p.enemyMinions;
            foreach (var t in temp)
            {
                t.cantLowerHPbelowONE = true;
            }

            p.drawACard(SimCard.None, ownplay);
        }
    }
}