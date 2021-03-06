using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_701",
  "name": [
    "游荡恶鬼",
    "Skulking Geist"
  ],
  "text": [
    "<b>战吼：</b>摧毁双方手牌中和牌库中所有法力值消耗为（1）的\n法术牌。",
    "<b>Battlecry:</b> Destroy all\n1-Cost spells in both hands and decks."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "ICECROWN",
  "collectible": true,
  "dbfId": 42784
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_701 : SimTemplate //* Skulking Geist
    {
        // Battlecry: Destroy all 1-Cost spells in both hands and decks.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                foreach (var hc in p.owncards.ToArray())
                {
                    if (hc.manacost == 1 && hc.card.Type == CardType.SPELL)
                    {
                        p.owncards.Remove(hc);
                    }
                }

                p.renumHandCards(p.owncards);
            }
        }
    }
}