using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "CFM_685",
  "name": [
    "唐·汉古",
    "Don Han'Cho"
  ],
  "text": [
    "<b>战吼：</b>随机使你手牌中的一张随从牌获得+5/+5。",
    "<b>Battlecry:</b> Give a random minion in your hand +5/+5."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "GANGS",
  "collectible": true,
  "dbfId": 40703
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CFM_685 : SimTemplate //* Don Han'Cho
    {
        // Battlecry: Give a random minion in your hand +5/+5.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                var hc = p.searchRandomMinionInHand(p.owncards, SearchMode.LowCost, SearchMode.MinionOnly);
                if (hc != null)
                {
                    hc.addattack += 5;
                    hc.addHp += 5;
                    p.anzOwnExtraAngrHp += 10;
                }
            }
        }
    }
}