using HearthDb;
using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_010",
  "name": [
    "暴躁的牧羊人",
    "Ram Wrangler"
  ],
  "text": [
    "<b>战吼：</b>如果你控制任何野兽，则随机召唤一个野兽。",
    "<b>Battlecry:</b> If you have a Beast, summon a\nrandom Beast."
  ],
  "cardClass": "HUNTER",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2552
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_010 : SimTemplate //* Ram Wrangler
    {
        //Battlecry: If you have a Beast, summon a random Beast.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var temp = own.own ? p.ownMinions : p.enemyMinions;
            foreach (var m in temp)
            {
                if (m.handcard.card.Race == Race.PET)
                {
                    p.callKid(CardIds.Collectible.Neutral.RiverCrocolisk, temp.Count, own.own); //river crocolisk
                    break;
                }
            }
        }
    }
}