

/* _BEGIN_TEMPLATE_
{
  "id": "CS2_150",
  "name": [
    "雷矛特种兵",
    "Stormpike Commando"
  ],
  "text": [
    "<b>战吼：</b>造成2点伤害。",
    "<b>Battlecry:</b> Deal 2 damage."
  ],
  "CardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 413
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_CS2_150 : SimTemplate //stormpikecommando
    {
//    kampfschrei:/ verursacht 2 schaden.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.minionGetDamageOrHeal(target, 2);
        }
    }
}