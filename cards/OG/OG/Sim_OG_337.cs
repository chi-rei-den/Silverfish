

/* _BEGIN_TEMPLATE_
{
  "id": "OG_337",
  "name": [
    "巨型独眼怪",
    "Cyclopian Horror"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>每有一个敌方随从，便获得+1生命值。",
    "<b>Taunt</b>. <b>Battlecry:</b> Gain      +1 Health for each enemy minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 4,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 39041
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_337 : SimTemplate //* Cyclopian Horror
    {
        //Taunt. Battlecry: Gain +1 Health for each enemy minion.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var gain = own.own ? p.enemyMinions.Count : p.ownMinions.Count;
            if (gain > 0)
            {
                p.minionGetBuffed(own, 0, gain);
            }
        }
    }
}