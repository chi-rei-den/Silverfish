using Chireiden.Silverfish;

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_012",
  "name": [
    "血法师萨尔诺斯",
    "Bloodmage Thalnos"
  ],
  "text": [
    "<b>法术伤害+1</b>，<b>亡语：</b>抽一张牌。",
    "<b>Spell Damage +1</b>\n<b>Deathrattle:</b> Draw a card."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 2,
  "rarity": "LEGENDARY",
  "set": "EXPERT1",
  "collectible": true,
  "dbfId": 749
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_012 : SimTemplate //* bloodmage thalnos
    {
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
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

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.drawACard(SimCard.None, m.own);
        }
    }
}