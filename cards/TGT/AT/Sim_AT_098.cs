

/* _BEGIN_TEMPLATE_
{
  "id": "AT_098",
  "name": [
    "杂耍吞法者",
    "Sideshow Spelleater"
  ],
  "text": [
    "<b>战吼：</b>复制对手的英雄技能。",
    "<b>Battlecry:</b> Copy your opponent's Hero Power."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2573
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_098 : SimTemplate //* Sideshow Spelleater
    {
        //Battlecry: Copy your opoonent's Hero Power.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                p.ownHeroAblility = new Handcard(p.enemyHeroAblility);
            }
            else
            {
                p.enemyHeroAblility = new Handcard(p.ownHeroAblility);
            }
        }
    }
}