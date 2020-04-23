

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_022",
  "name": [
    "幻象制造者",
    "Mirage Caller"
  ],
  "text": [
    "<b>战吼：</b>选择一个友方随从，召唤一个它的1/1复制。",
    "<b>Battlecry:</b> Choose a friendly minion. Summon a 1/1 copy of it."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41155
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_022 : SimTemplate //* Mirage Caller
    {
        //Battlecry: Choose a friendly minion. Summon a 1/1 copy of it.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null && p.ownMinions.Count < 7)
            {
                p.callKid(own.handcard.card, own.zonepos, own.own);
                p.ownMinions[own.zonepos].setMinionToMinion(target);
                p.ownMinions[own.zonepos].Angr = 1;
                p.ownMinions[own.zonepos].Hp = 1;
                p.ownMinions[own.zonepos].maxHp = 1;
            }
        }
    }
}