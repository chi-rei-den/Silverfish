

/* _BEGIN_TEMPLATE_
{
  "id": "OG_118",
  "name": [
    "弃暗投明",
    "Renounce Darkness"
  ],
  "text": [
    "将你的英雄技能和术士卡牌替换成其它职业的。这些牌的法力值消耗减少（1）点。",
    "Replace your Hero Power and Warlock cards with another class's. The cards cost (1) less."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38461
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_118 : SimTemplate //* Renounce Darkness
    {
        //Replace your Hero Power and Warlock cards with another class's. The cards cost (1) less.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                foreach (var hc in p.owncards)
                {
                    hc.manacost--;
                }
            }
        }
    }
}