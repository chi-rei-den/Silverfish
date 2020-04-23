using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "KAR_061",
  "name": [
    "馆长",
    "The Curator"
  ],
  "text": [
    "<b>嘲讽，战吼：</b>从你的牌库中抽一张野兽牌、龙牌和鱼人牌置入你的手牌。",
    "<b>Taunt</b>\n<b>Battlecry:</b> Draw a Beast, Dragon, and Murloc from your deck."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "KARA",
  "collectible": true,
  "dbfId": 39225
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_KAR_061 : SimTemplate //* The Curator
    {
        //Taunt. Battlecry: Draw a Beast, Dragon, and Murloc from your deck.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(SimCard.None, own.own);
            p.drawACard(SimCard.None, own.own);
        }
    }
}