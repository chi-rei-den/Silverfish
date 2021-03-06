using Chireiden.Silverfish;
using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "GVG_105",
  "name": [
    "载人飞天魔像",
    "Piloted Sky Golem"
  ],
  "text": [
    "<b>亡语：</b>随机召唤一个法力值消耗为（4）的随从。",
    "<b>Deathrattle:</b> Summon a random 4-Cost minion."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 6,
  "rarity": "EPIC",
  "set": "GVG",
  "collectible": true,
  "dbfId": 2073
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_GVG_105 : SimTemplate //* Piloted Sky Golem
    {
        // Deathrattle: Summon a random 4-Cost minion.  

        SimCard kid = CardIds.Collectible.Neutral.ChillwindYeti; //chillwind

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(this.kid, m.zonepos - 1, m.own);
        }
    }
}