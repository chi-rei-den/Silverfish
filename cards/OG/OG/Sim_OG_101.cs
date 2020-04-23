

/* _BEGIN_TEMPLATE_
{
  "id": "OG_101",
  "name": [
    "禁忌畸变",
    "Forbidden Shaping"
  ],
  "text": [
    "消耗你所有的法力值，随机\n召唤一个法力值消耗相同的随从。",
    "Spend all your Mana. Summon a random minion that costs that much."
  ],
  "cardClass": "PRIEST",
  "type": "SPELL",
  "cost": 0,
  "rarity": "EPIC",
  "set": "OG",
  "collectible": true,
  "dbfId": 38434
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_OG_101 : SimTemplate //* Forbidden Shaping
    {
        //Spend all your Mana. Summon a random minion that costs that much.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var anz = ownplay ? p.mana : p.enemyMaxMana;
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            p.callKid(p.getRandomCardForManaMinion(anz), pos, ownplay, false);
            if (ownplay)
            {
                p.mana = 0;
            }
        }
    }
}