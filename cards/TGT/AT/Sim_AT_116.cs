using HearthDb.Enums;

/* _BEGIN_TEMPLATE_
{
  "id": "AT_116",
  "name": [
    "龙眠教官",
    "Wyrmrest Agent"
  ],
  "text": [
    "<b>战吼：</b>如果你的手牌中有龙牌，便获得+1攻击力和<b>嘲讽</b>。",
    "<b>Battlecry:</b> If you're holding a Dragon, gain +1 Attack and <b>Taunt</b>."
  ],
  "cardClass": "PRIEST",
  "type": "MINION",
  "cost": 2,
  "rarity": "RARE",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2596
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_116 : SimTemplate //* Wyrmrest Agent
    {
        //Battlecry: If you're holding a Dragon, gain +1 Attack and Taunt.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                var dragonInHand = false;
                foreach (var hc in p.owncards)
                {
                    if (hc.card.Race == Race.DRAGON)
                    {
                        dragonInHand = true;
                        break;
                    }
                }

                if (dragonInHand)
                {
                    p.minionGetBuffed(m, 1, 0);
                    m.taunt = true;
                    p.anzOwnTaunt++;
                }
            }
            else
            {
                if (p.enemyAnzCards >= 2)
                {
                    p.minionGetBuffed(m, 1, 0);
                    m.taunt = true;
                    p.anzEnemyTaunt++;
                }
            }
        }
    }
}