using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_060",
  "name": [
    "军需官",
    "Quartermaster"
  ],
  "text": [
    "<b>战吼：</b>使你的白银之手新兵获得+2/+2。",
    "<b>Battlecry:</b> Give your Silver Hand Recruits +2/+2."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2028
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_060 : SimTemplate //Quartermaster
    {
        //   Battlecry: Give your Silver Hand Recruits +2/+2.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.name == CardIds.NonCollectible.Paladin.Reinforce_SilverHandRecruitToken)
                {
                    p.minionGetBuffed(m, 2, 2);
                }
            }
        }
    }
}