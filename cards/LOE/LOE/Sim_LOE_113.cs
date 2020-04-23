

/* _BEGIN_TEMPLATE_
{
  "id": "LOE_113",
  "name": [
    "鱼人恩典",
    "Everyfin is Awesome"
  ],
  "text": [
    "使你的所有随从获得+2/+2。你每控制一个鱼人，该牌的法力值消耗便减少（1）点。",
    "Give your minions +2/+2.\nCosts (1) less for each Murloc you control."
  ],
  "cardClass": "SHAMAN",
  "type": "SPELL",
  "cost": 7,
  "rarity": "RARE",
  "set": "LOE",
  "collectible": true,
  "dbfId": 3007
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_LOE_113 : SimTemplate //* Everyfin is Awesome
    {
        //Give your minions +2/+2. Costs (1) less for each murloc you control.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.allMinionOfASideGetBuffed(ownplay, 2, 2);
        }
    }
}