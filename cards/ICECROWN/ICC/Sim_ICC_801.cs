using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_801",
  "name": [
    "咆哮的指挥官",
    "Howling Commander"
  ],
  "text": [
    "<b>战吼：</b>从你的牌库中抽一张具有<b>圣盾</b>的随从牌。",
    "<b>Battlecry:</b> Draw a <b>Divine Shield</b> minion from your deck."
  ],
  "cardClass": "PALADIN",
  "type": "MINION",
  "cost": 3,
  "rarity": "RARE",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42948
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_801 : SimTemplate //* Howling Commander
    {
        // Battlecry: Draw a Divine Shield minion from your deck.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.drawACard(SimCard.None, m.own);
        }
    }
}