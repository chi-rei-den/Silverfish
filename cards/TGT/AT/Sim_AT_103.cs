

/* _BEGIN_TEMPLATE_
{
  "id": "AT_103",
  "name": [
    "北海海怪",
    "North Sea Kraken"
  ],
  "text": [
    "<b>战吼：</b>造成4点伤害。",
    "<b>Battlecry:</b> Deal 4 damage."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 9,
  "rarity": "COMMON",
  "set": "TGT",
  "collectible": true,
  "dbfId": 2520
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_AT_103 : SimTemplate //* North Sea Kraken
    {
        //Battlecry: Deal 4 damage.

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            var dmg = 4;
            p.minionGetDamageOrHeal(target, dmg);
        }
    }
}