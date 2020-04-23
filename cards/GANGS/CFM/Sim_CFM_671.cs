

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_671",
  "name": [
    "凛风巫师",
    "Cryomancer"
  ],
  "text": [
    "<b>战吼：</b>如果有敌人被<b>冻结</b>，便获得+2/+2。",
    "<b>Battlecry:</b> If an enemy is <b>Frozen</b>, gain +2/+2."
  ],
  "cardClass": "MAGE",
  "type": "MINION",
  "cost": 5,
  "rarity": "COMMON",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40988
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_671 : SimTemplate //* Cryomancer
    {
        // Battlecry: Gain +2/+2 if an enemy is Frozen.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            var temp = m.own ? p.enemyMinions : p.ownMinions;
            foreach (var mnn in temp)
            {
                if (mnn.frozen)
                {
                    p.minionGetBuffed(m, 2, 2);
                    break;
                }
            }
        }
    }
}