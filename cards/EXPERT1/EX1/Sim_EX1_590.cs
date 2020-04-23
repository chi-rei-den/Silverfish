

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_590",
  "name": [
    "血骑士",
    "Blood Knight"
  ],
  "text": [
    "<b>战吼：</b>所有随从失去<b>圣盾</b>。每有一个随从失去圣盾，便获得+3/+3。",
    "<b>Battlecry:</b> All minions lose <b>Divine Shield</b>. Gain +3/+3 for each Shield lost."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 3,
  "rarity": "EPIC",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 755
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_590 : SimTemplate //* Blood Knight
    {
        //Battlecry: All minions lose Divine Shield. Gain +3/+3 for each Shield lost.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var shilds = 0;
            foreach (var m in p.ownMinions)
            {
                if (m.divineshild)
                {
                    p.minionLosesDivineShield(m);
                    shilds++;
                }
            }

            foreach (var m in p.enemyMinions)
            {
                if (m.divineshild)
                {
                    p.minionLosesDivineShield(m);
                    shilds++;
                }
            }

            p.minionGetBuffed(own, 3 * shilds, 3 * shilds);
        }
    }
}