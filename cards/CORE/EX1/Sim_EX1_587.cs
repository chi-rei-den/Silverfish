

/* _BEGIN_TEMPLATE_
{
  "id": "EX1_587",
  "name": [
    "风语者",
    "Windspeaker"
  ],
  "text": [
    "<b>战吼：</b>使一个友方随从获得<b>风怒</b>。",
    "<b>Battlecry:</b> Give a friendly minion <b>Windfury</b>."
  ],
  "CardClass": "SHAMAN",
  "type": "MINION",
  "cost": 4,
  "rarity": "FREE",
  "set": "CORE",
  "collectible": true,
  "dbfId": 178
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_EX1_587 : SimTemplate //windspeaker
    {
//    kampfschrei:/ verleiht einem befreundeten diener windzorn/.
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (target != null)
            {
                p.minionGetWindfurry(target);
            }
        }
    }
}