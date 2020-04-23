using HearthDb;

/* _BEGIN_TEMPLATE_
{
  "id": "ICC_314t2",
  "name": [
    "亡者大军",
    "Army of the Dead"
  ],
  "text": [
    "移除你的牌库顶的五张牌。召唤其中所有被移除的随从。",
    "Remove the top 5 cards of your deck. Summon any minions removed."
  ],
  "cardClass": "DEATHKNIGHT",
  "type": "SPELL",
  "cost": 6,
  "rarity": null,
  "set": "ICECROWN",
  "collectible": null,
  "dbfId": 42586
}
_END_TEMPLATE_ */

namespace HREngine.Bots
{
    class Sim_ICC_314t2 : SimTemplate //* Army of the Dead
    {
        // Remove the top 5 cards of your deck. Summon any minions removed.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            var pos = ownplay ? p.ownMinions.Count : p.enemyMinions.Count;
            var anz = ownplay ? p.ownDeckSize : p.enemyDeckSize;
            if (anz > 5)
            {
                anz = 5;
            }

            if (ownplay)
            {
                p.ownDeckSize -= anz;
            }
            else
            {
                p.enemyDeckSize -= anz;
            }

            if (anz > 0)
            {
                p.callKid(CardIds.Collectible.Neutral.RiverCrocolisk, pos, ownplay, false); //river crocolisk
            }

            if (anz > 2)
            {
                p.callKid(CardIds.Collectible.Neutral.GoldshireFootman, pos, ownplay, false); //goldshire footman
            }

            if (anz > 4)
            {
                p.callKid(CardIds.Collectible.Neutral.Spellbreaker, pos, ownplay, false); //spellbreaker
            }
        }
    }
}