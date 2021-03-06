using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_755",
  "name": [
    "污手街典当师",
    "Grimestreet Pawnbroker"
  ],
  "text": [
    "<b>战吼：</b>随机使你手牌中的一张武器牌获得+1/+1。",
    "<b>Battlecry:</b> Give a random weapon in your hand +1/+1."
  ],
  "cardClass": "WARRIOR",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40569
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_755 : SimTemplate //* Grimestreet Pawnbroker
    {
        // Battlecry: Give a random weapon in your hand +1/+1.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                var hc = p.searchRandomMinionInHand(p.owncards, SearchMode.LowCost, SearchMode.WeaponOnly);
                if (hc != null)
                {
                    hc.addattack++;
                    hc.addHp++;
                    p.anzOwnExtraAngrHp += 2;
                }
            }
        }
    }
}