using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_284",
  "name": [
    "碧蓝幼龙",
    "Azure Drake"
  ],
  "text": [
    "<b>法术伤害+1</b>，<b>战吼：</b>抽一张牌。",
    "<b>Spell Damage +1</b>\n<b>Battlecry:</b> Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "HOF",
  "collectible": true,
  "dbfId": 825
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_284 : SimTemplate //azuredrake
    {
//    zauberschaden +1/. kampfschrei:/ zieht eine karte.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.drawACard(SimCard.None, own.own);
        }

        public override void onAuraStarts(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower++;
            }
            else
            {
                p.enemyspellpower++;
            }
        }

        public override void onAuraEnds(Playfield p, Minion m)
        {
            if (m.own)
            {
                p.spellpower--;
            }
            else
            {
                p.enemyspellpower--;
            }
        }
    }
}