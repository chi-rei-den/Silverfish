using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "FP1_015",
  "name": [
    "费尔根",
    "Feugen"
  ],
  "text": [
    "<b>亡语：</b>如果斯塔拉格也在本局对战中死亡，召唤塔迪乌斯。",
    "<b>Deathrattle:</b> If Stalagg also died this game, summon Thaddius."
  ],
  "cardClass": "NEUTRAL",
  "type": "MINION",
  "cost": 5,
  "rarity": "LEGENDARY",
  "set": "NAXX",
  "collectible": true,
  "dbfId": 1797
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_FP1_015 : SimTemplate //* feugen
    {
        public override void onDeathrattle(Playfield p, Minion m)
        {
            if (p.stalaggDead)
            {
                p.callKid(CardIds.NonCollectible.Neutral.Stalagg_ThaddiusToken, m.zonepos - 1, m.own);
            }
        }
    }
}