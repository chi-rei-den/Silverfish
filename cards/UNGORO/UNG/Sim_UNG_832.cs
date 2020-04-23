

/* _BEGIN_TEMPLATE_
{
  "id": "UNG_832",
  "name": [
    "血色绽放",
    "Bloodbloom"
  ],
  "text": [
    "在本回合中，你施放的下一个法术不再消耗法力值，转而消耗生命值。",
    "The next spell you cast this turn costs Health instead of Mana."
  ],
  "cardClass": "WARLOCK",
  "type": "SPELL",
  "cost": 2,
  "rarity": "EPIC",
  "set": "UNGORO",
  "collectible": true,
  "dbfId": 41872
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_UNG_832 : SimTemplate //* Bloodbloom
    {
        //The next spell you cast this turn costs Health instead of Mana.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                p.nextSpellThisTurnCostHealth = true;
            }
        }
    }
}