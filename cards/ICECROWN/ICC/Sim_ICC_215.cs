

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_215",
  "name": [
    "大主教本尼迪塔斯",
    "Archbishop Benedictus"
  ],
  "text": [
    "<b>战吼：</b>复制你对手的牌库，并洗入你的\n牌库。",
    "<b>Battlecry:</b> Shuffle a copy of your opponent's deck into your deck."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 7,
  "rarity": "LEGENDARY",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42633
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_215 : SimTemplate //* Archbishop Benedictus
    {
        // Battlecry: Shuffle a copy of your opponent's deck into your deck.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                p.ownDeckSize += p.enemyDeckSize;
                p.evaluatePenality -= 6;
            }
            else
            {
                p.enemyDeckSize += p.ownDeckSize;
            }
        }
    }
}