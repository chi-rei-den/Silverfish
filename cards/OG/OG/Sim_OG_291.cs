

/* _BEGIN_TEMPLATE_
{
  "id": "OG_291",
  "name": [
    "暗影施法者",
    "Shadowcaster"
  ],
  "text": [
    "<b>战吼：</b>选择一个友方随从，将它的一张1/1的复制置入你的手牌，其法力值消耗为（1）点。",
    "<b>Battlecry:</b> Choose a friendly minion. Add a 1/1 copy to your hand that costs (1)."
  ],
  "cardClass": "ROGUE",
  "type": "MINION",
  "cost": 5,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38876
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_291 : SimTemplate //* Shadowcaster
    {
        //Battlecry: Choose a friendly minion. Add a 1/1 copy to your hand that costs (1).

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (target != null)
            {
                if (m.own)
                {
                    p.drawACard(target.handcard.card.CardId, m.own, true);
                    var i = p.owncards.Count - 1;
                    p.owncards[i].addattack = 1 - p.owncards[i].card.Attack;
                    p.owncards[i].addHp = 1 - p.owncards[i].card.Health;
                    p.owncards[i].manacost = 1;
                }
            }
        }
    }
}