using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_043",
  "name": [
    "重型刃弩",
    "Glaivezooka"
  ],
  "text": [
    "<b>战吼：</b>随机使一个友方随从获得+1攻击力。",
    "<b>Battlecry:</b> Give a random friendly minion +1 Attack."
  ],
  "cardClass": "HUNTER",
  "type": "WEAPON",
  "cost": 2,
  "rarity": "COMMON",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2011
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_043 : SimTemplate //Glaivezooka
    {
        //   Battlecry: Give a random friendly minion +1 Attack.

        SimCard w = CardIds.Collectible.Hunter.Glaivezooka;

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(this.w, ownplay);
            var temp = ownplay ? p.ownMinions : p.enemyMinions;
            if (temp.Count <= 0)
            {
                return;
            }

            // Drew: Null check for searchRandomMinion.
            var found = p.searchRandomMinion(temp, SearchMode.LowAttack);
            if (found != null)
            {
                p.minionGetBuffed(found, 1, 0);
            }
        }
    }
}