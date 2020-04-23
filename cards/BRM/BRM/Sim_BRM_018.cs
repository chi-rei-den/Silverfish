

/* _BEGIN_TEMPLATE_
{
  "id": "BRM_018",
  "name": [
    "龙王配偶",
    "Dragon Consort"
  ],
  "text": [
    "<b>战吼：</b>你的下一张龙牌的法力值消耗减少（2）点。",
    "<b>Battlecry:</b> The next Dragon you play costs (2) less."
  ],
  "CardClass": "PALADIN",
  "type": "MINION",
  "cost": 5,
  "rarity": "RARE",
  "set": "BRM",
  "collectible": true,
  "dbfId": 2299
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_BRM_018 : SimTemplate //* Dragon Consort
    {
        // Battlecry: The next Dragon you play costs (2) less.

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            if (m.own)
            {
                p.anzOwnDragonConsort++;
            }
        }
    }
}