

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_360",
  "name": [
    "谦逊",
    "Humility"
  ],
  "text": [
    "使一个随从的攻击力变为1。",
    "Change a minion's Attack to 1."
  ],
  "CardClass": "PALADIN",
  "type": "SPELL",
  "cost": 1,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 854
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_360 : SimTemplate //* Humility
    {
        //Change a minion's Attack to 1.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionSetAngrToX(target, 1);
        }
    }
}